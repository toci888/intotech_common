// See https://aka.ms/new-console-template for more information
using Intotech.ReflectiveTools.SourceGenerators;

Console.WriteLine("The runner is a midnight runner ! xd");

List<string> fileNames =  ModelsReader.ReadAllModelsNames(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Toci.Driver.Database.Persistence\Models");

InterfaceAndLogicFileGenerator ifG = new InterfaceAndLogicFileGenerator();

ifG.GenerateCodeFiles(@"C:\Users\bzapa\source\repos\dawid", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Wheelo.Bll.Persistence.Interfaces", ModelPersistenceUsing = "Toci.Driver.Database.Persistence.Models" }, false);

Console.WriteLine(fileNames.Count);
