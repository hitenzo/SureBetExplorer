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
            _dbConnection = new SQLiteConnection("Data Source=C:\\sqliteDB\\sureBets.db;Version=3;");
            _dbConnection.Open();
        }

        public void Add(List<SureBetInfo> sureBets)
        {
            foreach (var singleBet in sureBets)
            {
                string sqlInsert = string.Format("insert into sureBets (matchingEvents, FirstSiteName, SecondSiteName, BetForHome, BetForDraw, BetForAway) " +
                                                 "values ({0}, {1}, {2}, {3}, {4}, {5})",
                            singleBet.MatchingEvent, singleBet.FirstSiteName, singleBet.SecondSiteName, singleBet.BetForHome, singleBet.BetForDraw, singleBet.BetForAway);
                SQLiteCommand insertCommand = new SQLiteCommand(sqlInsert, _dbConnection);
                insertCommand.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void CloseConnection()
        {
            _dbConnection.Close();
        }
    }
}
