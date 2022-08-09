using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;



public class FileUpload
{

    public string FileNameCheck(string fileName, string savePath)
    {

        string pathToCheck = savePath + fileName;
        string tempfileName = "";

        if (System.IO.File.Exists(pathToCheck))
        {
            int counter = 2;
            while (System.IO.File.Exists(pathToCheck))
            {
                tempfileName = counter.ToString() + "_" + fileName;
                pathToCheck = savePath + tempfileName;
                counter++;
            }
            fileName = tempfileName;
        }
        
        return fileName;
    }


}
