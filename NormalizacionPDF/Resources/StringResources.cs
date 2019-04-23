using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalizacionPDF
{
    class StringResources
    {
        public List<String> Tramites
        {
            get;
            set;
        }

        public StringResources()
        {
            Tramites = new List<String>()
            {
            "Radicación Industrial - Presentación",
            "Radicación Industrial - Estudia de Impacto Ambiental",
            "Radicación Industrial - Informe Ambiental de Cumplimiento"
            };
        }
    }
}
