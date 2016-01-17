using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicModule
{
    public enum FileTypes { XLSM, Dm };
    public enum FldTypes { StringFld, FloatFld };

    public interface IFile
    {
         FileTypes FileType  { get; }

    }

    public class FldInfo
    {
        string FldName { get; set; }
        FldTypes FldType { get; set; }
    }

    public class FileObject
    {
        List<FldInfo> ObjStru { get; set; }
        dynamic Data { get; set; }
    }

    public class MineTrustFiles
    {
        private dynamic _mtObject = null;
        private dynamic _mtObject2 = null;
        private bool _mtOpened = false;
        private string _mtServer;
        private string _mtRootFolder;
        private string _tempFolder;
        enum replaceMode : byte { always = 1, if_older, never }
        UInt64 mode= 1;

        public MineTrustFiles (string MtServer , string MtRootFolder , string TempFolder)
        {
            _mtServer = MtServer;
            _mtRootFolder = MtRootFolder;
            _tempFolder = TempFolder;

            try {
                _mtObject = Activator.CreateInstance(Type.GetTypeFromProgID("Datamine.MineTrust.Client.COMService"));
               // _mtObject2 = Activator.CreateInstance(Type.GetTypeFromProgID("Datamine.MineTrust.Client"));
                _mtOpened = true;
            }
            catch (Exception e)
            {
                _mtOpened = false;
                _mtObject = null;
            }
            
        }

        public FileObject GetObjFromFile (string FileName )
        {
            FileObject reurnedFileObject = new FileObject();
            CopyFileToTemp(FileName);
            return reurnedFileObject;
        }

        private void CopyFileToTemp(string FileName)
        {
            if (!_mtOpened)
                throw new NotImplementedException("MineTrust object is not opened");
            String fullPathMt = _mtRootFolder + "\\" + FileName;
            String fullPathTemp = _tempFolder + "\\" + FileName;
            
      //  _mtObject.GetLatestFile(fullPathMt, fullPathTemp, false , "always");
        _mtObject.GetLatestFile("Folders\\Managed Folders\\Ore Control\\Polyus Gold\\BL\\300\\BL-300-002-results.xlsm", "e:\\MDB\\temp\\2\\BL-300-002-results.xlsm", false, mode);
        }

    }
}
