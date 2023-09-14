using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class PersonBusiness
    {
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public PersonBusiness(Person person, Business business)
        {
            Person = person;
            PersonId = person.Id;
            Business = business;
            BusinessId = business.Id;
        }
    }
}
