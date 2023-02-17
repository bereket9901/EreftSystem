using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				INSERT INTO public.""Category""(""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
					VALUES ('ቁርስ', CURRENT_DATE, null);

				INSERT INTO public.""Group""(""CatagoryId"", ""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
					VALUES (1, 'ቁርስ', CURRENT_DATE, null);

				INSERT INTO public.""MenuItem""(""Name"", ""UnitPrice"", ""GroupId"", ""CreateDateTime"", ""ModifiedDateTime"")
					VALUES ('ኮንቲነንታል', 164, 1, CURRENT_DATE, null),
							('ኦምሌት', 127, 1, CURRENT_DATE, null),
							('ዕንቁላል ፍርፍር', 97, 1, CURRENT_DATE, null),
							('ኖርማል ፉል', 84, 1, CURRENT_DATE, null),
							('ስፔሻል ፉል', 100, 1, CURRENT_DATE, null),
							('ጨጨብሳ', 75, 1, CURRENT_DATE, null),
							('ስፔሻል ጨጨብሳ', 90, 1, CURRENT_DATE, null),
							('ቡላ ገንፎ', 95, 1, CURRENT_DATE, null),
							('ቂንጬ', 95, 1, CURRENT_DATE, null),
							('ስፔሻል ፈጢራ', 110, 1, CURRENT_DATE, null),
							('እረፍት ፈጢራ', 130, 1, CURRENT_DATE, null),
							('ቺፕስ', 55, 1, CURRENT_DATE, null),
							('ጭማሪ ዳቦ', 10, 1, CURRENT_DATE, null),
							('ጭማሪ ቺዝ', 10, 1, CURRENT_DATE, null)		
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
