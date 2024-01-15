using System.ComponentModel.DataAnnotations;

namespace Exam_pre.Areas.manage.ViewModel
{
    public class AdminLoginViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [MinLength(8)]
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
