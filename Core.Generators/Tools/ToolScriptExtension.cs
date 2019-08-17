﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Tools.Migrations;
using Core.UsuallyCommon;
namespace Core.Generators
{
    public class ToolScriptExtension<T> : ToolStrip where T : class, new()
    {
        public GeneratorTools tools { get; set; }
        public PanelExtension<T> Panel { get; set; }
        public ToolScriptExtension(PanelExtension<T> panel, GeneratorTools _tools)
        {
            tools = _tools;
            Panel = panel;

            this.Dock = DockStyle.Fill;
            List<string> btn = typeof(ToolScriptButton).EnumToList();
            foreach (var item in btn)
            {
                // add button 
                ToolStripButton button = new ToolStripButton() { Text = item, Name = $"btn{item}" };
                button.Click += Button_Click;

                var btnenum = item.ToEnum<ToolScriptButton>();

                switch (btnenum)
                {
                    case ToolScriptButton.Insert:
                        button.Image = tools.imageList.Images[(int)ImageEnum.Add];
                        break;
                    case ToolScriptButton.Update:
                        button.Image = tools.imageList.Images[(int)ImageEnum.Edit];
                        break;
                    case ToolScriptButton.Delete:
                        button.Image = tools.imageList.Images[(int)ImageEnum.Remove];
                        break;
                    case ToolScriptButton.Refresh:
                        button.Image = tools.imageList.Images[(int)ImageEnum.Refresh];
                        break;
                }
                this.Items.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            var btnenum = button.Text.ToEnum<ToolScriptButton>();
            switch (btnenum)
            {
                case ToolScriptButton.Insert:
                    WindowExtension<T> windowinsert = new WindowExtension<T>(new T(), true, tools);
                    DialogResult dialoginsert = windowinsert.ShowDialog();
                    break;
                case ToolScriptButton.Update:
                    var rows = Panel.gridView.SelectedRows;
                    if (rows.Count == 0)
                    {
                        return;
                    }
                    var result = ExtenstionClass.GetList<T>(new DefaultDB()).Skip(Panel.gridView.SelectedRows[0].Index).Take(1).FirstOrDefault();
                    WindowExtension<T> windowupdate = new WindowExtension<T>(result, false, tools);
                    DialogResult dialogupdate = windowupdate.ShowDialog();
                    break;
                case ToolScriptButton.Delete:
                    DefaultDB db = new DefaultDB();
                    var resultDelete = ExtenstionClass.GetList<T>(new DefaultDB()).Skip(Panel.gridView.SelectedRows[0].Index).Take(1).FirstOrDefault();
                    DbEntityEntry entry = db.Entry<T>(resultDelete);
                    var entity = db.Set(typeof(T)).Attach(resultDelete);
                    entry.State = EntityState.Deleted;
                    db.SaveChanges();
                    break;
                case ToolScriptButton.Refresh:
                    break;
            }
            Panel.gridView.DataSource = ExtenstionClass.GetList<T>(new DefaultDB());
        }


    }
}
