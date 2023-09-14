using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class BusinessAddress
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public BusinessAddress() { }
        public BusinessAddress(Business business, Address address) 
        {
            BusinessId = business.Id; 
            AddressId = address.Id;
            Business = business;
            Address = address;  
        }
    }
}
