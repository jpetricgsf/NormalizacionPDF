using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalizacionPDF.Persistence.Model
{

    class FormPresentacion
    {
        public Empresa Empresa { get; set; }

        public FormPresentacion()
        {
            Empresa = new Empresa();

        }
    }
}
