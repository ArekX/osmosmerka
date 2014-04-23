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
using System.Collections;

namespace OsmosmerkaGenerator
{


    /// <summary>
    /// Enumeration which represents all available direction to which one
    /// word can go.
    /// </summary>
    enum Direction
    {
        Dir1, // Direction to Top-Left
        Dir2, // Direction to Top
        Dir3, // Direction to Top-Right
        Dir4, // Direction to Left
        Dir6, // Direction to Right
        Dir7, // Direction to Bottom-Left
        Dir8, // Direction to Bottom
        Dir9  // Direction to Bottom-Right
    }

    /// <summary>
    /// Class which represents one word.
    /// </summary>
    class Word
    {
        /// <summary>
        /// Represents one direction of the current word.
        /// </summary>
        private Direction direction;

        /// <summary>
        /// Contains passed word.
        /// </summary>
        private string wordString;

        /// <summary>
        /// Represents a list of all directions which are available to this word.
        /// </summary>
        private List<Direction> availableDirections;

        /// <summary>
        /// Property for Direction
        /// </summary>
        public Direction Direction
        {
            get
            {
                return direction;
            }
        }

        /// <summary>
        /// Returns length of one word.
        /// </summary>
        public int Length
        {
            get
            {
                return wordString.Length;
            }
        }

        /// <summary>
        /// Returns character from word.
        /// </summary>
        /// <param name="i">Index of the word</param>
        /// <returns>Returns character.</returns>
        public string this[int i]
        {
            get
            {
                if (i >= wordString.Length)
                    return null;

                return wordString[i].ToString();
            }
        }

        /// <summary>
        /// Construcs one Word object.
        /// </summary>
        /// <param name="wordString">String which will be used in building this word.</param>
        public Word(string wordString)
        {
            availableDirections = new List<Direction>() 
                { Direction.Dir1, Direction.Dir2, Direction.Dir3, Direction.Dir4, 
                  Direction.Dir6, Direction.Dir7, Direction.Dir8, Direction.Dir9 };

            availableDirections.Shuffle();

            direction = availableDirections.Pop();

            this.wordString = wordString;
        }

        /// <summary>
        /// Chooses new direction to which the word will be added.
        /// </summary>
        /// <returns></returns>
        public bool chooseNewDirection()
        {
            if (availableDirections.Count == 0) return false;

            availableDirections.Shuffle();
            direction = availableDirections.Pop();

            return true;
        }

        /// <summary>
        /// Returns current word.
        /// </summary>
        /// <returns>Added word to this class.</returns>
        public override string ToString()
        {
            return wordString;
        }

        /// <summary>
        /// Returns whether or not this word equals to specific string.
        /// </summary>
        /// <param name="st">String which will be checked</param>
        /// <returns>True if strings are equal, false if otherwise</returns>
        public bool Equals(string st)
        {
            return wordString.Equals(st);
        }
    }
}
