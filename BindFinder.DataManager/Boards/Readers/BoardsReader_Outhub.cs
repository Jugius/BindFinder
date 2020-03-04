using BindFinder.AppModels.Boards;
using BindFinder.DataManager.GrigDownload;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindFinder.DataManager.Boards.Readers
{
    sealed class BoardsReader_Outhub : BoardsReader
    {
        private OuthubResponse Response;
        public string FilePath { get; set; }
        public bool DownloadGrid { get; set; }
        public override IEnumerable<IBoard> ReadData()
        {
            var response = GetResponseAsync().GetAwaiter().GetResult();
            var boards = response.items.Select(a => new Board_Outhub(a));
            return boards;
        }
        private async Task<OuthubResponse> GetResponseAsync()
        {
            if (this.Response == null)
            {
                var result = await LoadResponse().ConfigureAwait(false);
                this.Response = result;
            }
            return this.Response;
        }
        private async Task<OuthubResponse> LoadResponse()
        {
            OuthubResponse response;
            if (this.DownloadGrid)
            {
                response = await OuthubResponse.GetResponse().ConfigureAwait(false);
                await Task.Run(() => { OuthubResponse.SaveToFile(response, this.FilePath); });                
            }
            else
            {
                response = await OuthubResponse.LoadFromFile(this.FilePath).ConfigureAwait(false);
            }
            return response;
        }
        

    }
}
