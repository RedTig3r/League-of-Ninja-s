//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeagueOfNinja.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public Nullable<int> EquipmentId { get; set; }
    
        public virtual Ninja Ninja { get; set; }
    }
}
