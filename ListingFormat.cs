// ╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
// ║ File:        ListingFormat.cs                                                                               ║
// ║ Project:     EbayScraper                                                                                    ║
// ║ Date:        December 29, 2022                                                                              ║
// ║ Author:      Elijah Creed Fedele                                                                            ║
// ║ Description: Implements an enumeration for use by the Query and Listing classes which indicates the sale    ║
// ║              format of a particular eBay listing.                                                           ║
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

namespace EbayScraper
{
    public enum ListingFormat
    {
        All,
        AcceptsOffers,
        Auction,
        BuyItNow
    }
}