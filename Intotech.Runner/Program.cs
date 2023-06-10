// See https://aka.ms/new-console-template for more information
using Intotech.Common;
using Intotech.Common.Bll.Seed;
using Intotech.ReflectiveTools.SourceGenerators;

Console.WriteLine("The runner is a midnight runner ! xd");

//List<string> fileNames = ModelsReader.ReadAllModelsNames(@"D:\Razer\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Database.Persistence\Models");

//InterfaceAndLogicFileGenerator ifG = new InterfaceAndLogicFileGenerator();

//ifG.GenerateCodeFiles(@"D:\Razer\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Bll.Persistence.Interfaces", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Xerion.Bll.Persistence", ModelPersistenceUsing = "Intotech.Xerion.Database.Persistence.Models" }, true);
//ifG.GenerateCodeFiles(@"D:\Razer\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Bll.Persistence", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Xerion.Bll.Persistence", ModelPersistenceUsing = "Intotech.Xerion.Database.Persistence.Models" }, false);

//Console.WriteLine(fileNames.Count);

SeedModelGenerator smg = new SeedModelGenerator();
//string solutionPath = EnvironmentUtils.GetSolutionDirectory();
////smg.GenerateFiles(@$"{solutionPath}\Toci.Driver.Bll.Porsche.Interfaces\Toci.Driver.Database.Persistence\Models", 
////    @$"{solutionPath}\Intotech.Wheelo.Seed.Common\Wheelo.Main\", "Wheelo.Main", "Toci.Driver.Database.Persistence.Models",
////    "SeedWheeloMainLogic"); // 

smg.GenerateFiles(@$"C:\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Database.Persistence\Models",
    @$"C:\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Common\Seed\Xerion.Main",
    "Intotech.Xerion.Common.Seed.Xerion.Main",
    "Intotech.Xerion.Database.Persistence.Models",
    "SeedXerionMainLogic");