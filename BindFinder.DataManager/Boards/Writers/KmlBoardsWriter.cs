using System;
using System.Collections.Generic;
using System.ComponentModel;
using BindFinder.AppModels.Boards;
using Ookii.Dialogs;

namespace BindFinder.DataManager.Boards.Writers
{
    sealed class KmlBoardsWriter : IProcessor
    {
        private readonly List<IBoard> boards;
        private readonly string path;

        public KmlBoardsWriter(List<IBoard> boards, string kmlPath)
        {
            this.boards = boards;
            this.path = kmlPath;
        }
        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
