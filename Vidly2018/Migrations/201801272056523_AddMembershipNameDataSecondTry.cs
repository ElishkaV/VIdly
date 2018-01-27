namespace Vidly2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipNameDataSecondTry : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Monthly' WHERE Id = 2");
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE dbo.MembershipTypes SET MembershipName = 'Yearly' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
