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
    
    public partial class CustomerCategorySubCategory
    {
        public int ID { get; set; }
        public Nullable<int> categoryID { get; set; }
        public Nullable<int> subcategoryID { get; set; }
        public string customerID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual CustomerSubCategory CustomerSubCategory { get; set; }
    }
}
