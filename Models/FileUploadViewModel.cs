using System.ComponentModel.DataAnnotations;

namespace EC_ASP.NET.Models
{
    public class FileUploadViewModel
    {
        [Display(Name = "File Upload")]
        [Required(ErrorMessage = "Please select a file to upload.")]
        public IFormFile File { get; set; } = null!;


    }
}
