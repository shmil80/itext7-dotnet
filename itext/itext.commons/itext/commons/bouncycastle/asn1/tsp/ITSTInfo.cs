/*
This file is part of the iText (R) project.
Copyright (c) 1998-2022 iText Group NV
Authors: iText Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using iText.Commons.Bouncycastle.Asn1;

namespace iText.Commons.Bouncycastle.Asn1.Tsp {
    /// <summary>
    /// This interface represents the wrapper for TSTInfo that provides the ability
    /// to switch between bouncy-castle and bouncy-castle FIPS implementations.
    /// </summary>
    public interface ITSTInfo : IASN1Encodable {
        /// <summary>
        /// Calls actual
        /// <c>getMessageImprint</c>
        /// method for the wrapped TSTInfo object.
        /// </summary>
        /// <returns>
        /// 
        /// <see cref="IMessageImprint"/>
        /// wrapper for the received MessageImprint object.
        /// </returns>
        IMessageImprint GetMessageImprint();

        /// <summary>
        /// Calls actual
        /// <c>getGenTime</c>
        /// method for the wrapped TSTInfo object and gets date.
        /// </summary>
        /// <returns>
        /// the received
        /// <see cref="System.DateTime"/>
        /// object.
        /// </returns>
        DateTime GetGenTime();
    }
}
