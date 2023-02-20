using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               INSERT INTO public.""OrderStatus""(""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
                                    VALUES ('Created', CURRENT_DATE, null);
               INSERT INTO public.""OrderStatus""(""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
                                    VALUES ('Delivered', CURRENT_DATE, null);
               INSERT INTO public.""OrderStatus""(""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
                                    VALUES ('Canceled', CURRENT_DATE, null);
               INSERT INTO public.""Role""(""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
	                                VALUES ('Cashier', CURRENT_DATE, null);
               INSERT INTO public.""User""(""UserName"", ""Password"", ""Phone"", ""Email"", ""FirstName"", ""LastName"", ""RoleId"", ""CreateDateTime"", ""ModifiedDateTime"")
	                                VALUES ('aman.tedla', 'data.2020', '0912443352', null,'Amanuel', 'Tedla', '1', CURRENT_DATE, null);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
