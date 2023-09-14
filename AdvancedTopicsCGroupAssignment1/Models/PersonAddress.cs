using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class PersonAddress
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public PersonAddress() { }
        public PersonAddress(Person person, Address address) 
        {
            Person = person;
            PersonId = person.Id;
            Address = address;
            AddressId = address.Id;
        }  
    }
}