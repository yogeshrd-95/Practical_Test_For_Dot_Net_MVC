using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_Test_For_Dot_Net_MVC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Flight Reference is required.")]
        [Display(Name = "Flight Reference")]
        public string FlightRef { get; set; }

        [Required(ErrorMessage = "Departure Date is required.")]
        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]
        public DateTime DepDate { get; set; }

        [Required(ErrorMessage = "Arrival Date is required.")]
        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        public DateTime ArrDate { get; set; }

        [Required(ErrorMessage = "Flight Type is required.")]
        [Display(Name = "Flight Type")]
        public string FlightType { get; set; }

        [Required(ErrorMessage = "Departure Time is required.")]
        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        public TimeSpan DepTime { get; set; }

        [Required(ErrorMessage = "Arrival Time is required.")]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        public TimeSpan ArrTime { get; set; }

        [Required(ErrorMessage = "Flight Supplier is required.")]
        [Display(Name = "Flight Supplier")]
        public string FlightSupplier { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Flight Price is required.")]
        [Display(Name = "Flight Price")]
        [DataType(DataType.Currency)]
        public decimal FlightPrice { get; set; }
    }

}