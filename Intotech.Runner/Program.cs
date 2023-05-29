// See https://aka.ms/new-console-template for more information
using Intotech.Common.Bll.Seed;
using Intotech.ReflectiveTools.SourceGenerators;

Console.WriteLine("The runner is a midnight runner ! xd");

/*List<string> fileNames =  ModelsReader.ReadAllModelsNames(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Intotech.Wheelo.Social.Database.Persistence\Models");

InterfaceAndLogicFileGenerator ifG = new InterfaceAndLogicFileGenerator();

//ifG.GenerateCodeFiles(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\reflective", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Wheelo.Social.Bll.Persistence.Interfaces", ModelPersistenceUsing = "Intotech.Wheelo.Social.Database.Persistence.Models" }, true);
ifG.GenerateCodeFiles(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\reflective", fileNames, new GeneratedFileDto() { KeyNamespace = "Intotech.Wheelo.Social.Bll.Persistence", ModelPersistenceUsing = "Intotech.Wheelo.Social.Database.Persistence.Models" }, false);

Console.WriteLine(fileNames.Count);*/

SeedModelGenerator smg = new SeedModelGenerator();

smg.GenerateFiles(@"C:\Users\bzapa\Source\Repos\toci888\intotech_wheelo\Toci.Driver.Bll.Porsche.Interfaces\Toci.Driver.Database.Persistence\Models", 
    @"C:\Users\bzapa\Source\Repos\toci888\intotech_wheelo\Intotech.Wheelo.Seed.Common\Wheelo.Main\", "Wheelo.Main", "Toci.Driver.Database.Persistence.Models",
    "SeedWheeloMainLogic");
