//
// C2Trade.cs
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

namespace Mictlanix.C2Sharp {
	public class C2Trade {
		[JsonProperty ("trade_id")]
		public string Id { get; set; }

		[JsonProperty ("symbol")]
		public string Symbol { get; set; }

		[JsonProperty ("symbol_description")]
		public string SymbolDescription { get; set; }

		[JsonProperty ("closeVWAP_timestamp")]
		public long CloseVWAPTimestamp { get; set; }

		[JsonProperty ("strike")]
		public string Strike { get; set; }

		[JsonProperty ("open_or_closed")]
		public string OpenOrClosed { get; set; }

		[JsonProperty ("expir")]
		public string Expir { get; set; }

		[JsonProperty ("openVWAP_timestamp")]
		public string OpenVWAPTimestamp { get; set; }

		[JsonProperty ("underlying")]
		public string Underlying { get; set; }

		[JsonProperty ("closing_price_VWAP")]
		public decimal ClosingPriceVWAP { get; set; }

		[JsonProperty ("putcall")]
		public string Putcall { get; set; }

		[JsonProperty ("quant_closed")]
		public int QuantityClosed { get; set; }

		[JsonProperty ("markToMarket_time")]
		public DateTime? MarkToMarketTime { get; set; }

		[JsonProperty ("opening_price_VWAP")]
		public decimal OpeningPriceVWAP { get; set; }

		[JsonProperty ("quant_opened")]
		public int QuantityOpened { get; set; }

		[JsonProperty ("instrument")]
		public C2SymbolType Instrument { get; set; }

		[JsonProperty ("ptValue")]
		public string PtValue { get; set; }

		[JsonProperty ("PL")]
		public string PL { get; set; }

		[JsonProperty ("closedWhen")]
		public DateTime ClosedWhen { get; set; }

		[JsonProperty ("closedWhenUnixTimeStamp")]
		public long ClosedWhenTimestamp { get; set; }

		[JsonProperty ("openedWhen")]
		public DateTime OpenedWhen { get; set; }

		[JsonProperty ("long_or_short")]
		public string LongOrShort { get; set; }
	}
}
