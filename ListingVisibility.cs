// ╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
// ║ File:        ListingVisibility.cs                                                                           ║
// ║ Project:     EbayScraper                                                                                    ║
// ║ Date:        December 29, 2022                                                                              ║
// ║ Author:      Elijah Creed Fedele                                                                            ║
// ║ Description: Implements an enumeration for use by the Query and Listing classes which indicates special     ║
// ║              visibility or sale characteristics of a listing.                                               ║
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
    [Flags]
    public enum ListingVisibility
    {
        FreeReturns           = (1 <<  0),
        ReturnsAccepted       = (1 <<  1),
        AuthorizedSeller      = (1 <<  2),
        CompletedItems        = (1 <<  3),
        SoldItems             = (1 <<  4),
        DealsAndSavings       = (1 <<  5),
        SaleItems             = (1 <<  6),
        ListedAsLots          = (1 <<  7),
        SearchInDescription   = (1 <<  8),
        BenefitsCharity       = (1 <<  9),
        AuthenticityGuarantee = (1 << 10)
    }
}