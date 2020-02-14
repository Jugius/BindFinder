using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindFinder.AppModels.Boards;
using BindFinder.AppModels.DataReaders;

namespace BindFinder.DataManager.Boards.Readers
{
    internal abstract class BoardsReader : IBoardsReader
    {        
        public List<IBoard> Boards { get; private set; }
        public event AppModels.DataReaders.DataReadCompletedEventHandler DataReadCompleted;
        public abstract IEnumerable<IBoard> ReadData();
        public async void ReadDataAsync()
        {
            BoardsReadCompletedEventArgs args = await Task<BoardsReadCompletedEventArgs>.Factory.StartNew(() =>
            {
                try
                {
                    List<IBoard> list = ReadData().ToList();
                    return new BoardsReadCompletedEventArgs(list);
                }
                catch (Exception ex)
                {
                    return new BoardsReadCompletedEventArgs(ex);
                }
            });

            if (args.Error == null)
            {
                this.Boards = args.Result;
            }

            DataReadCompleted?.Invoke(args);
        }
    }
}
