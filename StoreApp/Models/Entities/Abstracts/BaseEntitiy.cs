namespace StoreApp.Models.Entities.Abstracts
{
    public class BaseEntitiy
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
