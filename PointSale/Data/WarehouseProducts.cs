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
    
    public partial class WarehouseProducts
    {
        public int Id { get; set; }
        public int QtyAvailable { get; set; }
        public int Warehouse { get; set; }
        public int Product { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
    }
}
