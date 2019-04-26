using com.dir.inno.normalizacion_pdfs;
using Microsoft.Win32;
using NormalizacionPDF.Resources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
                ArchivoLista t = new ArchivoLista(element);
                t.Index = ListaTab.Items.Count + 1;
                ListaArchivos.Add(t);
            }
        }

        private void ImprimirClicked(object sender, RoutedEventArgs e)
        {
            HashSet<string> carpetasImpresos = new HashSet<string>();
            foreach (ArchivoLista a in ListaArchivos)
            {
                if (!a.Impreso)
                {
                    PDFPrinter.PrintPDF(a.NombreArchivo);
                }
                else
                {
                    string fileName = Path.GetFileName(a.NombreArchivo);
                    string targetPath = a.Ruta;
                    targetPath += @"\Impresos";
                    string destFile = Path.Combine(targetPath, fileName);
                    File.Copy(a.NombreArchivo, destFile, true);
                    carpetasImpresos.Add(destFile);
                }
            }
            ListaArchivos.Clear();
            List<string> archivosImpresos = new List<string>();
            foreach (string a in carpetasImpresos)
            {
                archivosImpresos.AddRange(Directory.GetFiles(a));
            }
            foreach (string element in archivosImpresos)
            {
                ArchivoLista t = new ArchivoLista(element);
                t.Index = ListaTab.Items.Count + 1;
                ListaArchivos.Add(t);
            }
        }

        private void procesarClicked(object sender, RoutedEventArgs e)
        {
            foreach(ArchivoLista a in ListaArchivos)
            {
                a.Procesar(tramitesCombo.Text);
            }
        }
    }
}