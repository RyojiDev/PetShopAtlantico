using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShopAtlantico.Domain;
using PetShopAtlantico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopAtlantico.DataBaseAccess.Entity.Mappings
{
    public class PetAccomodationMap : IEntityTypeConfiguration<PetAccomodation>
    {
        public void Configure(EntityTypeBuilder<PetAccomodation> builder)
        {
            builder.ToTable("PetAccomodations");
            builder.HasKey(x => x.PetAccomodationId);

            builder.Property(x => x.PetAccomodationId).HasColumnName("PetAccomodationId");
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.Available).HasColumnName("Available");
            builder.Property(x => x.AccommodationStatus).HasColumnName("AccommodationStatus");

            builder.Ignore(x => x.Pet);

            builder.HasData(DataFillAccomodation());
        }

        private IList<PetAccomodation> DataFillAccomodation()
        {
            return new List<PetAccomodation>
            {
                new PetAccomodation()
                {
                     PetAccomodationId = 1,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 1",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 2,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 2",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 3,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 3",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 4,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 4",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 5,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 5",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 6,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 6",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 7,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 7",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 8,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 8",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 9,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 9",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 10,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 10",
                     Available = true
                },
                new PetAccomodation()
                {
                     PetAccomodationId = 11,
                     AccommodationStatus = AccommodationStatus.Free,
                     Name = "Alojamento num 11",
                     Available = true
                }
            };
        }
    }
}
