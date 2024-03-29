using Mezeta.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mezeta.Infrastructure.Data.Configuration
{
    internal class SpiceConfiguration : IEntityTypeConfiguration<Spice>
    {
        public void Configure(EntityTypeBuilder<Spice> builder)
        {
            builder.HasData(CreateSpices());
        }

        private IEnumerable<Spice> CreateSpices()
        {
            List<Spice> spices = new List<Spice>()
            {
                new Spice()
                { 
                  Id = 1,
                  Name = "Нитритна сол",
                  Description = "Смес от нейодирана изпарена кухненска сол и натриев нитрит." +
                  "Солта за консервиране предпазва месото от загуба на естествения му червено-розов цвят," +
                  " но преди всичко предпазва хранителните продукти от развитието на нежелани микроби," +
                  " главно бактериите, които произвеждат ботулиновия токсин.",
                  ImageUrl="https://img.freepik.com/free-photo/spoon-heap-salt-table_144627-11035.jpg?t=st=1709647024~exp=1709650624~hmac=a23d4b5ef03f7d5d15c1d648d6985dea830de19ac4a5b0dac2d6552e43f8ea5b&w=1380"
                },

                new Spice()
                { 
                   Id = 2,
                   Name = "Витамин Ц на прах",
                   Description = "Използва се и като натурален консервант, тъй като има свойството да забавя окислителните процеси.",
                   ImageUrl="https://img.freepik.com/free-photo/top-view-arrangement-with-spoon-citrus_23-2148329218.jpg?t=st=1709647433~exp=1709651033~hmac=717489b46dc56b6650c45511586ffddb720f108f7dfbb04aaa5a2e0384458cd7&w=1380"
                },

                new Spice()
                { 
                  Id = 3,
                  Name = "Черен пипер",
                  Description = "\"Царят на подправките\" се е доказал като един от най-забележителните фактори, влияещи върху човешката култура в историята." +
                  "Черният пипер е една от най-използваните подправки в широка гама ястия готвени ястия - месо, зеленчуци, супи, дори десерти. " +
                  "За да запази аромата си и вкуса си, той обикновено се смила непосредствено преди добавяне в ястието.",
                  ImageUrl="https://img.freepik.com/free-photo/closeup-shot-spoon-black-pepper-seeds-table_181624-57747.jpg?t=st=1709647103~exp=1709650703~hmac=6cae401b6145a848e2e4c707a8318a335c9e41d4ca6cf984b9b9ea8d1630744a&w=1380"

                },

                new Spice()
                {
                  Id = 4,
                  Name = "Кимион",
                  Description = "От времето на египетските фараони, през Средновековието та чак до ден днешен кимионът е една от най-известните подправки," +
                  " които намират широко приложение в кулинарията. Кимионът се отличава с доста силна миризма и специфичен натрапчив вкус," +
                  " който е изключително подходящ за приготвянето на месни ястия. В наши дни, кимионът редовно се прибавя към различни колбаси от" +
                  " млени и кълцани меса, както и към домашни наденици и суджуци.",
                  ImageUrl="https://img.freepik.com/free-photo/dry-fennel_501050-341.jpg?t=st=1709647257~exp=1709650857~hmac=87727d84031211c9072f2a00bef13844cd414578eecf33f9df2ffb392db97754&w=740"
                },

                 new Spice()
                {
                  Id = 5,
                  Name = "Захар",
                  Description = "Захарта спомага за привличане на добрите бактерии и за зреенето на сурово-сушените колбаси",
                  ImageUrl="https://img.freepik.com/free-photo/world-diabetes-day-sugar-wooden-bowl-dark-surface_1150-26666.jpg?t=st=1711700263~exp=1711703863~hmac=7df68aca69e0e19008e6359acd2ec66925e493b3e157e9ed703f2a82544ca3b1&w=1380"
                }

            };

            return spices;
        }
    }
}
