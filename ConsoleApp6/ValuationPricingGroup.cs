using System.ComponentModel.DataAnnotations;

namespace ConsoleApp6
{
	public class ValuationPricingGroup
	{
		
		public int PricingGroupId { get; set; }
		public string PricingGroupName { get; set; }
		[Key]
		public string QuoteType { get; set; }
		[Key]
		public string PricingSource { get; set; }
	}
}