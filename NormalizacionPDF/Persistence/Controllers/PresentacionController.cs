using com.dir.inno.normalizacion_pdfs;
using NormalizacionPDF.Persistence.Model;
using System;

namespace NormalizacionPDF.Persistence.Controllers
{
    class PresentacionController
    {
        public PresentacionController(string nombreArchivo)
        {
            LectorPDFImpreso47 lector = new LectorPDFImpreso47(nombreArchivo);
            float version;
            float.TryParse(lector.obtenerVersion(), out version);
            ProcesarDocumento(nombreArchivo, version);
        }

        private void ProcesarDocumento(string nombreArchivo, float version)
        {
            switch (version)
            {
                case 4.7F:
                    ProcesarDocumento47(nombreArchivo);
                    break;

            }

            //form.Empresa.cuit = lector.obtenerCuit();
            //form.Empresa.fechaInicioActividades = new DateTime(lector.obtenerFechaInicioAct().getTime() * 10000);


        }

        private void ProcesarDocumento47(string nombreArchivo)
        {
            LectorPDFImpreso47V lector = new LectorPDFImpreso47V(nombreArchivo);
            FormPresentacion form = new FormPresentacion();
            form.Empresa.razonSocial = lector.obtenerNombre();

        }
    }
}
