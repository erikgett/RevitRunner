using System.Diagnostics;

namespace RevitRunner
{
    /// <summary>
    ///  Базовый пример запуска ревита, для этого необходимо указать путь к файлу ревита, а так же исполняемый журнал
    ///  В ревит подгружаются только те плагины, которые расположены рядом с файлом журнала ( Подгрузятся только те addin-ы, которые в той же папке что и журнал )
    /// </summary>
    public class BaseRevitProcess
    {
        Process revitProcess = new Process();
        /// <summary> Запускает экземляр ревита, который выполняет действия из журнала </summary>
        /// <param name="revitPath">Путь к файл ревита, для его дальнейшего запуска</param>
        /// <param name="argument">Журнал ревита является аргументом запуска процесса Revit</param>
        public void ProccesExecute(string revitPath = @"C:\Program Files\Autodesk\Revit 2021\Revit.exe", string argument = @"C:\Users\gette.e\AppData\Roaming\Autodesk\Revit\Addins\2021\journall.0001.txt")
        {
            try
            {                               
                revitProcess.StartInfo.FileName = revitPath;
                revitProcess.StartInfo.Arguments = argument;
                // Запускаем процесс
                revitProcess.Start();
            }
            catch { }
        }

        /// <summary> Убивает экземляр ревита, который был запущен </summary>
        public void ProccesKill() { revitProcess.Kill(); }
    }
}
