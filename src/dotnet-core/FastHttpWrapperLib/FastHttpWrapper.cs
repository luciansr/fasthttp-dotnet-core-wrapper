using System;

namespace FastHttpWrapperLib
{
    public class FastHttpWrapper
    {
        private System.Diagnostics.Process _process;

        public FastHttpWrapper(string fastHttpExePath)
        {
            _process = new System.Diagnostics.Process();
            _process.StartInfo.FileName = fastHttpExePath;
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardOutput = true;
        }
        public string DoPost(string uri, string postBody)
        {
            try
            {
                _process.StartInfo.Arguments = uri + " \"" + postBody + "\"";
                _process.Start();
                // _process.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Get program output
            string strOutput = _process.StandardOutput.ReadToEnd();

            //Wait for process to finish
            _process.WaitForExit();

            return strOutput;
        }
    }
}
