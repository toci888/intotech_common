using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace GenerateDtosTest
{
    internal class CopyModelGeterator
    {

        internal static string GetFileName(string file)
        {
            FileInfo fileInfo = new FileInfo(file);

            return fileInfo.Name.Replace(".cs", "");
        }

        internal static void GenerateNewClass(string solutionDestinationPath, Type exportedType, string? sufixNewClass)
        {

            var className = exportedType.Name;

            var exportedProperties = exportedType.GetProperties().ToList();

            string nameSpace = CopyModelGeterator.ConvertPathToNamespace(solutionDestinationPath);

            // Tworzenie dostawcy kodu C#
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            // Tworzenie deklaracji klasy
            CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration(className);
            classDeclaration.IsClass = true;

            // Tworzenie properties
            foreach (var expoetedProperty in exportedProperties)
            {
                CodeMemberProperty property1 = new CodeMemberProperty();
                property1.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                property1.Type = new CodeTypeReference(expoetedProperty.PropertyType);
                property1.Name = expoetedProperty.Name;
                property1.HasSet = true;
                property1.HasGet = true;

                // Tworzenie kodu gettera
                //property1.GetStatements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(expoetedProperty.Name)));

                //// Tworzenie kodu settera
                //property1.SetStatements.Add(new CodeAssignStatement(new CodeVariableReferenceExpression(expoetedProperty.Name), new CodeVariableReferenceExpression("value")));

                classDeclaration.Members.Add(property1);
            }

            
            // Tworzenie przestrzeni nazw
            CodeNamespace namespaceDeclaration = new CodeNamespace(nameSpace);
            namespaceDeclaration.Types.Add(classDeclaration);

            // Tworzenie jednostki kodu
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            compileUnit.Namespaces.Add(namespaceDeclaration);

            // Generowanie kodu do pliku
            string fileName;
            if (sufixNewClass != null) { fileName = $"{className}{sufixNewClass}.cs"; }
            else { fileName = className + ".cs"; }
            using (StreamWriter sw = new StreamWriter($"{ solutionDestinationPath }/{ fileName}"))
            {
                provider.GenerateCodeFromCompileUnit(compileUnit, sw, new CodeGeneratorOptions());
            }

            
        }

        public static string ConvertPathToNamespace(string folderPath)
        {
            string[] parts = folderPath.Split('\\');
            int generateDtosTestIndex = Array.IndexOf(parts, "GenerateDtosTest");

            if (generateDtosTestIndex >= 0 && generateDtosTestIndex < parts.Length - 1)
            {
                string[] desiredParts = parts[(generateDtosTestIndex + 1)..];
                return string.Join(".", desiredParts);
            }

            return string.Empty;
        }

        public static void ClearFolder(string folderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }
    }
}
