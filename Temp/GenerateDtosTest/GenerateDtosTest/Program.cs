
using GenerateDtosTest;
using System.Reflection.Emit;
using System.Reflection;
using ClassesFrom.ClassesFromCopy;

string solutionSourcePath = "C:\\Users\\stasx\\source\\repos\\GenerateDtosTest";

string projectNameSource = "ClassesFrom";

string solutionDestinationPath = "C:\\Users\\stasx\\source\\repos\\GenerateDtosTest\\ClassesTo\\FolderToCopy";

string sufixNewClass = "ModelDto";


//string solutionSourcePath = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces";

//string projectNameSource = "Toci.Driver.Database.Persistence";

//string solutionDestinationPath = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\ModelDtos\\Intotech.Wheelo.Dtos";

//string sufixNewClass = "ModelDto";

CopyDtosGenerator dtosGenerator = new CopyDtosGenerator();

 var isGenerated = dtosGenerator.GenerateFromPersistance(solutionSourcePath, projectNameSource, solutionDestinationPath, sufixNewClass);

////ClassesTo.FolderToCopy.Accountmetadatum accountmetadatum = new();

//accountmetadatum.Id = 4;



//if (isGenerated == true)
//{
//    Console.WriteLine("Pliki utworzono pimyślnie");
//}
//else
//{
//    Console.WriteLine("Pliki nie utworzono");
//}


