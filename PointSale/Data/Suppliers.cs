//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Suppliers
    {
        public Suppliers()
        {
            this.ProductSuppliers = new HashSet<ProductSuppliers>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Telephone { get; set; }
        public string Address { get; set; }
        public string Detail { get; set; }
    
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; }
    }
}