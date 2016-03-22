//
// C2RejectedSignal.cs
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

using System.Collections.Generic;
using Newtonsoft.Json;
using Mictlanix.C2Sharp.Converters;

namespace Mictlanix.C2Sharp {
	public class C2RejectedSignal {
		[JsonProperty ("systemid")]
		public string SystemId { get; set; }

		[JsonProperty ("duration")]
		public C2Duration Duration { get; set; }

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

		[JsonProperty ("profittarget")]
		public decimal ProfitTarget { get; set; }

		[JsonProperty ("stoploss")]
		public decimal StopLoss { get; set; }

		[JsonProperty ("market")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsMarket { get; set; }

		[JsonProperty ("day")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsDay { get; set; }

		[JsonProperty ("gtc")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsGTC { get; set; }

		[JsonProperty ("pSymbol")]
		public string PSymbol { get; set; }

		[JsonProperty ("_brokercode")]
		public object BrokerCode { get; set; }

		[JsonProperty ("_forceFillPrice")]
		public object ForceFillPrice { get; set; }

		[JsonProperty ("_personid")]
		public object PersonId { get; set; }

		[JsonProperty ("__forceTradePrice")]
		public object ForceTradePrice { get; set; }

		[JsonProperty ("_brokerid")]
		public object BrokerId { get; set; }

		[JsonProperty ("__forceTradeTimeSecs")]
		public object ForceTradeTimeSecs { get; set; }

		[JsonProperty ("_accountnum")]
		public object AccountNum { get; set; }

		[JsonProperty ("_replace_into_oca_group")]
		public object ReplaceIntoOcaGroup { get; set; }

		[JsonProperty ("__allowExpiredOrUnknownSymbol")]
		public object AllowExpiredOrUnknownSymbol { get; set; }

		[JsonProperty ("__forceImmediateFill")]
		public object ForceImmediateFill { get; set; }

		[JsonProperty ("tradeleader")]
		public object TradeLeader { get; set; }
	}
}
