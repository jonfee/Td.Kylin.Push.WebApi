using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Td.Common;
using Td.Kylin.WebApi;

namespace Td.Kylin.Push
{
    public static class PushProviderExtensions
    {
	    public static void RegisterPushProvider(IConfigurationRoot configuration)
	    {
			foreach(var section in configuration.GetSection("Push").GetChildren())
			{
				var provider = section.GetSection("Provider").Value;
				var key = section.GetSection("Key").Value;
				var secret = section.GetSection("Secret").Value;

				if(string.IsNullOrWhiteSpace(provider))
					continue;

				var instance = TypeExtension.GetType(provider).CreateInstance<IPushProvider>(key, secret);

				PushProviderFactory.Register(instance);
			}
	    }
    }
}
