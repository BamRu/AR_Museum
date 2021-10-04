namespace ED_DB.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class test_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        UUID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "UniqueAttribute",
                                    new AnnotationValues(oldValue: null, newValue: "SQLite.CodeFirst.UniqueAttribute")
                                },
                            }),
                    })
                .PrimaryKey(t => t.UUID);
            
            CreateTable(
                "dbo.Placment",
                c => new
                    {
                        UUID = c.Int(nullable: false, identity: true),
                        UUID_Room = c.Int(),
                        UUID_Model = c.Int(nullable: false),
                        UUID_Position = c.Int(nullable: false),
                        UUID_Rotation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UUID)
                .ForeignKey("dbo.Room", t => t.UUID_Room)
                .Index(t => t.UUID_Room, name: "IX_Placment_UUID_Room");
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        UUID_Room = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "UniqueAttribute",
                                    new AnnotationValues(oldValue: null, newValue: "SQLite.CodeFirst.UniqueAttribute")
                                },
                            }),
                    })
                .PrimaryKey(t => t.UUID_Room);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        UUID = c.Int(nullable: false, identity: true),
                        x = c.Double(nullable: false),
                        y = c.Double(nullable: false),
                        z = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UUID);
            
            CreateTable(
                "dbo.Rotation",
                c => new
                    {
                        UUID = c.Int(nullable: false, identity: true),
                        w = c.Double(nullable: false),
                        x = c.Double(nullable: false),
                        y = c.Double(nullable: false),
                        z = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UUID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Placment", "UUID_Room", "dbo.Room");
            DropIndex("dbo.Placment", "IX_Placment_UUID_Room");
            DropTable("dbo.Rotation");
            DropTable("dbo.Position");
            DropTable("dbo.Room",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "UniqueAttribute", "SQLite.CodeFirst.UniqueAttribute" },
                        }
                    },
                });
            DropTable("dbo.Placment");
            DropTable("dbo.Model",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Name",
                        new Dictionary<string, object>
                        {
                            { "UniqueAttribute", "SQLite.CodeFirst.UniqueAttribute" },
                        }
                    },
                });
        }
    }
}
