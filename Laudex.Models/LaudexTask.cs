using System.ComponentModel.DataAnnotations.Schema;

namespace Laudex.Models
{
    public class LaudexTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public LaudexStatuses Status { get; set; }
    }

    [Table("Tasks")]
    public class LaudexTaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StatusId { get; set; }
    }
}
