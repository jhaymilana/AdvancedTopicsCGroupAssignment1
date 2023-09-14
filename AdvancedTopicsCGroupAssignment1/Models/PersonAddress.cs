using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class PersonAddress
    {
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public PersonAddress(Person person, Address address) 
        {
            Person = person;
            PersonId = person.Id;
            Address = address;
            AddressId = address.Id;
        }  
    }
}