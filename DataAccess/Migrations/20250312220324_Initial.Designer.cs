﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250312220324_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("Abouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsPublish")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrash")
                        .HasColumnType("bit");

                    b.Property<int>("LitterBoxTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Image = "title",
                            IsPublish = true,
                            IsTrash = false,
                            LitterBoxTime = 0,
                            PublishDate = new DateTime(2025, 3, 13, 1, 3, 23, 696, DateTimeKind.Local).AddTicks(6624),
                            Slug = "title",
                            Title = "Title"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Image = "title2",
                            IsPublish = true,
                            IsTrash = false,
                            LitterBoxTime = 0,
                            PublishDate = new DateTime(2025, 3, 13, 1, 3, 23, 698, DateTimeKind.Local).AddTicks(7043),
                            Slug = "title-2",
                            Title = "Title 2"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Image = "title3",
                            IsPublish = true,
                            IsTrash = false,
                            LitterBoxTime = 0,
                            PublishDate = new DateTime(2025, 3, 13, 1, 3, 23, 698, DateTimeKind.Local).AddTicks(7059),
                            Slug = "title-3",
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Entities.Concrete.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Entities.Concrete.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Educations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Degree = "Title",
                            Department = "Title",
                            Description = "Title",
                            EndDate = new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(5814),
                            StartDate = new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(5580),
                            Title = "Title"
                        },
                        new
                        {
                            Id = 2,
                            Degree = "Title2",
                            Department = "Title2",
                            Description = "Title2",
                            EndDate = new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6009),
                            StartDate = new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6008),
                            Title = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Degree = "Title3",
                            Department = "Title3",
                            Description = "Title3",
                            EndDate = new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6011),
                            StartDate = new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6011),
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int?>("TypeOfEmploymentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeOfEmploymentId");

                    b.ToTable("Experiences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Company = "Title",
                            Description = "Title",
                            EndDate = new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(5852),
                            Location = "Title",
                            StartDate = new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(5624),
                            Title = "Title",
                            TypeOfEmploymentId = 1
                        },
                        new
                        {
                            Id = 2,
                            Company = "Title2",
                            Description = "Title2",
                            EndDate = new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6129),
                            Location = "Title2",
                            StartDate = new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6127),
                            Title = "Title2",
                            TypeOfEmploymentId = 2
                        },
                        new
                        {
                            Id = 3,
                            Company = "Title3",
                            Description = "Title3",
                            EndDate = new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6131),
                            Location = "Title3",
                            StartDate = new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6131),
                            Title = "Title3",
                            TypeOfEmploymentId = 3
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PortfolioCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioCategoryId");

                    b.ToTable("Portfolios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "image",
                            PortfolioCategoryId = 1,
                            SubTitle = "title",
                            Title = "Title"
                        },
                        new
                        {
                            Id = 2,
                            Image = "image2",
                            PortfolioCategoryId = 2,
                            SubTitle = "title2",
                            Title = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Image = "image3",
                            PortfolioCategoryId = 3,
                            SubTitle = "title3",
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.PortfolioCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("PortfolioCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Test"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Test2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Test3"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            Icon = "Icon",
                            Name = "Name"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description2",
                            Icon = "Icon2",
                            Name = "Name2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description3",
                            Icon = "Icon3",
                            Name = "Name3"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Skills", t =>
                        {
                            t.HasCheckConstraint("CK_Skill_Point", "[Point] BETWEEN 0 AND 100");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Name",
                            Point = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Name2",
                            Point = 20
                        },
                        new
                        {
                            Id = 3,
                            Name = "Name3",
                            Point = 30
                        },
                        new
                        {
                            Id = 4,
                            Name = "Name4",
                            Point = 40
                        },
                        new
                        {
                            Id = 5,
                            Name = "Name5",
                            Point = 50
                        },
                        new
                        {
                            Id = 6,
                            Name = "Name6",
                            Point = 60
                        },
                        new
                        {
                            Id = 7,
                            Name = "Name7",
                            Point = 70
                        });
                });

            modelBuilder.Entity("Entities.Concrete.SocialMediaIcon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("SocialMediaIcons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "Icon",
                            Link = "Link",
                            Name = "Name"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "Icon2",
                            Link = "Link2",
                            Name = "Name2"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "Icon3",
                            Link = "Link3",
                            Name = "Name3"
                        },
                        new
                        {
                            Id = 4,
                            Icon = "Icon4",
                            Link = "Link4",
                            Name = "Name4"
                        },
                        new
                        {
                            Id = 5,
                            Icon = "Icon5",
                            Link = "Link5",
                            Name = "Name5"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("Entities.Concrete.TypeOfEmployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfEmployments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sürekli / Tam Zamanlı"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Yarı Zamanlı"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Stajyer"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dönemsel"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Serbest"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Gönüllü"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CvLink")
                        .HasMaxLength(255)
                        .HasColumnType("varbinary(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "İstanbul",
                            Email = "furkanaltintas785@gmail.com",
                            FirstName = "Furkan",
                            LastName = "Altıntaş",
                            Password = "1234",
                            Phone = "+90 555 555 55 55",
                            Profession = "NET DEVELOPER",
                            Profile = "frkn",
                            UserName = "FRKN"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.WebSiteInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MenuTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoTags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebSiteInfos");
                });

            modelBuilder.Entity("Entities.Concrete.WebSiteTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CvButtonColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SidebarColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebSiteTemplates");
                });

            modelBuilder.Entity("Entities.Concrete.Experience", b =>
                {
                    b.HasOne("Entities.Concrete.TypeOfEmployment", "TypeOfEmployment")
                        .WithMany("Experiences")
                        .HasForeignKey("TypeOfEmploymentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("TypeOfEmployment");
                });

            modelBuilder.Entity("Entities.Concrete.Portfolio", b =>
                {
                    b.HasOne("Entities.Concrete.PortfolioCategory", "PortfolioCategory")
                        .WithMany("Portfolios")
                        .HasForeignKey("PortfolioCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PortfolioCategory");
                });

            modelBuilder.Entity("Entities.Concrete.PortfolioCategory", b =>
                {
                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("Entities.Concrete.TypeOfEmployment", b =>
                {
                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
