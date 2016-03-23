# Mictlanix C2Sharp

.NET wrapper for the Collective2 API v3.

### Quick Start

Install the [NuGet package](https://nuget.org/packages/Mictlanix.C2Sharp/) from the package manager console:

```powershell
Install-Package Mictlanix.C2Sharp
```
Next, you will need to provide C2Sharp with your API key in code.  Need help finding your API key?  Check here: https://www.collective2.com/api-docs/latest#toc-acquiring-an-api-key

In your application, call:

```CSharp
// Pass the API key on the constructor:
var client = new Collective2Client ("your-api-key-here");

// Next, make any API call you'd like:
var result = await client.GetSystemRosterAsync ();

...

// Dispose after you've finished using it.
client.Dispose ();
```

### Examples

##### Getting the system roster.

```CSharp
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Mictlanix.C2Sharp;

public class Example {
	public static void Main (string [] args)
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		RunSystemRosterAsync ().Wait ();
	}

	static async Task RunSystemRosterAsync ()
	{
		using (var client = new Collective2Client ("your-api-key-here")) {
			var content = await client.GetSystemRosterAsync ();
			PrintJson (content);
		}
	}

	static void PrintJson (object o)
	{
		Console.WriteLine (JsonConvert.SerializeObject (o, Formatting.Indented));
	}
}
```

##### Getting system details.

```CSharp
static async Task RunSystemDetailsAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.GetSystemDetailsAsync (<system id>);
		PrintJson (content);
	}
}
```

##### List all strategies with real-time access.

```CSharp
static async Task RunListAllSystemsAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.ListAllSystemsAsync ();
		PrintJson (content);
	}
}
```

##### Retrieving open and closed position information about a system.

```CSharp
static async Task RunRequestTradesAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.RequestTradesAsync (<system id>);
		PrintJson (content);
	}
}
```

##### Request only open positions.

```CSharp
static async Task RunRequestTradesOpenAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.RequestTradesOpenAsync (<system id>);
		PrintJson (content);
	}
}
```

##### List all working signals (i.e. signals that have not yet traded, been canceled, or expired) within a system.

```CSharp
static async Task RunRetrieveSignalsWorkingAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.RetrieveSignalsWorkingAsync (<system id>);
		PrintJson (content);
	}
}
```

##### List all signals (with filtering) within a system.

```CSharp
static async Task RunRetrieveSignalsAllAsync ()
{
	using (var client = CreateClient ()) {
		var content = await client.RetrieveSignalsAllAsync (<system id>, C2TimeFilterType.Posted,
		                                                    DateTime.Parse ("2016-01-01 08:00:00"),
		                                                    DateTime.Parse ("2016-12-31 16:00:00"));
		PrintJson (content);
	}
}
```

##### Submitting a basic order (C2 Signal).
_Sell To Close 10 contracts of Direxion Daily Small Cap Bear 3X ETF (TZA) stocks, at 48.5 limit. The order is a GTC order._

```CSharp
static async Task RunSubmitSignalAsync ()
{
	using (var client = CreateClient ()) {
		var content = await client.SubmitSignalAsync (<system id>, C2Duration.GoodTilCanceled,
							C2Action.SellToClose, 10, "TZA", C2SymbolType.Stock, 48.5m);
		PrintJson (content);
	}
}
```

##### Submitting a bracket order (Entry + Stop Loss + Profit Target).
_Buy To Open 200 contracts of Direxion Daily Small Cap Bull 3X ETF (TNA) stocks, at 55.00 limit with a profit target of 55.30 and an stop loss of 53.00. The order is a DAY order._

```CSharp
static async Task RunBracketOrderAsync ()
{
	using (var client = CreateClient ()) {
		var content = await client.SubmitBracketOrderAsync (<system id>, C2Duration.Day, C2Action.BuyToOpen, 200,
								"TNA", C2SymbolType.Stock, 55.00m, 55.3m, 53m);
		PrintJson (content);
	}
}
```

##### Cancel an order.

```CSharp
static async Task RunCancelSignalAsync ()
{
	using (var client = CreateClient ()) {
		var content = await client.CancelSignalAsync (<system id>, <signal id>);
		PrintJson (content);
	}
}
```

##### Cancel and replace (xreplace) an order.
_Replace existing order with Sell To Close 100 contracts of Direxion Daily Small Cap Bear 3X ETF (TZA) stocks as market order._

```CSharp
static async Task RunReplaceSignalAsync ()
{
	using (var client = CreateClient ()) {
		var content = await client.ReplaceSignalAsync (<system id>, <signal id>, C2Duration.GoodTilCanceled,
							C2Action.SellToClose, 100, "TZA", C2SymbolType.Stock, 0);
		PrintJson (content);
	}
}
```

### Status
Here is the progress so far (according to [the Collective2 API Documentation](https://www.collective2.com/api-docs/latest)) :

- [Strategy Access API](https://www.collective2.com/api-docs/latest#toc--strategy-access-api-): **10%** (2 of 10)
- [Signal Entry API](https://www.collective2.com/api-docs/latest#toc--signal-entry-api-): **70%** (7 of 10)
- [AutoTrade Management API](https://www.collective2.com/api-docs/latest#toc--autotrade-management-api-): **0%** (0 of 6)
- [Private-Branded Platform API](https://www.collective2.com/api-docs/latest#toc--private-branded-platform-api-): **0%** (0 of 10)

**Overall**: **25%** (9 of 36)

### Thanks

The C2Sharp project is generously sponsored by one great company:

* [GAANNA](https://www.gaanna.com/) who support this project and enable us to pay for important development work.
