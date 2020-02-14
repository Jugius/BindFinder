using Ookii.Dialogs;
using System.ComponentModel;

namespace BindFinder.DataManager
{
    interface IProcessor
    {
        void StartProcess(ProgressDialog dialog, DoWorkEventArgs e);
    }
}
