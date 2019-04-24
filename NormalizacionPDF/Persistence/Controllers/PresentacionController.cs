using com.dir.inno.normalizacion_pdfs;

namespace NormalizacionPDF.Persistence.Controllers
{
    class PresentacionController
    {
        private string NombreArchivo;

        public PresentacionController(string nombreArchivo)
        {
            this.NombreArchivo = nombreArchivo;
            ProcesarDocumento();
        }

        private void ProcesarDocumento()
        {

        }
    }
}
