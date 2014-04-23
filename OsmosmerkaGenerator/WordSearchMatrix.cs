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
using System.IO;
using System.Drawing;

namespace OsmosmerkaGenerator
{
    /// <summary>
    /// Represents generator of the Word Search
    /// </summary>
    class WordSearchMatrix
    {
        /// <summary>
        /// List of added words.
        /// </summary>
        private List<Word> words;

        /// <summary>
        /// List of dumped words.
        /// </summary>
        private List<string> dumpedWords;

        /// <summary>
        /// Represents letter positions.
        /// </summary>
        private List<ValueLetter> letterPositions;

        /// <summary>
        /// List of loaded words.
        /// </summary>
        private string[] wordList;

        /// <summary>
        /// List of excluded words.
        /// </summary>
        private string[] exclusionList;

        /// <summary>
        /// Represents final letter matrix.
        /// </summary>
        private string[][] letterMatrix;

        /// <summary>
        /// Represents maximum number of words.
        /// </summary>
        private int maxWords;

        /// <summary>
        /// Represents maximum widthxheight of letter matrix.
        /// </summary>
        private int maxLetters;

        /// <summary>
        /// Represents number of retries to fill the letter matrix with a word.
        /// </summary>
        private int maxRetries;

        /// <summary>
        /// Filename which represents exclusion list on disk.
        /// </summary>
        private string exclusionFilename;

        /// <summary>
        /// Gets one entry from letter matrix.
        /// </summary>
        /// <param name="i">Row of the matrix</param>
        /// <param name="j">Column of the matrix</param>
        /// <returns></returns>
        public string this[int i, int j]
        {
            get
            {
                if (i > letterMatrix.Length)
                    return null;

                if (j > letterMatrix[i].Length)
                    return null;

                return letterMatrix[i][j];
            }
        }

        /// <summary>
        /// Returns current list of words.
        /// </summary>
        public List<Word> Words
        {
            get
            {
                return words;
            }
        }

