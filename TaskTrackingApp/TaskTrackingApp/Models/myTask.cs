//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskTrackingApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class myTask
    {
        public int taskId { get; set; }
        public string taskTitle { get; set; }
        public string taskDetails { get; set; }
        public string assigneeName { get; set; }
        public string project { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }
}
