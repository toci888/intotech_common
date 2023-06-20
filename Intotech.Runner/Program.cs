// See https://aka.ms/new-console-template for more information
using Intotech.Common;
using Intotech.Common.Bll.Seed;
using Intotech.ReflectiveTools.DtosLogicGenerator;
using Intotech.ReflectiveTools.SourceGenerators;
using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
using Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator;

Console.WriteLine("The runner is a midnight runner ! xd");


// Generate DtoLogic Classes 

DtoLogicRendererRunner dtosRender = new();

dtosRender.LoadAndReadAssembly("GitHub", "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Logic\\DtoLogics\\",
    "using System.Linq.Expressions;\r\nusing Intotech.Common.Bll.ChorDtoBll;\r\nusing Intotech.Common.Bll.ChorDtoBll.Dto;\r\nusing Intotech.Wheelo.Bll.Models.Dtos;\r\nusing Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;\r\nusing Intotech.Wheelo.Bll.Persistence;\r\nusing Intotech.Wheelo.Common.Interfaces.ModelMapperInterfaces;\r\nusing Toci.Driver.Database.Persistence.Models;",
    "namespace Intotech.Wheelo.Bll.Logic.DtoLogics;");

// Generate Dto Classes

//DtoRendererRunner.LoadAndReadAssembly("GitHub", "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\Dtos\\", "using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;", "namespace Intotech.Wheelo.Bll.Models.Dtos;");

// Generate Logic Classes (zostawić Logic.cs i AccountLogicConstants.cs)

//LogicRendererRunner.LoadAndReadAssembly("GitHub", "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Persistence\\",
//"using Intotech.Wheelo.Bll.Persistence.Interfaces;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing Toci.Driver.Database.Persistence.Models;",
//"namespace Intotech.Wheelo.Bll.Persistence;", false);


// Generate ILogic Interfases

//LogicRendererRunner.LoadAndReadAssembly("GitHub", "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Persistence.Interfaces\\",
//"using Intotech.Common.Bll.Interfaces;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing Toci.Driver.Database.Persistence.Models;",
//"namespace Intotech.Wheelo.Bll.Persistence;", true);


//ClassRendererRunner.LoadAndReadAssembly("C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll",
//    "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\ModelDtos\\Intotech.Wheelo.Dtos\\",
//    "using Intotech.Common.Bll.ChorDtoBll.Dto;\r\nusing Toci.Driver.Database.Persistence.Models;",
//    "namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;");

//List<string> fileNames = ModelsReader.ReadAllModelsNames(@"C:\Users\stasx\Documents\GitHub\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Toci.Driver.Database.Persistence\Models\");


//tutaj trzeba przerobić na refleksję

//InterfaceAndLogicFileGenerator ifG = new InterfaceAndLogicFileGenerator();

//ifG.GenerateCodeFiles(@"C:\Users\stasx\Documents\GitHub\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Intotech.Wheelo.Bll.Persistence.Interfaces\Intotech.Wheelo.Bll.Persistence.Interfaces.csproj", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Xerion.Bll.Persistence", ModelPersistenceUsing = "Intotech.Xerion.Database.Persistence.Models" }, true);
//ifG.GenerateCodeFiles(@"C:\Users\stasx\Documents\GitHub\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Intotech.Wheelo.Bll.Persistence\Intotech.Wheelo.Bll.Persistence", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Xerion.Bll.Persistence", ModelPersistenceUsing = "Intotech.Xerion.Database.Persistence.Models" }, false);

//Console.WriteLine(fileNames.Count);

//SeedModelGenerator smg = new SeedModelGenerator();
//string solutionPath = EnvironmentUtils.GetSolutionDirectory();
//smg.GenerateFiles(@$"{solutionPath}\Toci.Driver.Bll.Porsche.Interfaces\Toci.Driver.Database.Persistence\Models",
//    @$"{solutionPath}\Intotech.Wheelo.Seed.Common\Wheelo.Main\", "Wheelo.Main", "Toci.Driver.Database.Persistence.Models",
//    "SeedWheeloMainLogic"); // 

/*smg.GenerateFiles(@$"C:\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Database.Persistence\Models",
    @$"C:\Dev\Intotech.Xerion\Backend\Intotech.Xerion.Common\Seed\Xerion.Main",
    "Intotech.Xerion.Common.Seed.Xerion.Main",
    "Intotech.Xerion.Database.Persistence.Models",
    "SeedXerionMainLogic");
*/