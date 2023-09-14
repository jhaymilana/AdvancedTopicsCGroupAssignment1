using System.ComponentModel.DataAnnotations;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "First Name must have at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "First Name has a limit of 100 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last Name must have at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "Last Name has a limit of 100 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public HashSet<PersonAddress> PersonAddresses { get; set; }
        public HashSet<PersonBusiness> PersonBusinesses { get; set; }

        public Person(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PersonAddresses = new HashSet<PersonAddress>();
            PersonBusinesses = new HashSet<PersonBusiness>();
        }
    }
}