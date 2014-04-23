using System;
using System.Collections.Generic;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsmosmerkaGenerator
{
    /// <summary>
    /// Contains extensions to List type.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Static random initialization.
        /// </summary>
        public static Random rngStatic = new Random();

        /// <summary>
        /// Performs shuffle on a list.
        /// </summary>
        /// <typeparam name="T">Type of the list</typeparam>
        /// <param name="list">List which will be shuffled</param>
        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rngStatic.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Removes last item from the list and returns it.
        /// </summary>
        /// <typeparam name="T">Type of the list</typeparam>
        /// <param name="list">List variable</param>
        /// <returns></returns>
        public static T Pop<T>(this List<T> list)
        {
            T retVar = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);

            return retVar;
        }
    }
}
