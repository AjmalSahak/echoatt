namespace EchoAttendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceDetail",
                c => new
                    {
                        ADID = c.Int(nullable: false, identity: true),
                        AttID = c.Int(nullable: false),
                        ParticipantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ADID);
            
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        AttID = c.Int(nullable: false, identity: true),
                        SessionID = c.Int(nullable: false),
                        SiteID = c.Int(nullable: false),
                        ParticipantCount = c.Int(nullable: false),
                        FileAtt = c.String(),
                        ImageFile = c.String(),
                        VideoURL = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        DesID = c.Int(nullable: false, identity: true),
                        DesTitle = c.String(),
                    })
                .PrimaryKey(t => t.DesID);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        ParticipantName = c.String(),
                        FatherName = c.String(),
                        ContactNo = c.String(),
                        EmailID = c.String(),
                        SiteID = c.Int(nullable: false),
                        DesID = c.Int(nullable: false),
                        IsSessionOrganizer = c.Boolean(nullable: false),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipantID);
            
            CreateTable(
                "dbo.Program",
                c => new
                    {
                        ProgramID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                    })
                .PrimaryKey(t => t.ProgramID);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        SessionTopic = c.String(),
                        SessionDate = c.DateTime(nullable: false),
                        ProgramID = c.Int(nullable: false),
                        SiteID = c.Int(nullable: false),
                        PresentationFile = c.String(),
                    })
                .PrimaryKey(t => t.SessionID);
            
            CreateTable(
                "dbo.Site",
                c => new
                    {
                        SiteID = c.Int(nullable: false, identity: true),
                        SiteName = c.String(),
                        SiteCode = c.String(),
                        ProvinceID = c.Int(nullable: false),
                        EstablishmentDate = c.DateTime(),
                        IsHub = c.Boolean(nullable: false),
                        IsEchoSite = c.Boolean(nullable: false),
                        EmailID = c.String(),
                        EncodeID = c.String(),
                    })
                .PrimaryKey(t => t.SiteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Site");
            DropTable("dbo.Session");
            DropTable("dbo.Province");
            DropTable("dbo.Program");
            DropTable("dbo.Participant");
            DropTable("dbo.Designation");
            DropTable("dbo.Attendance");
            DropTable("dbo.AttendanceDetail");
        }
    }
}
