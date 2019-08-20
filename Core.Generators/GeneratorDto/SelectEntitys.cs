using Core.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.UsuallyCommon;
using Core.Tools.Migrations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using EnvDTE80;

namespace Core.Generators
{
    public partial class SelectEntitys : Form
    {
        public SelectEntitys()
        {
            InitializeComponent();
        }
        List<String> listUrl = new List<string>();


        public class CsharpClass
        {
            public string Name { get; set; }

            public string Comment { get; set; }
        }
        public SelectEntitys(DTE2 dte)
        {
            InitializeComponent();

            DataGridViewCheckBoxColumn dtCheck = new DataGridViewCheckBoxColumn();
            dtCheck.DataPropertyName = "check";
            dtCheck.HeaderText = "";
            dataGridViewColumns.Columns.Add(dtCheck); 

            ApplicationVsHelper._applicationObject = dte;


             listUrl = ApplicationVsHelper.GetSolutionFiles("*.cs");
            this.ActiveControl = this.txtSearch;
            txtSearch.SelectAll();
            txtSearch.Focus();
        }

        List<DefaultColumn> _columns = new List<DefaultColumn>();

        List<DefaultColumn> _response = new List<DefaultColumn>();

    

        private void treedto_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridViewColumns.EndEdit();
            var selects = dataGridViewColumns.Rows.Count;
            StringBuilder propertys = new StringBuilder();

            string replsceproperty = @"/// <summary>
        /// @ColumnDescription
        /// </summary>
        public @CsharpType @ColumnName;";
            for (int i = 0; i < selects; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridViewColumns.Rows[i].Cells[0];

                if (checkCell.Value.ToBoolean())
                {
                    var col = selectColumns.Skip(i).Take(1).FirstOrDefault(); //selectColumns.Skip(i).Take(1).FirstOrDefault();
                    _response.Add(col);
                    propertys.AppendLine("/// <summary>");
                    propertys.AppendLine($"///{col.ColumnDescription}");
                    propertys.AppendLine("/// </summary>");
                    propertys.AppendLine($"public {col.CSharpType} {col.ColumnName}{{get;set;}};");
                }
                    
            } 

            string response = @"using System;
using System.Collections.Generic;
using System.Text;

namespace Zeus.Entity
{
    /// <summary>
    ///  @ClassDescription
    /// </summary>
    public class @ClassName : BaseDto
    { 
         @Propertys
    }
}
";
            response = response.Replace("@ClassDescription", treedto.SelectedNode.ToolTipText);
            response = response.Replace("@ClassName", txtClassName.Text.Trim().Replace(".cs",string.Empty));
            response = response.Replace("@Propertys", propertys.ToString());
             
            string path = ApplicationVsHelper._applicationObject.SelectedItems.Item(1).ProjectItem.FileNames[0] + txtClassName.Text.Trim();
            FileExtenstion.WriteText(path, response);


            MessageBox.Show($"生成成功,路劲:{path}");
            this.Close();

        }


        List<DefaultColumn> selectColumns = new List<DefaultColumn>();

        private void treedto_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var className = treedto.SelectedNode.Text;
            txtClassName.Text = className.Replace("Entity", string.Empty) + "Dto.cs";
            selectColumns = _columns.Where(x => x.Table == className).ToList();
           
            dataGridViewColumns.DataSource = selectColumns;

            for (int i = 0; i < selectColumns.Count; i++)
            {
                dataGridViewColumns.Rows[i].Cells[0].Value = true;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(!string.IsNullOrEmpty(txtSearch.Text))
                {
                    var classnames = txtSearch.Text.Trim();
                    treedto.Nodes.Clear();
                     
                    List<CsharpClass> ClassNames = new List<CsharpClass>(); 
                    DefaultDB dbContext = new DefaultDB(); 
                    listUrl.Where(y => !y.Contains("Debug") && !y.Contains("Release")).ToList().ForEach(x =>
                    {
                        CsharpParser parser = new CsharpParser(x);
                        var classes = parser.GetClasses();

                        foreach (var u in classes)
                        {

                            var s = parser.semanticModel.GetDeclaredSymbol(u).BaseType.Name;
                            var className = u.Identifier.Text;
                            if (className == classnames)
                            {

                                var classcomment = CsharpParser.GetClassComment(u);
                                if (!ClassNames.Any(z => z.Name == className))
                                {
                                    ClassNames.Add(new CsharpClass() { Name = className, Comment = classcomment });
                                }

                                var allproperty = parser.GetCsharpClassProperty(u);
                                allproperty.ForEach(o =>
                                {
                                    DefaultColumn column = new DefaultColumn()
                                    {
                                        ColumnName = o.PropertyName,
                                        ColumnDescription = o.PropertyComment,
                                        CSharpType = o.PropertyType.Replace("?", string.Empty),
                                        IsRequire = !(o.PropertyType.IndexOf("?") > -1),
                                        MaxLength = o.MaxLength,
                                        Table = o.Table
                                    };

                                    _columns.Add(column);
                                    if (!dbContext.DefaultColumns.Any(z => z.ColumnName == column.ColumnName && z.CSharpType == column.CSharpType && z.Table == column.Table))
                                    {
                                        dbContext.DefaultColumns.Add(column);
                                        dbContext.SaveChanges();
                                    }
                                });

                                break;
                            } 
                        } 
                    });

                    ClassNames.OrderBy(o => o.Name).ToList().ForEach(x =>
                    {
                        TreeNode node = new TreeNode() { Name = x.Name, Text = x.Name, ToolTipText = x.Comment };
                        treedto.Nodes.Add(node);
                    });
                }
            }
        }
    }
}
