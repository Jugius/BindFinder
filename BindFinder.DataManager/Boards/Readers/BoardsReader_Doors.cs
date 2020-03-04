using System.Collections.Generic;
using System.Data.OleDb;
using BindFinder.AppModels.Boards;
using System.Linq;
using System.Threading.Tasks;

namespace BindFinder.DataManager.Boards.Readers
{
    sealed class BoardsReader_Doors : BoardsReader
    {
        private DBSet.NosDataTableDataTable DataTable;
        public string ConnectionString { get; set; }
        public string Year { get; set; }
        public override IEnumerable<IBoard> ReadData()
        {
            DBSet.NosDataTableDataTable table = GetTableAsync().GetAwaiter().GetResult();
            
            var boards = table.Where(a => !a.deleted).Select(a => new Board_Doors(a)).Where(a => !string.IsNullOrEmpty(a.Address.Street)).DistinctBy(a => a.ID);
            return boards;
        }
        private async Task<DBSet.NosDataTableDataTable> GetFilledTableAsync()
        {
            string dbName = $"_{Year}nos";

            string query = $"SELECT {dbName}.city, {dbName}.type, {dbName}.owner AS Supplier, {dbName}.snjt AS Deleted, {dbName}.x AS Longitude, {dbName}.y AS Latitude, {dbName}.streets AS Street, {dbName}.house AS StreetNumber, {dbName}.looc AS Description, " +
                           $"{dbName}.number AS Code, {dbName}.ots, {dbName}.ndex AS GRP, {dbName}.dix AS ID, {dbName}.storona AS Side, {dbName}.`size`, {dbName}.d_id, {dbName}.lighting, cities.short_nam AS CityShort " +
                           $"FROM _{Year}nos, cities " +
                           $"WHERE _{Year}nos.n_city = cities.id_city";

            DBSet.NosDataTableDataTable result = await Task.Run(() =>
            {
                DBSet.NosDataTableDataTable table = new DBSet.NosDataTableDataTable();
                using (var con = new OleDbConnection(ConnectionString))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(table);
                    con.Close();
                }
                return table;
            }).ConfigureAwait(false);
            return result;
        }

        private async Task<DBSet.NosDataTableDataTable> GetTableAsync()
        {
            if (this.DataTable == null || this.DataTable.Count == 0)
            {
                var result = await GetFilledTableAsync().ConfigureAwait(false);
                this.DataTable = result;
            }
            return this.DataTable;
        }
    }
}
