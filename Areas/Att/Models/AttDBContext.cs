using EchoAttendance.Areas.Att.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EchoAttendance.Areas.Att.Models
{
    public class AttDBContext : DbContext
    {
        public AttDBContext() : base("ATTConnection") { }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceDetail> AttendanceDetails { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Site> Sites { get; set; }
    }
}