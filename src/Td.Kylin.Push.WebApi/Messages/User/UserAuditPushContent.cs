﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.Messages.User
{
    /// <summary>
    /// 实名认证审核推送
    /// </summary>
	public class UserAuditPushContent
    {
        public string PushCode { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID
        {
            get;
            set;
        }

        public string Contents
        {
            get;
            set;
        }
        public bool Status { get; set; }
        public DateTime CreateTime { get { return DateTime.Now; } }
    }
}