using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.RegenerateScaffoldClasses
{
    public class RegenerateScafRunner
    {
        string _fileContent { get; set; }
        public virtual void Regenerate(string folderPath, string? Usings, string? Inheritance)
        {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                
                string fileName = GetFileNameFromPath(file);
                if (fileName.Contains("Context")) { 
                    continue;
                }

                using (StreamReader reader = new StreamReader(file)) 
                {
                    string fileContent = reader.ReadToEnd();

                    string[] words = fileContent.Split("\r\n");


                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Contains(fileName))
                        {
                            string name = string.Copy(fileName);
                            fileName += $" : {Inheritance}\r\n";
                           words[i] = words[i].Replace(name, fileName) ;
                            break;
                        }

                        
                    }

                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] += "\r\n";
                    }
                    string word = string.Join(" ", words); ;
                    _fileContent = string.Copy(word);
                }

                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(Usings);
                    writer.Write(_fileContent);
                }
            }
        }

        static string GetFileNameFromPath(string filePath)
        {
            string fileName = Path.GetFileName(filePath).Replace(".cs", "");
            return fileName;
        }
    }
}
