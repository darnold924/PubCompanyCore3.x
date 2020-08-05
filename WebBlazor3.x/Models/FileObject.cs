using System.IO;

namespace WebRazor3.x.Models
{
    public class FileObject
    {
        private string _webRootPath;
        public FileObject(string webrootpath)
        {
            _webRootPath = webrootpath;
            GetFiles();
        }
        public string [] Files { get; set; } = new string[1000];

        private void GetFiles()
        {
            
            var docsPath = Path.Combine(_webRootPath, "documents");

            Files  = Directory.GetFiles("targetDirectory");
        }
    }
}
