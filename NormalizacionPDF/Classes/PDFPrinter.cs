using System.Printing;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Linq;

namespace NormalizacionPDF.Resources
{
    class PDFPrinter
    {

        public static void PrintPDF(string pdfFileName)
        {
            ProcessStartInfo infoPrintPdf = new ProcessStartInfo
            {
                FileName = pdfFileName
            };
            // The printer name is hardcoded here, but normally I get this from a combobox with all printers
            string printerName = "Adobe PDF";
            string driverName = "printqueue.inf";
            string portName = @"Documents\*.pdf";
            infoPrintPdf.FileName = @"C:\Program Files (x86)\Adobe\Acrobat 11.0\Acrobat\Acrobat.exe";
            infoPrintPdf.Arguments = string.Format("/t {0} \"{1}\" \"{2}\" \"{3}\"",
                pdfFileName, printerName, driverName, portName);
            infoPrintPdf.CreateNoWindow = true;
            infoPrintPdf.UseShellExecute = false;
            infoPrintPdf.WindowStyle = ProcessWindowStyle.Hidden;
            Process printPdf = new Process
            {
                StartInfo = infoPrintPdf
            };
            printPdf.Start();

            // This time depends on the printer, but has to be long enough to
            // let the printer start printing
            System.Threading.Thread.Sleep(10000);

            
            if (!printPdf.CloseMainWindow()) printPdf.Kill(); // CloseMainWindow never seems to succeed

                printPdf.WaitForExit();  // Kill Acrobat.exe

            foreach (Process clsProcess in Process.GetProcesses().Where(
                         clsProcess => clsProcess.ProcessName.StartsWith("acrodist")))
            {
                clsProcess.Kill();
            }
                printPdf.Close();  // Close the process and release resources
        }

    }
}
