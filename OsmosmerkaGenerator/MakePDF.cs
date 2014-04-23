/**
 *  Generator Osmosmerke
 *  Copyright (C) 2014 Panic Aleksandar
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace OsmosmerkaGenerator
{
    /// <summary>
    /// Class which generates output PDF.
    /// </summary>
    class MakePDF
    {
        /// <summary>
        /// Represents one PDF document instance.
        /// </summary>
        private PdfDocument doc;

        /// <summary>
        /// Output filename of PDF file.
        /// </summary>
        private string oFilename;

        /// <summary>
        /// Constructor for MakePDF class.
        /// </summary>
        /// <param name="outputFilename">Filename to which PDF will be saved.</param>
        public MakePDF(string outputFilename)
        {
            doc = new PdfDocument();
            this.oFilename = outputFilename;
        }

        /// <summary>
        /// Saves output to disk.
        /// </summary>
        public void savePDF()
        {
            doc.Info.Author = "Generator Osmosmerke";
            doc.Info.Title = doc.PageCount == 1 ? "Osmosmerka" : "Osmosmerke";
            doc.Info.Subject = doc.PageCount == 1 ? "Osmosmerka" : "Osmosmerke";
            doc.Info.ModificationDate = DateTime.Now;
            doc.Info.CreationDate = DateTime.Now;
            doc.Info.Creator = "Generator Osmosmerke 1.0.0 by Panic Aleksandar";

            doc.Save(oFilename);
        }

        /// <summary>
        /// Executes saved output of PDF file.
        /// </summary>
        public void showPDF()
        {
            Process.Start(oFilename);
        }
        
        /// <summary>
        /// Adds another page to PDF document of Word Search puzzle.
        /// </summary>
        /// <param name="maxLetters">Maximum number of letters</param>
        /// <param name="wsm">Word Search Matrix which will be used to generate the page</param>
        public void addWordSearchPuzzle(int maxLetters, WordSearchMatrix wsm)
        {
            PdfPage page = doc.AddPage();

            XGraphics g = XGraphics.FromPdfPage(page);

            XFont fnt = new XFont("Arial", 24, XFontStyle.Bold);

            g.DrawString("Osmosmerka #" + doc.PageCount.ToString(), fnt, XBrushes.Black, new XRect(20, 20, page.Width, fnt.Height),
                XStringFormats.TopLeft);

            g.DrawLine(new XPen(XColor.FromName("blue")), new XPoint(20, 25 + fnt.Height), new XPoint(page.Width - 20, 25 + fnt.Height));

            int startY = 30 + fnt.Height;

            fnt = new XFont("Arial", (int)((page.Width - 40) / (maxLetters)), XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always));
            
            XRect drawRect = new XRect(20, startY, page.Width, fnt.Height);

            double coeff = (page.Width - 40) / (maxLetters);

            for(int i = 0; i < maxLetters; i++)
            {
                drawRect.Y = startY + i * coeff;

                for (int j = 0; j < maxLetters; j++)
                {
                    drawRect.X = 20 + j * coeff;
                    g.DrawString(wsm[i, j], fnt, XBrushes.Black, drawRect, XStringFormats.TopLeft);
                }
            }

            drawRect.Y = startY + maxLetters * coeff + 10;
            fnt = new XFont("Arial", 16, XFontStyle.Bold, new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always));
            g.DrawLine(new XPen(XColor.FromName("blue")), new XPoint(20, drawRect.Y), new XPoint(page.Width - 20, drawRect.Y));

            drawRect.X = 20;
            g.DrawString("Reči:", fnt, XBrushes.Black, drawRect, XStringFormats.TopLeft);
            
            drawRect = new XRect(20, startY + maxLetters * coeff + 15 + fnt.Height, page.Width - 40, fnt.Height);

            fnt = new XFont("Arial", 12, XFontStyle.Bold, new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always));

            StringBuilder wordStrings = new StringBuilder();

            for (int i = 0; i < wsm.Words.Count; i++)
            {
                string drawWord = wsm.Words[i].ToString();
                XSize sz = g.MeasureString(drawWord, fnt);

                if (drawRect.X + sz.Width > (page.Width - 20))
                {
                    drawRect.X = 20;
                    drawRect.Y += fnt.Height;

                    if (drawRect.Y > page.Height - 20)
                    {
                        page = doc.AddPage();
                        drawRect = new XRect(20, 20, page.Width - 40, fnt.Height);
                        g = XGraphics.FromPdfPage(page);
                    }
                }

                g.DrawString(drawWord, fnt, XBrushes.Black, drawRect, XStringFormats.TopLeft);

                drawRect.X += sz.Width + 20;
            }

            

        }
    }
}
