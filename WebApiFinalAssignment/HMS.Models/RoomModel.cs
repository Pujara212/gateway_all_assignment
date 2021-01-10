using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    using System;
    using System.Collections.Generic;

    public class RoomModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomModel()
        {
            this.Books = new HashSet<BookModel>();
        }

        public int Room_Id { get; set; }
        public string RoomName { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> Hotel_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookModel> Books { get; set; }
        public virtual HotelModel Hotel { get; set; }
    }
}
