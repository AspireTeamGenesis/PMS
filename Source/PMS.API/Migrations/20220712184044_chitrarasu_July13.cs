using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS_API.Migrations
{
    public partial class chitrarasu_July13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievementtype",
                columns: table => new
                {
                    AchievementTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievementtype", x => x.AchievementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ChangePasswords",
                columns: table => new
                {
                    ChangePasswordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangePasswords", x => x.ChangePasswordId);
                });

            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.CollegeId);
                });

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    CountryCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.CountryCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganisationId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileStatuss",
                columns: table => new
                {
                    ProfileStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileStatuss", x => x.ProfileStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCodeId = table.Column<int>(type: "int", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    ReportingPersonUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_users_CountryCodes_CountryCodeId",
                        column: x => x.CountryCodeId,
                        principalTable: "CountryCodes",
                        principalColumn: "CountryCodeId");
                    table.ForeignKey(
                        name: "FK_users_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_users_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_users_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_profile_ProfileStatuss_ProfileStatusId",
                        column: x => x.ProfileStatusId,
                        principalTable: "ProfileStatuss",
                        principalColumn: "ProfileStatusId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_profile_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "achievements",
                columns: table => new
                {
                    AchievementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    AchievementTypeId = table.Column<int>(type: "int", nullable: false),
                    base64header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchievementImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.AchievementId);
                    table.ForeignKey(
                        name: "FK_achievements_achievementtype_AchievementTypeId",
                        column: x => x.AchievementTypeId,
                        principalTable: "achievementtype",
                        principalColumn: "AchievementTypeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_achievements_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    Starting = table.Column<int>(type: "int", nullable: true),
                    Ending = table.Column<int>(type: "int", nullable: true),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_educations_Colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "Colleges",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_educations_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "personalDetails",
                columns: table => new
                {
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    base64header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalDetails", x => x.PersonalDetailsId);
                    table.ForeignKey(
                        name: "FK_personalDetails_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_personalDetails_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "profilehistory",
                columns: table => new
                {
                    ProfileHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profilehistory", x => x.ProfileHistoryId);
                    table.ForeignKey(
                        name: "FK_profilehistory_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingYear = table.Column<int>(type: "int", nullable: true),
                    EndingMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndingYear = table.Column<int>(type: "int", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolsUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_projects_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_skills_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_skills_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_skills_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "breakDurations",
                columns: table => new
                {
                    BreakDuration_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breakDurations", x => x.BreakDuration_Id);
                    table.ForeignKey(
                        name: "FK_breakDurations_personalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "personalDetails",
                        principalColumn: "PersonalDetailsId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Write = table.Column<bool>(type: "bit", nullable: false),
                    Speak = table.Column<bool>(type: "bit", nullable: false),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_languages_personalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "personalDetails",
                        principalColumn: "PersonalDetailsId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    SocialMedia_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMedia_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMedia_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.SocialMedia_Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_personalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "personalDetails",
                        principalColumn: "PersonalDetailsId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Colleges",
                columns: new[] { "CollegeId", "CollegeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "SKCET", true },
                    { 2, "SKCT", true },
                    { 3, "BIT", true },
                    { 4, "SA", true },
                    { 5, "PSNA", true },
                    { 6, "CIT", true },
                    { 7, "PSG", true },
                    { 8, "Kumaraguru", true },
                    { 9, "MIT", true },
                    { 10, "GCT", true }
                });

            migrationBuilder.InsertData(
                table: "CountryCodes",
                columns: new[] { "CountryCodeId", "CountryCodeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "+91", true },
                    { 2, "+1", true },
                    { 3, "+44", true },
                    { 4, "+61", true },
                    { 5, "+62", true },
                    { 6, "+86", true },
                    { 7, "+213", true },
                    { 8, "+355", true },
                    { 9, "+93", true },
                    { 10, "+54", true }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "DesignationId", "DesignationName", "IsActive" },
                values: new object[,]
                {
                    { 1, "HR", true },
                    { 2, "Admin", true },
                    { 3, "CEO", true },
                    { 4, "VP", true },
                    { 5, "SLO", true },
                    { 6, "DM", true },
                    { 7, "PM", true },
                    { 8, "PL", true },
                    { 9, "ML", true },
                    { 10, "TL", true },
                    { 11, "SSE", true },
                    { 12, "SE", true }
                });

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "DomainId", "DomainName", "IsActive" },
                values: new object[,]
                {
                    { 1, "IT", true },
                    { 2, "Marketing", true },
                    { 3, "R&D", true },
                    { 4, "Gaming", true },
                    { 5, "AI", true },
                    { 6, "Logistics", true },
                    { 7, "Hospitality", true },
                    { 8, "Finance", true },
                    { 9, "Food", true },
                    { 10, "Travel", true }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderId", "GenderName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Male", true },
                    { 2, "Female", true },
                    { 3, "Others", true }
                });

            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "OrganisationId", "IsActive", "OrganisationName" },
                values: new object[,]
                {
                    { 1, true, "Development" },
                    { 2, true, "Testing" },
                    { 3, true, "Support" },
                    { 4, true, "Cloud" },
                    { 5, true, "Server" },
                    { 6, true, "AI" },
                    { 7, true, "UI/UX" },
                    { 8, true, "R&D" },
                    { 9, true, "HR" },
                    { 10, true, "Food" }
                });

            migrationBuilder.InsertData(
                table: "ProfileStatuss",
                columns: new[] { "ProfileStatusId", "IsActive", "ProfileStatusName" },
                values: new object[,]
                {
                    { 1, true, "Approved" },
                    { 2, true, "Waiting" },
                    { 3, true, "Declined" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "IsActive", "TechnologyName" },
                values: new object[,]
                {
                    { 1, true, "Java" },
                    { 2, true, "DotNet" },
                    { 3, true, "Lamp" },
                    { 4, true, "BFS" },
                    { 5, true, "Sql" },
                    { 6, true, "Python" },
                    { 7, true, "EBA" },
                    { 8, true, "Angular" },
                    { 9, true, "C" },
                    { 10, true, "Pearl" }
                });

            migrationBuilder.InsertData(
                table: "achievementtype",
                columns: new[] { "AchievementTypeId", "AchievementTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Awards", true },
                    { 2, "Certificates", true }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "CountryCodeId", "CreatedBy", "CreatedOn", "DesignationId", "Email", "GenderId", "IsActive", "MobileNumber", "Name", "OrganisationId", "Password", "ReportingPersonUsername", "UpdatedBy", "UpdatedOn", "UserName" },
                values: new object[,]
                {
                    { 1, 1, null, null, 2, "chittu123@gmail.com", 1, true, "8610805521", "Chitrarasu", 3, "Chitra@2321", "Jaya19", null, null, "Chittu@25" },
                    { 2, 1, null, null, 2, "guganrb@gmail.com", 1, true, "9994660926", "Gugan", 1, "Gugan45@1924", "Savitha25", null, null, "gugan@45" },
                    { 3, 1, null, null, 3, "harinir@gmail.com", 2, true, "8610806522", "Harini", 2, "harini@2626", "snigdha30", null, null, "harini@22" },
                    { 4, 2, null, null, 3, "kishore45@gmail.com", 1, true, "8610805513", "Kishore", 1, "kishore@6754", "Jaya19", null, null, "kishore@65" },
                    { 5, 1, null, null, 2, "brindham@gmail.com", 2, true, "9610805522", "Brindha", 4, "brindha@1234", "Savitha25", null, null, "Brindha@77" }
                });

            migrationBuilder.InsertData(
                table: "profile",
                columns: new[] { "ProfileId", "CreatedBy", "CreatedOn", "IsActive", "ProfileStatusId", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, true, 1, null, 1 },
                    { 2, null, null, true, 3, null, 2 },
                    { 3, null, null, true, 1, null, 3 },
                    { 4, null, null, true, 2, null, 4 },
                    { 5, null, null, true, 2, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "achievements",
                columns: new[] { "AchievementId", "AchievementImage", "AchievementTypeId", "CreatedBy", "CreatedOn", "IsActive", "ProfileId", "UpdatedBy", "UpdatedOn", "base64header" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, true, 1, null, null, "abc" },
                    { 2, null, 2, null, null, true, 2, null, null, "abc" },
                    { 3, null, 1, null, null, true, 3, null, null, "abc" },
                    { 4, null, 2, null, null, true, 4, null, null, "abc" },
                    { 5, null, 1, null, null, true, 5, null, null, "abc" }
                });

            migrationBuilder.InsertData(
                table: "educations",
                columns: new[] { "EducationId", "CollegeId", "Course", "CreatedBy", "CreatedOn", "Degree", "Ending", "IsActive", "Percentage", "ProfileId", "Starting", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 2, "ECE", null, null, "BE", 2022, true, 85.6f, 1, 2018, null, null },
                    { 2, 1, "IT", null, null, "BTech", 2022, true, 96.8f, 2, 2018, null, null },
                    { 3, 4, "CSE", null, null, "Bsc", 2022, true, 91f, 3, 2018, null, null },
                    { 4, 10, "CSE", null, null, "ME", 2022, true, 89.5f, 4, 2020, null, null },
                    { 5, 6, "IT", null, null, "MTech", 2022, true, 83.6f, 5, 2020, null, null }
                });

            migrationBuilder.InsertData(
                table: "personalDetails",
                columns: new[] { "PersonalDetailsId", "CreatedBy", "CreatedOn", "DateOfBirth", "DateOfJoining", "Image", "IsActive", "Nationality", "Objective", "ProfileId", "UpdatedBy", "UpdatedOn", "UserId", "base64header" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2000, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Indian", "My description", 1, null, null, 1, "abc" },
                    { 2, null, null, new DateTime(2000, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Indian", "My description", 2, null, null, 2, "qwe" },
                    { 3, null, null, new DateTime(2000, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Indian", "My description", 3, null, null, 3, "abc" },
                    { 4, null, null, new DateTime(2000, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Indian", "My description", 4, null, null, 4, "abc" },
                    { 5, null, null, new DateTime(2000, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Indian", "My description", 5, null, null, 5, "abc" }
                });

            migrationBuilder.InsertData(
                table: "profilehistory",
                columns: new[] { "ProfileHistoryId", "ApprovedDate", "IsActive", "ProfileId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { 3, new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { 4, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "ProjectId", "CreatedBy", "CreatedOn", "Designation", "EndingMonth", "EndingYear", "IsActive", "ProfileId", "ProjectDescription", "ProjectName", "StartingMonth", "StartingYear", "ToolsUsed", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, "SE", "October", 2019, true, 1, "Create a Profile", "PMS", "October", 2018, "Figma", null, null },
                    { 2, null, null, "SSE", "July", 2021, true, 2, "Monitor the Trainee", "TMS", "April", 2018, "Balsamic", null, null },
                    { 3, null, null, "SE", "June", 2020, true, 3, "Interview process", "IMS", "January", 2019, "JIRA", null, null },
                    { 4, null, null, "ML", "February", 2021, true, 4, "Award Distribution", "AMS", "November", 2020, "Figma", null, null },
                    { 5, null, null, "PM", "September", 2020, true, 5, "Query Management", "QMS", "December", 2019, "JIRA", null, null }
                });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "SkillId", "CreatedBy", "CreatedOn", "DomainId", "IsActive", "ProfileId", "TechnologyId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, 6, true, 1, 7, null, null },
                    { 2, null, null, 2, true, 3, 2, null, null },
                    { 3, null, null, 7, true, 4, 5, null, null },
                    { 4, null, null, 3, true, 2, 1, null, null },
                    { 5, null, null, 3, true, 5, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "SocialMedia_Id", "CreatedBy", "CreatedOn", "IsActive", "PersonalDetailsId", "SocialMedia_Link", "SocialMedia_Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, true, 5, "www.linkedin.com", "LinkedIn", null, null },
                    { 2, null, null, true, 4, "www.telegram.com", "Telegram", null, null },
                    { 3, null, null, true, 3, "www.facebook.com", "Facebook", null, null },
                    { 4, null, null, true, 2, "www.twitter.com", "Twitter", null, null },
                    { 5, null, null, true, 1, "www.instagram.com", "Instagram", null, null }
                });

            migrationBuilder.InsertData(
                table: "breakDurations",
                columns: new[] { "BreakDuration_Id", "CreatedBy", "CreatedOn", "EndingDuration", "IsActive", "PersonalDetailsId", "StartingDuration", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 2, null, null, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 3, null, null, new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 4, null, null, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 5, null, null, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { 6, null, null, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "LanguageId", "CreatedBy", "CreatedOn", "IsActive", "LanguageName", "PersonalDetailsId", "Read", "Speak", "UpdatedBy", "UpdatedOn", "Write" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3553), true, "English", 1, true, true, null, null, true },
                    { 2, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3567), true, "Tamil", 2, true, true, null, null, true },
                    { 3, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3568), true, "Hindi", 3, true, true, null, null, true },
                    { 4, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3569), true, "Telugu", 4, true, true, null, null, true },
                    { 5, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3574), true, "Malayalam", 5, true, true, null, null, true },
                    { 6, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3575), true, "Kannada", 3, true, true, null, null, true },
                    { 7, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3576), true, "Bengali", 4, true, true, null, null, true },
                    { 8, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3576), true, "Marathi", 3, true, true, null, null, true },
                    { 9, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3577), true, "Urdu", 1, true, true, null, null, true },
                    { 10, null, new DateTime(2022, 7, 13, 0, 10, 43, 745, DateTimeKind.Local).AddTicks(3578), true, "French", 2, true, true, null, null, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_achievements_AchievementTypeId",
                table: "achievements",
                column: "AchievementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_achievements_ProfileId",
                table: "achievements",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_breakDurations_PersonalDetailsId",
                table: "breakDurations",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_educations_CollegeId",
                table: "educations",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_educations_ProfileId",
                table: "educations",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_languages_PersonalDetailsId",
                table: "languages",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_personalDetails_ProfileId",
                table: "personalDetails",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personalDetails_UserId",
                table: "personalDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profile_ProfileStatusId",
                table: "profile",
                column: "ProfileStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_profile_UserId",
                table: "profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profilehistory_ProfileId",
                table: "profilehistory",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_ProfileId",
                table: "projects",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_DomainId",
                table: "skills",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_ProfileId",
                table: "skills",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_skills_TechnologyId",
                table: "skills",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_PersonalDetailsId",
                table: "SocialMedias",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_users_CountryCodeId",
                table: "users",
                column: "CountryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_users_DesignationId",
                table: "users",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_users_GenderId",
                table: "users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_users_OrganisationId",
                table: "users",
                column: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achievements");

            migrationBuilder.DropTable(
                name: "breakDurations");

            migrationBuilder.DropTable(
                name: "ChangePasswords");

            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "profilehistory");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "achievementtype");

            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "personalDetails");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "ProfileStatuss");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
