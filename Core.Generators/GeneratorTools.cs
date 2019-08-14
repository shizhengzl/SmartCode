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

            listUrl.ForEach(x => {
                CsharpParser parser = new CsharpParser(x);
                var cs = parser.GetClasses();
            });


           
        }


    



        private void GeneratorTools_Load(object sender, EventArgs e)
        {

        }
    }
}
