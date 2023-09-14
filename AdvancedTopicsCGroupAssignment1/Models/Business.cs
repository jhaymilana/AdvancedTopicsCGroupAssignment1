using System.ComponentModel.DataAnnotations;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "Name has a limit of 100 characters.")]
        public string Name { get; set; }

    
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public HashSet<PersonBusiness> personBusinesses { get; set; }
        public HashSet<BusinessAddress> businesssAdresses { get; set; }

        public Business() { }
        public Business(string name, string emailAdress, string phoneNumber) 
        {
            Name = name;
            EmailAddress = emailAdress;
            PhoneNumber = phoneNumber;
            personBusinesses = new HashSet<PersonBusiness>();
            businesssAdresses = new HashSet<BusinessAddress>();
        }
    }
}
