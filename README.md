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

##### Getting the system roster:

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

##### Getting system details:

```CSharp
static async Task RunSystemDetailsAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.GetSystemDetailsAsync (<system id>);
		PrintJson (content);
	}
}
```

##### List all strategies with real-time access:

```CSharp
static async Task RunListAllSystemsAsync ()
{
	using (var client = new Collective2Client ("your-api-key-here")) {
		var content = await client.ListAllSystemsAsync ();
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
