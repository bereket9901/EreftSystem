using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RequestTablesSeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.""RequestStatus""( ""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
                                                                 VALUES('Created', CURRENT_DATE, null),
                                                                       ('Approved', CURRENT_DATE, null),
                                                                       ('Rejected', CURRENT_DATE, null); 
 



                             ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
