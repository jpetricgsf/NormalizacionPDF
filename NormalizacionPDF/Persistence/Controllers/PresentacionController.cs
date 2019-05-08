using com.dir.inno.normalizacion_pdfs;
using NormalizacionPDF.Persistence.Model;
using System;
using System.Collections.Generic;

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
            Empresa emp = new Empresa();
            emp.razonSocial = lector.obtenerNombre();
            emp.cuit = lector.obtenerCuit().longValue();
            //Proceso agregar fecha inicio. Unica forma de pasar de java.Date a System.Date
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            emp.fechaInicioActividades = epoch.AddMilliseconds(lector.obtenerFechaInicioAct().getTime());
            //Proceso de obtener actEmpresas. Se recorre la lista obtenida y se va agregando por problemas de pasar de java a C
            foreach(int a in lector.obtenerActividades())
            {
                Actividad act = new Actividad();

                act.cuacm = a;
                act.Empresas.Add(emp);
                emp.Actividads.Add(act);
            }
            //Se traduce el string obtenido a una variable Dominio ya que el proyecto de java no cuenta con esa clase
            string dom = lector.obtenerDomicilioLegal();
            Domicilio legal = new Domicilio();




        }
    }
}
