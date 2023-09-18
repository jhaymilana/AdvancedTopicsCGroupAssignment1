using AdvancedTopicsCGroupAssignment1.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class PersonBusiness
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business? Business { get; set; }

        public PersonBusiness() { }
        public PersonBusiness(int personId, int businessId, GroupAssignmentDbContext context)
        {
            PersonId = personId;
            BusinessId = businessId;

            Person = context.Persons.FirstOrDefault(p => p.Id == personId);
            Business = context.Businesss.FirstOrDefault(b => b.Id == businessId);
        }
    }
}
