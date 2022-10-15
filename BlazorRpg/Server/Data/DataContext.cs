using BlazorRpg.Shared.Models.Buildings;
using BlazorRpg.Shared.Models.Resources;

namespace BlazorRpg.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<SecondTestModel> SecondTestModels { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CurrentCombatant> CurrentCombatants { get; set; }
        public DbSet<ResourceProfile> ResourceProfiles { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingComponent> BuildingComponents { get; set; }
        public DbSet<BuildingJoinBuildingComponent> BuildingJoinBuildingComponents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("BlazorRpgConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<StudentGrade>()
    //                     .HasKey(s => new { s.GradeId, s.StudentId });
    //        var students = new[]
    //        {
    // new Student{Id=1, Name="John"},
    // new Student{Id=2, Name="Alex"},
    // new Student{Id=3, Name="Tom"}
    //}

    //var grades = new[]
    //{
    // new Grade{Id=1, Grade=5},
    // new Grade{Id=2, Grade=6}
    //}

    //var studentGrades = new[]
    //{
    // new StudentGrade{GradeId=1, StudentId=1},
    // new StudentGrade{GradeId=2, StudentId=2},

    // // Student 3 relates to grade 1 
    // new StudentGrade{GradeId=1, StudentId=3}
    //}

    //modelBuilder.Entity<Student>().HasData(stdudents[0], students[1], students[2]);
    //        modelBuilder.Entity<Grade>().HasData(grades[0], grades[1]);
    //        modelBuilder.Entity<StudentGrade>().HasData(studentGrades[0], studentGrades[1], studentGrades[2]);

    //        base.OnModelCreating(modelBuilder);
    //    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>()
                .HasOne(t => t.SecondTestModel)
                .WithMany().OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TestModel>().HasData(
                new TestModel { Id = 1, Name = "T1", SecondTestModelId = 1 },
                new TestModel { Id = 2, Name = "T2", SecondTestModelId = 2 }
            );
            modelBuilder.Entity<SecondTestModel>().HasData(
                new SecondTestModel { Id = 1, Name = "N1" },
                new SecondTestModel { Id = 2, Name = "N2" }
            );

            modelBuilder.Entity<BuildingComponent>().HasData(
                new BuildingComponent { Id = 101, Level = 1, Name = "Metal Extractor 1", Resource = Resource.Metal, ResourceValue = 10 },
                new BuildingComponent { Id = 102, Level = 2, Name = "Metal Extractor 2", Resource = Resource.Metal, ResourceValue = 20 },
                new BuildingComponent { Id = 103, Level = 3, Name = "Metal Extractor 3", Resource = Resource.Metal, ResourceValue = 45 },

                new BuildingComponent { Id = 201, Level = 1, Name = "Crystal Extractor 1", Resource = Resource.Crystal, ResourceValue = 5 },
                new BuildingComponent { Id = 202, Level = 2, Name = "Crystal Extractor 2", Resource = Resource.Crystal, ResourceValue = 10 },
                new BuildingComponent { Id = 203, Level = 3, Name = "Crystal Extractor 3", Resource = Resource.Crystal, ResourceValue = 25 },

                new BuildingComponent { Id = 201, Level = 1, Name = "Crystal Extractor 1", Resource = Resource.Crystal, ResourceValue = 5 },
                new BuildingComponent { Id = 202, Level = 2, Name = "Crystal Extractor 2", Resource = Resource.Crystal, ResourceValue = 10 },
                new BuildingComponent { Id = 203, Level = 3, Name = "Crystal Extractor 3", Resource = Resource.Crystal, ResourceValue = 25 }
                );

            modelBuilder.Entity<Building>().HasData(
                new Building { Id = 101, Level = 1, Name = "Forge 1" },
                new Building { Id = 102, Level = 2, Name = "Forge 2" },
                new Building { Id = 103, Level = 3, Name = "Forge 3" },

                new Building { Id = 201, Level = 1, Name = "Vat 1" },
                new Building { Id = 202, Level = 2, Name = "Vat 2" },
                new Building { Id = 203, Level = 3, Name = "Vat 3" },

                new Building { Id = 201, Level = 1, Name = "Mine 1" },
                new Building { Id = 202, Level = 2, Name = "Mine 2" },
                new Building { Id = 203, Level = 3, Name = "Mine 3" }
                );

            modelBuilder.Entity<BuildingJoinBuildingComponent>().HasData(
                new BuildingJoinBuildingComponent { BuildingId = 101, BuildingComponentId = 101 }
                );

            modelBuilder.Entity<ResourceProfile>().HasData(
                new ResourceProfile 
                { 
                    Id = 1,
                    Buildings = new List<Building> 
                    { 
                        new CrystalMine { Level = 1 },
                        new MetalMine { Level = 1 },
                        new FuelMine { Level = 1 },
                    }
                },
                new ResourceProfile
                {
                    Id = 2,
                    Buildings = new List<Building>
                    {
                        new CrystalMine { Level = 2 },
                        new MetalMine { Level = 4 },
                        new FuelMine { Level = 3 },
                    }
                }
            );
        }
    }
}
