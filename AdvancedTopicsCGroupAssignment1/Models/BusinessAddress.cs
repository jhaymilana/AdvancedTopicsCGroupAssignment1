using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedTopicsCGroupAssignment1.Models
{
    public class BusinessAddress
    {
        [ForeignKey("Business")]
        public Business Business { get; set; }
        public int BusinessId { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public BusinessAddress(Business business, Address address) 
        {
            BusinessId = business.Id; 
            AddressId = address.Id;
            Business = business;
            Address = address;  
        }
    }
}
