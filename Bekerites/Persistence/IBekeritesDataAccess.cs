using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BekeritesPersistence
{
    public interface IBekeritesDataAccess
    {
        Board Load(String path);
        void Save(string path, Board board, int id);
    }
}
