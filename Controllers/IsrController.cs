using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsrController : ControllerBase
    {
        private readonly IsrContext _context;
        public IsrController(IsrContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Isr>>> GetIsrs()
        {
            return Ok(await _context.Isrs.ToListAsync());
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetIsrCountr()
        {
            var count = await _context.Isrs.CountAsync();
            return Ok(count);
        }

        private readonly string uploadDir = @"C:\Users\zcsarillana\source\repos\uploads";

        // POST: api/Isr/upload
        [HttpPost("upload")]
        public async Task<ActionResult<List<Isr>>> CreateIsrs(
        [FromForm] string isr_name,
        [FromForm] string isr_others,
        [FromForm] string isr_type,
        [FromForm] string description,
        [FromForm] IFormFile file)
            {
                try
                {
                    if (string.IsNullOrEmpty(isr_name) || string.IsNullOrEmpty(isr_type))
                    {
                        return BadRequest("Required form fields are missing.");
                    }

                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    string uniqueFileName = null;
                    if (file != null && file.Length > 0)
                    {
                        // Generate a unique file name
                        var fileExtension = Path.GetExtension(file.FileName);
                        var uniqueFileNameWithoutExtension = Guid.NewGuid().ToString();
                        uniqueFileName = $"{uniqueFileNameWithoutExtension}{fileExtension}";

                        var filePath = Path.Combine(uploadDir, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    var isr = new Isr
                    {
                        isr_name = isr_name,
                        isr_others = isr_others,
                        isr_type = isr_type,
                        description = description,
                        image_path = uniqueFileName // Store the unique file name
                    };

                    _context.Isrs.Add(isr);
                    await _context.SaveChangesAsync();

                    return Ok(await _context.Isrs.ToListAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return StatusCode(500, "Internal server error.");
                }
        }

        // GET: api/Isr/image/{filename}
        [HttpGet("image/{filename}")]
        public IActionResult GetImage(string filename)
        {
            // Combine the upload directory path with the filename
            var filePath = Path.Combine(uploadDir, filename);

            // Check if the file exists at the specified path
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Return 404 if the file does not exist
            }

            // Get the file extension from the filename
            var fileExtension = Path.GetExtension(filename).ToLowerInvariant();

            // Determine the MIME type based on the file extension
            string contentType = fileExtension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".webp" => "image/webp",
                _ => "application/octet-stream" // Default MIME type for unknown file types
            };

            // Open the file and return it as a FileResult with the correct MIME type
            var image = System.IO.File.OpenRead(filePath);
            return File(image, contentType);
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<Isr>>> UpdatePods(
     [FromForm] int id,
     [FromForm] string isr_name,
     [FromForm] string? isr_others, // Make pod_others nullable
     [FromForm] string isr_type,
     [FromForm] string description,
     [FromForm] IFormFile? file) // The file parameter is already nullable
        {
            // Validate required fields
            if (string.IsNullOrEmpty(isr_name) || string.IsNullOrEmpty(isr_type))
            {
                return BadRequest("Required form fields (pod_name and pod_type) are missing.");
            }

            // Find the pod in the database
            var dbPod = await _context.Isrs.FindAsync(id);
            if (dbPod == null)
            {
                return NotFound("Pod not found");
            }

            // Update non-image properties
            dbPod.isr_name = isr_name;
            dbPod.isr_type = isr_type;
            dbPod.isr_others = isr_others; // This can now be null
            dbPod.description = description;

            // Handle file upload only if a file is provided
            if (file != null && file.Length > 0)
            {
                try
                {
                    // Define the upload directory (hardcoded path)
                    var uploadDir = @"C:\Users\zcsarillana\source\repos\uploads";
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    // Generate a unique file name
                    var fileExtension = Path.GetExtension(file.FileName);
                    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    var filePath = Path.Combine(uploadDir, uniqueFileName);

                    // Remove old image if it exists
                    if (!string.IsNullOrEmpty(dbPod.image_path))
                    {
                        var oldFilePath = Path.Combine(uploadDir, dbPod.image_path);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Save the new file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Update the image path in the database
                    dbPod.image_path = uniqueFileName;
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error while processing the image: {ex.Message}");
                }
            }

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while saving changes: {ex.Message}");
            }

            // Return the updated list of Pods
            return Ok(await _context.Isrs.ToListAsync());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Area>>> DeleteArea(int id)
        {

            var dbRESTFUL = await _context.Isrs.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Area not found");

            _context.Isrs.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.Isrs.ToListAsync());
        }
    }
}