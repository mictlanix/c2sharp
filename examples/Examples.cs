using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Mictlanix.C2Sharp;

namespace Examples {
	class MainClass {
		// C2's api server (api.collective2.com) uses Tls 1.2 but mono doesn't support it yet.
		// A workaround is to use "collective2.com" domain instead of "api.collective2.com".
#if __MonoCS__
		public static readonly string ApiUrl = "https://collective2.com/world/apiv3/";
#endif
		public static readonly string ApiKey = "< your api key >";
		public static readonly string SystemId = "< strategy number >";
		public static readonly string SignalId = "< signal number >";

		public static void Main (string [] args)
		{
#if !__MonoCS__
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
			//RunSystemRosterAsync ().Wait ();
			//RunSystemDetailsAsync ().Wait ();
			//RunListAllSystemsAsync ().Wait ();
			//RunRequestTradesAsync ().Wait ();
			//RunRequestTradesOpenAsync ().Wait ();
			//RunRetrieveSignalsWorkingAsync ().Wait ();
			//RunRetrieveSignalsAllAsync ().Wait ();
			//RunSubmitSignalAsync ().Wait ();
			//RunBracketOrderAsync ().Wait ();
			//RunCancelSignalAsync ().Wait ();
			//RunReplaceSignalAsync ().Wait ();

		}

		static async Task RunSystemRosterAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.GetSystemRosterAsync ();
				PrintJson (content);
			}
		}

		static async Task RunSystemDetailsAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.GetSystemDetailsAsync (SystemId);
				PrintJson (content);
			}
		}

		static async Task RunListAllSystemsAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.ListAllSystemsAsync ();
				PrintJson (content);
			}
		}

		static async Task RunRequestTradesAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.RequestTradesAsync (SystemId);
				PrintJson (content);
			}
		}

		static async Task RunRequestTradesOpenAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.RequestTradesOpenAsync (SystemId);
				PrintJson (content);
			}
		}

		static async Task RunRetrieveSignalsWorkingAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.RetrieveSignalsWorkingAsync (SystemId);
				PrintJson (content);
			}
		}

		static async Task RunRetrieveSignalsAllAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.RetrieveSignalsAllAsync (SystemId, C2TimeFilterType.Posted,
				                                                    DateTime.Parse ("2016-01-01 08:00:00"),
				                                                    DateTime.Parse ("2016-12-31 16:00:00"));
				PrintJson (content);
			}
		}

		static async Task RunSubmitSignalAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.SubmitSignalAsync (SystemId, C2Duration.GoodTilCanceled, C2Action.SellToClose, 10, "TZA", C2SymbolType.Stock, 48.5m);
				PrintJson (content);
			}
		}

		static async Task RunBracketOrderAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.SubmitBracketOrderAsync (SystemId, C2Duration.GoodTilCanceled, C2Action.BuyToOpen, 200, "TNA", C2SymbolType.Stock,
				                                                    55.00m, 55.3m, 53m);
				PrintJson (content);
			}
		}

		static async Task RunCancelSignalAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.CancelSignalAsync (SystemId, SignalId);
				PrintJson (content);
			}
		}

		static async Task RunReplaceSignalAsync ()
		{
			using (var client = CreateClient ()) {
				var content = await client.ReplaceSignalAsync (SystemId, SignalId, C2Duration.GoodTilCanceled, C2Action.SellToClose, 10, "TZA",
				                                               C2SymbolType.Stock, 0);
				PrintJson (content);
			}
		}

		static Collective2Client CreateClient ()
		{
			var client = new Collective2Client (ApiKey);
#if __MonoCS__
			client.UrlEndpoint = ApiUrl;
#endif
			return client;
		}

		static void PrintJson (object o)
		{
			System.Diagnostics.Debug.WriteLine (JsonConvert.SerializeObject (o, Formatting.Indented));
		}
	}
}
