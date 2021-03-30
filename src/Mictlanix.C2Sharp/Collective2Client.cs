//
// Collective2Client.cs
//
// Author:
//       Eddy Zavaleta <eddy@mictlanix.com>
//
// Copyright (c) 2016-2021 Eddy Zavaleta, Mictlanix, and contributors.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mictlanix.C2Sharp {
	public class Collective2Client : IDisposable {
		public static readonly string DefaultUrlEndpoint = "https://api.collective2.com/world/apiv3/";

		readonly HttpClient client;

		public string ApiKey { get; set; }
		public string UrlEndpoint {
			get {
				return client.BaseAddress == null ? null : client.BaseAddress.AbsoluteUri;
			}
			set {
				client.BaseAddress = new Uri (value);
			}
		}

		public Collective2Client (string apiKey) : this (apiKey, DefaultUrlEndpoint)
		{
		}

		public Collective2Client (string apiKey, string url)
		{
			ApiKey = apiKey;

			client = new HttpClient ();
			client.BaseAddress = new Uri (url);
			client.DefaultRequestHeaders.Accept.Clear ();
			client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
		}

		public void Dispose ()
		{
			client.Dispose ();
		}

		/* 
		 * Strategy Access API
		 * 
		 * Done:
		 * getSystemRoster
		 * getSystemDetails
		 * 
		 * ToDo:
		 * getListSubscribers
		 * unsubscribeFromStrategy
		 * requestMarginEquity
		 * changeSystemAttribute
		 * createNewSystem
		 * requestAllTrades_overview
		 * subscribeToStrategy
		 * retrieveSystemEquity
		 * 
		 */

		public IEnumerable<C2System> GetSystemRoster (bool recently = false)
		{
			return GetSystemRosterAsync (recently).Result;
		}

		public async Task<IEnumerable<C2System>> GetSystemRosterAsync (bool recently = false)
		{
			var request = new { apikey = ApiKey, filter = recently ? "recently_active" : "active" };
			var response = await client.PostAsJsonAsync ("getSystemRoster", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2CollectionResponse<C2System>> ());
		}

		public C2System GetSystemDetails (string systemId)
		{
			return GetSystemDetailsAsync (systemId).Result;
		}

		public async Task<C2System> GetSystemDetailsAsync (string systemId)
		{
			var request = new { apikey = ApiKey, systemid = systemId };
			var response = await client.PostAsJsonAsync ("getSystemDetails", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2Response<C2System>> ());
		}

		/* 
		 * Signal Entry API
		 * 
		 * Done:
		 * submitSignal
		 * cancelSignal
		 * listAllSystems
		 * requestTrades
		 * requestTradesOpen
		 * retrieveSignalsWorking
		 * retrieveSignalsAll
		 * 
		 * ToDo:
		 * recentTradePolling
		 *
		 * Future Work:
		 * setDesiredPositions
		 * getDesiredPositions
		 * 
		 */

		public IEnumerable<C2System> ListAllSystems ()
		{
			return ListAllSystemsAsync ().Result;
		}

		public async Task<IEnumerable<C2System>> ListAllSystemsAsync ()
		{
			var request = new { apikey = ApiKey };
			var response = await client.PostAsJsonAsync ("listAllSystems", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2CollectionResponse<C2System>> ());
		}

		public IEnumerable<C2Trade> RequestTrades (string systemId)
		{
			return RequestTradesAsync (systemId).Result;
		}

		public async Task<IEnumerable<C2Trade>> RequestTradesAsync (string systemId)
		{
			var request = new { apikey = ApiKey, systemid = systemId };
			var response = await client.PostAsJsonAsync ("requestTrades", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2CollectionResponse<C2Trade>> ());
		}

		public IEnumerable<C2Trade> RequestTradesOpen (string systemId)
		{
			return RequestTradesOpenAsync (systemId).Result;
		}

		public async Task<IEnumerable<C2Trade>> RequestTradesOpenAsync (string systemId)
		{
			var request = new { apikey = ApiKey, systemid = systemId };
			var response = await client.PostAsJsonAsync ("requestTradesOpen", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2CollectionResponse<C2Trade>> ());
		}

		public IEnumerable<C2RetrievalSignal> RetrieveSignalsWorking (string systemId)
		{
			return RetrieveSignalsWorkingAsync (systemId).Result;
		}

		public async Task<IEnumerable<C2RetrievalSignal>> RetrieveSignalsWorkingAsync (string systemId)
		{
			var request = new { apikey = ApiKey, systemid = systemId };
			var response = await client.PostAsJsonAsync ("retrieveSignalsWorking", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2CollectionResponse<C2RetrievalSignal>> ());
		}

		public IEnumerable<C2RetrievalSignal> RetrieveSignalsAll (string systemId, C2TimeFilterType filterType,
		                                                     DateTime start, DateTime end)
		{
			return RetrieveSignalsAllAsync (systemId, filterType, start, end).Result;
		}

		public async Task<IEnumerable<C2RetrievalSignal>> RetrieveSignalsAllAsync (string systemId, C2TimeFilterType filterType,
		                                                                      DateTime start, DateTime end)
		{
			var request = new {
				apikey = ApiKey,
				systemid = systemId,
				filter_type = filterType,
				filter_date_time_start = ConvertToNewYorkTime (start),
				filter_date_time_end = ConvertToNewYorkTime (end)
			};
			var response = await client.PostAsJsonAsync ("retrieveSignalsAll", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2CollectionResponse<C2RetrievalSignal>> ());
		}

		public C2Signal SubmitSignal (string systemId, C2Duration duration, C2Action action, int quantity, string symbol,
		                              C2SymbolType typeOfSymbol, decimal limit)
		{
			return SubmitSignalAsync (systemId, duration, action, quantity, symbol, typeOfSymbol, limit).Result;
		}

		public async Task<C2Signal> SubmitSignalAsync (string systemId, C2Duration duration, C2Action action, int quantity,
		                                               string symbol, C2SymbolType typeOfSymbol, decimal limit)
		{
			var request = new {
				apikey = ApiKey,
				systemid = systemId,
				signal = new {
					action,
					quant = quantity,
					symbol,
					typeofsymbol = typeOfSymbol,
					limit = limit == 0m ? null : new decimal? (limit),
					duration,
					market = limit == 0m ? 1 : 0
				}
			};
			var response = await client.PostAsJsonAsync ("submitSignal", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2SignalResponse> ());
		}

		public C2Signal SubmitBracketOrder (string systemId, C2Duration duration, C2Action action, int quantity, string symbol, C2SymbolType typeOfSymbol, decimal limit,
		                                    decimal profitTarget, decimal stopLoss)
		{
			return SubmitBracketOrderAsync (systemId, duration, action, quantity, symbol, typeOfSymbol, limit, profitTarget, stopLoss).Result;
		}

		public async Task<C2Signal> SubmitBracketOrderAsync (string systemId, C2Duration duration, C2Action action, int quantity, string symbol, C2SymbolType typeOfSymbol,
		                                                     decimal limit, decimal profitTarget, decimal stopLoss)
		{
			var request = new {
				apikey = ApiKey,
				systemid = systemId,
				signal = new {
					action,
					quant = quantity,
					symbol,
					typeofsymbol = typeOfSymbol,
					limit = limit == 0m ? null : new decimal? (limit),
					duration,
					market = limit == 0m ? 1 : 0,
					profittarget = profitTarget,
					stoploss = stopLoss
				}
			};
			var response = await client.PostAsJsonAsync ("submitSignal", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2SignalResponse> ());
		}

		public C2Signal SubmitConditionalOrder (string systemId, string parentSignal, C2Duration duration, C2Action action, int quantity, string symbol,
		                                        C2SymbolType typeOfSymbol, decimal limit)
		{
			return SubmitConditionalOrderAsync (systemId, parentSignal, duration, action, quantity, symbol, typeOfSymbol, limit).Result;
		}

		public async Task<C2Signal> SubmitConditionalOrderAsync (string systemId, string parentSignal, C2Duration duration, C2Action action, int quantity, string symbol,
		                                                         C2SymbolType typeOfSymbol, decimal limit)
		{
			var request = new {
				apikey = ApiKey,
				systemid = systemId,
				signal = new {
					action,
					quant = quantity,
					symbol,
					typeofsymbol = typeOfSymbol,
					limit = limit == 0m ? null : new decimal? (limit),
					duration,
					market = limit == 0m ? 1 : 0,
					conditionalupon = parentSignal
				}
			};
			var response = await client.PostAsJsonAsync ("submitSignal", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2SignalResponse> ());
		}

		public C2Signal ReplaceSignal (string systemId, string signalId, C2Duration duration, C2Action action,
		                               int quantity, string symbol, C2SymbolType typeOfSymbol, decimal limit)
		{
			return ReplaceSignalAsync (systemId, signalId, duration, action, quantity, symbol, typeOfSymbol, limit).Result;
		}

		public async Task<C2Signal> ReplaceSignalAsync (string systemId, string signalId, C2Duration duration, C2Action action,
		                                                int quantity, string symbol, C2SymbolType typeOfSymbol, decimal limit)
		{
			var request = new {
				apikey = ApiKey,
				systemid = systemId,
				signal = new {
					action,
					quant = quantity,
					symbol,
					typeofsymbol = typeOfSymbol,
					limit = limit == 0m ? null : new decimal? (limit),
					duration,
					market = limit == 0m ? 1 : 0,
					xreplace = signalId,
					leave_oca_intact = 1
				}
			};
			var response = await client.PostAsJsonAsync ("submitSignal", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2SignalResponse> ());
		}

		public C2Signal CancelSignal (string systemId, string signalId)
		{
			return CancelSignalAsync (systemId, signalId).Result;
		}

		public async Task<C2Signal> CancelSignalAsync (string systemId, string signalId)
		{
			var request = new {
				apikey = ApiKey,
				systemid = systemId,
				signalid = signalId
			};
			var response = await client.PostAsJsonAsync ("cancelSignal", request);

			response.EnsureSuccessStatusCode ();

			return HandleResponse (await response.Content.ReadAsAsync<C2SignalResponse> ());
		}

		T HandleResponse<T> (C2Response<T> response)
		{
			if (!response.IsOK) {
				throw new C2Exception (response.Error.Title, response.Error.Message);
			}

			return response.Response;
		}

		IEnumerable<T> HandleResponse<T> (C2CollectionResponse<T> response)
		{
			if (!response.IsOK) {
				throw new C2Exception (response.Error.Title, response.Error.Message);
			}

			return response.Response;
		}

		C2Signal HandleResponse (C2SignalResponse response)
		{
			if (!response.IsOK) {
				var exception = new C2Exception (response.Error.Title, response.Error.Message);
				exception.Signal = response.RejectedSignal;
				throw exception;
			}

			return response.Signal;
		}

		static string ConvertToNewYorkTime (DateTime dt)
		{
			PlatformID pid = Environment.OSVersion.Platform;

			if (pid == PlatformID.Unix || pid == PlatformID.MacOSX) {
				return TimeZoneInfo.ConvertTimeBySystemTimeZoneId (dt, "America/New_York").ToString ("yyyy-MM-dd HH:mm:ss");
			}

			return TimeZoneInfo.ConvertTimeBySystemTimeZoneId (dt, "Eastern Standard Time").ToString ("yyyy-MM-dd HH:mm:ss");
		}
	}
}
