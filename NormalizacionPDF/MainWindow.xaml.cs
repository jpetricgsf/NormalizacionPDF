using com.dir.inno.normalizacion_pdfs;
using Microsoft.Win32;
using NormalizacionPDF.Resources;
using System.Collections.ObjectModel;
using System.Windows;

namespace NormalizacionPDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<ArchivoLista> ListaArchivos { get; set; }

        public MainWindow()
        {
            ListaArchivos = new ObservableCollection<ArchivoLista>();
            InitializeComponent();
            ListaTab.DataContext = this;
        }


        public void AgregarDocClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                string[] archivos = dialog.FileNames;
                AgregarArchivos(archivos);
            }
        }

        private void DocumentosDropped(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop);
                AgregarArchivos(archivos);
            }
        }

        private void AgregarArchivos(string[] archivos)
        {
            foreach (string element in archivos)
            {
                string fileName = element;
                string version;
                bool impreso = EstaImpreso(element);
                if (impreso)
                {
                    LectorPDFImpreso47 lector = new LectorPDFImpreso47(element);
                    version = lector.obtenerVersion();
                }
                else
                {
                    version = "-";
                }
                ArchivoLista t = new ArchivoLista();
                t.Index = ListaTab.Items.Count + 1;
                t.NombreArchivo = element;
                t.Ruta = System.IO.Path.GetDirectoryName(element);
                t.Version = version;
                t.Impreso = impreso;
                ListaArchivos.Add(t);
            }
        }

        private bool EstaImpreso(string element)
        {
            LectorPDFImpreso47 lector = new LectorPDFImpreso47(element);
            float number;
            if (float.TryParse(lector.obtenerVersion(), out number)) return true;
            else return false;
        }

        private void ImprimirClicked(object sender, RoutedEventArgs e)
        {
            foreach (ArchivoLista a in ListaArchivos)
            {
                if (!a.Impreso)
                {
                    PDFPrinter.PrintPDF(a.NombreArchivo);
                }
                else
                {
                    string fileName = System.IO.Path.GetFileName(a.NombreArchivo);
                    string targetPath = a.Ruta;
                    targetPath += @"\Impresos";
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(a.NombreArchivo, destFile, true);
                }
            }
        }
    }
}