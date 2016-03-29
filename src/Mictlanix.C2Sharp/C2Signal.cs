//
// C2Signal.cs
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
	public class C2Signal {
		[JsonProperty ("signalid")]
		public string Id { get; set; }

		[JsonProperty ("profittargetsignalid")]
		public string ProfitTargetSignalId { get; set; }

		[JsonProperty ("stoplosssignalid")]
		public string StopLossSignalId { get; set; }

		[JsonProperty ("systemid")]
		public string SystemId { get; set; }

		[JsonProperty ("duration")]
		public C2Duration? Duration { get; set; }

		[JsonProperty ("action")]
		public C2Action Action { get; set; }

		[JsonProperty ("quant")]
		public int Quantity { get; set; }

		[JsonProperty ("symbol")]
		public string Symbol { get; set; }

		[JsonProperty ("typeofsymbol")]
		public C2SymbolType TypeOfSymbol { get; set; }

		[JsonProperty ("limit")]
		public decimal Limit { get; set; }

		[JsonProperty ("islimit")]
		internal decimal Limit2 {
			get { return Limit; }
			set { Limit = value; }
		}

		[JsonProperty ("stop")]
		public decimal Stop { get; set; }

		[JsonProperty ("profittarget")]
		public decimal? ProfitTarget { get; set; }

		[JsonProperty ("stoploss")]
		public decimal? StopLoss { get; set; }

		[JsonProperty ("market")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsMarket { get; set; }

		[JsonProperty ("day")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsDay { get; set; }

		[JsonProperty ("gtc")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsGTC { get; set; }

		[JsonProperty ("description")]
		public string SymbolDescription { get; set; }

		[JsonProperty ("currency")]
		public string Currency { get; set; }

		[JsonProperty ("comments")]
		public string Comments { get; set; }

		[JsonProperty ("targetocagroupid")]
		public string TargetOcaGroupId { get; set; }

		[JsonProperty ("expiresat")]
		public long ExpiresAtTimestamp { get; set; }

		[JsonProperty ("signalexpiresat")]
		internal long SignalExpiresAtTimestamp {
			get { return ExpiresAtTimestamp; }
			set { ExpiresAtTimestamp = value; }
		}

		[JsonProperty ("pointvalue")]
		public int PointValue { get; set; }

		[JsonProperty ("conditionalupon")]
		public string ConditionalUpon { get; set; }

		[JsonProperty ("ocaid")]
		public string OcaId { get; set; }

		[JsonProperty ("parkUntilYYYYMMDDHHMM")]
		[JsonConverter (typeof (DateTimeConverter))]
		public DateTime? ParkUntil { get; set; }

		[JsonProperty ("parkUntilSecs")]
		public long? ParkUntilTimestamp { get; set; }

		[JsonProperty ("strike")]
		public string Strike { get; set; }

		[JsonProperty ("expir")]
		public string Expir { get; set; }

		[JsonProperty ("personid")]
		public string PersonId { get; set; }

		[JsonProperty ("underlying")]
		public string Underlying { get; set; }

		[JsonProperty ("tradeprice")]
		public string TradePrice { get; set; }

		[JsonProperty ("decimalprecision")]
		public int DecimalPrecision { get; set; }

		[JsonProperty ("leave_oca_intact")]
		public string LeaveOcaIntact { get; set; }

		[JsonProperty ("putcall")]
		public object Putcall { get; set; }

		[JsonProperty ("guid")]
		public string Guid { get; set; }

		[JsonProperty ("xreplace")]
		public string XReplace { get; set; }

		[JsonProperty ("postedwhen")]
		public long PostedWhenTimestamp { get; set; }

		[JsonProperty ("tradedwhen")]
		public long TradedWhenTimestamp { get; set; }

		[JsonProperty ("expiredwhen")]
		public long ExpiredWhenTimestamp { get; set; }

		[JsonProperty ("killedwhen")]
		public long KilledWhenTimestamp { get; set; }
	}
}
