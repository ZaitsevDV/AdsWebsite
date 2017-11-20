using System.Reflection;
using System.Runtime.InteropServices;

// Управление общиC:\Projects\AdsWebsite\PresentationTier\Properties\AssemblyInfo.csми сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанных с этой сборкой.
[assembly: AssemblyTitle("PresentationTier")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PresentationTier")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения false в параметре ComVisible делает типы в этой сборке невидимыми 
// для компонентов COM. Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение true для требуемого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов typelib, если этот проект видим для COM
[assembly: Guid("97537a5e-1cd7-4459-8d97-566adb864d35")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      основной номер версии;
//      дополнительный номер версии;
//      номер сборки;
//      редакция.
//
// Можно задать все значения или принять номер сборки и номер редакции по умолчанию, 
// используя "*", как показано ниже:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log.config", Watch = true)]