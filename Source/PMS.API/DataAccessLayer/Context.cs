using Microsoft.EntityFrameworkCore;


namespace PMS_API
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ASPLAP1916;database=PMS;trusted_connection=true;");
        }
        public DbSet<User> users { get; set; }
        public DbSet<Profile> profile { get; set; }
        public DbSet<PersonalDetails> personalDetails { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<BreakDuration> breakDurations { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Skills> skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<ProfileStatus> ProfileStatuss { get; set; }
        public DbSet<AchievementType> achievementtype { get; set; }
        public DbSet<Achievements> achievements { get; set; }
        public DbSet<ProfileHistory> profilehistory { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<ChangePassword> ChangePasswords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<College>()
                        .HasData(
                         new College { CollegeId = 1, CollegeName = "SKCET", IsActive = true },
                         new College { CollegeId = 2, CollegeName = "SKCT", IsActive = true },
                         new College { CollegeId = 3, CollegeName = "BIT", IsActive = true },
                         new College { CollegeId = 4, CollegeName = "SA", IsActive = true },
                         new College { CollegeId = 5, CollegeName = "PSNA", IsActive = true },
                         new College { CollegeId = 6, CollegeName = "CIT", IsActive = true },
                         new College { CollegeId = 7, CollegeName = "PSG", IsActive = true },
                         new College { CollegeId = 8, CollegeName = "Kumaraguru", IsActive = true },
                         new College { CollegeId = 9, CollegeName = "MIT", IsActive = true },
                         new College { CollegeId = 10, CollegeName = "GCT", IsActive = true }
                         );
            modelBuilder.Entity<Designation>()
                        .HasData(
                         new Designation { DesignationId = 1, DesignationName = "HR", IsActive = true },
                         new Designation { DesignationId = 2, DesignationName = "Admin", IsActive = true },
                         new Designation { DesignationId = 3, DesignationName = "CEO", IsActive = true },
                         new Designation { DesignationId = 4, DesignationName = "VP", IsActive = true },
                         new Designation { DesignationId = 5, DesignationName = "SLO", IsActive = true },
                         new Designation { DesignationId = 6, DesignationName = "DM", IsActive = true },
                         new Designation { DesignationId = 7, DesignationName = "PM", IsActive = true },
                         new Designation { DesignationId = 8, DesignationName = "PL", IsActive = true },
                         new Designation { DesignationId = 9, DesignationName = "ML", IsActive = true },
                         new Designation { DesignationId = 10, DesignationName = "TL", IsActive = true },
                         new Designation { DesignationId = 11, DesignationName = "SSE", IsActive = true },
                         new Designation { DesignationId = 12, DesignationName = "SE", IsActive = true }
                         );
            modelBuilder.Entity<Domain>()
                        .HasData(
                         new Domain { DomainId = 1, DomainName = "IT", IsActive = true },
                         new Domain { DomainId = 2, DomainName = "Marketing", IsActive = true },
                         new Domain { DomainId = 3, DomainName = "R&D", IsActive = true },
                         new Domain { DomainId = 4, DomainName = "Gaming", IsActive = true },
                         new Domain { DomainId = 5, DomainName = "AI", IsActive = true },
                         new Domain { DomainId = 6, DomainName = "Logistics", IsActive = true },
                         new Domain { DomainId = 7, DomainName = "Hospitality", IsActive = true },
                         new Domain { DomainId = 8, DomainName = "Finance", IsActive = true },
                         new Domain { DomainId = 9, DomainName = "Food", IsActive = true },
                         new Domain { DomainId = 10, DomainName = "Travel", IsActive = true }
                         );
            modelBuilder.Entity<Gender>()
                        .HasData(
                         new Gender { GenderId = 1, GenderName = "Male", IsActive = true },
                         new Gender { GenderId = 2, GenderName = "Female", IsActive = true },
                         new Gender { GenderId = 3, GenderName = "Others", IsActive = true }
                         );
            modelBuilder.Entity<Organisation>()
                        .HasData(
                         new Organisation { OrganisationId = 1, OrganisationName = "Development", IsActive = true },
                         new Organisation { OrganisationId = 2, OrganisationName = "Testing", IsActive = true },
                         new Organisation { OrganisationId = 3, OrganisationName = "Support", IsActive = true },
                         new Organisation { OrganisationId = 4, OrganisationName = "Cloud", IsActive = true },
                         new Organisation { OrganisationId = 5, OrganisationName = "Server", IsActive = true },
                         new Organisation { OrganisationId = 6, OrganisationName = "AI", IsActive = true },
                         new Organisation { OrganisationId = 7, OrganisationName = "UI/UX", IsActive = true },
                         new Organisation { OrganisationId = 8, OrganisationName = "R&D", IsActive = true },
                         new Organisation { OrganisationId = 9, OrganisationName = "HR", IsActive = true },
                         new Organisation { OrganisationId = 10, OrganisationName = "Food", IsActive = true }
                         );
            modelBuilder.Entity<Technology>()
                        .HasData(
                         new Technology { TechnologyId = 1, TechnologyName = "Java", IsActive = true },
                         new Technology { TechnologyId = 2, TechnologyName = "DotNet", IsActive = true },
                         new Technology { TechnologyId = 3, TechnologyName = "Lamp", IsActive = true },
                         new Technology { TechnologyId = 4, TechnologyName = "BFS", IsActive = true },
                         new Technology { TechnologyId = 5, TechnologyName = "Sql", IsActive = true },
                         new Technology { TechnologyId = 6, TechnologyName = "Python", IsActive = true },
                         new Technology { TechnologyId = 7, TechnologyName = "EBA", IsActive = true },
                         new Technology { TechnologyId = 8, TechnologyName = "Angular", IsActive = true },
                         new Technology { TechnologyId = 9, TechnologyName = "C", IsActive = true },
                         new Technology { TechnologyId = 10, TechnologyName = "Pearl", IsActive = true }
                         );
            modelBuilder.Entity<ProfileStatus>()
                        .HasData(
                         new ProfileStatus { ProfileStatusId = 1, ProfileStatusName = "Approved", IsActive = true },
                         new ProfileStatus { ProfileStatusId = 2, ProfileStatusName = "Waiting", IsActive = true },
                         new ProfileStatus { ProfileStatusId = 3, ProfileStatusName = "Declined", IsActive = true }
                        );
            modelBuilder.Entity<CountryCode>()
                        .HasData(
                         new CountryCode { CountryCodeId = 1, CountryCodeName = "+91", IsActive = true },
                         new CountryCode { CountryCodeId = 2, CountryCodeName = "+1", IsActive = true },
                         new CountryCode { CountryCodeId = 3, CountryCodeName = "+44", IsActive = true },
                         new CountryCode { CountryCodeId = 4, CountryCodeName = "+61", IsActive = true },
                         new CountryCode { CountryCodeId = 5, CountryCodeName = "+62", IsActive = true },
                         new CountryCode { CountryCodeId = 6, CountryCodeName = "+86", IsActive = true },
                         new CountryCode { CountryCodeId = 7, CountryCodeName = "+213", IsActive = true },
                         new CountryCode { CountryCodeId = 8, CountryCodeName = "+355", IsActive = true },
                         new CountryCode { CountryCodeId = 9, CountryCodeName = "+93", IsActive = true },
                         new CountryCode { CountryCodeId = 10, CountryCodeName = "+54", IsActive = true }
                         );
            modelBuilder.Entity<User>()
            .HasData(
                new User { UserId = 1, Name = "Chitrarasu", Email = "chittu123@gmail.com", UserName = "Chittu@25", Password = "Chitra@2321", CountryCodeId = 1, MobileNumber = "8610805521", DesignationId = 2, ReportingPersonUsername = "Jaya19", OrganisationId = 3, GenderId = 1, IsActive = true },
                new User { UserId = 2, Name = "Gugan", Email = "guganrb@gmail.com", UserName = "gugan@45", Password = "Gugan45@1924", CountryCodeId = 1, MobileNumber = "9994660926", DesignationId = 2, ReportingPersonUsername = "Savitha25", OrganisationId = 1, GenderId = 1, IsActive = true },
                new User { UserId = 3, Name = "Harini", Email = "harinir@gmail.com", UserName = "harini@22", Password = "harini@2626", CountryCodeId = 1, MobileNumber = "8610806522", DesignationId = 3, ReportingPersonUsername = "snigdha30", OrganisationId = 2, GenderId = 2, IsActive = true },
                new User { UserId = 4, Name = "Kishore", Email = "kishore45@gmail.com", UserName = "kishore@65", Password = "kishore@6754", CountryCodeId = 2, MobileNumber = "8610805513", DesignationId = 3, ReportingPersonUsername = "Jaya19", OrganisationId = 1, GenderId = 1, IsActive = true },
                new User { UserId = 5, Name = "Brindha", Email = "brindham@gmail.com", UserName = "Brindha@77", Password = "brindha@1234", CountryCodeId = 1, MobileNumber = "9610805522", DesignationId = 2, ReportingPersonUsername = "Savitha25", OrganisationId = 4, GenderId = 2, IsActive = true }            
            );

            modelBuilder.Entity<Profile>()
                       .HasData(
                        new Profile { ProfileId = 1, ProfileStatusId = 1, UserId = 1, IsActive = true },
                        new Profile { ProfileId = 2, ProfileStatusId = 3, UserId = 2, IsActive = true },
                        new Profile { ProfileId = 3, ProfileStatusId = 1, UserId = 3, IsActive = true },
                        new Profile { ProfileId = 4, ProfileStatusId = 2, UserId = 4, IsActive = true },
                        new Profile { ProfileId = 5, ProfileStatusId = 2, UserId = 5, IsActive = true }
                        );
            modelBuilder.Entity<Education>()
                       .HasData(
                        new Education { EducationId = 1, ProfileId = 1, Degree = "BE", Course = "ECE", CollegeId = 2, Starting = 2018, Ending = 2022, Percentage = 85.6f, IsActive = true },
                        new Education { EducationId = 2, ProfileId = 2, Degree = "BTech", Course = "IT", CollegeId = 1, Starting = 2018, Ending = 2022, Percentage = 96.8f, IsActive = true },
                        new Education { EducationId = 3, ProfileId = 3, Degree = "Bsc", Course = "CSE", CollegeId = 4, Starting = 2018, Ending = 2022, Percentage = 91.0f, IsActive = true },
                        new Education { EducationId = 4, ProfileId = 4, Degree = "ME", Course = "CSE", CollegeId = 10, Starting = 2020, Ending = 2022, Percentage = 89.5f, IsActive = true },
                        new Education { EducationId = 5, ProfileId = 5, Degree = "MTech", Course = "IT", CollegeId = 6, Starting = 2020, Ending = 2022, Percentage = 83.6f, IsActive = true }
                        
                        );
            modelBuilder.Entity<ProfileHistory>()
                       .HasData(
                        new ProfileHistory { ProfileHistoryId = 1, ProfileId = 1, ApprovedDate = new System.DateTime(2022, 10, 24), IsActive = true },
                        new ProfileHistory { ProfileHistoryId = 2, ProfileId = 3, ApprovedDate = new System.DateTime(2021, 06, 11), IsActive = true },
                        new ProfileHistory { ProfileHistoryId = 3, ProfileId = 2, ApprovedDate = new System.DateTime(2022, 10, 19), IsActive = true },
                        new ProfileHistory { ProfileHistoryId = 4, ProfileId = 4, ApprovedDate = new System.DateTime(2022, 12, 27), IsActive = true }
                        );
            modelBuilder.Entity<Skills>()
                        .HasData(
                         new Skills { SkillId = 1, ProfileId = 1, TechnologyId = 7, DomainId = 6, IsActive = true },
                         new Skills { SkillId = 2, ProfileId = 3, TechnologyId = 2, DomainId = 2, IsActive = true },
                         new Skills { SkillId = 3, ProfileId = 4, TechnologyId = 5, DomainId = 7, IsActive = true },
                         new Skills { SkillId = 4, ProfileId = 2, TechnologyId = 1, DomainId = 3, IsActive = true },
                         new Skills { SkillId = 5, ProfileId = 5, TechnologyId = 1, DomainId = 3, IsActive = true }
                        );
            modelBuilder.Entity<Projects>()
                        .HasData(
                         new Projects { ProjectId = 1, ProfileId = 1, ProjectName = "PMS", ProjectDescription = "Create a Profile", StartingMonth = "October", StartingYear = 2018, EndingMonth = "October", EndingYear = 2019, Designation = "SE", ToolsUsed = "Figma", IsActive = true },
                         new Projects { ProjectId = 2, ProfileId = 2, ProjectName = "TMS", ProjectDescription = "Monitor the Trainee", StartingMonth = "April", StartingYear = 2018, EndingMonth = "July", EndingYear = 2021, Designation = "SSE", ToolsUsed = "Balsamic", IsActive = true },
                         new Projects { ProjectId = 3, ProfileId = 3, ProjectName = "IMS", ProjectDescription = "Interview process", StartingMonth = "January", StartingYear = 2019, EndingMonth = "June", EndingYear = 2020, Designation = "SE", ToolsUsed = "JIRA", IsActive = true },
                         new Projects { ProjectId = 4, ProfileId = 4, ProjectName = "AMS", ProjectDescription = "Award Distribution", StartingMonth = "November", StartingYear = 2020, EndingMonth = "February", EndingYear = 2021, Designation = "ML", ToolsUsed = "Figma", IsActive = true },
                         new Projects { ProjectId = 5, ProfileId = 5, ProjectName = "QMS", ProjectDescription = "Query Management", StartingMonth = "December", StartingYear = 2019, EndingMonth = "September", EndingYear = 2020, Designation = "PM", ToolsUsed = "JIRA", IsActive = true }
                        );

            modelBuilder.Entity<PersonalDetails>()
                       .HasData(
                        new PersonalDetails { PersonalDetailsId = 1, ProfileId = 1, Objective = "My description", DateOfBirth = new System.DateTime(2000, 12, 15), Nationality = "Indian", DateOfJoining = new System.DateTime(2018, 04, 21), base64header = "abc", UserId = 1, IsActive = true },
                        new PersonalDetails { PersonalDetailsId = 2, ProfileId = 2, Objective = "My description", DateOfBirth = new System.DateTime(2000, 01, 23), Nationality = "Indian", DateOfJoining = new System.DateTime(2020, 04, 21), base64header = "qwe", UserId = 2, IsActive = true },
                        new PersonalDetails { PersonalDetailsId = 3, ProfileId = 3, Objective = "My description", DateOfBirth = new System.DateTime(2000, 10, 19), Nationality = "Indian", DateOfJoining = new System.DateTime(2019, 04, 21), base64header = "abc", UserId = 3, IsActive = true },
                        new PersonalDetails { PersonalDetailsId = 4, ProfileId = 4, Objective = "My description", DateOfBirth = new System.DateTime(2000, 11, 02), Nationality = "Indian", DateOfJoining = new System.DateTime(2018, 06, 11), base64header = "abc", UserId = 4, IsActive = true },
                        new PersonalDetails { PersonalDetailsId = 5, ProfileId = 5, Objective = "My description", DateOfBirth = new System.DateTime(2000, 06, 29), Nationality = "Indian", DateOfJoining = new System.DateTime(2021, 08, 21), base64header = "abc", UserId = 5, IsActive = true }
                       );
            modelBuilder.Entity<BreakDuration>()
                        .HasData(
                         new BreakDuration { BreakDuration_Id = 1, StartingDuration = new DateTime(2020, 01, 02), EndingDuration = new DateTime(2019, 06, 15), PersonalDetailsId = 1, IsActive = true },
                         new BreakDuration { BreakDuration_Id = 2, StartingDuration = new DateTime(2020, 02, 15), EndingDuration = new DateTime(2021, 07, 15), PersonalDetailsId = 2, IsActive = true },
                         new BreakDuration { BreakDuration_Id = 3, StartingDuration = new DateTime(2020, 04, 15), EndingDuration = new DateTime(2020, 12, 15), PersonalDetailsId = 3, IsActive = true },
                         new BreakDuration { BreakDuration_Id = 4, StartingDuration = new DateTime(2019, 01, 15), EndingDuration = new DateTime(2019, 06, 15), PersonalDetailsId = 4, IsActive = true },
                         new BreakDuration { BreakDuration_Id = 5, StartingDuration = new DateTime(2021, 12, 15), EndingDuration = new DateTime(2022, 02, 15), PersonalDetailsId = 5, IsActive = true },
                         new BreakDuration { BreakDuration_Id = 6, StartingDuration = new DateTime(2021, 11, 15), EndingDuration = new DateTime(2022, 02, 15), PersonalDetailsId = 5, IsActive = true }
                         );
            modelBuilder.Entity<Language>()
                      .HasData(
                       new Language { LanguageId = 1, LanguageName = "English", Read = true, Write = true, Speak = true, PersonalDetailsId = 1, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 2, LanguageName = "Tamil", Read = true, Write = true, Speak = true, PersonalDetailsId = 2, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 3, LanguageName = "Hindi", Read = true, Write = true, Speak = true, PersonalDetailsId = 3, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 4, LanguageName = "Telugu", Read = true, Write = true, Speak = true, PersonalDetailsId = 4, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 5, LanguageName = "Malayalam", Read = true, Write = true, Speak = true, PersonalDetailsId = 5, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 6, LanguageName = "Kannada", Read = true, Write = true, Speak = true, PersonalDetailsId = 3, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 7, LanguageName = "Bengali", Read = true, Write = true, Speak = true, PersonalDetailsId = 4, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 8, LanguageName = "Marathi", Read = true, Write = true, Speak = true, PersonalDetailsId = 3, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 9, LanguageName = "Urdu", Read = true, Write = true, Speak = true, PersonalDetailsId = 1, CreatedOn = System.DateTime.Now, IsActive = true },
                       new Language { LanguageId = 10, LanguageName = "French", Read = true, Write = true, Speak = true, PersonalDetailsId = 2, CreatedOn = System.DateTime.Now, IsActive = true }
                    );



            modelBuilder.Entity<SocialMedia>()
                    .HasData(
                          new SocialMedia { SocialMedia_Id = 1, SocialMedia_Name = "LinkedIn", SocialMedia_Link = "www.linkedin.com", PersonalDetailsId = 5, IsActive = true },
                          new SocialMedia { SocialMedia_Id = 2, SocialMedia_Name = "Telegram", SocialMedia_Link = "www.telegram.com", PersonalDetailsId = 4, IsActive = true },
                          new SocialMedia { SocialMedia_Id = 3, SocialMedia_Name = "Facebook", SocialMedia_Link = "www.facebook.com", PersonalDetailsId = 3, IsActive = true },
                          new SocialMedia { SocialMedia_Id = 4, SocialMedia_Name = "Twitter", SocialMedia_Link = "www.twitter.com", PersonalDetailsId = 2, IsActive = true },
                          new SocialMedia { SocialMedia_Id = 5, SocialMedia_Name = "Instagram", SocialMedia_Link = "www.instagram.com", PersonalDetailsId = 1, IsActive = true }
                         );
            modelBuilder.Entity<AchievementType>()
                        .HasData(
                         new AchievementType { AchievementTypeId = 1, AchievementTypeName = "Awards", IsActive = true },
                         new AchievementType { AchievementTypeId = 2, AchievementTypeName = "Certificates", IsActive = true }
                        );
            modelBuilder.Entity<Achievements>()
                        .HasData(
                         new Achievements { AchievementId = 1, ProfileId = 1, AchievementTypeId = 1, base64header = "abc", IsActive = true },
                         new Achievements { AchievementId = 2, ProfileId = 2, AchievementTypeId = 2, base64header = "abc", IsActive = true },
                         new Achievements { AchievementId = 3, ProfileId = 3, AchievementTypeId = 1, base64header = "abc", IsActive = true },
                         new Achievements { AchievementId = 4, ProfileId = 4, AchievementTypeId = 2, base64header = "abc", IsActive = true },
                         new Achievements { AchievementId = 5, ProfileId = 5, AchievementTypeId = 1, base64header = "abc", IsActive = true }
                        );



        }

    }
}