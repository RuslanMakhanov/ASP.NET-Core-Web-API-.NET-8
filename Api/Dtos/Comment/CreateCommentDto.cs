using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title Must Be 5 Charaters")]
        [MaxLength(280, ErrorMessage = "Title Can Not be Over 280 Characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content Must Be 5 Charaters")]
        [MaxLength(280, ErrorMessage = "Content Can Not be Over 280 Characters")]
        public string Content { get; set; } = string.Empty;
    }
}
