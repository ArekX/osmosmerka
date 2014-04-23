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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OsmosmerkaGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            btnClearExclusion.Enabled = (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "exclude.txt"));
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string standardDictPath = AppDomain.CurrentDomain.BaseDirectory + "dictionary.txt";
            string standardExclusionPath = AppDomain.CurrentDomain.BaseDirectory + "exclude.txt";

            WordSearchMatrix wsm = new WordSearchMatrix((int)nmWords.Value, (int)nmWidth.Value, 5, standardDictPath, standardExclusionPath);

            string oFile = "";

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                oFile = dlgSave.FileName;
            }
            else
                return;

            MakePDF pdf = new MakePDF(oFile);

            for (int i = 0; i < (int)nmMaxWS.Value; i++)
            {
                wsm.reset();
                wsm.generate();
                pdf.addWordSearchPuzzle((int)nmWidth.Value, wsm);

                pbProgress.Value = (int)(pbProgress.Maximum * i / nmMaxWS.Value);
            }

            pbProgress.Value = pbProgress.Maximum;

            pdf.savePDF();
            pdf.showPDF();

            btnClearExclusion.Enabled = true;
        }

        private void btnClearExclusion_Click(object sender, EventArgs e)
        {
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "exclude.txt");

            MessageBox.Show("Lista očišćena.");

            btnClearExclusion.Enabled = false;
        }
    }
}
