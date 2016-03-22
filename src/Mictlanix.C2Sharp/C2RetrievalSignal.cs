//
// C2RetrievalSignal.cs
//
// Author:
//       Eddy Zavaleta <eddy@mictlanix.com>
//
// Copyright (c) 2016 Eddy Zavaleta, Mictlanix, and contributors.
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
using Newtonsoft.Json;
using Mictlanix.C2Sharp.Converters;

namespace Mictlanix.C2Sharp {
	public class C2RetrievalSignal {
		[JsonProperty ("signal_id")]
		public string Id { get; set; }

		[JsonProperty ("tif")]
		public C2Duration TimeInForce { get; set; }

		[JsonProperty ("action")]
		public C2Action Action { get; set; }

		[JsonProperty ("symbol")]
		public string Symbol { get; set; }

		[JsonProperty ("name")]
		public string SymbolDescription { get; set; }

		[JsonProperty ("strike")]
		public string Strike { get; set; }

		[JsonProperty ("status")]
		public C2SignalStatus Status { get; set; }

		[JsonProperty ("traded_time")]
		public DateTime? TradedTime { get; set; }

		[JsonProperty ("traded_time_unix")]
		public long TradedTimestamp { get; set; }

		[JsonProperty ("expired_time")]
		[JsonConverter (typeof (DateTimeConverter))]
		public DateTime? ExpiredTime { get; set; }

		[JsonProperty ("expired_time_unix")]
		public long ExpiredTimestamp { get; set; }

		[JsonProperty ("underlying")]
		public string Underlying { get; set; }

		[JsonProperty ("isLimitOrder")]
		public decimal LimitOrder { get; set; }

		[JsonProperty ("isMarketOrder")]
		public decimal MarketOrder { get; set; }

		[JsonProperty ("isStopOrder")]
		public decimal StopOrder { get; set; }

		[JsonProperty ("putcall")]
		public string Putcall { get; set; }

		[JsonProperty ("expiration")]
		public string Expiration { get; set; }

		[JsonProperty ("quant")]
		public int Quantity { get; set; }

		[JsonProperty ("canceled_time")]
		public DateTime? CanceledTime { get; set; }

		[JsonProperty ("canceled_time_unix")]
		public long CanceledTimestamp { get; set; }

		[JsonProperty ("instrument")]
		public C2SymbolType Instrument { get; set; }

		[JsonProperty ("posted_time")]
		public DateTime? PostedTime { get; set; }

		[JsonProperty ("posted_time_unix")]
		public long PostedTimestamp { get; set; }

		[JsonProperty ("trade_id_opening")]
		public string OpeningTradeId { get; set; }

		[JsonProperty ("trade_id_closing")]
		public string ClosingTradeId { get; set; }

		[JsonProperty ("traded_price")]
		public decimal? TradedPrice { get; set; }
	}
}
