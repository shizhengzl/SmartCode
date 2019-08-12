using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    public static class VisualHelper
    {
        private static Tuple<string, string, string> GetProjPath(DTE2 dte)
        { 
            var projects = (UIHierarchyItem[])dte?.ToolWindows.SolutionExplorer.SelectedItems;
            if (projects == null)
            {
                return null;

            }
            var project = projects[0];
            var item = project.Object as Project;
            var path = item?.FullName;
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;

            }
            if (!File.Exists(path))
            {
                return null;
            }

            var srcPath = item?.Properties.Item("FullPath").Value?.ToString();
            if (string.IsNullOrWhiteSpace(srcPath))
            {
                return null;

            }
            //path:.csproj全路径
            //srcPath:.csproj所在的目录
            //item.Name:项目名称
            return Tuple.Create(path, srcPath, item.Name);
        }
    }
}
