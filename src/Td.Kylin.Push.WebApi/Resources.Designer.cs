﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Td.Kylin.Push.WebApi {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    强类型资源类，用于查找本地化字符串，等等。
    /// </summary>
    // 此类已由 StronglyTypedResourceBuilder 自动生成
    // 通过 ResGen 或 Visual Studio 之类的工具提供的类。
    // 若要添加或删除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (使用 /str 选项)，或重新生成 VS 项目。
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal Resources() {
        }
        
        /// <summary>
        ///    返回此类使用的缓存 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Td.Kylin.Push.WebApi.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    重写所有项的当前线程的 CurrentUICulture 属性
        ///    使用此强类型资源类进行资源查找。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    查找与 “新单来啦,快来抢单喽！”操作:点击/滑动进入接单中心页面并弹出报价弹窗 类似的本地化字符串。
        /// </summary>
        public static string Legwork_AssignOrder_Message {
            get {
                return ResourceManager.GetString("Legwork.AssignOrder.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 “接单了，接单了！有新指派的订单需要确定，快去处理吧！”操作:点击/滑动进入该订单详情页面 类似的本地化字符串。
        /// </summary>
        public static string Legwork_MallLegworkerPush_Message {
            get {
                return ResourceManager.GetString("Legwork.MallLegworkerPush.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 用户催单了,快点查看一下!(滑动进行到该订单详情页) 类似的本地化字符串。
        /// </summary>
        public static string Legwork_MessageBuy_Message {
            get {
                return ResourceManager.GetString("Legwork.MessageBuy.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 您有一个确认订单,快去跑腿吧! 类似的本地化字符串。
        /// </summary>
        public static string Legwork_OrderConfirm_Message {
            get {
                return ResourceManager.GetString("Legwork.OrderConfirm.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 “您的订单“{0}”跑腿员已经送达，快去收货吧~”操作:点击/滑动进入该订单详情页面 类似的本地化字符串。
        /// </summary>
        public static string Legwork_OrderDelivery_Message {
            get {
                return ResourceManager.GetString("Legwork.OrderDelivery.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 “您的跑腿订单跑腿员已经报价，赶快确定吧！”点击/滑动进入等待接单页面并弹出报价确认窗口 类似的本地化字符串。
        /// </summary>
        public static string Legwork_OrderOffer_Message {
            get {
                return ResourceManager.GetString("Legwork.OrderOffer.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 用户已成功支付,恭喜您完成了该订单. (滑动进入到该订单的详情页面) 类似的本地化字符串。
        /// </summary>
        public static string Legwork_PaymentComplete_Message {
            get {
                return ResourceManager.GetString("Legwork.PaymentComplete.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 物品已送达,请进行支付(滑动该消息,进入该订单的支付页面) 类似的本地化字符串。
        /// </summary>
        public static string Legwork_RequestPayment_Message {
            get {
                return ResourceManager.GetString("Legwork.RequestPayment.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 “订单‘{0}’用户确认收货”点击/滑动进入该订单详情页面 类似的本地化字符串。
        /// </summary>
        public static string Legwork_UserConfirm_Message {
            get {
                return ResourceManager.GetString("Legwork.UserConfirm.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 你的账户已在别的设备上登录 类似的本地化字符串。
        /// </summary>
        public static string User_SingleLogin_Message {
            get {
                return ResourceManager.GetString("User.SingleLogin.Message", resourceCulture);
            }
        }
    }
}
