using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UnyimeWebApp.Models;

public partial class UnyimeDbContext : DbContext
{
    public UnyimeDbContext()
    {
    }

    public UnyimeDbContext(DbContextOptions<UnyimeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<EntityReview> EntityReviews { get; set; }

    public virtual DbSet<Individual> Individuals { get; set; }

    public virtual DbSet<IndividualApplication> IndividualApplications { get; set; }

    public virtual DbSet<IndividualDonation> IndividualDonations { get; set; }

    public virtual DbSet<IndividualExperience> IndividualExperiences { get; set; }

    public virtual DbSet<IndividualFavourite> IndividualFavourites { get; set; }

    public virtual DbSet<IndividualReview> IndividualReviews { get; set; }

    public virtual DbSet<Initiative> Initiatives { get; set; }

    public virtual DbSet<InitiativeMedium> InitiativeMedia { get; set; }

    public virtual DbSet<InitiativeNeed> InitiativeNeeds { get; set; }

    public virtual DbSet<Sdg> Sdgs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.EntityId).HasName("PK__Entity__DEC178F8F748B331");

            entity.ToTable("Entity");

            entity.Property(e => e.EntityId).HasColumnName("entityID");
            entity.Property(e => e.About).HasColumnName("about");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .HasColumnName("emailAddress");
            entity.Property(e => e.EntityName).HasColumnName("entityName");
            entity.Property(e => e.EntityPasswordHash)
                .HasMaxLength(50)
                .HasColumnName("entityPasswordHash");
            entity.Property(e => e.EntityType)
                .HasMaxLength(100)
                .HasColumnName("entityType");
            entity.Property(e => e.EntityUserName)
                .HasMaxLength(200)
                .HasColumnName("entityUserName");
            entity.Property(e => e.LocationCity)
                .HasMaxLength(200)
                .HasColumnName("locationCity");
            entity.Property(e => e.LocationContinent)
                .HasMaxLength(200)
                .HasColumnName("locationContinent");
            entity.Property(e => e.LocationCountry)
                .HasMaxLength(200)
                .HasColumnName("locationCountry");
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber1");
            entity.Property(e => e.PhoneNumber2)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber2");
            entity.Property(e => e.Website).HasColumnName("website");

