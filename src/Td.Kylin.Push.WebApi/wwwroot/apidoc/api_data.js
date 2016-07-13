define({ "api": [
  {
    "version": "1.0.0",
    "description": "<p>此接口用于用户上门或预约订单被接时推送消息给下单用户</p> ",
    "type": "post",
    "url": "/v1/appoint/accept",
    "title": "订单已被接单",
    "sampleRequest": [
      {
        "url": "/v1/appoint/accept"
      }
    ],
    "name": "OrderAccept",
    "group": "Appoint",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>上门订单ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>下单的用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>下单的用户昵称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "AcceptType",
            "description": "<p>接单方类型（1为商户，2为个人服务者）</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "AcceptAccountID",
            "description": "<p>接单方的账号ID（商户时为商户ID，个人服务者时为服务人员ID）</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "AcceptName",
            "description": "<p>接单方的名称（商户名称或服务人员名称）</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "BusinessID",
            "description": "<p>订单所属服务的业务ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "ServiceName",
            "description": "<p>订单所属服务或业务的名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "Number",
            "description": "<p>数量</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Unit",
            "description": "<p>单位(如：小时)</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Address",
            "description": "<p>上门服务的地址</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "ServiceTime",
            "description": "<p>服务时间</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "AcceptTime",
            "description": "<p>接单时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/AppointController.cs",
    "groupTitle": "Appoint"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口用于商户指派订单给工作人员时使用</p> ",
    "type": "post",
    "url": "/v1/appoint/allot",
    "title": "上门订单指派",
    "sampleRequest": [
      {
        "url": "/v1/appoint/allot"
      }
    ],
    "name": "OrderAllot",
    "group": "Appoint",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>上门订单ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>下单的用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>下单的用户昵称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>预约的商家ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "MerchantName",
            "description": "<p>预约的商家名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "WorkerID",
            "description": "<p>被指派的工作人员ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "BusinessID",
            "description": "<p>订单所属服务的业务ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "ServiceName",
            "description": "<p>订单所属服务或业务的名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "Number",
            "description": "<p>数量</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Unit",
            "description": "<p>单位(如：小时)</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Address",
            "description": "<p>上门服务的地址</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "ServiceTime",
            "description": "<p>服务时间</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "AllotTime",
            "description": "<p>指派时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/AppointController.cs",
    "groupTitle": "Appoint"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口在用户针对上门服务下单成功后推送给相关业务的商家或个人服务人员</p> ",
    "type": "post",
    "url": "/v1/appoint/pushshangmen",
    "title": "用户上门服务下单",
    "sampleRequest": [
      {
        "url": "/v1/appoint/pushshangmen"
      }
    ],
    "name": "PushShangMenOrder",
    "group": "Appoint",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>上门订单ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>下单的用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>下单的用户昵称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "BusinessID",
            "description": "<p>订单所属服务的业务ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "ServiceName",
            "description": "<p>订单所属服务或业务的名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "Number",
            "description": "<p>数量</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Unit",
            "description": "<p>单位(如：小时)</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Address",
            "description": "<p>上门服务的地址</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "ServiceTime",
            "description": "<p>服务时间</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "CreateTime",
            "description": "<p>下单时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/AppointController.cs",
    "groupTitle": "Appoint"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口在用户针对商家服务预约下单成功后推送给预约的商家</p> ",
    "type": "post",
    "url": "/v1/appoint/pushyuyue",
    "title": "用户预约服务下单",
    "sampleRequest": [
      {
        "url": "/v1/appoint/pushyuyue"
      }
    ],
    "name": "PushYuYueOrder",
    "group": "Appoint",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>上门订单ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>下单的用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>下单的用户昵称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>预约的商家ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "BusinessID",
            "description": "<p>订单所属服务的业务ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "ServiceName",
            "description": "<p>订单所属服务或业务的名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "Number",
            "description": "<p>数量</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Unit",
            "description": "<p>单位(如：小时)</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Address",
            "description": "<p>上门服务的地址</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "ServiceTime",
            "description": "<p>服务时间</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "CreateTime",
            "description": "<p>下单时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/AppointController.cs",
    "groupTitle": "Appoint"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口在B2C订单发货-推送用户端</p> ",
    "type": "post",
    "url": "/v1/b2c_order/deliver",
    "title": "B2C订单发货-推送用户端",
    "sampleRequest": [
      {
        "url": "/v1/b2c_order/deliver"
      }
    ],
    "name": "OrderDeliver",
    "group": "B2C_Order",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OperatorID",
            "description": "<p>运营商ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OperatorName",
            "description": "<p>运营商名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Contents",
            "description": "<p>内容</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/B2COrderController.cs",
    "groupTitle": "B2C_Order"
  },
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p> "
          },
          {
            "group": "Success 200",
            "type": "<p>String</p> ",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p> "
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/wwwroot/apidoc/main.js",
    "group": "D__20151120Git_Td_Kylin_Push_WebApi_src_Td_Kylin_Push_WebApi_wwwroot_apidoc_main_js",
    "groupTitle": "D__20151120Git_Td_Kylin_Push_WebApi_src_Td_Kylin_Push_WebApi_wwwroot_apidoc_main_js",
    "name": ""
  },
  {
    "version": "1.0.0",
    "description": "<p>用户下单后，系统将订单指派给相关的工作人员。</p> ",
    "type": "post",
    "url": "/v1/legwork/assign_order",
    "title": "订单指派",
    "sampleRequest": [
      {
        "url": "/v1/legwork/assign_order"
      }
    ],
    "name": "AssignOrder",
    "group": "Legwork",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "PushCode",
            "description": "<p>需要推送给工作端的推送号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>short</p> ",
            "optional": false,
            "field": "OrderType",
            "description": "<p>订单类型。</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "{\n\t  \"Code\": 0,\n\t  \"Message\": null,\n\t  \"IsError\": false,\n\t  \"Content\": true\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n   \"Code\":错误代号,\n   \"Message\":\"错误标题\",\n   \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/LegworkController.cs",
    "groupTitle": "Legwork"
  },
  {
    "version": "1.0.0",
    "description": "<p>用户接受报价后，将结果推送给指定的工作人员。</p> ",
    "type": "post",
    "url": "/v1/legwork/order_confirm",
    "title": "订单报价确认",
    "sampleRequest": [
      {
        "url": "/v1/legwork/order_confirm"
      }
    ],
    "name": "OrderConfirm",
    "group": "Legwork",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "PushCode",
            "description": "<p>需要推送给用户端的推送号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>short</p> ",
            "optional": false,
            "field": "OrderStatus",
            "description": "<p>订单状态。</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "{\n\t  \"Code\": 0,\n\t  \"Message\": null,\n\t  \"IsError\": false,\n\t  \"Content\": true\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n   \"Code\":错误代号,\n   \"Message\":\"错误标题\",\n   \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/LegworkController.cs",
    "groupTitle": "Legwork"
  },
  {
    "version": "1.0.0",
    "description": "<p>工作人员确认送达(取送物品)及工作人员选择线下支付时(购买物品)，推送给用户。</p> ",
    "type": "post",
    "url": "/v1/legwork/order_delivery",
    "title": "物品送达",
    "sampleRequest": [
      {
        "url": "/v1/legwork/order_delivery"
      }
    ],
    "name": "OrderDelivery",
    "group": "Legwork",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "PushCode",
            "description": "<p>需要推送给用户端的推送号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "WorkerName",
            "description": "<p>工作人员名称。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>short</p> ",
            "optional": false,
            "field": "OrderStatus",
            "description": "<p>订单状态。</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "{\n\t  \"Code\": 0,\n\t  \"Message\": null,\n\t  \"IsError\": false,\n\t  \"Content\": true\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n   \"Code\":错误代号,\n   \"Message\":\"错误标题\",\n   \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/LegworkController.cs",
    "groupTitle": "Legwork"
  },
  {
    "version": "1.0.0",
    "description": "<p>工作人员报价后，将报价结果推送给指定的用户。</p> ",
    "type": "post",
    "url": "/v1/legwork/order_offer",
    "title": "订单报价",
    "sampleRequest": [
      {
        "url": "/v1/legwork/order_offer"
      }
    ],
    "name": "OrderOffer",
    "group": "Legwork",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "PushCode",
            "description": "<p>需要推送给用户端的推送号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "Charge",
            "description": "<p>服务费用。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "WorkerID",
            "description": "<p>服务人员ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "WorkerName",
            "description": "<p>服务人员名称。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>double</p> ",
            "optional": false,
            "field": "Distance",
            "description": "<p>服务员距离取货地或收货地的距离。</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "{\n\t  \"Code\": 0,\n\t  \"Message\": null,\n\t  \"IsError\": false,\n\t  \"Content\": true\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n   \"Code\":错误代号,\n   \"Message\":\"错误标题\",\n   \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/LegworkController.cs",
    "groupTitle": "Legwork"
  },
  {
    "version": "1.0.0",
    "description": "<p>用户线上支付成功,推送给工作人员。</p> ",
    "type": "post",
    "url": "/v1/legwork/payment_complete",
    "title": "支付完成",
    "sampleRequest": [
      {
        "url": "/v1/legwork/payment_complete"
      }
    ],
    "name": "PaymentComplete",
    "group": "Legwork",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "PushCode",
            "description": "<p>需要推送给用户端的推送号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>用户昵称。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "Amount",
            "description": "<p>支付金额。</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "{\n\t  \"Code\": 0,\n\t  \"Message\": null,\n\t  \"IsError\": false,\n\t  \"Content\": true\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n   \"Code\":错误代号,\n   \"Message\":\"错误标题\",\n   \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/LegworkController.cs",
    "groupTitle": "Legwork"
  },
  {
    "version": "1.0.0",
    "description": "<p>工作人员选择线上支付,推送给用户端，请求用户支付。</p> ",
    "type": "post",
    "url": "/v1/legwork/request_payment",
    "title": "请求支付",
    "sampleRequest": [
      {
        "url": "/v1/legwork/request_payment"
      }
    ],
    "name": "RequestPayment",
    "group": "Legwork",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "PushCode",
            "description": "<p>需要推送给用户端的推送号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "GoodsAmount",
            "description": "<p>商品费用。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "ServiceCharge",
            "description": "<p>服务费用。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "ActualAmount",
            "description": "<p>实际总额。</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>short</p> ",
            "optional": false,
            "field": "OrderStatus",
            "description": "<p>订单状态。</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "{\n\t  \"Code\": 0,\n\t  \"Message\": null,\n\t  \"IsError\": false,\n\t  \"Content\": true\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n   \"Code\":错误代号,\n   \"Message\":\"错误标题\",\n   \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/LegworkController.cs",
    "groupTitle": "Legwork"
  },
  {
    "version": "1.0.0",
    "description": "<p>商家审核结果。</p> ",
    "type": "post",
    "url": "/v1/merchant/audit",
    "title": "商家审核结果",
    "sampleRequest": [
      {
        "url": "/v1/merchant/audit"
      }
    ],
    "name": "MerchantAudit",
    "group": "Merchant",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>商家ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "AuditStatus",
            "description": "<p>审核状态</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Contents",
            "description": "<p>内容</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/MerchantController.cs",
    "groupTitle": "Merchant"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口在商家发货-推送用户端</p> ",
    "type": "post",
    "url": "/v1/order/send",
    "title": "商家发货-推送用户端",
    "sampleRequest": [
      {
        "url": "/v1/order/send"
      }
    ],
    "name": "PayOrder",
    "group": "Order",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>订单ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>商家ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "ActualOrderAmount",
            "description": "<p>实际订单总金额</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>买家用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>用户名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "SendTime",
            "description": "<p>发货时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/OrderController.cs",
    "groupTitle": "Order"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口在商家订单-用户支付成功-推送商家端</p> ",
    "type": "post",
    "url": "/v1/order/pay",
    "title": "商家订单-用户支付成功-推送商家端",
    "sampleRequest": [
      {
        "url": "/v1/order/pay"
      }
    ],
    "name": "PayOrder",
    "group": "Order",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "OrderID",
            "description": "<p>福利ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "OrderCode",
            "description": "<p>订单编号</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>商家ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>decimal</p> ",
            "optional": false,
            "field": "ActualOrderAmount",
            "description": "<p>实际订单总金额</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>买家用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserName",
            "description": "<p>用户名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "PayTime",
            "description": "<p>付款时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/OrderController.cs",
    "groupTitle": "Order"
  },
  {
    "version": "1.0.0",
    "description": "<p>帖子删除推送。</p> ",
    "type": "post",
    "url": "/v1/topic/delete",
    "title": "帖子删除推送",
    "sampleRequest": [
      {
        "url": "/v1/topic/delete"
      }
    ],
    "name": "TopicDelete",
    "group": "Topic",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "TopicID",
            "description": "<p>帖子ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "UserIDs",
            "description": "<p>报名用户id集合，多个id使用&quot;,&quot;隔开</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Title",
            "description": "<p>帖子标题</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "AreaFormName",
            "description": "<p>区域圈子名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Contents",
            "description": "<p>内容</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/TopicController.cs",
    "groupTitle": "Topic"
  },
  {
    "version": "1.0.0",
    "description": "<p>用户审核结果。</p> ",
    "type": "post",
    "url": "/v1/user/audit",
    "title": "用户审核结果",
    "sampleRequest": [
      {
        "url": "/v1/user/audit"
      }
    ],
    "name": "UserAudit",
    "group": "User",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "UserID",
            "description": "<p>用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "AuditStatus",
            "description": "<p>审核状态</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "Contents",
            "description": "<p>内容</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/UserController.cs",
    "groupTitle": "User"
  },
  {
    "version": "1.0.0",
    "description": "<p>此接口在用户针对上门服务下单成功后推送给相关业务的商家或个人服务人员</p> ",
    "type": "post",
    "url": "/v1/welfare/lottery",
    "title": "用户上门服务下单",
    "sampleRequest": [
      {
        "url": "/v1/welfare/lottery"
      }
    ],
    "name": "LotteryResult",
    "group": "Welfare",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "Welfare",
            "description": "<p>福利ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>int</p> ",
            "optional": false,
            "field": "WelfareType",
            "description": "<p>福利类型</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "WelfarePhaseID",
            "description": "<p>福利活动ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "WelfareName",
            "description": "<p>福利名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>福利提供商ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "MerchantName",
            "description": "<p>福利提供商名称</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long[]</p> ",
            "optional": false,
            "field": "UserIDs",
            "description": "<p>中奖用户ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>datetime</p> ",
            "optional": false,
            "field": "LooeryTime",
            "description": "<p>中奖时间</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/WelfareController.cs",
    "groupTitle": "Welfare"
  },
  {
    "version": "1.0.0",
    "description": "<p>福利审核结果。</p> ",
    "type": "post",
    "url": "/v1/welfare/audit",
    "title": "福利审核结果",
    "sampleRequest": [
      {
        "url": "/v1/welfare/audit"
      }
    ],
    "name": "WelfareAudit",
    "group": "Welfare",
    "permission": [
      {
        "name": "All"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "MerchantID",
            "description": "<p>商家ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>long</p> ",
            "optional": false,
            "field": "WelfareID",
            "description": "<p>福利ID</p> "
          },
          {
            "group": "Parameter",
            "type": "<p>string</p> ",
            "optional": false,
            "field": "WelfareName",
            "description": "<p>福利名称</p> "
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "正常输出：",
          "content": "推送结果[Boolean]，True表示推送成功，Flase表示失败",
          "type": "json"
        }
      ]
    },
    "error": {
      "examples": [
        {
          "title": "错误输出:",
          "content": "{\n         \"Code\":错误代号,\n         \"Message\":\"错误标题\",\n         \"Content\":\"错误详细信息\"\n}",
          "type": "json"
        }
      ]
    },
    "filename": "D:/20151120Git/Td.Kylin.Push.WebApi/src/Td.Kylin.Push.WebApi/Controllers/WelfareController.cs",
    "groupTitle": "Welfare"
  }
] });