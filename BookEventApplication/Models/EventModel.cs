using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookEventApplication.Models
{
    public class EventModel
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = " Please Enter title of the book")]
        [Display(Name = "Title of the Book")]
        public string Title { get; set; }



        [Required(ErrorMessage = "Please Enter the Event Date")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Please Enter the venue")]
        [Display(Name = "Location")]
        public string Location { get; set; }


        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter the start time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }


        [Display(Name = "Type of Event")]
        public string EventType { get; set; }


        [Required]
        [Display(Name = "Organiser")]
        public string Organiser { get; set; }

        [Required,Range(1, 4, ErrorMessage = " Duration should be 1-4 hours only")]
        public int Duration { get; set; }


        [StringLength(maximumLength: 50)]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [StringLength(maximumLength: 500)]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }


        [Display(Name = "Invite People")]
        public string InviteEmails { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
