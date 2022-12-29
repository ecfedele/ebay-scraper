// ╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
// ║ File:        ListingConditions.cs                                                                           ║
// ║ Project:     EbayScraper                                                                                    ║
// ║ Date:        December 29, 2022                                                                              ║
// ║ Author:      Elijah Creed Fedele                                                                            ║
// ║ Description: Implements an enumeration for use by the Query and Listing classes which indicates the         ║
// ║              condition of an item for sale.                                                                 ║
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
    public enum ListingCondition
    {
        New                   = (1 << 0),
        OpenBox               = (1 << 1),
        CertifiedRefurbished  = (1 << 2),
        ExcellentRefurbished  = (1 << 3),
        VeryGoodRefurbished   = (1 << 4),
        GoodRefurbished       = (1 << 5),
        SellerRefurbished     = (1 << 6),
        Used                  = (1 << 7), 
        ForParts              = (1 << 8),
        Unspecified           = (1 << 9)
    }
}