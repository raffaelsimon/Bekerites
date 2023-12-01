using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BekeritesPersistence
{
    public class BekeritesFileDataAccess : IBekeritesDataAccess
    {

        //betoltes
        public Board Load(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path)) // fájl megnyitása
                {
                    List<string> lines = new List<string>();
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }


                    Board board = new Board(lines.Count); // létrehozzuk a táblát

                    for (int i = 0; i < lines.Count; i++)
                    {

                        string[] numbers = lines[i].Split(' ');

                        for (int j = 0; j < lines.Count; j++)
                        {

                            board.setCell(j, i, Int32.Parse(numbers[j]));
                        }
                    }


                    return board;

                }

            }
            catch
            {
                throw new BekeritesDataException();
            }
        }
        //mentes

        public void Save(String path, Board board, int id)
        {



            try
            {
                using (StreamWriter writer = new StreamWriter(path)) // fájl megnyitása
                {
                    // get the size of the table
                    int n = board.getSize();

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (id == 1 && i == 0 && j == 0)
                                writer.Write(board.getCell(j, i) + 100 + " "); // kiírjuk az értékeket
                            else if (id == 2 && i == 0 && j == 0)
                                writer.Write(board.getCell(j, i) + 200 + " ");
                            else writer.Write(board.getCell(j, i) + " ");
                            Debug.Write(board.getCell(j, i));
                        }
                        writer.WriteLine();
                        Debug.Write('\n');
                    }
                }
            }
            catch
            {
                throw new BekeritesDataException();
            }
        }



    }
}
