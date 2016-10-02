using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebDeveloper.Model
{   

    [Table("Person.BusinessEntity")]
    [ExcludeFromCodeCoverage]
    public partial class BusinessEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusinessEntity()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }
        [Key, ForeignKey("Person")]
        public int BusinessEntityID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }

        public virtual Person Person { get; set; }
    }
}
