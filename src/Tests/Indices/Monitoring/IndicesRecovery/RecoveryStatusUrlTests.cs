﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Indices.Monitoring.RecoveryStatus
{
	public class RecoveryStatusUrlTests
	{
		[U] public async Task Urls()
		{
			await GET($"/_recovery")
				.Fluent(c => c.RecoveryStatus(Nest.Indices.All))
				.Request(c => c.RecoveryStatus(new RecoveryStatusRequest()))
				.FluentAsync(c => c.RecoveryStatusAsync(Nest.Indices.All))
				.RequestAsync(c => c.RecoveryStatusAsync(new RecoveryStatusRequest()))
				;

			var index = "index1,index2";
			await GET($"/{index}/_recovery")
				.Fluent(c => c.RecoveryStatus(index))
				.Request(c => c.RecoveryStatus(new RecoveryStatusRequest(index)))
				.FluentAsync(c => c.RecoveryStatusAsync(index))
				.RequestAsync(c => c.RecoveryStatusAsync(new RecoveryStatusRequest(index)))
				;
		}
	}
}