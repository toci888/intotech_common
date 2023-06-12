// See https://aka.ms/new-console-template for more information
using Intotech.Common;
using Intotech.Common.Bll.Seed;
using Intotech.ReflectiveTools.SourceGenerators;
using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

Console.WriteLine("The runner is a midnight runner ! xd");

ClassRendererRunner.LoadAndReadAssembly("C:\\Users\\bzapart\\source\\repos\\toci888\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll",
    "C:\\Users\\bzapart\\source\\repos\\toci888\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\ModelDtos\\Intotech.Wheelo.Dtos\\");

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

/*smg.GenerateFiles(@$"C:\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Database.Persistence\Models",
    @$"C:\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Common\Seed\Xerion.Main",
    "Intotech.Xerion.Common.Seed.Xerion.Main",
    "Intotech.Xerion.Database.Persistence.Models",
    "SeedXerionMainLogic");
*/