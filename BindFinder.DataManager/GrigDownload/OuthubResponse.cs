﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BindFinder.DataManager.GrigDownload
{
    sealed class OuthubResponse
    {
        public List<string> items { get; set; }
        public int status { get; set; }
        public int dateFromSec { get; set; }
        public int dateToSec { get; set; }
        public System.DateTime Downloaded { get; set; }

        internal static async Task<OuthubResponse> GetResponse()
        {
            var contents = await WebUtils.GetResponseContentAsStringAsync(@"http://outhub.online/api/booking/GetBoardsData", "POST").ConfigureAwait(false);
            var deserialized = await Load(contents);
            deserialized.Downloaded = System.DateTime.Now;
            return deserialized;
        }            

        private static async Task<OuthubResponse> Load(string content)
        {
            var deserialized = await Task.Run(() => {

                content = content.Replace(@"\r", "");
                content = content.Replace(@"\n", "");
                OuthubResponse schema = JsonConvert.DeserializeObject<OuthubResponse>(content);
                return schema;
            });
            return deserialized;
        }
        public static async Task<OuthubResponse> LoadFromFile(string filename)
        {
            var content = await Task.Factory.StartNew(() =>
            {
                string loaded = System.IO.File.ReadAllText(filename);
                return loaded;
            }).ConfigureAwait(false);

            var deserialized = await Load(content);
            return deserialized;
        }
        public static void SaveToFile(OuthubResponse response, string filePath)
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            string dir = System.IO.Path.GetDirectoryName(filePath);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            string converted = JsonConvert.SerializeObject(response);
            System.IO.File.WriteAllText(filePath, converted);
        }
    }
}
