using Mezeta.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mezeta.Infrastructure.Data.Configuration
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(CreateIngrediants());
        }

        private IEnumerable<Ingredient> CreateIngrediants()
        {
            List<Ingredient> ingrediants = new List<Ingredient>()
            {
                new Ingredient()
                { 
                  Id = 1,
                  Name = "Телешки шол",
                  Description = "Телешкото месо е предпочитано от любителите на здравословното хранене, защото има умерено съдържание" +
                  " на мазнини и е особено богато на витамин B12. Шолът се намира в горната задна част на тялото и е от по-крехките меса.",
                  ImageUrl = "https://img.freepik.com/free-photo/close-up-view-green-fresh-red-raw-meat-cutting-board-pepper-lemon-black-hammer-flower-green-black-mix-color-background_179666-46997.jpg?w=740&t=st=1709646615~exp=1709647215~hmac=ab69f1429ae8a1e621d31a36fd277ec3be3c2312d7b62863e05ab4b12fac6d4d"

                },

                  new Ingredient()
                {
                  Id = 2,
                  Name = "Свинска плешка",
                  Description = "Свинското месо е едно от най-вкусните и лесни за приготвяне. Има високо съдържание на витамини – В1, В2, B3, B6 и B12. " +
                  "Съдържа още витамини А, Е и Д. Изключително богато на протеини и минералите – фосфор, магнезий и цинк.",
                  ImageUrl="https://img.freepik.com/premium-photo/organic-uncooked-pork-belly-raw-bacon-meat-wooden-plate-with-thyme-wooden-background-top-view_89816-34988.jpg?w=740"
                },


            };

            return ingrediants;
        }
    }
}
