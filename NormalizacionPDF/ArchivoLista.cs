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

        public ArchivoLista()
        {
        }
    }
}
