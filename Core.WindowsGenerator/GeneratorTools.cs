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

namespace Core.WindowsGenerator
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
            HasDte = true;
            _dte = dte;
        }

        /// <summary>
        /// 是否有DTE
        /// </summary>
        public bool HasDte { get; set; } = false;
        /// <summary>
        /// DTE 对象
        /// </summary>
        public DTE2 _dte { get; set; }
    }
}
