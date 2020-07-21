using Core.Tools;
using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;
using Core.Tools.Migrations;

namespace Core.Generators
{
    public partial class GeneratorTools : Form
    {
        //public GeneratorTools()
        //{
        //    InitializeComponent();
        //    //InitSystemConfig();
        //}

        #region SystemConfig

        public void InitSystemConfig()
        {
            InitClass<DefaultColumn>();
            InitClass<DataBaseAddress>();
            InitClass<SQLConfig>(); 
            InitClass<DataTypeConfig>();
             
        }

        public void InitClass<T>() where T : class, new()
        {
            var type = typeof(T);
            var className = type.Name;
            TabPage tpclass = new TabPage() { Name = className, Text = className };

            PanelExtension<T> panel = new PanelExtension<T>(this);
            tpclass.Controls.Add(panel);
            tabsettings.TabPages.Add(tpclass);
        }
        #endregion 

        public GeneratorTools()//DTE2 dte , MenuStatus menuStatus)
        {
            InitializeComponent();
        //    ApplicationVsHelper._applicationObject = dte;
        //    InitSystemConfig();
        //    var fullname = dte.Solution.FileName;
        //    var projects = dte.Solution.Projects;

        //    List<String> listUrl = ApplicationVsHelper.GetSolutionFiles("*.cs");
             List<String> listUrl = new List<string>();
            Core.UsuallyCommon.FileExtenstion.GetFileByExtension(@"D:\workcode\emps\trunk\Entity","*.cs",ref listUrl);

            List<String> ClassNames = new List<string>();
            List<DefaultColumn> defaultColumns = new List<DefaultColumn>();
            //List<ClassDeclarationSyntax> classDeclarationSyntaxes = new List<ClassDeclarationSyntax>();
            DefaultDB dbContext = new DefaultDB();

            listUrl.ForEach(x =>
            {
                CsharpParser parser = new CsharpParser(x);
                var classes = parser.GetClasses();
                classes.ForEach(u =>
                {
                    //var s = parser.semanticModel.GetDeclaredSymbol(u).BaseType.Name;
                    //if (s == "BaseEntity")
                    //{ 
                        var className = u.Identifier.Text;
                        if(!ClassNames.Contains(className)) 
                        {
                            ClassNames.Add(className);
                        }

                        var classcomment = CsharpParser.GetClassComment(u);

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
                                Table  = o.Table,
                                TableDescription = classcomment
                            };

                            defaultColumns.Add(column);
                            //if (!dbContext.DefaultColumns.Any(z => z.ColumnName == column.ColumnName && z.CSharpType == column.CSharpType && z.Table == column.Table))
                            //{
                            //    dbContext.DefaultColumns.Add(column);
                            //    dbContext.SaveChanges();
                            //} 
                        }); 
                   // }
                });
            });
            var rs = defaultColumns.Where(o => o.ColumnDescription.Length > 0);
        }


        private void GeneratorTools_Load(object sender, EventArgs e)
        {

        }
    }
}
