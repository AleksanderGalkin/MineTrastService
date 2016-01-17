using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicModule
{
    public enum FileTypes { XLSM, Dm };

    public interface IFile
    {
         FileTypes FileType  { get; }

    }

    public class MineTrustFiles
    {
        private dynamic _mtObject = null;
        private bool _mtOpened = false;
        private string _mtServer;
        private string _mtRootFolder;
        private string _tempFolder;

        public MineTrustFiles (string MtServer , string MtRootFolder , string TempFolder)
        {
            _mtServer = MtServer;
            _mtRootFolder = MtRootFolder;
            _tempFolder = TempFolder;

            try {
                _mtObject = Activator.CreateInstance(Type.GetTypeFromProgID("Datamine.MineTrust.Client.COMService"));
                _mtOpened = true;
            }
            catch (Exception e)
            {
                _mtOpened = false;
                _mtObject = null;
            }
            
        }

        public void GetFile (string FileName )
        {

        }

    }
}
