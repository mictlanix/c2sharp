//
// C2Responses.cs
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
	class C2Response<T> {
		[JsonProperty ("ok")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsOK { get; set; }

		[JsonProperty ("response")]
		public T Response { get; set; }

		[JsonProperty ("error")]
		public C2Error Error { get; set; }
	}

	class C2CollectionResponse<T> {
		[JsonProperty ("ok")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsOK { get; set; }

		[JsonProperty ("response")]
		public IEnumerable<T> Response { get; set; }

		[JsonProperty ("error")]
		public C2Error Error { get; set; }
	}

	class C2SignalResponse {
		[JsonProperty ("ok")]
		[JsonConverter (typeof (BoolConverter))]
		public bool IsOK { get; set; }

		[JsonProperty ("signal")]
		public C2Signal Signal { get; set; }

		[JsonProperty ("rejectedSignal")]
		public C2RejectedSignal RejectedSignal { get; set; }

		[JsonProperty ("signalid")]
		public string SignalId { get; set; }

		[JsonProperty ("title")]
		public string Title { get; set; }

		[JsonProperty ("elapsed_time")]
		public string ElapsedTime { get; set; }

		[JsonProperty ("message")]
		public string Message { get; set; }

		[JsonProperty ("error")]
		public C2Error Error { get; set; }
	}

	class C2Error {
		[JsonProperty ("title")]
		public string Title { get; set; }

		[JsonProperty ("message")]
		public string Message { get; set; }
	}
}