        /// <summary>
        /// Constructs new instance of WordSearchGenerator
        /// </summary>
        /// <param name="maxWords">Maximum number of words which will be added</param>
        /// <param name="maxLetters">Maximum number of WidthxHeight parameter</param>
        /// <param name="maxRetries">Maximum number of retries to fill letter matrix with words</param>
        /// <param name="inputDictionaryFilename">Filename of input dictionary from which words will be taken</param>
        /// <param name="exclusionFilename">Filename with list of excluded words from main dictionary</param>
        public WordSearchMatrix(int maxWords, int maxLetters, int maxRetries, string inputDictionaryFilename, string exclusionFilename)
        {
            this.maxWords = maxWords;
            this.maxLetters = maxLetters;
            this.maxRetries = maxRetries;

            StringBuilder dataString = new StringBuilder();
            words = new List<Word>();
            dumpedWords = new List<string>();
            letterPositions = new List<ValueLetter>();

            FileStream fs = new FileStream(inputDictionaryFilename, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buffer = new byte[1048576];
                int readCount = fs.Read(buffer, 0, buffer.Length);

                while (readCount > 0)
                {
                    dataString.Append(Encoding.UTF8.GetString(buffer, 0, readCount));
                    readCount = fs.Read(buffer, 0, buffer.Length);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            wordList = dataString.ToString().Split('\n');

            this.exclusionFilename = exclusionFilename;

            if (File.Exists(exclusionFilename))
            {
                dataString.Clear();
                fs = new FileStream(exclusionFilename, FileMode.Open, FileAccess.Read);
                try
                {
                    byte[] buffer = new byte[1048576];
                    int readCount = fs.Read(buffer, 0, buffer.Length);

                    while (readCount > 0)
                    {
                        dataString.Append(Encoding.UTF8.GetString(buffer, 0, readCount));
                        readCount = fs.Read(buffer, 0, buffer.Length);
                    }
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }

                exclusionList = dataString.ToString().Split('\n');
            }

            

            letterMatrix = new string[maxLetters][];

            for (int i = 0; i < maxLetters; i++)
                letterMatrix[i] = new string[maxLetters];
        }


        /// <summary>
        /// Resets all data for generator.
        /// </summary>
        public void reset()
        {
            words.Clear();
            dumpedWords.Clear();
            letterPositions.Clear();

            for (int i = 0; i < maxLetters; i++)
            {
                for (int j = 0; j < maxLetters; j++)
                    letterMatrix[i][j] = "0";
            }

            if (File.Exists(exclusionFilename))
            {
                StringBuilder dataString = new StringBuilder();
                FileStream fs = new FileStream(exclusionFilename, FileMode.Open, FileAccess.Read);
                try
                {
                    byte[] buffer = new byte[1048576];
                    int readCount = fs.Read(buffer, 0, buffer.Length);

                    while (readCount > 0)
                    {
                        dataString.Append(Encoding.UTF8.GetString(buffer, 0, readCount));
                        readCount = fs.Read(buffer, 0, buffer.Length);
                    }
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }

                exclusionList = dataString.ToString().Split('\n');
            }
        }

        /// <summary>
        /// Performs actual generation of the matrix.
        /// </summary>
        public void generate()
        {
            bool stop = false;
            bool retry = false;
            bool success = false;

            Random rng = new Random(DateTime.Now.Millisecond);

            Word newWord = null;
            string newWordStr = null;

            reset();

            while((words.Count < maxWords) || stop)
            {
                if (!retry)
                {
                    newWordStr = wordList[rng.Next(wordList.Length - 1)];

                    bool contains = false;
                    foreach (string s in dumpedWords)
                    {
                        if (s.Equals(newWordStr))
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (contains) continue;

                    if (exclusionList != null)
                    {
                        foreach (string s in exclusionList)
                        {
                            if (s.Equals(newWordStr))
                            {
                                contains = true;
                                break;
                            }
                        }

                        if (contains) continue;
                    }

                    foreach (Word s in words)
                    {
                        if (s.Equals(newWordStr))
                        {
                            contains = true;
                            break;
                        }
                    }

                    if (contains) continue;

                    newWord = new Word(newWordStr);
                }

                success = insertDirectional(newWord);

                if (!success)
                {
                    if (!newWord.chooseNewDirection())
                    {
                        dumpedWords.Add(newWordStr);
                        stop = (dumpedWords.Count == maxRetries);
                    }
                }
                else
                    words.Add(newWord);
            }


            string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Z", "Š", "Đ", "Ć", "Č", "Ž" };

            for (int i = 0; i < maxLetters; i++)
                for (int j = 0; j < maxLetters; j++)
                {
                    if (letterMatrix[i][j] == "0")
                        letterMatrix[i][j] = letters[rng.Next(letters.Length - 1)];
                }

            writeToExclusionList();
        }

        /// <summary>
        /// Performs directional insert into letter matrix if possible,
        /// </summary>
        /// <param name="word">Word which will be inserted</param>
        /// <returns>True if insert is successfull, false otherwise.</returns>
        private bool insertDirectional(Word word)
        {
            int minI = word.Length;
            int minJ = word.Length;
            int signumI = 0;
            int signumJ = 0;
            bool canAdd = false;

            List<Point> startPositions = new List<Point>();

            switch(word.Direction)
            {
                case Direction.Dir1:
                    signumI = -1;
                    signumJ = -1;
                    break;
                case Direction.Dir2:
                    signumI = -1;
                    break;
                case Direction.Dir3:
                    signumI = -1;
                    signumJ = 1;
                    break;
                case Direction.Dir4:
                    signumJ = -1;
                    break;
                case Direction.Dir6:
                    signumJ = 1;
                    break;
                case Direction.Dir7:
                    signumI = 1;
                    signumJ = -1;
                    break;
                case Direction.Dir8:
                    signumI = 1;
                    break;
                case Direction.Dir9:
                    signumI = 1;
                    signumJ = 1;
                    break;
            }

            for (int i = 0; i < letterMatrix.Length; i++)
            {
                for (int j = 0; j < letterMatrix.Length; j++)
                {
                    if ((letterMatrix[i][j] == word[0]) || (letterMatrix[i][j] == "0"))
                    {
                        switch (word.Direction)
                        {
                            case Direction.Dir1:
                                minI = i + 1;
                                minJ = j + 1;
                                break;
                            case Direction.Dir2:
                                minI = i + 1;
                                break;
                            case Direction.Dir3:
                                minI = i + 1;
                                minJ = letterMatrix[i].Length - j - 1;
                                break;
                            case Direction.Dir4:
                                minJ = j + 1;
                                break;
                            case Direction.Dir6:
                                minJ = letterMatrix[i].Length - j - 1;
                                break;
                            case Direction.Dir7:
                                minI = letterMatrix.Length - i - 1;
                                minJ = j + 1;
                                break;
                            case Direction.Dir8:
                                minI = letterMatrix.Length - i - 1;
                                break;
                            case Direction.Dir9:
                                minI = letterMatrix.Length - i - 1;
                                minJ = letterMatrix[i].Length - j - 1;
                                break;
                        }

                        if ((minI < word.Length) || (minJ < word.Length)) continue;

                        startPositions.Add(new Point(j, i));
                    }

                }
            }

            startPositions.Shuffle();

            foreach(Point p in startPositions)
            {
                int i = p.Y;
                int j = p.X;

                canAdd = true;

                for(int k = 0; k < word.Length; k++)
                {
                    foreach(ValueLetter letter in letterPositions)
                    {
                        canAdd = letter.canReplaceAt(i + k * signumI, j + k * signumJ, word[k]);
                        if (!canAdd) break;
                    }
                    if (!canAdd) break;
                }

                if (canAdd)
                {
                    for (int k = 0; k < word.Length; k++)
                    {
                        letterMatrix[i + k * signumI][j + k * signumJ] = word[k];
                        letterPositions.Add(new ValueLetter(i + k * signumI, j + k * signumJ, word[k]));
                    }

                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Writes new words to exclusion list.
        /// </summary>
        private void writeToExclusionList()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Word s in words)
                sb.Append(s.ToString() + "\n");

            FileStream fs = new FileStream(exclusionFilename, FileMode.Append);
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }

    
}
