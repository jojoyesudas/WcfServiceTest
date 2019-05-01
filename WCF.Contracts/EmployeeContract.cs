using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Contracts
{
    [DataContract]
    public class EmployeeContract
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(50)]
        public string FName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(50)]
        public string LName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Gender Required")]
        [StringLength(1)]
        [RegularExpression("^M|m|F|f$")]
        public string Gender { get; set; }

        [DataMember]
        public AddressContract Address { get; set; }
    }

    [DataContract]
    public partial class AddressContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int EmployeeContractId { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Line1 Required")]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string POBox { get; set; }

        [DataMember]
        [Required(ErrorMessage = "City Required")]
        public string City { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Country Required")]
        public string Country { get; set; }

        [DataMember]
        [RegularExpression(@"(?=^[^\s]{8,}$)(?=.*\d)(?=.*[a-zA-Z])")]
        public string Email { get; set; }

        [DataMember]
        [RegularExpression(@"\+\d{2}-\d{4}-\d{3}-\d{3}")]        
        public string Phone { get; set; }        
    }
}
