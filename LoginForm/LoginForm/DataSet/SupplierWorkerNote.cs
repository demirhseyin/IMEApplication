//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginForm.DataSet
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierWorkerNote
    {
        public int ID { get; set; }
        public string supplierID { get; set; }
        public Nullable<int> sw_ID { get; set; }
        public Nullable<int> workerID { get; set; }
    
        public virtual SupplierWorker SupplierWorker { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}