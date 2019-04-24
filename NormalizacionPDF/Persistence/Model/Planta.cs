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
    
    public partial class Planta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Planta()
        {
            this.Domicilios = new HashSet<Domicilio>();
            this.Efluentes = new HashSet<Efluente>();
            this.EmisionGaseosas = new HashSet<EmisionGaseosa>();
            this.FormacionDePersonals = new HashSet<FormacionDePersonal>();
            this.Insumoes = new HashSet<Insumo>();
            this.MateriaPrimas = new HashSet<MateriaPrima>();
            this.Productoes = new HashSet<Producto>();
            this.ResiduosSolidos = new HashSet<ResiduosSolido>();
            this.RiesgoPresuntoes = new HashSet<RiesgoPresunto>();
            this.Subproductoes = new HashSet<Subproducto>();
        }
    
        public int idPlanta { get; set; }
        public int cuit { get; set; }
        public double superficieTotalM2 { get; set; }
        public double superficieCubiertaM2 { get; set; }
        public double potenciaInstaladaHP { get; set; }
        public int dotacionDePersonal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Domicilio> Domicilios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Efluente> Efluentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmisionGaseosa> EmisionGaseosas { get; set; }
        public virtual Empresa Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormacionDePersonal> FormacionDePersonals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Insumo> Insumoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MateriaPrima> MateriaPrimas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Productoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResiduosSolido> ResiduosSolidos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiesgoPresunto> RiesgoPresuntoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subproducto> Subproductoes { get; set; }
    }
}