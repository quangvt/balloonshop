using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BalloonShop.Domain.Concrete
{
    public class AppDbContext : DbContext, IDbContext 
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AppDbContext() : base("name=balloonshop")
        {
        }
        
        /// <summary>
        /// DB Entry List for Table
        /// </summary>
        public DbSet<Department> Department { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Product> Product { get; set; }
        //public DbSet<Cart> Cart { get; set; }
        //public DbSet<ShippingDetails> ShippingDetails { get; set; }

        /// <summary>
        /// DB Entry List for View
        /// </summary>
        public DbSet<DepartmentViewInfo> DepartmentViewInfo { get; set; }

        // Store Procedure and Table-value Function
        // ...
        // TODO: detach this from creating this table in db
        /// <summary>
        /// DB Entry List for Store Procedure or Table-value Function
        /// </summary>
        public DbSet<CategoryViewInfo> CategoryViewInfo { get; set; }

        /// <summary>
        /// Configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region sample
            //modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            // (2nd) Modal Builder: chain multiple methods for a single property together.
            //   This chaining of methods is called the Fluent API.
            //            modelBuilder.Entity<Person>().Property(p => p.FirstName)
            //              .HasMaxLength(30);
            //            modelBuilder.Entity<Person>().Property(p => p.LastName)
            //              .HasMaxLength(30);
            //            modelBuilder.Entity<Person>().Property(p => p.MiddleName)
            //              .HasMaxLength(1)
            //              .IsFixedLength()
            //              .IsUnicode(false);

            // (3rd) Configuration Class
            //modelBuilder.Configurations.Add(new DepartmentMap());
            #endregion sample

            // (1st Method) Custom Convention => Need change to specific class
            //     inherits from the Convention base class, override the constructor, then use the
            //     same preceding code, call the Properties method of the Convention class instead
            //     of modelBuilder
            //modelBuilder.Properties<string>()
            //    .Configure(config => config.IsUnicode(false));

            // Global setting conventions
            modelBuilder.Conventions
                .Add(new AppConvention());

            // Turn off OnCascadeDelete
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions
                .Remove<ManyToManyCascadeDeleteConvention>();
            
            // Add Configuration Class
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new DepartmentViewInfoMap());
            modelBuilder.Configurations.Add(new CategoryViewInfoMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }

    // (2nd Method) Custom Convention
    /// <summary>
    /// Global Conventions
    /// </summary>
    class AppConvention : Convention
    {
        public AppConvention()
        {
            //Properties<string>()
            //    .Configure(config => config.IsUnicode(false));
            Properties<decimal>()
                .Configure(config => config.HasPrecision(15, 3));
        }
    }

    /* Using Configuration Class Method */
    class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            Property(p => p.DepartmentId)
                .IsRequired();
            Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();
            Property(p => p.Description)
                .HasMaxLength(500);
            //Property(p => p.Categories) // Error
            HasMany(p => p.Categories)
                .WithRequired()
                .HasForeignKey(ph => ph.DepartmentId);
        }
    }

    class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            Property(p => p.CategoryId)
                .IsRequired();
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            Property(p => p.Description)
                .HasMaxLength(500);
        }
    }

    class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            Property(p => p.FirstName)
                .HasMaxLength(20)
                .IsRequired();
            Property(p => p.LastName)
                .HasMaxLength(20)
                .IsRequired();
            Ignore(p => p.FullName);

        }
    }

    class AddressMap : ComplexTypeConfiguration<Address>
    {
        public AddressMap()
        {
            Property(p => p.Street)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Street");
        }
    }

    class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Apply DML by Store Procedure
            MapToStoredProcedures();
            //MapToStoredProcedures(config =>
            //{
            //    config.Delete(
            //        procConfig =>
            //        {
            //            procConfig.HasName("CompanyDelete");
            //            procConfig.Parameter(company =>
            //                company.CompanyId, "companyId");
            //        });
            //    config.Insert(procConfig =>
            //        procConfig.HasName("CompanyInsert"));
            //    config.Update(procConfig =>
            //        procConfig.HasName("CompanyUpdate"));
            //});
        

                Property(p => p.Name)
                .IsRequired();
            Property(p => p.Description)
                .IsRequired();
            Property(p => p.Price)
                .IsRequired();
            Property(p => p.Category)
                .IsRequired();

        }
    }

    // ViewInfo
    class DepartmentViewInfoMap : 
        EntityTypeConfiguration<DepartmentViewInfo>
    {
        public DepartmentViewInfoMap()
        {
            HasKey(p => p.DeptId);
            ToTable("DepartmentViewInfo");
        }
    }

    class CategoryViewInfoMap :
        EntityTypeConfiguration<CategoryViewInfo>
    {
        public CategoryViewInfoMap()
        {
            HasKey(p => p.CategoryId);
            //ToTable("CategoryViewInfo"); //Use this when Table Name is different
        }
    }

    /* Sample
    // (3rd) Configuration Class: Prefer way to config entity
    //public class DepartmentMap : EntityTypeConfiguration<Department>
    //{
    //    public DepartmentMap()
    //    {
    //        Property(p => p.Name)
    //            .HasMaxLength(10);

    // Other:
    // In Entity:
    //   public decimal HeightInFeet { get; set; }
    //   public byte[] Photo { get; set; }
    // In Configuration Class:
    //   Property(p => p.HeightInFeet)
    //      .HasPrecision(4, 2);
    // => decimal(4,2) in db
    //   Property(p => p.Photo)
    //      .IsVariableLength()
    //      .HasMaxLength(4000);
    // => varbinary(4000) in db

    // Nullable
    // (1st) Datetime?
    // (2nd) IsOptional in Fluent API

    // HasColumnType for notavailable column type
    //   this only using in Class Define (not in Fluent API or Attribute(constant))
    //   HasColumnName, HasColumnOrder

    //    HasMany(p =>p.Phones)
    //.WithRequired() => Phone number must has a person
    //.HasForeignKey(ph =>ph.PersonId); => change name of col: Person_PersonId to PersonId

    // Many to Many
//    HasMany(p =>p.Companies)
//      .WithMany(c =>c.Persons)
//      .Map(m =>
//    {
//        m.MapLeftKey("PesonId");
//        m.MapRightKey("CompanyId");
//    });


    //    }
    //}

//    public class PersonTypeMap : EntityTypeConfiguration<PersonType>
//    {
//          publicPersonTypeMap()
//        {
//            HasMany(pt => pt.Persons)
//            .WithOptional(p => p.PersonType)
//            .HasForeignKey(p => p.PersonTypeId)
//            .WillCascadeOnDelete(false);
//        }
//    }
*/


}
