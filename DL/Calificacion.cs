//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calificacion
    {
        public int IdCalificacion { get; set; }
        public Nullable<int> IdEvaluador { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdPeriodo { get; set; }
        public Nullable<int> Calificacion1 { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Evaluador Evaluador { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
