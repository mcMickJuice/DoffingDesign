using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DoffingDesign.DAL.Secrets;

namespace DoffingDesign.DAL.EntityModels
{
    public class DoffingDotComModel : DbContext,IDoffingDotComModel
    {
        // Your context has been configured to use a 'DoffingDotComModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DoffingDesign.DAL.DoffingDotComModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DoffingDotComModel' 
        // connection string in the application configuration file.
        public DoffingDotComModel(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        internal DoffingDotComModel()
            : this(DefaultDatabaseInfo.ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ProjectId");

            modelBuilder.Entity<ProjectTemplate>()
                .HasMany(p => p.Projects)
                .WithRequired(p => p.ProjectTemplate);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.ProjectItems)
                .WithOptional(p => p.Project)
                .Map(p => p.MapKey("Project_Id"))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProjectItem>()
                .HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ProjectItemId");

            modelBuilder.Entity<ProjectTemplate>()
                .HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ProjectTemplateId");

            modelBuilder.Entity<ThirdPartySiteInfo>()
                .HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ThirdPartySiteInfoId");

            modelBuilder.Entity<ContactInfo>()
                .HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ContactInfoId");
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectItem> ProjectItems { get; set; }
        public virtual DbSet<ProjectTemplate> ProjectTemplates { get; set; }
        public virtual DbSet<ThirdPartySiteInfo> ThirdPartySiteInfos { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
    }
}