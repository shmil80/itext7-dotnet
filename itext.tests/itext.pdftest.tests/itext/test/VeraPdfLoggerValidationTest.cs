/*
This file is part of the iText (R) project.
Copyright (c) 1998-2022 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using iText.Test.Pdfa;
using iText.Test.Utils;

namespace iText.Test {
    [NUnit.Framework.Category("UnitTest")]
    public class VeraPdfLoggerValidationTest : ExtendedITextTest {
        internal static readonly String SOURCE_FOLDER = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/pdftest/cmp/VeraPdfLoggerValidationTest/";

        internal static readonly String DESTINATION_FOLDER = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/pdftest/VeraPdfLoggerValidationTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateDestinationFolder(DESTINATION_FOLDER);
        }

        [NUnit.Framework.Test]
        public virtual void CheckValidatorLogsTest() {
            String fileNameWithWarnings = "cmp_pdfA2b_checkValidatorLogsTest_with_warnings.pdf";
            String fileNameWithoutWarnings = "cmp_pdfA2b_checkValidatorLogsTest.pdf";
            FileUtil.Copy(SOURCE_FOLDER + fileNameWithWarnings, DESTINATION_FOLDER + fileNameWithWarnings);
            FileUtil.Copy(SOURCE_FOLDER + fileNameWithoutWarnings, DESTINATION_FOLDER + fileNameWithoutWarnings);
            String expectedWarningsForFileWithWarnings = "The following warnings and errors were logged during validation:\n"
                 + "WARNING: Invalid embedded cff font. Charset range exceeds number of glyphs\n" + "WARNING: Missing OutputConditionIdentifier in an output intent dictionary\n"
                 + "WARNING: The Top DICT does not begin with ROS operator";
            NUnit.Framework.Assert.AreEqual(expectedWarningsForFileWithWarnings, new VeraPdfValidator().Validate(DESTINATION_FOLDER
                 + fileNameWithWarnings));
            //We check that the logs are empty after the first check
            NUnit.Framework.Assert.IsNull(new VeraPdfValidator().Validate(DESTINATION_FOLDER + fileNameWithoutWarnings
                ));
        }
    }
}
