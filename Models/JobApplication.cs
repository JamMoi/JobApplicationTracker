using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models
{
    public class JobApplication
    {
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string JobTitle { get; set; } = string.Empty;
        public string? Location { get; set; }

        [Url]
        public string? JobUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Deadline { get; set; }

        public WorkMode? WorkMode { get; set; }

        public ApplicationStatus Status { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime? ApplicationDate { get; set; }

        public string? Notes { get; set; }
        public string? ContactName { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }

        [Phone]
        public string? ContactPhone { get; set; }
    }
}
