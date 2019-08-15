using Core.Tools;
using Core.Tools.Migrations; 
using Core.UsuallyCommon;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
namespace Core.ConsoleLogs
{
    class Program
    {
        static void Main(string[] args)
        {

            //InitDataBaseHelper initDataBaseHelper = new InitDataBaseHelper();

            //DefaultDB dbContext = new DefaultDB();
            //var dbaddressre = dbContext.DataBaseAddresses.ToList();
            //foreach (var item in dbaddressre)
            //{
            //    initDataBaseHelper.InitDataBase(item);


            //    if(item.DataBases.Count > 0)
            //    {
            //        foreach (var database in item.DataBases)
            //        {
            //            initDataBaseHelper.InitTable(database);


            //            if(database.Tables.Count > 0)
            //            {
            //                var firsttable = database.Tables.FirstOrDefault();
            //                initDataBaseHelper.InitColumn(firsttable);


                          
            //                var b =  firsttable;
                             
            //            }
            //        }
            //    }
            //} 
            const string csFile = @"E:\work\Yunshu\src\01_DataAccess\Zeus.Entity\Zeus\Entity\DepartmentVend.cs";

            CsharpParser csharpHelper = new CsharpParser(csFile);
            var classes = csharpHelper.GetClasses().FirstOrDefault();
            var res = csharpHelper.GetCsharpClassProperty(classes);

            //csharpHelper.ReplaceProperty(classes, res.Where(x => x.PropertyName == "Remark").FirstOrDefault(),
            //     new CsharpProperty() { PropertyComment = "HHH", PropertyName = "TDOks", PropertyType = "Int32 ?" }
            //    ); 
            //csFile.WriteText(csharpHelper.roots.ToFullString());
            return;
            var text = csFile.GetFileContext();
            // Parse .cs file using Roslyn SyntaxTree
            var syntaxTree = CSharpSyntaxTree.ParseText(text);
            var root = syntaxTree.GetRoot();
            // Get the first class from the syntax tree

            // get all class
            var allClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            // find class
            var myClass = allClass.FirstOrDefault(x => x.Identifier.ToString() == "ClassDemo");

            //var myClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();

            // Create a new property : 'public bool MyProperty { get; set; }'

           var propertys =  myClass.DescendantNodes().OfType<PropertyDeclarationSyntax>().ToList();

            propertys.ForEach(x => {
                Console.WriteLine($"Value:{x.Identifier.Value} Text:{x.Identifier.Text}");
            });
            // Add the new property to the class
           // var updatedClass = myClass.AddMembers(Csharp);
            //Update the SyntaxTree and normalize whitespace
          //  root = root.ReplaceNode(myClass, updatedClass).NormalizeWhitespace();

            // Is this the way to write the syntax tree? ToFullString?
           // File.WriteAllText(csFile, root.ToFullString());


            //var result = CsharpHelper.GetInterfaces<IXmlLineInfo>(@"D:\Demo");

            //result.ForEach(x => { Console.WriteLine(x.Name); });
            Console.ReadLine();
        }
    }
}
