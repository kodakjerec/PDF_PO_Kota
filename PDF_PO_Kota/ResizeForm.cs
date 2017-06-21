using System.Windows.Forms;
using System.Drawing;
namespace ResizeForm
{
    #region 調整表單大小
    public partial class ResizeForm
    {
        private static float WidthChange = 0;
        private static float HeightChange = 0;
        private static float ChangeSize = 0;

        public static void WSC_Resize(Form form)
        {
            //將視窗所有控制項大小調整至與  螢幕  相同
            WidthChange = (float)Screen.PrimaryScreen.WorkingArea.Width / form.Width;
            HeightChange = (float)(Screen.PrimaryScreen.WorkingArea.Height) / form.Height;
            ChangeSize = (float)WidthChange > HeightChange ? HeightChange : WidthChange;
            Controls_adjust(form);
        }

        public static void WSC_Resize(Form form, short type)
        {
            //將視窗所有控制項大小調整至與  *設計大小*  相同
            WidthChange = (float)Screen.PrimaryScreen.WorkingArea.Width /800;
            HeightChange = (float)Screen.PrimaryScreen.WorkingArea.Height /600;
            ChangeSize = (float)WidthChange > HeightChange ? HeightChange : WidthChange;
            Controls_adjust(form);
        }

        public static void Controls_adjust(Form form)
        {
            form.AutoScaleMode = AutoScaleMode.None;
            form.Width = (int)(form.Width * WidthChange);
            form.Height = (int)(form.Height * HeightChange);

            foreach (Control con in form.Controls)
            {
                con.Left = (int)(con.Left * WidthChange);
                con.Width = (int)(con.Width * WidthChange);
                //超出寬度邊界的判斷
                if (con.Right > Screen.PrimaryScreen.WorkingArea.Right)
                    con.Width = Screen.PrimaryScreen.WorkingArea.Right - con.Left;
                con.Top = (int)(con.Top * HeightChange);
                con.Height = (int)(con.Height * HeightChange);
                //超出高度邊界的判斷
                if (con.Bottom > Screen.PrimaryScreen.WorkingArea.Bottom)
                    con.Height = Screen.PrimaryScreen.WorkingArea.Bottom - con.Top;
                con.Font = new Font(con.Font.Name, con.Font.Size * ChangeSize);


                //分頁大小調整
                if (con is TabControl)
                {
                    foreach (TabPage tabpage in con.Controls)
                    {
                        foreach (Control tabcontrol in tabpage.Controls)
                        {
                            tabcontrol.Left = (int)(tabcontrol.Left * WidthChange);
                            tabcontrol.Width = (int)(tabcontrol.Width * WidthChange);
                            tabcontrol.Top = (int)(tabcontrol.Top * HeightChange);
                            tabcontrol.Height = (int)(tabcontrol.Height * HeightChange);
                            tabcontrol.Font = new Font(tabcontrol.Font.Name, tabcontrol.Font.Size * ChangeSize);
                        }
                    }
                }
                //DataGridView調整
                else if (con is DataGridView)
                {
                    foreach (DataGridViewColumn dvc in ((DataGridView)con).Columns)
                    {
                        if (dvc.DefaultCellStyle.Font == null)
                            dvc.DefaultCellStyle.Font = new Font("新細明體", 12);
                        dvc.DefaultCellStyle.Font = new Font(dvc.DefaultCellStyle.Font.Name, dvc.DefaultCellStyle.Font.Size * ChangeSize);

                    }
                }
            }
        }
    }
    #endregion
}