//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prilozenie.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kross
    {
        public int Id_Kross { get; set; }
        public Nullable<int> Id_Equipment { get; set; }
        public Nullable<int> Id_Station { get; set; }
        public Nullable<int> Id_Linear { get; set; }
        public Nullable<int> Id_CableType { get; set; }
        public Nullable<int> Id_Place { get; set; }
    
        public virtual CableType CableType { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Linear Linear { get; set; }
        public virtual Place Place { get; set; }
        public virtual Station Station { get; set; }
    }
}