using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class Weight
	{
		[Key]
		public int Id { get; set; }
		public double Value { get; set; }
        public string TimeStamp { get; set; } = string.Empty;
    }
}
