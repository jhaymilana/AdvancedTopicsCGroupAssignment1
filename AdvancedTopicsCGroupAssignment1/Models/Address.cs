using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Street Name")]
        [MinLength(3, ErrorMessage = "Last Name must have at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "Last Name has a limit of 100 characters.")] 
        public string StreetName { get; set; }

        [Required]
        [DisplayName("Street Number")]
        public int StreetNumber { get; set; }

        [DisplayName("Unit Number")]
        public int? UnitNumber { get; set; }

        [Required]  
        [DisplayName("Postal Code")]
        [DataType(DataType.PostalCode)]
        [MaxLength(7, ErrorMessage = "Postal Code has to be in the 'A1A A1A' format.")]
        [StringLength(7, MinimumLength = 7)]
        public string PostalCode { get; set; }

        public int? BusinessId { get; set; }
        public Business? Business { get; set; }

        public HashSet<PersonAddress> personAddresses { get; set; }

        public Address() { }
        public Address(string streetName, int streetNumber, int? unitNumber, string postalCode, Business? business)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            UnitNumber = unitNumber;
            PostalCode = postalCode;
            personAddresses = new HashSet<PersonAddress>();
            BusinessId = business.Id;
            Business = business;
        }
    }
}
