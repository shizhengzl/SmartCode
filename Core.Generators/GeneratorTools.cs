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
        public GeneratorTools()
        {
            InitializeComponent();
        }

        public GeneratorTools(DTE2 dte)
        {
            InitializeComponent();
            ApplicationVsHelper._applicationObject = dte;
            var fullname = dte.Solution.FileName; 
            var projects = dte.Solution.Projects;

            List<String> listUrl = ApplicationVsHelper.GetSolutionFiles("*.cs");

            List<ClassDeclarationSyntax> classDeclarationSyntaxes = new List<ClassDeclarationSyntax>();
            DefaultDB dbContext = new DefaultDB();
            listUrl.Where(y => !y.Contains("Debug") && !y.Contains("Release")).ToList().ForEach(x =>
            {
                CsharpParser parser = new CsharpParser(x);
                var classes = parser.GetClasses();
                classes.ForEach(u =>
                {
                    var s = parser.semanticModel.GetDeclaredSymbol(u).BaseType.Name;
                    if (s == "BaseEntity")
                    {

                        var className = u.Identifier.Text;
                        var allproperty = parser.GetCsharpClassProperty(u);
                        allproperty.ForEach(o =>
                        {
                            DefaultColumn column = new DefaultColumn()
                            {
                                ColumnName = o.PropertyName,
                                ColumnDescription = o.PropertyComment,
                                CSharpType = o.PropertyType.Replace("?", string.Empty),
                                IsRequire = !(o.PropertyType.IndexOf("?") > -1),
                                MaxLength = 0
                            };
                            if(!dbContext.Columns.Any(z=>z.ColumnName == column.ColumnName && z.CSharpType == column.CSharpType))
                            {
                                dbContext.Columns.Add(column);
                                dbContext.SaveChanges();
                            }

                        });
                        //classDeclarationSyntaxes.Add(u);
                    }
                });
            });
            
        }


        private void GeneratorTools_Load(object sender, EventArgs e)
        {

        }
    }
}
