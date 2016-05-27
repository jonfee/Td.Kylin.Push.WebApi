using System;
using JPush.Api;
using JPush.Api.push.mode;
using JPush.Api.push.notification;
using Td.Diagnostics;
using Newtonsoft.Json;

namespace Td.Kylin.Push
{
	public abstract class PushProviderBase : IPushProvider
	{
		#region 私有字段

		private string _name;
		private JPushClient _client;

		#endregion

		#region 保护属性

		protected JPushClient Client
		{
			get
			{
				return _client;
			}
		}

		#endregion

		#region 公共属性

		public string Name
		{
			get
			{
				return _name;
			}
		}

		#endregion

		#region 构造方法

		public PushProviderBase(string name, string key, string secret)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException("name");

			if(string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException("key");

			if(string.IsNullOrWhiteSpace(secret))
				throw new ArgumentNullException("secret");

			this._name = name;
			this._client = new JPushClient(key, secret);
		}

		#endregion

		#region 公共方法

		public PushResponse Send(PushRequest request)
		{
			if(request == null)
				throw new InvalidOperationException("request is null.");

			var response = new PushResponse();

			try
			{
				var payload = this.GetPayload(request);
				var result = this.Client.SendPush(payload);

				response.Success = result.isResultOK();
				response.MessageId = result.msg_id;
			}
			catch(Exception ex)
			{
				Logger.Error(ex);
			}

			return response;
		}

		#endregion

		#region 虚拟方法

		protected virtual PushPayload GetPayload(PushRequest request)
		{
			var payload = new PushPayload();

			// 设置为所有平台。
			payload.platform = Platform.all();

			// 设置推送范围。
			if(!string.IsNullOrWhiteSpace(request.PushCode))
			{
				payload.audience = Audience.s_alias(ResolveAlias(request.PushCode));
			}
			else
			{
				payload.audience = Audience.all();
			}


			// 设置推送类型
			if(request.PushType == PushType.Notification)
			{
				payload.notification = this.ResolveNotification(request);
				payload.notification.setAllAddExtra("datatype", request.DataType.ToString("d"));
				payload.notification.setAllAddExtra("parameters", JsonConvert.SerializeObject(request.Parameters, Formatting.None));
			}
			else
			{
				payload.message = this.ResolveMessage(request);
				payload.message.AddExtras("datatype", request.DataType.ToString("d"));
				payload.message.AddExtras("parameters", JsonConvert.SerializeObject(request.Parameters, Formatting.None));
			}

			// 设置业务类型。

			return payload;
		}

		#endregion

		#region 私有方法

		/// <summary>
		/// 根据推送号解析别名。
		/// </summary>
		/// <param name="pushCode">推送号。</param>
		/// <returns>解析后的别名数组。</returns>
		private string[] ResolveAlias(string pushCode)
		{
			if(pushCode.LastIndexOf(',') == pushCode.Length - 1)
				pushCode = pushCode.Substring(0, pushCode.Length - 1);

			return pushCode.Split(',');
		}

		/// <summary>
		/// 根据请求解析通知消息对象。
		/// </summary>
		/// <param name="request">请求实例。</param>
		/// <returns>解析后的通知消息对象。</returns>
		private Notification ResolveNotification(PushRequest request)
		{
			var notification = new Notification();
			
			// 设置通知内容。
			notification.setAlert(request.Message);

			// 设置IOS的角标。
			notification.setIos(request.AutoBadge ? new IosNotification().autoBadge() : new IosNotification().disableBadge());

			// 设置安卓的标题。
			if(!string.IsNullOrWhiteSpace(request.Title))
				notification.setAndroid(new AndroidNotification().setTitle(request.Title));

			return notification;
		}

		/// <summary>
		/// 根据请求解析消息对象。
		/// </summary>
		/// <param name="request">请求实例。</param>
		/// <returns>解析后的消息对象。</returns>
		private Message ResolveMessage(PushRequest request)
		{
			// 设置消息内容。
			var message = Message.content(request.Message);

			// 设置消息标题。
			message.setTitle(request.Title);

			return message;
		}

		#endregion
	}
}
