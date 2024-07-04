using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title Must Be 5 Charaters")]
        [MaxLength(280, ErrorMessage = "Title Can Not be Over 280 Characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Comment Must Be 5 Charaters")]
        [MaxLength(280, ErrorMessage = "Comment Can Not be Over 280 Characters")]
        public string Content { get; set; } = string.Empty;
    }
}
