using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SureBetExplorer
{
    public class SureBetRepository : IRepository
    {
        private SQLiteConnection _dbConnection;

        public SureBetRepository()
        {
            SQLiteConnection.CreateFile("C:\\sqliteDB\\sureBetDb\\sureBets.db");
            _dbConnection = new SQLiteConnection("Data Source=C:\\sqliteDB\\sureBetDb\\sureBets.db;Version=3;");
            _dbConnection.Open();

            _dbConnection.Close();
        }

        public void Add(SureBetInfo sureBet)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
