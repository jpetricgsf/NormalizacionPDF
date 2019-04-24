using com.dir.inno.normalizacion_pdfs;
using NormalizacionPDF.Persistence.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalizacionPDF.Resources
{

    public class ArchivoLista
    {

        public int Index { get; internal set; }
        public string NombreArchivo { get; internal set; }
        public string Version { get; internal set; }
        public string Ruta { get; internal set; }
        public bool Impreso { get; internal set; }

        public ArchivoLista(string nombreArchivo)
        {
            NombreArchivo = nombreArchivo;
            Ruta = System.IO.Path.GetDirectoryName(NombreArchivo);
            Impreso = EstaImpreso();
            if (Impreso)
            {
                LectorPDFImpreso47 lector = new LectorPDFImpreso47(NombreArchivo);
                Version = lector.obtenerVersion();
            }
            else
            {
                Version = "-";
            }
        }

        private bool EstaImpreso()
        {
            LectorPDFImpreso47 lector = new LectorPDFImpreso47(NombreArchivo);
            float number;
            if (float.TryParse(lector.obtenerVersion(), out number)) return true;
            else return false;
        }

        internal void Procesar(string tramite)
        {
            if (tramite.Equals(StringResources.Tramites[0]))
            {
                PresentacionController pc = new PresentacionController(NombreArchivo);
            }
            else if (tramite.Equals(StringResources.Tramites[1]))
            {

            }
            else if (tramite.Equals(StringResources.Tramites[2]))
            {

            }
        }
    }
}
