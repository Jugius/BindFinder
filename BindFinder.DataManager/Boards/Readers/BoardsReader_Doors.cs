using System.Collections.Generic;
using System.Data.OleDb;
using BindFinder.AppModels.Boards;
using System.Linq;


namespace BindFinder.DataManager.Boards.Readers
{
    class BoardsReader_Doors : BoardsReader
    {
        public string ConnectionString { get; set; }
        public string Year { get; set; }
        public override IEnumerable<IBoard> ReadData()
        {
            DBSet.NosDataTableDataTable table = new DBSet.NosDataTableDataTable();
            string dbName = $"_{Year}nos";            

            string query = $"SELECT {dbName}.city, {dbName}.type, {dbName}.owner AS Supplier, {dbName}.snjt AS Deleted, {dbName}.x AS Longitude, {dbName}.y AS Latitude, {dbName}.streets AS Street, {dbName}.house AS StreetNumber, {dbName}.looc AS Description, " +
                           $"{dbName}.number AS Code, {dbName}.ots, {dbName}.ndex AS GRP, {dbName}.dix AS ID, {dbName}.storona AS Side, {dbName}.`size`, {dbName}.d_id, {dbName}.lighting, cities.short_nam AS CityShort " +
                           $"FROM _{Year}nos, cities " +
                           $"WHERE _{Year}nos.n_city = cities.id_city";     

            using (var con = new OleDbConnection(ConnectionString))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand(query, con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(table);
                con.Close();
            }
            
            var boards = table.Where(a => !a.deleted).Select(a => new Board_Doors(a)).Where(a => !string.IsNullOrEmpty(a.Address.Street)).DistinctBy(a => a.ID);
            return boards;            
        }
    }
}
