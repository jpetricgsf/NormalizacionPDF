//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NormalizacionPDF.Persistence.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class actividadEmpresa
    {
        public int cuit { get; set; }
        public int cuacm { get; set; }
        public int orden { get; set; }
    
        public virtual Actividad Actividad { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}