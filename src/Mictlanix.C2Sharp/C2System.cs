//
// C2System.cs
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
	public class C2System {
		[JsonProperty ("system_id")]
		public string Id { get; set; }

		[JsonProperty ("systemName")]
		public string Name { get; set; }

		[JsonProperty ("system_name")]
		internal string SystemName {
			get { return Name; }
			set { Name = value; }
		}

		[JsonProperty ("shortDescription")]
		public string Summary { get; set; }

		[JsonProperty ("longDescription")]
		public string Description { get; set; }

		[JsonProperty ("ownerpersonid")]
		public string OwnerPersonId { get; set; }

		[JsonProperty ("owner_screenname")]
		public string OwnerScreenname { get; set; }

		[JsonProperty ("owner_email")]
		public string OwnerEmail { get; set; }

		[JsonProperty ("owner_firstname")]
		public string OwnerFirstname { get; set; }

		[JsonProperty ("owner_lastname")]
		public string OwnerLastname { get; set; }

		[JsonProperty ("createdWhen")]
		public DateTime? CreatedWhen { get; set; }

		[JsonProperty ("created_when")]
		internal DateTime? CreatedWhen2 {
			get { return CreatedWhen; }
			set { CreatedWhen = value; }
		}

		[JsonProperty ("test_system")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TestSystem { get; set; }

		[JsonProperty ("minimum_portfolio_size_required")]
		public decimal MinimumPortfolioSizeRequired { get; set; }

		[JsonProperty ("freeTrialPeriodDays")]
		public int FreeTrialPeriodDays { get; set; }

		[JsonProperty ("creditSystemTimeUntil_clock")]
		public DateTime? CreditSystemTimeUntil { get; set; }

		[JsonProperty ("creditSystemTimeUntil_epochSecs")]
		public long? CreditSystemTimeUntilSeconds { get; set; }

		[JsonProperty ("freeSignalEntryCredits")]
		public int FreeSignalEntryCredits { get; set; }

		[JsonProperty ("equitycurve_startingcapital")]
		public decimal StartingCapital { get; set; }

		[JsonProperty ("monthlyFee")]
		public decimal MonthlyFee { get; set; }

		[JsonProperty ("trades_forex")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesForex { get; set; }

		[JsonProperty ("trades_futures")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesFutures { get; set; }

		[JsonProperty ("trades_options")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesOptions { get; set; }

		[JsonProperty ("trades_stocks")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesStocks { get; set; }

		[JsonProperty ("trades_stocks_short")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesStocksShort { get; set; }

		[JsonProperty ("trades_options_short")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesOptionsShort { get; set; }

		[JsonProperty ("shorts_options")]
		public string ShortsOptions { get; set; }

		[JsonProperty ("shorts_stocks")]
		public string ShortsStocks { get; set; }

		[JsonProperty ("isAlive")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? IsAlive { get; set; }

		[JsonProperty ("recently_inactive_since")]
		public string RecentlyInactiveSince { get; set; }

		[JsonProperty ("trades_own_system_certified")]
		[JsonConverter (typeof (BoolConverter))]
		public bool? TradesOwnSystemCertified { get; set; }

		[JsonProperty ("trades_own_system_scaling")]
		public decimal? TradesOwnSystemScaling { get; set; }

		[JsonProperty ("trades_own_system_percent_followed")]
		public decimal? TradesOwnSystemPercentFollowed { get; set; }

		[JsonProperty ("trades_own_system_number_signals")]
		public int? TradesOwnSystemNumberSignals { get; set; }

		[JsonProperty ("statistics")]
		public C2Statistics Statistics { get; set; }
	}
}
