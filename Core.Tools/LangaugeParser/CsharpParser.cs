using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.Tools.LangaugeParser
{
    /// <summary>
    /// Csharp 字符串识别
    /// </summary>
    public class CsharpParser
    {

        public SyntaxNode roots { get; set; }
        /// <summary>
        /// 根据路劲
        /// </summary>
        /// <param name="Path"></param>
        public CsharpParser(string Path)
        {
            var context = Path.GetFileContext();
            var syntaxTree = CSharpSyntaxTree.ParseText(context);
            roots = syntaxTree.GetRoot(); 
        }


        /// <summary>
        /// 获取所有类
        /// </summary>
        /// <returns></returns>
        public List<ClassDeclarationSyntax> GetClasses()
        {
            return roots.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
        }

        /// <summary>
        /// 获取Class
        /// </summary>
        /// <returns></returns>
        public ClassDeclarationSyntax GetClass()
        {
            return roots.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
        }

        /// <summary>
        /// 获取最后文本
        /// </summary>
        /// <returns></returns>
        public string GetFullStrig()
        {
            return roots.ToFullString();
        }


        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="classes"></param>
        /// <param name="property"></param>
        public void AddProperty(ClassDeclarationSyntax classes, PropertyDeclarationSyntax property)
        {
            var propertys = classes.DescendantNodes().OfType<PropertyDeclarationSyntax>();
            //if(propertys.Any(x=>x.Identifier.va))
            var updatedClass = classes.AddMembers(property);
            //Update the SyntaxTree and normalize whitespace
            roots = roots.ReplaceNode(classes, updatedClass).NormalizeWhitespace();
        }


        /// <summary>
        /// 创建新属性
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public PropertyDeclarationSyntax CreateProperty( CsharpProperty property)
        {
            var documentcomment = SetPropertyComment(property.PropertyComment);
            var propertyDeclaration = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(property.PropertyType), property.PropertyName)
              .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
              .AddAccessorListAccessors(
                  SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                  SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))).WithModifiers(
               SyntaxFactory.TokenList(
                   new[]{
                        SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.Trivia(documentcomment)), // xmldoc
                                SyntaxKind.PublicKeyword, // original 1st token
                                SyntaxFactory.TriviaList()),
                        SyntaxFactory.Token(SyntaxKind.StaticKeyword)}));

            return propertyDeclaration;

        }


        public DocumentationCommentTriviaSyntax SetPropertyComment(string comment)
        {
            return SyntaxFactory.DocumentationCommentTrivia(
        SyntaxKind.SingleLineDocumentationCommentTrivia,
        SyntaxFactory.List<XmlNodeSyntax>(
            new XmlNodeSyntax[]{
            SyntaxFactory.XmlText()
            .WithTextTokens(
                SyntaxFactory.TokenList(
                    SyntaxFactory.XmlTextLiteral(
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.DocumentationCommentExterior("///")),
                        " ",
                        " ",
                        SyntaxFactory.TriviaList()))),
            SyntaxFactory.XmlElement(
                SyntaxFactory.XmlElementStartTag(
                    SyntaxFactory.XmlName(
                        SyntaxFactory.Identifier("summary"))),
                SyntaxFactory.XmlElementEndTag(
                    SyntaxFactory.XmlName(
                        SyntaxFactory.Identifier("summary"))))
             .WithContent(
                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                            SyntaxFactory.XmlText()
                                            .WithTextTokens(
                                                SyntaxFactory.TokenList(
                                                    new []{
                                                        SyntaxFactory.XmlTextNewLine(
                                                            SyntaxFactory.TriviaList(),
                                                            @"
",
                                                            @"
",
                                                            SyntaxFactory.TriviaList()),
                                                        SyntaxFactory.XmlTextLiteral(
                                                            SyntaxFactory.TriviaList(
                                                                SyntaxFactory.DocumentationCommentExterior(
                                                                    @"///")),
                                                            $"{comment}",
                                                            $"{comment}",
                                                            SyntaxFactory.TriviaList()),
                                                        SyntaxFactory.XmlTextNewLine(
                                                            SyntaxFactory.TriviaList(),
                                                            @"
",
                                                            @"
",
                                                            SyntaxFactory.TriviaList()),
                                                        SyntaxFactory.XmlTextLiteral(
                                                            SyntaxFactory.TriviaList(
                                                                SyntaxFactory.DocumentationCommentExterior(
                                                                    @"///")),
                                                            @" ",
                                                            @" ",
                                                            SyntaxFactory.TriviaList())})))),
                                    SyntaxFactory.XmlText()
                                    .WithTextTokens(
                                        SyntaxFactory.TokenList(
                                            SyntaxFactory.XmlTextNewLine(
                                                SyntaxFactory.TriviaList(),
                                                @"
",
                                                @"
",
                                                SyntaxFactory.TriviaList())))}));
        }
    } 
}
