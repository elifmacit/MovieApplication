using MovieApplication.Enums;

namespace MovieApplication.Models
{
    public abstract class BaseEntity
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime  CreatedDate{ get; set; } = DateTime.Now;
        public DateTime  ModifiedDate{ get; set; }
        public DataStatu Statu { get; set; } = DataStatu.Create;
    }
}
