// ╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
// ║ File:        Query.cs                                                                                       ║
// ║ Project:     EbayScraper                                                                                    ║
// ║ Date:        December 29, 2022                                                                              ║
// ║ Author:      Elijah Creed Fedele                                                                            ║
// ║ Description: A class component of the EbayScraper package which implements a configurable query interface.  ║
// ╠═════════════════════════════════════════════════════════════════════════════════════════════════════════════╣
// ║ Copyright (C) 2022 Elijah Creed Fedele.                                                                     ║
// ║                                                                                                             ║
// ║ This program is free software: you can redistribute it and/or modify it under the terms of the GNU General  ║
// ║ Public License as published by the Free Software Foundation, either version 3 of the License, or (at your   ║
// ║ option) any later version.                                                                                  ║
// ║                                                                                                             ║
// ║ This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the  ║
// ║ implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public        ║
// ║ License for more details.                                                                                   ║
// ║                                                                                                             ║
// ║ You should have received a copy of the GNU General Public License along with this program. If not, see      ║
// ║ <http://www.gnu.org/licenses/>.                                                                             ║
// ╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════╝

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EbayScraper
{
    public class Query : ICloneable
    {
        private int DistanceFromLocation;
        private ListingCondition ListingConditions;
        private ListingFormat ListingFormat;
        private ListingVisibility ListingVisibility;
        private RunOptions RunOptions;
        private string Keywords;
        private string ZipCode;
        private string QueryUrl;

        private bool withListingConditions;
        private bool withListingFormat;
        private bool withListingVisibility;
        private bool withMaximumPrice;
        private bool withMinimumPrice;
        private bool withShippingRadius;     /* _sadis=<MILES>&LH_PrefLoc=99 */
        private bool withShippingZipCode;

        public Query(RunOptions runOptions)
        {
            this.RunOptions = runOptions;
            this.Keywords = "";
            this.ZipCode = "";
            this.QueryUrl = "https://www.ebay.com/sch/i.html?";
        }

        public string GetUrl()
        {
            return this.QueryUrl;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Chainable method call used to add keywords to a eBay search query URL. This function relies on the 
        /// class method <c>SanitizeHtml(string)</c> to handle escaping behaviors required by eBay servers.
        /// <summary>
        /// <param name="keywords">The keywords to add to the search query</param>
        /// <returns>A <c>Query</c> object with the intended modification</returns>
        public Query AddKeywords(string keywords)
        {
            Query copy = (Query) this.Clone();
            this.Keywords += keywords;
            copy.QueryUrl += ((copy.QueryUrl.Last() == '?') ? "&" : "") + SanitizeHtml(keywords);
            return copy;
        }

        /// <summary>
        /// Private class method which escapes and sanitizes (strips offending characters out of) supplied HTML 
        /// strings. Applied only to the keyword query search string; ampersands are required for proper URL 
        /// formation.
        /// </summary>
        /// <param name="htmlString">The HTML string to sanitize and escape per eBay request format</param>
        /// <returns>A string consisting of escaped and santized HTML suitable for use in web queries</returns>
        private static string SanitizeHtml(string htmlString)
        {
            StringBuilder outputString = new StringBuilder();
            for (int i = 0; i < htmlString.Length; i++) {
                switch(htmlString[i]) {
                    case '\'':
                        outputString.Append("&apos;");
                        break;
                    case '&':
                        outputString.Append("&amp;");
                        break;
                    case '<':
                        outputString.Append("&lt;");
                        break;
                    case '>':
                        outputString.Append("&gt;");
                        break;
                    case ' ':
                        outputString.Append('+');
                        break;
                    default:
                        outputString.Append(htmlString[i]);
                        break;
                }
            }
            return outputString.ToString().ToLower();
        }

        /// <summary>
        /// Private class helper method which returns the standard deviation of the prices occurring within the 
        /// set. This method should be used with care; as the C# <c>decimal</c> type does not have a full-featured
        /// analogue to <c>System.Math</c>, liberal casting was used to internally convert values 1) to 
        /// <c>double</c> and 2) back to <c>decimal</c> following calculation. As such, there is possibility of 
        /// floating-point errors arising in the price data through the use of this function, although such errors 
        /// are likely to be small for any price data list of reasonable size and individual magnitude.
        /// </summary>
        /// <param name="values">A <c>List</c> of <c>decimal</c> price values</param>
        /// <returns>A <c>decimal</c> value corresponding to the standard deviation of the set</returns>
        private static decimal StandardDeviation(List<decimal> values)
        {
            double internalSum = 0.0, meanDouble = (double) Mean(values);
            List<double> castedValues = new List<double>();
            foreach (decimal value in values) 
                castedValues.Add((double) value);

            for (int i = 0; i < castedValues.Count; i++)
                internalSum += Math.Pow(castedValues[i] - meanDouble, 2.0D);
            return (decimal) Math.Sqrt(internalSum / castedValues.Count);
        }

        /// <summary>
        /// Private class helper method which returns the mean (average) price occurring in the set following 
        /// scraping and parsing.
        /// </summary>
        /// <param name="values">A <c>List</c> of <c>decimal</c> price values</param>
        /// <returns>A <c>decimal</c> value corresponding to the set mean</returns>
        private static decimal Mean(List<decimal> values)
        {
            decimal sum = 0.0m;
            foreach (decimal value in values)
                sum += value;
            return sum / ((decimal) values.Count);
        }
    }
}