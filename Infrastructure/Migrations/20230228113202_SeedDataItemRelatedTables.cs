using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataItemRelatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.""MeasuringUnit""( ""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
                                                                        VALUES('Kg', CURRENT_DATE, null),
                                                                              ('Lt', CURRENT_DATE, null),
                                                                              ('pcs', CURRENT_DATE, null);

                                   INSERT INTO public.""ItemCategory""(""Name"", ""CreateDateTime"", ""ModifiedDateTime"")
                                                                        VALUES('የሼፍ ዕቃ', CURRENT_DATE, null),
                                                                              ('የባሬስታ ዕቃ', CURRENT_DATE, null);
                                INSERT INTO public.""Item""(""Name"", ""MeasuringUnitId"", ""UnitPrice"", ""CreateDateTime"", ""ModifiedDateTime"")
                                                                         VALUES('ስጋ-ለጥብስ', 1, 480, CURRENT_DATE, null),
                                                                                ('ስጋ-ለጥብስ ፍርፍር', 1, 480, CURRENT_DATE, null),        
                                                                                ('ስጋ-ለቦዘና', 1, 480, CURRENT_DATE, null),            
                                                                                ('በርበሬ', 1, 400, CURRENT_DATE, null),       
                                                                                ('እርጎ', 2, 80, CURRENT_DATE, null),     
                                                                                ('ዳቦ', 3, 6, CURRENT_DATE, null),     
                                                                                ('እንጀራ ነጭ', 3, 12, CURRENT_DATE, null),            
                                                                                ('ስትሮብሪ ሲሮፕ', 2, 600, CURRENT_DATE, null),
                                                                                ('ቸኮሌት ሲሮፕ', 2, 800, CURRENT_DATE, null),
                                                                                ('ክኖር', 3, 3, CURRENT_DATE, null),
                                                                                ('ማዮኒዝ', 2, 300, CURRENT_DATE, null),
                                                                                ('ካቻፕ', 2, 500, CURRENT_DATE, null),
                                                                                ('ቺዝ', 1, 500, CURRENT_DATE, null),
                                                                                ('ቢፍ', 1, 500, CURRENT_DATE, null),
                                                                                ('ማር', 1, 800, CURRENT_DATE, null),
                                                                                ('ዱቄት', 1, 60, CURRENT_DATE, null),
                                                                                ('ቺክን', 3, 1200, CURRENT_DATE, null),
                                                                                ('ዘይት', 2, 200, CURRENT_DATE, null),
                                                                                ('የገበታ ቅቤ', 1, 460, CURRENT_DATE, null),
                                                                                ('እንቁላል', 3, 12, CURRENT_DATE, null),
                                                                                ('መስታርድ', 1, 350, CURRENT_DATE, null),
                                                                                ('ቱና', 3, 80, CURRENT_DATE, null),
                                                                                ('ሚጥሚጣ', 1, 180, CURRENT_DATE, null),
                                                                                ('ሽንኩርት', 1, 30, CURRENT_DATE, null),
                                                                                ('ቲማቲም', 1, 30, CURRENT_DATE, null),
                                                                                ('ቃርያ', 1, 120, CURRENT_DATE, null),
                                                                                ('አቮካዶ', 1, 60, CURRENT_DATE, null),
                                                                                ('አቸቶ', 2, 90, CURRENT_DATE, null),
                                                                                ('ሶያ ሶስ', 1, 290, CURRENT_DATE, null),
                                                                                ('ቤኪንግ ፓዉደር', 1, 80, CURRENT_DATE, null),
                                                                                ('የአበሻ ቅቤ', 1,800, CURRENT_DATE, null),
                                                                                ('እስትሮበሪ ፍሬዉ', 1, 300, CURRENT_DATE, null),
                                                                                ('ሙዝ', 1, 60, CURRENT_DATE, null),
                                                                                ('ብስኩት', 3, 50, CURRENT_DATE, null),
                                                                                ('ሶፍት ኪችን', 3, 100, CURRENT_DATE, null),
                                                                                ('ድንች', 1, 30, CURRENT_DATE, null),
                                                                                ('ወተት', 2, 80, CURRENT_DATE, null),
                                                                                ('የተቀቀለ እንቁላል', 3, 15, CURRENT_DATE, null),
                                                                                ('የክለብ ስጋ', 1, 480, CURRENT_DATE, null),
                                                                                ('የግማሽ ክለብ ስጋ ', 1, 480, CURRENT_DATE, null), 
                                                                                ('ተቆሪጭ', 3, 30, CURRENT_DATE, null),
                                                                                ('የዱለት ስጋ', 1,500, CURRENT_DATE, null),
                                                                                ('የበርገር ስጋ', 1, 500, CURRENT_DATE, null),
                                                                                ('ቡና', 1, 450, CURRENT_DATE, null),
                                                                                ('ስኳር', 1, 90, CURRENT_DATE, null),
                                                                                ('ወተት', 2, 80, CURRENT_DATE, null),
                                                                                ('ሻይ ቅጠል-ብትን', 3, 40, CURRENT_DATE, null),
                                                                                ('ሻይ ቅጠል-የሚነከር', 3,50, CURRENT_DATE, null),
                                                                                ('ከኮካ', 3, 20, CURRENT_DATE, null),
                                                                                ('ሚሪንዳ', 3, 20, CURRENT_DATE, null),
                                                                                ('አማቦ ዉሃ', 3,20, CURRENT_DATE, null),
                                                                                ('የታሸገ  ዉሃ 1/2', 3, 10, CURRENT_DATE, null),
                                                                                ('ሶፍት ከስተመር', 3, 100, CURRENT_DATE, null);




            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
