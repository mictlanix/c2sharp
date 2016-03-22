//
// C2Statistics.cs
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
	public class C2Statistics {
		[JsonProperty ("numloss")]
		public string NumLoss { get; set; }

		[JsonProperty ("avgpts_@SP")]
		public C2Statistic AvgPtsSP { get; set; }

		[JsonProperty ("avgpts_@ES")]
		public C2Statistic AvgPtsES { get; set; }

		[JsonProperty ("avgpts_@US")]
		public C2Statistic AvgPtsUS { get; set; }

		[JsonProperty ("avgpts_@YM")]
		public C2Statistic AvgPtsYM { get; set; }

		[JsonProperty ("AvgPts_@ER2")]
		public C2Statistic AvgPtsER2 { get; set; }

		[JsonProperty ("avgptsfutures")]
		public C2Statistic AvgPtsFutures { get; set; }

		[JsonProperty ("avgptsstocks")]
		public C2Statistic AvgPtsStocks { get; set; }

		[JsonProperty ("avgpips")]
		public C2Statistic AvgPips { get; set; }

		[JsonProperty ("avgDollarPosWinners")]
		public C2Statistic AvgDollarPosWinners { get; set; }

		[JsonProperty ("Calmar Ratio")]
		public C2Statistic CalmarRatio { get; set; }

		[JsonProperty ("sumDollarPosLosers")]
		public C2Statistic SumDollarPosLosers { get; set; }

		[JsonProperty ("Popularity (today)")]
		public C2Statistic PopularityToday { get; set; }

		[JsonProperty ("Popularity (week)")]
		public C2Statistic PopularityWeek { get; set; }

		[JsonProperty ("Popularity (month)")]
		public C2Statistic PopularityMonth { get; set; }

		[JsonProperty ("numtrades")]
		public string NumTrades { get; set; }

		[JsonProperty ("sumDollarPosWinners")]
		public C2Statistic SumDollarPosWinners { get; set; }

		[JsonProperty ("monteCarlo_risk_of_account_loss")]
		public IEnumerable<C2Risk> MonteCarloRiskOfAccountLoss { get; set; }

		[JsonProperty ("deltaEquityAcrossRecentTime_noFees")]
		public IEnumerable<C2Delta> DeltaEquityAcrossRecentTimeNoFees { get; set; }

		[JsonProperty ("subPricePerPeriod")]
		public C2Statistic SubPricePerPeriod { get; set; }

		[JsonProperty ("Sortino Ratio")]
		public C2Statistic SortinoRatio { get; set; }

		[JsonProperty ("businessModel")]
		public C2Statistic BusinessModel { get; set; }

		[JsonProperty ("startUnitSize")]
		public C2Statistic StartUnitSize { get; set; }

		[JsonProperty ("Sharpe Ratio")]
		public C2Statistic SharpeRatio { get; set; }

		[JsonProperty ("latestequity")]
		public C2Statistic LatestEquity { get; set; }

		[JsonProperty ("avgDollarPosLosers")]
		public C2Statistic AvgDollarPosLosers { get; set; }

		[JsonProperty ("numPosWinners")]
		public C2Statistic NumPosWinners { get; set; }

		[JsonProperty ("trialPeriodDays")]
		public C2Statistic TrialPeriodDays { get; set; }

		[JsonProperty ("systemAgeDays")]
		public C2Statistic SystemAgeDays { get; set; }

		[JsonProperty ("numwins")]
		public string NumWins { get; set; }

		[JsonProperty ("cashdivs")]
		public C2Statistic CashDivs { get; set; }

		[JsonProperty ("dollarwin")]
		public string DollarWin { get; set; }

		[JsonProperty ("ownerAutoTrades")]
		public C2Statistic OwnerAutoTrades { get; set; }

		[JsonProperty ("Ann Return (Compnd, No Fees)")]
		public C2Statistic AnnReturnCompoundNoFees { get; set; }

		[JsonProperty ("billingPeriodDays")]
		public C2Statistic BillingPeriodDays { get; set; }

		[JsonProperty ("ownerAutoTradesPcnt")]
		public C2Statistic OwnerAutoTradesPcnt { get; set; }

		[JsonProperty ("dollarloss")]
		public string DollarLoss { get; set; }

		[JsonProperty ("creatorAliasOrName")]
		public C2Statistic<string> CreatorAliasOrName { get; set; }

		[JsonProperty ("keepAfterSlip")]
		public C2Statistic KeepAfterSlip { get; set; }

		[JsonProperty ("numPosLosers")]
		public C2Statistic NumPosLosers { get; set; }
	}

	public class C2Statistic<T> {
		[JsonProperty ("value")]
		public T Value { get; set; }

		[JsonProperty ("metainfo")]
		public C2MetaInfo MetaInfo { get; set; }

		public override string ToString ()
		{
			return Value == null ? "null" : Value.ToString ();
		}
	}

	public class C2Statistic : C2Statistic<decimal?> {
	}

	public class C2Risk {
		[JsonProperty ("probability")]
		public decimal Probability { get; set; }

		[JsonProperty ("percent_loss")]
		public decimal PercentLoss { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Probability={0}, PercentLoss={1}]", Probability, PercentLoss);
		}
	}

	public class C2Delta {
		[JsonProperty ("percentChange")]
		public string Change { get; set; }

		[JsonProperty ("delta_days")]
		public string Days { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Change={0}, Days={1}]", Change, Days);
		}
	}

	public class C2MetaInfo {
		[JsonProperty ("bunch")]
		public string Bunch { get; set; }

		[JsonProperty ("dataset")]
		public string Dataset { get; set; }

		[JsonProperty ("group")]
		public string Group { get; set; }

		[JsonProperty ("suffix")]
		public string Suffix { get; set; }

		[JsonProperty ("category")]
		public string Category { get; set; }

		[JsonProperty ("helpText")]
		public string HelpText { get; set; }

		[JsonProperty ("precision")]
		public int Precision { get; set; }

		[JsonProperty ("prefix")]
		public string Prefix { get; set; }

		[JsonProperty ("multiplier")]
		public decimal Multiplier { get; set; }
	}
}
