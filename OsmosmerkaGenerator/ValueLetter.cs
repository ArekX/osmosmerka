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

namespace OsmosmerkaGenerator
{
    /// <summary>
    /// Represents one added letter to Word Search
    /// </summary>
    class ValueLetter
    {
        /// <summary>
        /// X (zero-based) of the letter position.
        /// </summary>
        private int x;

        /// <summary>
        /// Y (zero-based) of the letter position.
        /// </summary>
        private int y;

        /// <summary>
        /// Letter of value.
        /// </summary>
        private string letter;

        /// <summary>
        /// Constructs new instance of ValueLetter.
        /// </summary>
        /// <param name="x">X position of the letter</param>
        /// <param name="y">Y position of the letter.</param>
        /// <param name="letter">Letter which is represented at these positions</param>
        public ValueLetter(int x, int y, string letter)
        {
            this.x = x;
            this.y = y;
            this.letter = letter;
        }

        /// <summary>
        /// Returns true if letter can be replaced at specified coordinates.
        /// </summary>
        /// <param name="x">X position which will be checked</param>
        /// <param name="y">Y position which will be checked</param>
        /// <param name="withLetter">Letter to which this letter will be compared</param>
        /// <returns>True if letters are at the same coordinates and are the same, false otherwise.</returns>
        public bool canReplaceAt(int x, int y, string withLetter)
        {
            if ((this.x == x) && (this.y == y))
            {
                return (this.letter == withLetter);
            }
            else
                return true;
        }
    }
}
