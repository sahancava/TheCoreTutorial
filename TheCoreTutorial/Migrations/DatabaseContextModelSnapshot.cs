﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheCoreTutorial.Models.DBHandler;

namespace TheCoreTutorial.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheCoreTutorial.Models.Authors", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AuthorPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AuthorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorEmail = "J.Blair@gmail.co",
                            AuthorPassword = "2bbamu5x",
                            AuthorUsername = "AvaOsborne"
                        },
                        new
                        {
                            ID = 4,
                            AuthorEmail = "Isaac.Burrows@sky.info",
                            AuthorPassword = "8rx7d9yb",
                            AuthorUsername = "TristanJones"
                        },
                        new
                        {
                            ID = 2,
                            AuthorEmail = "Ava.Hooper@cnn.co.uk",
                            AuthorPassword = "ot04r6h3",
                            AuthorUsername = "ChaseWeaver"
                        },
                        new
                        {
                            ID = 5,
                            AuthorEmail = "Hunter.Thomas@yelp.co.uk",
                            AuthorPassword = "j9jtwiaa",
                            AuthorUsername = "PiperGiles"
                        },
                        new
                        {
                            ID = 3,
                            AuthorEmail = "Joshua.Hilton@163.info",
                            AuthorPassword = "u6mnz2pn",
                            AuthorUsername = "BentleyStuart"
                        },
                        new
                        {
                            ID = 6,
                            AuthorEmail = "Aaliyah.White@deviantart.net",
                            AuthorPassword = "p2r0ps81",
                            AuthorUsername = "NathanielHooper"
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.Categories", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryDescription = "CategoryDescription for the CategoryID1",
                            CategoryName = "Category for the NewsID1"
                        },
                        new
                        {
                            ID = 4,
                            CategoryDescription = "CategoryDescription for the CategoryID4",
                            CategoryName = "Category for the NewsID4"
                        },
                        new
                        {
                            ID = 2,
                            CategoryDescription = "CategoryDescription for the CategoryID2",
                            CategoryName = "Category for the NewsID2"
                        },
                        new
                        {
                            ID = 5,
                            CategoryDescription = "CategoryDescription for the CategoryID5",
                            CategoryName = "Category for the NewsID5"
                        },
                        new
                        {
                            ID = 3,
                            CategoryDescription = "CategoryDescription for the CategoryID3",
                            CategoryName = "Category for the NewsID3"
                        },
                        new
                        {
                            ID = 6,
                            CategoryDescription = "CategoryDescription for the CategoryID6",
                            CategoryName = "Category for the NewsID6"
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.Comments", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewsID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("NewsID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentID = 1,
                            CommentBody = "Curabitur imperdiet dolor eget volutpat ultrices.",
                            NewsID = 1
                        },
                        new
                        {
                            CommentID = 2,
                            CommentBody = "Nunc ac ipsum sed purus consectetur sodales.",
                            NewsID = 2
                        },
                        new
                        {
                            CommentID = 3,
                            CommentBody = "Vestibulum in enim nec eros faucibus elementum sed vitae dolor.",
                            NewsID = 3
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.Config", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int?>("RecordsPerPage")
                        .HasColumnType("int");

                    b.Property<string>("WebSiteAddress")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("Config");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "lorem ipsum",
                            Keywords = "keyword,keyword2",
                            RecordsPerPage = 10,
                            WebSiteAddress = "http://localhost"
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.News", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NewsBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("NewsTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("NewsViewCount")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 1,
                            ImageURL = "blog-19.jpg",
                            IsActive = true,
                            NewsBody = "Maecenas tincidunt leo id nibh vestibulum, in feugiat justo varius.",
                            NewsTitle = "Duis gravida erat et euismod consequat.",
                            NewsViewCount = 9,
                            PublishDate = new DateTime(1989, 12, 16, 0, 35, 27, 851, DateTimeKind.Unspecified).AddTicks(7692)
                        },
                        new
                        {
                            ID = 4,
                            AuthorID = 4,
                            ImageURL = "blog-19.jpg",
                            IsActive = true,
                            NewsBody = "Praesent id magna sed massa hendrerit pellentesque ut quis enim.",
                            NewsTitle = "Sed dignissim augue eget orci vulputate, a pellentesque odio facilisis.",
                            NewsViewCount = 3,
                            PublishDate = new DateTime(1986, 6, 17, 17, 31, 4, 36, DateTimeKind.Unspecified).AddTicks(9658)
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 2,
                            ImageURL = "blog-19.jpg",
                            IsActive = true,
                            NewsBody = "Phasellus non ante non lectus ullamcorper faucibus id a eros.",
                            NewsTitle = "Curabitur sed lorem a dui consequat congue.",
                            NewsViewCount = 4,
                            PublishDate = new DateTime(1988, 11, 21, 22, 54, 32, 510, DateTimeKind.Unspecified).AddTicks(5019)
                        },
                        new
                        {
                            ID = 5,
                            AuthorID = 5,
                            ImageURL = "blog-19.jpg",
                            IsActive = true,
                            NewsBody = "Morbi sit amet nibh eget eros tempor mollis vel nec lacus.",
                            NewsTitle = "Fusce sollicitudin magna ut risus ullamcorper, ut ullamcorper elit adipiscing.",
                            NewsViewCount = 3,
                            PublishDate = new DateTime(1994, 12, 7, 23, 21, 8, 345, DateTimeKind.Unspecified).AddTicks(4607)
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 3,
                            ImageURL = "blog-19.jpg",
                            IsActive = true,
                            NewsBody = "Curabitur sed lorem a dui consequat congue.",
                            NewsTitle = "Nunc ac sem quis augue pharetra volutpat.",
                            NewsViewCount = 6,
                            PublishDate = new DateTime(1994, 9, 21, 10, 35, 15, 94, DateTimeKind.Unspecified).AddTicks(1488)
                        },
                        new
                        {
                            ID = 6,
                            AuthorID = 6,
                            ImageURL = "blog-19.jpg",
                            IsActive = true,
                            NewsBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                            NewsTitle = "Nullam et tellus posuere, consectetur ante eget, iaculis lorem.",
                            NewsViewCount = 7,
                            PublishDate = new DateTime(1976, 8, 5, 8, 19, 12, 966, DateTimeKind.Unspecified).AddTicks(1752)
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.NewsCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("NewsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("NewsCategories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryID = 1,
                            NewsID = 1
                        },
                        new
                        {
                            ID = 4,
                            CategoryID = 4,
                            NewsID = 4
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 2,
                            NewsID = 2
                        },
                        new
                        {
                            ID = 5,
                            CategoryID = 5,
                            NewsID = 5
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 3,
                            NewsID = 3
                        },
                        new
                        {
                            ID = 6,
                            CategoryID = 6,
                            NewsID = 6
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.Tags", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Tag = "Tag for the News 1"
                        },
                        new
                        {
                            ID = 4,
                            Tag = "Tag for the News 4"
                        },
                        new
                        {
                            ID = 2,
                            Tag = "Tag for the News 2"
                        },
                        new
                        {
                            ID = 5,
                            Tag = "Tag for the News 5"
                        },
                        new
                        {
                            ID = 3,
                            Tag = "Tag for the News 3"
                        },
                        new
                        {
                            ID = 6,
                            Tag = "Tag for the News 6"
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.TagsNews", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NewsID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NewsID");

                    b.ToTable("TagNews");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            NewsID = 1,
                            TagID = 1
                        },
                        new
                        {
                            ID = 4,
                            NewsID = 4,
                            TagID = 4
                        },
                        new
                        {
                            ID = 2,
                            NewsID = 2,
                            TagID = 2
                        },
                        new
                        {
                            ID = 5,
                            NewsID = 5,
                            TagID = 5
                        },
                        new
                        {
                            ID = 3,
                            NewsID = 3,
                            TagID = 3
                        },
                        new
                        {
                            ID = 6,
                            NewsID = 6,
                            TagID = 6
                        });
                });

            modelBuilder.Entity("TheCoreTutorial.Models.Comments", b =>
                {
                    b.HasOne("TheCoreTutorial.Models.News", "News")
                        .WithMany("Comment")
                        .HasForeignKey("NewsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheCoreTutorial.Models.News", b =>
                {
                    b.HasOne("TheCoreTutorial.Models.Authors", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheCoreTutorial.Models.TagsNews", b =>
                {
                    b.HasOne("TheCoreTutorial.Models.News", null)
                        .WithMany("Tags")
                        .HasForeignKey("NewsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
