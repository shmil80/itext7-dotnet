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
using System.IO;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Test;

namespace iText.Forms.Fields {
    [NUnit.Framework.Category("UnitTest")]
    public class TerminalFormFieldBuilderTest : ExtendedITextTest {
        private static readonly PdfDocument DUMMY_DOCUMENT = new PdfDocument(new PdfWriter(new MemoryStream()));

        private const String DUMMY_NAME = "dummy name";

        private static readonly Rectangle DUMMY_RECTANGLE = new Rectangle(7, 11, 13, 17);

        [NUnit.Framework.Test]
        public virtual void ConstructorTest() {
            TerminalFormFieldBuilderTest.TestBuilder builder = new TerminalFormFieldBuilderTest.TestBuilder(DUMMY_DOCUMENT
                , DUMMY_NAME);
            NUnit.Framework.Assert.AreSame(DUMMY_DOCUMENT, builder.GetDocument());
            NUnit.Framework.Assert.AreSame(DUMMY_NAME, builder.GetFormFieldName());
        }

        [NUnit.Framework.Test]
        public virtual void GetSetWidgetTest() {
            TerminalFormFieldBuilderTest.TestBuilder builder = new TerminalFormFieldBuilderTest.TestBuilder(DUMMY_DOCUMENT
                , DUMMY_NAME);
            builder.SetWidgetRectangle(DUMMY_RECTANGLE);
            NUnit.Framework.Assert.AreSame(DUMMY_RECTANGLE, builder.GetWidgetRectangle());
        }

        [NUnit.Framework.Test]
        public virtual void GetSetPageTest() {
            TerminalFormFieldBuilderTest.TestBuilder builder = new TerminalFormFieldBuilderTest.TestBuilder(DUMMY_DOCUMENT
                , DUMMY_NAME);
            PdfPage page = DUMMY_DOCUMENT.AddNewPage();
            builder.SetPage(page);
            NUnit.Framework.Assert.AreEqual(1, builder.GetPage());
            builder.SetPage(5);
            NUnit.Framework.Assert.AreEqual(5, builder.GetPage());
        }

        [NUnit.Framework.Test]
        public virtual void SetPageToFieldTest() {
            TerminalFormFieldBuilderTest.TestBuilder builder = new TerminalFormFieldBuilderTest.TestBuilder(DUMMY_DOCUMENT
                , DUMMY_NAME);
            builder.SetPage(5);
            PdfFormField formField = new _PdfFormField_78(DUMMY_DOCUMENT);
            builder.SetPageToField(formField);
        }

        private sealed class _PdfFormField_78 : PdfFormField {
            public _PdfFormField_78(PdfDocument baseArg1)
                : base(baseArg1) {
            }

            public override PdfFormField SetPage(int pageNum) {
                NUnit.Framework.Assert.AreEqual(5, pageNum);
                return this;
            }
        }

        private class TestBuilder : TerminalFormFieldBuilder<TerminalFormFieldBuilderTest.TestBuilder> {
            protected internal TestBuilder(PdfDocument document, String formFieldName)
                : base(document, formFieldName) {
            }

            protected internal override TerminalFormFieldBuilderTest.TestBuilder GetThis() {
                return this;
            }
        }
    }
}
