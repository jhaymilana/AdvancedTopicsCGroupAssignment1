using AdvancedTopicsCGroupAssignment1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class PersonAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public PersonAddress() { }
        public PersonAddress(int personId, int addressId, GroupAssignmentDbContext context)
        {
            PersonId = personId;
            AddressId = addressId;

            Person = context.Persons.FirstOrDefault(p => p.Id == personId);
            Address = context.Addresss.FirstOrDefault(b => b.Id == addressId);
        }  
    }
}