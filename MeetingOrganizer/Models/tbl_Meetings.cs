//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeetingOrganizer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Meetings
    {
        public int MeetingID { get; set; }
        public string Topic { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<int> ParticipantID { get; set; }
    
        public virtual tbl_Participants tbl_Participants { get; set; }
    }
}