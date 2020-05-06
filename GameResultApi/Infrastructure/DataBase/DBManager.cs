using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using GameResultApi.Infrastructure.Request;
using System.Threading.Tasks;
using GameResultApi.Infrastructure.Response;

namespace GameResultApi.Infrastructure.DataBase
{
    public class DBManager
    {
        #region Attributes
        private static DBManager instance = null;
        SqlConnection connection = null;
        SqlDataAdapter sqlDataAdapter = null;
        #endregion

        #region Constructor
        private DBManager()
        {
            string con = "Data Source=DESKTOP-OVPU799\\MSSQLSERVER01;Initial Catalog=BackendCodingTest;Integrated Security=True";
            connection = new SqlConnection(con);
            sqlDataAdapter = new SqlDataAdapter();
        }
        public static DBManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBManager();
                }
                return instance;
            }
        }

        #endregion

        #region RegiseterUser in DB
        public async Task<bool> RegisterUserAsync(UserRQ userRQ)
        {
            try
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = userRQ.UserName
                };
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(param);

                SqlCommand cmd = await ExecuteProcdureAsync(connection, "RegisterUser", sqlParams);
                return cmd != null;
            }
            catch(Exception e)
            {
                //ExecuteNonQuery throw an exception if the insert fails for some reason.
                Console.WriteLine("Exception source: {0}", e.Source);
                return false;
            }
        }
        #endregion

        #region Report GameResult in DB for RegistedUser
        public async Task<DataTable> CheckRegistedUser(GameResultRQ gameResultRQ)
        {
            try
            {
                DataSet dataSet = new DataSet();
                DataTable table = new DataTable();
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                SqlParameter nameParam = new SqlParameter { ParameterName = "@name", SqlDbType = SqlDbType.NVarChar, Value = gameResultRQ.UserName };

                sqlParams.Add(nameParam);

                SqlCommand cmd = await ExecuteProcdureAsync(connection, "CheckUser", sqlParams);
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(dataSet);
                table = dataSet.Tables[0];
                return table;
            }
            catch(Exception e)
            {
                return null;
            }
        
        }
        public async Task<bool> AddGameResultAsync(DataTable table, GameResultRQ gameResultRQ)
        {
            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                int id = Convert.ToInt32(table.Rows[0]["ID"].ToString().Trim());
                SqlParameter idParam = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = id };
                SqlParameter scoreParam = new SqlParameter { ParameterName = "@score", SqlDbType = SqlDbType.Int, Value = gameResultRQ.Score };

                sqlParams.Add(idParam);
                sqlParams.Add(scoreParam);
                sqlDataAdapter.SelectCommand = await ExecuteProcdureAsync(connection, "StoreGameResult", sqlParams);
                return sqlDataAdapter.SelectCommand != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region GetLeaderBoard from DB
        public async Task<LeaderBoardRS> GetLeaderBoardAsync()
        {
            LeaderBoardRS response = new LeaderBoardRS();

            DataSet dataSet = new DataSet();
            DataTable table = new DataTable();
            SqlCommand cmd = await ExecuteProcdureAsync(connection, "Leaderboard");
            sqlDataAdapter.SelectCommand = cmd;
            sqlDataAdapter.Fill(dataSet);
            table = dataSet.Tables[0];
          
                foreach(DataRow row in table.Rows)
                {
                    LeaderBoardItem leaderBoardItem = new LeaderBoardItem()
                    {
                   
                        UserName = row.ItemArray[0].ToString().Trim(),
                        Score = Convert.ToInt32 (row.ItemArray[1].ToString().Trim())
                    };
                    response.leaderBoardItems.Add(leaderBoardItem);
                }
            return response;
         }
        #endregion

        #region Execute Procedure
        private async Task<SqlCommand> ExecuteProcdureAsync(SqlConnection connection, string commandText, List<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(commandText, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            if(parameters != null)
                foreach(SqlParameter param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
                }
            cmd.ExecuteNonQuery();
            connection.Close();
            return cmd;
        }
        #endregion
    }
}