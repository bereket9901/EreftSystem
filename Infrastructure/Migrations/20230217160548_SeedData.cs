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
					VALUES ('ቁርስ', CURRENT_DATE, null),
                           ('ምሳ', CURRENT_DATE, null),
                           ('መጠጥ', CURRENT_DATE, null);

				INSERT INTO public.""Group""(""CatagoryId"", ""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
					VALUES (1, 'ቁርስ', CURRENT_DATE, null),
						   (2, 'ራፕ', CURRENT_DATE, null),
						   (2, 'ሳንድዊች', CURRENT_DATE, null),
						   (2, 'የሀበሻ ምግቦች', CURRENT_DATE, null),
						   (3, 'እርጎ', CURRENT_DATE, null),
						   (3, 'ትኩስ መጠጥ', CURRENT_DATE, null),
						   (3, 'አይስድ መጠጥ', CURRENT_DATE, null),
						   (3, 'ውሃ እና ለስላሳ', CURRENT_DATE, null);

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
							('ጭማሪ ቺዝ', 10, 1, CURRENT_DATE, null),
							('ቺክን ራፕ',164 , 2, CURRENT_DATE, null),
							('ቱና ራፕ',150 , 2, CURRENT_DATE, null),
							('አቮካዶ ቺክን ራፕ',166 , 2, CURRENT_DATE, null),
							('ክለብ ሳንድዊች',210 , 3, CURRENT_DATE, null),
							('ግማሽ  ክለብ ሳንድዊች',120 , 3, CURRENT_DATE, null),
							('ስፔሻል ቺክን ሳንድዊች',200 , 3, CURRENT_DATE, null),
							('ቱና ሳንድዊች',148 , 3, CURRENT_DATE, null),
							('ሳንድዊች',149 , 3, CURRENT_DATE, null),
							('እንቁላል ሳንድዊች',137 , 3, CURRENT_DATE, null),
							('ተጋቢኖ',110 , 4, CURRENT_DATE, null),
							('ቦዘና',156 , 4, CURRENT_DATE, null),
							('ቋንጣ ፍርፍር',161 , 4, CURRENT_DATE, null),
							('ጥብስ ፍርፍር',164 , 4, CURRENT_DATE, null),
							('ፍርፍር በቅቤ',110 , 4, CURRENT_DATE, null),
							('የጾም ፍርፍር',100 , 4, CURRENT_DATE, null),
							('ዱለት',116 , 4, CURRENT_DATE, null),
							('ጥብስ',228 , 4, CURRENT_DATE, null),
							('ሽሮ በቅቤ',120 , 4, CURRENT_DATE, null),
							('ኖርማል እርጎ',50, 5, CURRENT_DATE, null),
							('ፍሌቨርድ እርጎ',60, 5, CURRENT_DATE, null),
							('ስፔሻል እርጎ',60, 5, CURRENT_DATE, null),
							('ኤስፕረሶ',25, 6, CURRENT_DATE, null),
							('አሜሪካኖ',25, 6, CURRENT_DATE, null),
							('ስፕሪስ ሻይ',25, 6, CURRENT_DATE, null),
							('ማኪያቶ',25, 6, CURRENT_DATE, null),
							('የጀበና ቡና',15, 6, CURRENT_DATE, null),
							('ሻይ',20, 6, CURRENT_DATE, null),
							('ዝንጅብል ሻይ',25, 6, CURRENT_DATE, null),
							('ሃቢስከስ ሻይ',25, 6, CURRENT_DATE, null),
							('ስፔሻል ሻይ',30, 6, CURRENT_DATE, null),
							('ወተት',30, 6, CURRENT_DATE, null),
							('ካፑቺኖ',40, 6, CURRENT_DATE, null),
							('ብርቱካን ሻይ',30, 6, CURRENT_DATE, null),
							('ለውዝ ሻይ',30, 6, CURRENT_DATE, null),
							('የማሽን ቡና',25, 6, CURRENT_DATE, null),
							('አይስድ ቡና',50, 7, CURRENT_DATE, null),
							('አይስድ ሻይ',40, 7, CURRENT_DATE, null),
							('አይስድ ላቴ',50, 7, CURRENT_DATE, null),
							('ለስላሳ(1/2Lt)',30, 8, CURRENT_DATE, null),
							('ውሃ(1/2Lt)',15, 8, CURRENT_DATE, null),
							('ውሃ(1Lt)',20, 8, CURRENT_DATE, null);
							
 
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
