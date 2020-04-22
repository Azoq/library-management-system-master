using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public abstract class LibraryAsset
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }
        [Required] public Status Status { get; set; }

        [Required]
        [Display(Name = "Cost of Replacement")]
        public string ImageUrl { get; set; }
        public virtual LibraryBranch Location { get; set; }
    }
}