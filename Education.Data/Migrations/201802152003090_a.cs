namespace Education.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Security.ApiUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Secret = c.String(),
                        AppId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Security.AuthToken",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Expiration = c.DateTime(nullable: false),
                        ApiUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Security.ApiUser", t => t.ApiUser_Id)
                .Index(t => t.ApiUser_Id);
            
            CreateTable(
                "Communication.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        Person_Id = c.Int(),
                        Reciver_Id = c.Int(),
                        Sender_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Security.Person", t => t.Person_Id)
                .ForeignKey("Security.Person", t => t.Reciver_Id)
                .ForeignKey("Security.Person", t => t.Sender_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Reciver_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "Security.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        ApiUser_Id = c.Int(),
                        Part_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Security.ApiUser", t => t.ApiUser_Id)
                .ForeignKey("Partition.Part", t => t.Part_Id)
                .Index(t => t.ApiUser_Id)
                .Index(t => t.Part_Id);
            
            CreateTable(
                "Partition.Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Partition.Section", t => t.Section_Id)
                .Index(t => t.Section_Id);
            
            CreateTable(
                "Partition.Section",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Partition.Part", "Section_Id", "Partition.Section");
            DropForeignKey("Security.Person", "Part_Id", "Partition.Part");
            DropForeignKey("Communication.Message", "Sender_Id", "Security.Person");
            DropForeignKey("Communication.Message", "Reciver_Id", "Security.Person");
            DropForeignKey("Communication.Message", "Person_Id", "Security.Person");
            DropForeignKey("Security.Person", "ApiUser_Id", "Security.ApiUser");
            DropForeignKey("Security.AuthToken", "ApiUser_Id", "Security.ApiUser");
            DropIndex("Partition.Part", new[] { "Section_Id" });
            DropIndex("Security.Person", new[] { "Part_Id" });
            DropIndex("Security.Person", new[] { "ApiUser_Id" });
            DropIndex("Communication.Message", new[] { "Sender_Id" });
            DropIndex("Communication.Message", new[] { "Reciver_Id" });
            DropIndex("Communication.Message", new[] { "Person_Id" });
            DropIndex("Security.AuthToken", new[] { "ApiUser_Id" });
            DropTable("Partition.Section");
            DropTable("Partition.Part");
            DropTable("Security.Person");
            DropTable("Communication.Message");
            DropTable("Security.AuthToken");
            DropTable("Security.ApiUser");
        }
    }
}
