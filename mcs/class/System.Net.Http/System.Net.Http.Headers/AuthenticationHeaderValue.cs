//
// AuthenticationHeaderValue.cs
//
// Authors:
//	Marek Safar  <marek.safar@gmail.com>
//
// Copyright (C) 2011 Xamarin Inc (http://www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace System.Net.Http.Headers
{
	public class AuthenticationHeaderValue : ICloneable
	{
		public AuthenticationHeaderValue (string scheme)
			: this (scheme, null)
		{
		}

		public AuthenticationHeaderValue (string scheme, string parameter)
		{
			this.Scheme = scheme;
			this.Parameter = parameter;
		}

		public string Parameter { get; private set; }
		public string Scheme { get; private set; }

		object ICloneable.Clone ()
		{
			return MemberwiseClone ();
		}

		public override bool Equals (object obj)
		{
			var source = obj as AuthenticationHeaderValue;
			if (source == null || !string.Equals (source.Scheme, Scheme, StringComparison.OrdinalIgnoreCase))
				return false;

			if (string.IsNullOrEmpty (Parameter))
				return string.IsNullOrEmpty (source.Parameter);

			return string.Equals (source.Parameter, Parameter, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode ()
		{
			int hc = Scheme.ToLowerInvariant ().GetHashCode ();
			if (!string.IsNullOrEmpty (Parameter)) {
				hc ^= Parameter.ToLowerInvariant ().GetHashCode ();
			}

			return hc;
		}

		public static AuthenticationHeaderValue Parse (string input)
		{
			AuthenticationHeaderValue value;
			if (TryParse (input, out value))
				return value;

			throw new FormatException (input);
		}

		public static bool TryParse (string input, out AuthenticationHeaderValue parsedValue)
		{
			throw new NotImplementedException ();
		}
	}
}
