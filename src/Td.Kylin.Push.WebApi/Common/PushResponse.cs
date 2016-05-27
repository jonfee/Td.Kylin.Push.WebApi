using System;
using System.Collections.Generic;

namespace Td.Kylin.Push
{
	public class PushResponse
	{
		/// <summary>
		/// 推送ID。
		/// </summary>
		public long MessageId
		{
			get;
			set;
		}

		/// <summary>
		/// 是否提交成功。
		/// </summary>
		public bool Success
		{
			get;
			set;
		}
	}
}