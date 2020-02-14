using BindFinder.AppModels.Boards;
using System;
using System.Collections.Generic;

namespace BindFinder.AppModels.DataReaders
{
    public delegate void DataReadCompletedEventHandler(BoardsReadCompletedEventArgs e);
    public interface IBoardsReader
    {
        List<IBoard> Boards { get; }
        IEnumerable<IBoard> ReadData();
        void ReadDataAsync();
        event DataReadCompletedEventHandler DataReadCompleted;
    }    
}
