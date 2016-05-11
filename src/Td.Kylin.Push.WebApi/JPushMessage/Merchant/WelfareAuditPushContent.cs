namespace Td.Kylin.Push.WebApi.JPushMessage.Merchant
{
	public class WelfareAuditPushContent
	{
		/// <summary>
		///     商家ID
		/// </summary>
		public long MerchantID
		{
			get;
			set;
		}

		/// <summary>
		///     福利ID
		/// </summary>
		public long WelfareID
		{
			get;
			set;
		}

		/// <summary>
		///     福利名称
		/// </summary>
		public string WelfareName
		{
			get;
			set;
		}

		public string Contents
		{
			get;
			set;
		}
	}
}