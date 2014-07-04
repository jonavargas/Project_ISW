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
    
    public partial class Bill
    {
        public Bill()
        {
            this.BillDetail = new HashSet<BillDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Tax { get; set; }
        public Nullable<int> Discount { get; set; }
        public string PaymentType { get; set; }
        public string State { get; set; }
        public Nullable<int> SubTotal { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> Employee { get; set; }
        public Nullable<int> Client { get; set; }
    
        public virtual Client Client1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}
