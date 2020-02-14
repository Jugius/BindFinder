using BindFinder.AppModels.Binds;
using BindFinder.AppModels.Boards;
using BindFinder.AppModels.DataReaders;
using BindFinder.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BindFinder
{
    public partial class BoardsView : Form
    {
        private const float picScale = 4 / (float)3;
        public BoardsView()
        {
            InitializeComponent();
            InitializeObjectListView();
            this.Icon = Properties.Resources.Billboard_Icon;
        }

        private void InitializeObjectListView()
        {
            string boardState = Properties.Settings.Default.olvBoardsState;
            if (!string.IsNullOrEmpty(boardState))
            {
                try
                {
                    byte[] array = System.Convert.FromBase64String(Properties.Settings.Default.olvBoardsState);
                    olvBoards.RestoreState(array);
                }
                catch
                {
                    Properties.Settings.Default.olvBoardsState = null;
                }
            }
            string bindsState = Properties.Settings.Default.olvBindsState;
            if (!string.IsNullOrEmpty(bindsState))
            {
                try
                {
                    byte[] array = System.Convert.FromBase64String(Properties.Settings.Default.olvBindsState);
                    olvBinds.RestoreState(array);
                }
                catch
                {
                    Properties.Settings.Default.olvBindsState = null;
                }
            }

            olvColumn_Code.AspectGetter = delegate (object row) { return ((IBoard)row).Code; };
            olvColumn_GRP.AspectGetter = delegate (object row) { return (row as IBoard).Metrics.GRP; };
            olvColumn_ID.AspectGetter = delegate (object row) { return (row as IBoard).ID; };
            olvColumn_Light.AspectGetter = delegate (object row) { return (row as IBoard).Lighting ? "+" : null; };
            olvColumn_OTS.AspectGetter = delegate (object row) { return (row as IBoard).Metrics.OTS; };
            olvColumn_Side.AspectGetter = delegate (object row) { return (row as IBoard).Side; };
            olvColumn_Size.AspectGetter = delegate (object row) { return (row as IBoard).Size; };
            olvColumn_Street.AspectGetter = delegate (object row) { return (row as IBoard).Address.Street; };
            olvColumn_StreetNumber.AspectGetter = delegate (object row) { return (row as IBoard).Address.StreetNumber; };
            olvColumn_Supplier.AspectGetter = delegate (object row) { return (row as IBoard).Supplier; };
            olvColumn_Type.AspectGetter = delegate (object row) { return (row as IBoard).Type; };
            olvColumn_BindName.AspectGetter = delegate (object row) { return (row as Bind).Address.FormattedAddress; };
            olvColumn_BindDescription.AspectGetter = delegate (object row) { return (row as Bind).Description; };
            olvColumn_BindBoards.AspectGetter = delegate (object row)
            {
                int count = (row as Bind).BindedBoards.Count;
                if (count == 0) return null;
                return count;
            };
            olvBoards.BooleanCheckStateGetter = delegate (object row) { return (row as IBoard).IsChecked; };
            olvBoards.BooleanCheckStatePutter = delegate (object row, bool newValue) {
                (row as IBoard).IsChecked = newValue;
                return newValue; // return the value that you want the control to use
            };
            PanBoardInfo_Resize(null, null);
        }
        public void SetBoards(List<IBoard> boards)
        {
            if (olvBoards.Objects == null || olvBoards.GetItemCount() == 0)
                olvBoards.SetObjects(boards);
            else
                olvBoards.AddObjects(boards);
        }
        public void SetBinds(List<Bind> binds)
        {
            Helpers.ColorHelper.SetColors(binds);
            if (olvBinds.Objects == null || olvBinds.GetItemCount() == 0)
                olvBinds.SetObjects(binds);
            else
                olvBinds.AddObjects(binds);
        }

        private void OlvBoards_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            int cout = olvBoards.GetItemCount();
            lblBoardsCount.Text = cout > 0 ? ("Кол-во плоскостей: " + cout) : null;
        }
        private void PanBoardInfo_Resize(object sender, System.EventArgs e)
        {
            int newW = (int)((panBoardInfo.Height - 20) / 2.5);
            if (newW > panBoardInfo.Width) newW = panBoardInfo.Width;
            picturePhoto.Height = pictureSchema.Height = (int)(newW / picScale);
            pictureMap.Height = pictureMap.Width = picturePhoto.Width = pictureSchema.Width = newW;
        }

        private void OlvBoards_SelectionChanged(object sender, System.EventArgs e)
        {
            picturePhoto.Image = pictureSchema.Image = pictureMap.Image = null;
            if (olvBoards.SelectedObject == null) return;
            IBoard brd = olvBoards.SelectedObject as IBoard;
            Bind bind = olvBinds.SelectedObject as Bind;
            picturePhoto.LoadAsync(brd.URL_Photo);
            pictureSchema.LoadAsync(brd.URL_Map);

            if (string.IsNullOrEmpty(Helpers.GeocoderHelper.GoogleAPIKey)) return;
            var stMap = new Geocoding.Google.GoogleStaticMap(Helpers.GeocoderHelper.GoogleAPIKey) { Scale = 2, Zoom = 0 };
            stMap.Language = Helpers.GeocoderHelper.QueryLanguage;
            var markers = new Geocoding.Google.GoogleMarker[]
            {
                new Geocoding.Google.GoogleMarker(brd.Location),
                new Geocoding.Google.GoogleMarker(bind.Address.Coordinates) { Color = Geocoding.Google.GoogleMarker.MarkerColor.orange }
            };
            var uri = stMap.BuildUri(markers);
            pictureMap.Image = Helpers.ImageHelper.GetImage(uri);


        }
        private void BoardsView_FormClosing(object sender, FormClosingEventArgs e)
        {            
            Properties.Settings.Default.olvBoardsState = System.Convert.ToBase64String(olvBoards.SaveState());
            Properties.Settings.Default.olvBindsState = System.Convert.ToBase64String(olvBinds.SaveState());
        }

        private void OlvBinds_SelectionChanged(object sender, System.EventArgs e)
        {
            if (olvBinds.SelectedObject == null)
                RefreshBoards(null);
            else
                RefreshBoards((Bind)olvBinds.SelectedObject);
        }
        private void RefreshBoards(Bind bind)
        {
            if (bind == null)
            {
                olvBoards.ClearObjects();
                return;
            }

            List<IBoard> boards = bind.BindedBoards;
            if (bind.BindedBoards.Count>0)
            {
                boards.Sort((a, b) => a.Address.Street.CompareTo(b.Address.Street));
                olvBoards.SetObjects(boards);
            }
            else
            {
                RefreshBoards(null);
            }
        }
        private void MnuSearchDoors_Click(object sender, System.EventArgs e)
        {
            double dist;
            if (!double.TryParse(txtDistance.Text, out dist))
            {
                MessageBox.Show("Ошибка чтения ячейки с дистанцией.", "Дистанция поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dist > 2000 || dist < 1)
            {
                MessageBox.Show("Дистанция поиска может быть в диапазоне 1-2000 метров. Исправьте и повторите.", "Дистанция поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dist /= 1000;

            var binds = olvBinds.CollectCheckedObjects<Bind>(ObjectListViewHelper.ObjectListViewCollector.All);

            if (binds.Count == 0)
            {
                MessageBox.Show("Список привязок пуст. Необходимо загрузить привязки, прежде чем искать плоскости.", "Список привязок пуст", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IBoardsReader reader = Helpers.DoorsHelper.GetDataReader(true);

            if (reader == null) return;
            List<IBoard> boards;

            if (reader.Boards == null || reader.Boards.Count == 0)
            {
                try
                {
                    boards = reader.ReadData().ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Ошибка чтения базы Infopanel:\n" + ex.Message, "Ошибка подключения к базе", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                boards = reader.Boards;
            }                                  

            binds = binds.UpdateBoards(boards, dist).ToList();
            olvBinds.UpdateObjects(binds);
            OlvBinds_SelectionChanged(null, null);

            //foreach (var bind in binds)
            //{
            //    if (bind.Error == null)
            //    {
            //        bind.BindedBoards = new List<IBoard>();
            //        foreach (var board in boards)
            //        {
            //            var distance = bind.Address.Coordinates.DistanceBetween(board.Location, DistanceUnits.Kilometers);
            //            if (distance.Value <= dist)
            //            {                            
            //                bind.BindedBoards.Add(board);
            //            }
            //        }
            //        olvBinds.UpdateObject(bind);
            //    }
            //}
        }

        private void OlvBoards_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (olvBinds.SelectedObject == null) return;
                Bind bind = olvBinds.SelectedObject as Bind;

                if (olvBoards.SelectedObjects == null)
                {
                    if (olvBoards.SelectedObject == null) return;

                    IBoard brd = olvBoards.SelectedObject as IBoard;                   

                    bind.BindedBoards.Remove(brd);
                    olvBoards.RemoveObject(brd);
                    olvBinds.UpdateObject(bind);
                }
                else
                {
                    foreach (var obj in olvBoards.SelectedObjects)
                    {
                        bind.BindedBoards.Remove(obj as IBoard);
                    }
                    olvBoards.RemoveObjects(olvBoards.SelectedObjects);
                    olvBinds.UpdateObject(bind);
                }
            }
        }

        private void MnuExportExcel_Click(object sender, System.EventArgs e)
        {
            if (olvBinds.Objects == null || olvBinds.GetItemCount() == 0)
                return;
            List<Bind> binds = new List<Bind>();
            foreach (var item in olvBinds.Objects)
            {
                binds.Add(item as Bind);
            }

            if (binds.SelectMany(a => a.BindedBoards).Count() == 0)
            {
                MessageBox.Show("Нет плоскостей в этих привязках.", "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (binds.SelectMany(a => a.BindedBoards).Where(a => a.IsChecked).Count() == 0)
            {
                MessageBox.Show("Нет отмеченных плоскостей.", "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                

            var dialog = new DataManager.Boards.Writers.WriterBuilder().Build(binds);
            dialog.RunWorkerCompleted += new RunWorkerCompletedEventHandler((object s, System.ComponentModel.RunWorkerCompletedEventArgs a) => 
            {
                if (a.Error != null)
                    MessageBox.Show(a.Error.Message, "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            dialog.ShowDialog(this);
        }
        private void MnuCheckWithID_Click(object sender, System.EventArgs e)
        {
            var lines = Dialogs.Helper.GetBoardsIDs();
            if (lines == null || lines.Length == 0) return;
            HashSet<string> stringHash = new HashSet<string>(lines.Where(a => !string.IsNullOrEmpty(a)).Distinct());           

            foreach (var obj in olvBinds.Objects)
            {
                Bind bind = obj as Bind;
                foreach (var board in bind.BindedBoards)
                {
                    if (stringHash.Contains(board.ID) || stringHash.Contains(board.Code))
                        board.IsChecked = true;
                }
            }
        }

        private void MnuCheckAll_Click(object sender, System.EventArgs e)
        {
            string message = "Будут отмечены все плоскости во всех привязках. Продолжить?";
            if (MessageBox.Show(message, "Выделение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            foreach (var obj in olvBinds.Objects)
                foreach (var board in (obj as Bind).BindedBoards)
                    board.IsChecked = true;
        }

        private void MnuUncheckAll_Click(object sender, System.EventArgs e)
        {
            string message = "Будут сняты отметки для всех плоскостей во всех привязках. Продолжить?";
            if (MessageBox.Show(message, "Выделение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            foreach (var obj in olvBinds.Objects)
                foreach (var board in (obj as Bind).BindedBoards)
                    board.IsChecked = false;
        }

        private void OlvBinds_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.ColumnIndex == this.olvColumnBindColor.Index)
            {
                Bind bind = (Bind)e.Model;
                if (bind.Color != Color.Empty)
                    e.SubItem.BackColor = bind.Color;
            }
        }

        private void MnuBindColor_Click(object sender, System.EventArgs e)
        {
            if (olvBinds.SelectedObject == null) return;
            Bind bind = olvBinds.SelectedObject as Bind;

            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = bind.Color;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    bind.Color = dlg.Color;
                    olvBinds.UpdateObject(bind);
                }
            }
        }

        private void OlvBoards_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {            
            if ((e.Model as IBoard).IsChecked)
                e.Item.ForeColor = Color.Red;
        }
        private void MnuRemoveAllUncheckedBoards_Click(object sender, System.EventArgs e)
        {
            var binds = olvBinds.CollectCheckedObjects<Bind>(ObjectListViewHelper.ObjectListViewCollector.All);
            foreach (var bind in binds)
            {
                bind.BindedBoards = bind.BindedBoards.Where(a => a.IsChecked).ToList();
                olvBinds.UpdateObject(bind);
            }
            OlvBinds_SelectionChanged(null, null);
        }
        private void MnuRemoveAllEmptyBinds_Click(object sender, System.EventArgs e)
        {
            var binds = olvBinds.CollectCheckedObjects<Bind>(ObjectListViewHelper.ObjectListViewCollector.All)
                .Where(a => a.BindedBoards.Where(b => b.IsChecked).Count() < 1).ToList();
            olvBinds.RemoveObjects(binds);
            //foreach (var bind in binds)
            //    if (bind.BindedBoards.Where(a => a.IsChecked).Count() < 1)
            //        olvBinds.RemoveObject(bind);
        }

        private void PictureBox_DoubleClick(object sender, System.EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.Image == null) return;

            string description = string.Empty;

            if (pic.Name != "pictureMap")
            {
                description = (olvBoards.SelectedObject as IBoard).Address.FormattedAddress;
            }

            using (Ookii.Dialogs.ImageViewDialog dlg = new Ookii.Dialogs.ImageViewDialog())
            {
                dlg.Image = pic.Image;
                dlg.WindowTitle = dlg.Content = description;
                dlg.ShowDialog(this);
            }
        }
     
    }
}
