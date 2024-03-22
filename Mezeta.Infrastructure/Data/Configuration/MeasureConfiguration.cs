using Mezeta.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezeta.Infrastructure.Data.Configuration
{
    internal class MeasureConfiguration : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.HasData(CreateMeasures());
        }

        private IEnumerable<Measure> CreateMeasures()
        {
            List<Measure> measures = new List<Measure>()
            {
                new Measure()
                {
                  Id = 1,
                  Unit = "g"
                },

                 new Measure()
                {
                  Id = 2,
                  Unit = "kg"
                },

                new Measure()
                {
                  Id = 3,
                  Unit = "ml"
                },

            };

            return measures;
        }
    }
}