            entity.HasMany(d => d.Sdgs).WithMany(p => p.Entities)
                .UsingEntity<Dictionary<string, object>>(
                    "EntitySdg",
                    r => r.HasOne<Sdg>().WithMany()
                        .HasForeignKey("SdgId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EntitySDG__sdgID__44FF419A"),
                    l => l.HasOne<Entity>().WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EntitySDG__entit__440B1D61"),
                    j =>
                    {
                        j.HasKey("EntityId", "SdgId").HasName("PK__EntitySD__3CFE67E9FFA6A0CB");
                        j.ToTable("EntitySDG");
                        j.IndexerProperty<int>("EntityId").HasColumnName("entityID");
                        j.IndexerProperty<int>("SdgId").HasColumnName("sdgID");
                    });
        });

        modelBuilder.Entity<EntityReview>(entity =>
        {
            entity.HasKey(e => e.EntityReviewId).HasName("PK__EntityRe__EB5C040260CD9A87");

            entity.ToTable("EntityReview");

            entity.Property(e => e.EntityReviewId).HasColumnName("entityReviewID");
            entity.Property(e => e.EntityId).HasColumnName("entityID");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review).HasColumnName("review");

            entity.HasOne(d => d.Entity).WithMany(p => p.EntityReviews)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__EntityRev__entit__693CA210");
        });

        modelBuilder.Entity<Individual>(entity =>
        {
            entity.HasKey(e => e.IndividualId).HasName("PK__Individu__813582265CC47FB1");

            entity.ToTable("Individual");

            entity.Property(e => e.IndividualId).HasColumnName("individualID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(200)
                .HasColumnName("emailAddress");
            entity.Property(e => e.IndividualPasswordHash)
                .HasMaxLength(50)
                .HasColumnName("individualPasswordHash");
            entity.Property(e => e.IndividualUserName)
                .HasMaxLength(200)
                .HasColumnName("individualUserName");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .HasColumnName("lastName");
            entity.Property(e => e.LinkedinUsername)
                .HasMaxLength(200)
                .HasColumnName("linkedinUsername");
            entity.Property(e => e.LocationCity)
                .HasMaxLength(200)
                .HasColumnName("locationCity");
            entity.Property(e => e.LocationContinent)
                .HasMaxLength(200)
                .HasColumnName("locationContinent");
            entity.Property(e => e.LocationCountry)
                .HasMaxLength(200)
                .HasColumnName("locationCountry");
            entity.Property(e => e.OtherNames)
                .HasMaxLength(200)
                .HasColumnName("otherNames");
            entity.Property(e => e.PersonalWebsite)
                .HasMaxLength(200)
                .HasColumnName("personalWebsite");
            entity.Property(e => e.PhoneNumber1)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber1");
            entity.Property(e => e.PhoneNumber2)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber2");

            entity.HasMany(d => d.Sdgs).WithMany(p => p.Individuals)
                .UsingEntity<Dictionary<string, object>>(
                    "IndividualSdg",
                    r => r.HasOne<Sdg>().WithMany()
                        .HasForeignKey("SdgId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Individua__sdgID__412EB0B6"),
                    l => l.HasOne<Individual>().WithMany()
                        .HasForeignKey("IndividualId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Individua__indiv__403A8C7D"),
                    j =>
                    {
                        j.HasKey("IndividualId", "SdgId").HasName("PK__Individu__630A9D375ABDE2AF");
                        j.ToTable("IndividualSDG");
                        j.IndexerProperty<int>("IndividualId").HasColumnName("individualID");
                        j.IndexerProperty<int>("SdgId").HasColumnName("sdgID");
                    });
        });

        modelBuilder.Entity<IndividualApplication>(entity =>
        {
            entity.HasKey(e => e.IndividualApplicationId).HasName("PK__Individu__0944669A7C84D6E7");

            entity.ToTable("IndividualApplication");

            entity.Property(e => e.IndividualApplicationId).HasColumnName("individualApplicationID");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(50)
                .HasColumnName("applicationStatus");
            entity.Property(e => e.DateApplied).HasColumnName("dateApplied");
            entity.Property(e => e.DateRejected).HasColumnName("dateRejected");
            entity.Property(e => e.DateUnderReview).HasColumnName("dateUnderReview");
            entity.Property(e => e.Field)
                .HasMaxLength(200)
                .HasColumnName("field");
            entity.Property(e => e.IndividualId).HasColumnName("individualID");
            entity.Property(e => e.InitiativeId).HasColumnName("initiativeID");
            entity.Property(e => e.InitiativeNeedId).HasColumnName("initiativeNeedID");

            entity.HasOne(d => d.Individual).WithMany(p => p.IndividualApplications)
                .HasForeignKey(d => d.IndividualId)
                .HasConstraintName("FK__Individua__indiv__59063A47");

            entity.HasOne(d => d.Initiative).WithMany(p => p.IndividualApplications)
                .HasForeignKey(d => d.InitiativeId)
                .HasConstraintName("FK__Individua__initi__59FA5E80");

            entity.HasOne(d => d.InitiativeNeed).WithMany(p => p.IndividualApplications)
                .HasForeignKey(d => d.InitiativeNeedId)
                .HasConstraintName("FK__Individua__initi__5AEE82B9");
        });

        modelBuilder.Entity<IndividualDonation>(entity =>
        {
            entity.HasKey(e => e.IndividualDonationId).HasName("PK__Individu__79E9E738A1CAED03");

            entity.ToTable("IndividualDonation");

            entity.Property(e => e.IndividualDonationId).HasColumnName("individualDonationID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .HasColumnName("currency");
            entity.Property(e => e.DonationDate).HasColumnName("donationDate");
            entity.Property(e => e.IndividualId).HasColumnName("individualID");
            entity.Property(e => e.InitiativeId).HasColumnName("initiativeID");

            entity.HasOne(d => d.Individual).WithMany(p => p.IndividualDonations)
                .HasForeignKey(d => d.IndividualId)
                .HasConstraintName("FK__Individua__indiv__4BAC3F29");

            entity.HasOne(d => d.Initiative).WithMany(p => p.IndividualDonations)
                .HasForeignKey(d => d.InitiativeId)
                .HasConstraintName("FK__Individua__initi__4CA06362");
        });

        modelBuilder.Entity<IndividualExperience>(entity =>
        {
            entity.HasKey(e => e.IndividualExperienceId).HasName("PK__Individu__216C1BC719BF1C35");

            entity.ToTable("IndividualExperience");

            entity.Property(e => e.IndividualExperienceId).HasColumnName("individualExperienceID");
            entity.Property(e => e.ApplicationId).HasColumnName("applicationID");
            entity.Property(e => e.IndividualId).HasColumnName("individualID");

            entity.HasOne(d => d.Application).WithMany(p => p.IndividualExperiences)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__Individua__appli__628FA481");

            entity.HasOne(d => d.Individual).WithMany(p => p.IndividualExperiences)
                .HasForeignKey(d => d.IndividualId)
                .HasConstraintName("FK__Individua__indiv__619B8048");
        });

        modelBuilder.Entity<IndividualFavourite>(entity =>
        {
            entity.HasKey(e => e.IndividualFavouriteId).HasName("PK__Individu__1760ECE054752CF8");

            entity.ToTable("IndividualFavourite");

            entity.Property(e => e.IndividualFavouriteId).HasColumnName("individualFavouriteID");
            entity.Property(e => e.IndividualId).HasColumnName("individualID");
            entity.Property(e => e.InitiativeId).HasColumnName("initiativeID");

            entity.HasOne(d => d.Individual).WithMany(p => p.IndividualFavourites)
                .HasForeignKey(d => d.IndividualId)
                .HasConstraintName("FK__Individua__indiv__4F7CD00D");

            entity.HasOne(d => d.Initiative).WithMany(p => p.IndividualFavourites)
                .HasForeignKey(d => d.InitiativeId)
                .HasConstraintName("FK__Individua__initi__5070F446");
        });

        modelBuilder.Entity<IndividualReview>(entity =>
        {
            entity.HasKey(e => e.IndividualReviewId).HasName("PK__Individu__FABA6C3C30CDF764");

            entity.ToTable("IndividualReview");

            entity.Property(e => e.IndividualReviewId).HasColumnName("individualReviewID");
            entity.Property(e => e.IndividualExperienceId).HasColumnName("individualExperienceID");
            entity.Property(e => e.IndividualId).HasColumnName("individualID");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review).HasColumnName("review");

            entity.HasOne(d => d.IndividualExperience).WithMany(p => p.IndividualReviews)
                .HasForeignKey(d => d.IndividualExperienceId)
                .HasConstraintName("FK__Individua__indiv__66603565");

            entity.HasOne(d => d.Individual).WithMany(p => p.IndividualReviews)
                .HasForeignKey(d => d.IndividualId)
                .HasConstraintName("FK__Individua__indiv__656C112C");
        });

        modelBuilder.Entity<Initiative>(entity =>
        {
            entity.HasKey(e => e.InitiativeId).HasName("PK__Initiati__80DA7576A4E3A38F");

            entity.ToTable("Initiative");

            entity.Property(e => e.InitiativeId).HasColumnName("initiativeID");
            entity.Property(e => e.CommencementDate).HasColumnName("commencementDate");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Eligibility).HasColumnName("eligibility");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.InitiativeDescription).HasColumnName("initiativeDescription");
            entity.Property(e => e.InitiativeName).HasColumnName("initiativeName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LocationCity)
                .HasMaxLength(200)
                .HasColumnName("locationCity");
            entity.Property(e => e.LocationContinent)
                .HasMaxLength(200)
                .HasColumnName("locationContinent");
            entity.Property(e => e.LocationCountry)
                .HasMaxLength(200)
                .HasColumnName("locationCountry");
            entity.Property(e => e.SdgId).HasColumnName("sdgID");
            entity.Property(e => e.Sdgs).HasColumnName("sdgs");

            entity.HasOne(d => d.Sdg).WithMany(p => p.Initiatives)
                .HasForeignKey(d => d.SdgId)
                .HasConstraintName("FK__Initiativ__sdgID__3D5E1FD2");

            entity.HasMany(d => d.SdgsNavigation).WithMany(p => p.InitiativesNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "InitiativeSdg",
                    r => r.HasOne<Sdg>().WithMany()
                        .HasForeignKey("SdgId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Initiativ__sdgID__48CFD27E"),
                    l => l.HasOne<Initiative>().WithMany()
                        .HasForeignKey("InitiativeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Initiativ__initi__47DBAE45"),
                    j =>
                    {
                        j.HasKey("InitiativeId", "SdgId").HasName("PK__Initiati__62E56A67A7385C3D");
                        j.ToTable("InitiativeSDG");
                        j.IndexerProperty<int>("InitiativeId").HasColumnName("initiativeID");
                        j.IndexerProperty<int>("SdgId").HasColumnName("sdgID");
                    });
        });

        modelBuilder.Entity<InitiativeMedium>(entity =>
        {
            entity.HasKey(e => e.InitiativeMediaId).HasName("PK__Initiati__E5796415148AC874");

            entity.Property(e => e.InitiativeMediaId).HasColumnName("initiativeMediaID");
            entity.Property(e => e.AlternativeText).HasColumnName("alternativeText");
            entity.Property(e => e.InitiativeId).HasColumnName("initiativeID");
            entity.Property(e => e.MediaFormat)
                .HasMaxLength(50)
                .HasColumnName("mediaFormat");
            entity.Property(e => e.MediaLink).HasColumnName("mediaLink");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Initiative).WithMany(p => p.InitiativeMedia)
                .HasForeignKey(d => d.InitiativeId)
                .HasConstraintName("FK__Initiativ__initi__534D60F1");
        });

        modelBuilder.Entity<InitiativeNeed>(entity =>
        {
            entity.HasKey(e => e.InitiativeNeedId).HasName("PK__Initiati__591B9ABC9DEA986E");

            entity.ToTable("InitiativeNeed");

            entity.Property(e => e.InitiativeNeedId).HasColumnName("initiativeNeedID");
            entity.Property(e => e.InitiativeId).HasColumnName("initiativeID");
            entity.Property(e => e.NeedDetails).HasColumnName("needDetails");
            entity.Property(e => e.NeedType)
                .HasMaxLength(200)
                .HasColumnName("needType");

            entity.HasOne(d => d.Initiative).WithMany(p => p.InitiativeNeeds)
                .HasForeignKey(d => d.InitiativeId)
                .HasConstraintName("FK__Initiativ__initi__5629CD9C");
        });

        modelBuilder.Entity<Sdg>(entity =>
        {
            entity.HasKey(e => e.SdgId).HasName("PK__SDG__23F1F11FF4EAB946");

            entity.ToTable("SDG");

            entity.Property(e => e.SdgId).HasColumnName("sdgID");
            entity.Property(e => e.Color)
                .HasMaxLength(1)
                .HasColumnName("color");
            entity.Property(e => e.LogoLink).HasColumnName("logoLink");
            entity.Property(e => e.LongForm)
                .HasMaxLength(200)
                .HasColumnName("longForm");
            entity.Property(e => e.SdgNumber).HasColumnName("sdgNumber");
            entity.Property(e => e.ShortForm)
                .HasMaxLength(50)
                .HasColumnName("shortForm");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
