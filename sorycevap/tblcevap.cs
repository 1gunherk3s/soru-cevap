//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sorycevap
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblcevap
    {
        public int CevapID { get; set; }
        public string CevapA { get; set; }
        public string CevapB { get; set; }
        public string CevapC { get; set; }
        public string CevapD { get; set; }
    
        public virtual tblsoru tblsoru { get; set; }
    }
}
