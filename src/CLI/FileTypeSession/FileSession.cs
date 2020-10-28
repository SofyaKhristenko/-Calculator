using BLL;
using CLI.Model;
using System.Collections.Generic;

namespace CLI.FileTypeSession
{
    static class FileSession
    {
        public static void SetFileSession(Calculator calc, UserDialogConfig info)
        {
            string pathReadFile = FileEntrance.GetPath(info.ReadFilePath);
            string[] fileRows = Rows.GetLines(pathReadFile);

            List<string> resultCalculate = new List<string>();
            string pathSaveFileResult = FileEntrance.GetSaveFilePath(info.SaveFilePath);

            foreach (var line in fileRows)
            {
                resultCalculate.Add($"{line} = {calc.Count(line)}");
            }

            FileRecorder.Recording(resultCalculate, pathSaveFileResult);
        }

    }
}
