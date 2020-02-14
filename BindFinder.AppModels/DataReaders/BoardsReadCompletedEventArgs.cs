using BindFinder.AppModels.Boards;
using System;
using System.Collections.Generic;

namespace BindFinder.AppModels.DataReaders
{
    public class BoardsReadCompletedEventArgs
    {
        public Exception Error { get; }
        public List<IBoard> Result { get; }
        public BoardsReadCompletedEventArgs(Exception error) { this.Error = error; }
        public BoardsReadCompletedEventArgs(List<IBoard> result) { this.Result = result; }
    }
}
