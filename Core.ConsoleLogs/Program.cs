using Core.Toolss;
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

namespace Core.ConsoleLogs
{
    class Program
    {
        static void Main(string[] args)
        {


          


            const string csFile = @"D:\ClassDemo.cs";
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
