using com.dir.inno.normalizacion_pdfs;
using NormalizacionPDF.Persistence.Model;
using System;

namespace NormalizacionPDF.Persistence.Controllers
{
    class PresentacionController
    {
        private string NombreArchivo;

        public PresentacionController(string nombreArchivo)
        {
            //this.NombreArchivo = nombreArchivo;
            ProcesarDocumento(nombreArchivo);
        }

        private void ProcesarDocumento(string nombreArchivo)
        {
            LectorPDFImpreso47V lector = new LectorPDFImpreso47V(nombreArchivo);
            FormPresentacion form = new FormPresentacion();
            form.Empresa.razonSocial = lector.obtenerNombre();
            //form.Empresa.cuit = lector.obtenerCuit();
            form.Empresa.fechaInicioActividades = new DateTime(lector.obtenerFechaInicioAct().getTime() * 10000);


        }
    }
}
