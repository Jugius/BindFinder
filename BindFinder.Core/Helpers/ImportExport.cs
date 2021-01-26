using Newtonsoft.Json;
using OutOfHome.Models.Binds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BindFinder.Helpers
{
    internal static class ImportExport
    {
        public static Task SaveBindsToFile(IEnumerable<Bind> binds, string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            
            return ext.ToLower() switch
            {
                ".xlsx" => SaveBindsToXls(binds, fileName),
                ".json" => SaveBindsToJson(binds, fileName),
                ".kmz" => SaveBindsToGoogle(binds, fileName),
                _ => throw new Exception($"Не поддерживается расширение файла {ext}")
            };
        }
        private static Task SaveBindsToJson(IEnumerable<Bind> binds, string fileName)
        {
            if(System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);

            return Task.Run(() => 
            {
                string serialized = Newtonsoft.Json.JsonConvert.SerializeObject(binds, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings {  TypeNameHandling = TypeNameHandling.Auto });
                File.WriteAllText(fileName, serialized);
            });
        }
        private static async Task SaveBindsToXls(IEnumerable<Bind> binds, string fileName)
        {
            var file = new OutOfHome.Exports.Excel.DocumentModels.ExcelFileInfo
            {
                FilePath = fileName,
                SheetSchema = new OutOfHome.Exports.Excel.DocumentModels.SheetSchema
                {
                    TableColumns = OutOfHome.Exports.Excel.DocumentModels.BindExcelField.GetDefaultColumns()
                }
            };
            await OutOfHome.Exports.Excel.ExportBinds.Export(binds.ToList(), file).ConfigureAwait(false);
            Process.Start(new ProcessStartInfo { FileName = fileName, UseShellExecute = true });
        }
        private static Task SaveBindsToGoogle(IEnumerable<Bind> binds, string fileName)
        {
            throw new NotImplementedException();
        }

        internal static Task<IEnumerable<Bind>> OpenBindsFromFile(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName).ToLower();

            return ext.ToLower() switch
            {
                ".xlsx" => OpenBindsFromXls(fileName),
                ".json" => OpenBindsFromJson(fileName),               
                _ => throw new Exception($"Не поддерживается расширение файла {ext}")
            };
        }
        private static Task<IEnumerable<Bind>> OpenBindsFromXls(string fileName)
        {
            var file = new OutOfHome.Imports.Excel.Models.ExcelFileInfo
            {
                Columns = OutOfHome.Imports.BindPropertySetter.GetDefaultColumns(),
                FilePath = fileName
            };
            return OutOfHome.Imports.Excel.Import.ImportBinds(file);
        }
        private static Task<IEnumerable<Bind>> OpenBindsFromJson(string fileName)
        {
            return Task.Run(() => {
                string content = File.ReadAllText(fileName);
                var serialized = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Bind>>(content);
                return serialized;
            });
        }
    }
}
