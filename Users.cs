//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlinePlatforms_EX_StasIvan
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id { get; set; }
        public string NameUser { get; set; }
        public string FamiliaUser { get; set; }
        public string Patronymic { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string UserLogin { get; set; }
        public string NamePlatform { get; set; }
    
        public virtual OnlinePlatforms OnlinePlatforms { get; set; }
    }
}
