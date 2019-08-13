

using EnvDTE80;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public GeneratorTools(DTE2 _dte)
        {
            dte = _dte;
            InitializeComponent();
        }

        public DTE2 dte { get; set; }



    }
}
