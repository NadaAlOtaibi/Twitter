﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Twitter.Data;

namespace Twitter.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210620152205_SeedingDataToDB")]
    partial class SeedingDataToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Twitter.Models.FollowModel", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("followerId")
                        .HasColumnType("int");

                    b.HasKey("userId", "followerId");

                    b.HasIndex("followerId");

                    b.ToTable("Follow");
                });

            modelBuilder.Entity("Twitter.Models.ProfileModel", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<string>("DateOfJoin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTweets")
                        .HasColumnType("int");

                    b.Property<string>("ProfileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalFollowers")
                        .HasColumnType("int");

                    b.Property<int>("TotalFollowing")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            ProfileId = 1,
                            Bio = "Hardcore coffeeaholic. Thinker. Twitter maven. Problem solver. Evil travel lover.",
                            DateOfJoin = "2005-09-05",
                            NumberOfTweets = 31,
                            ProfileName = "Nada",
                            ProfilePicture = "https://i.pinimg.com/originals/0a/53/c3/0a53c3bbe2f56a1ddac34ea04a26be98.jpg",
                            TotalFollowers = 34,
                            TotalFollowing = 434,
                            UserId = 1
                        },
                        new
                        {
                            ProfileId = 2,
                            Bio = "Pop culture evangelist. Devoted internet nerd. Tv fanatic. Web maven. Typical travel aficionado. Thinker.",
                            DateOfJoin = "2005-10-10",
                            NumberOfTweets = 752,
                            ProfileName = "I love cats",
                            ProfilePicture = "https://i.redd.it/v0caqchbtn741.jpg",
                            TotalFollowers = 1000,
                            TotalFollowing = 234,
                            UserId = 2
                        },
                        new
                        {
                            ProfileId = 3,
                            Bio = "Wannabe bacon geek. Social media evangelist. Web maven. Twitter scholar. ",
                            DateOfJoin = "2005-08-01",
                            NumberOfTweets = 435,
                            ProfileName = "Taif",
                            ProfilePicture = "https://i.pinimg.com/originals/bc/b8/36/bcb83616190f26847422d44363434400.jpg",
                            TotalFollowers = 200,
                            TotalFollowing = 4534,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Twitter.Models.TweetModel", b =>
                {
                    b.Property<int>("TweetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TweetContent")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("TweetDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");

                    b.HasData(
                        new
                        {
                            TweetId = 1,
                            TweetContent = "Hi I am new member here",
                            TweetDate = "2005-09-01",
                            UserId = 1
                        },
                        new
                        {
                            TweetId = 2,
                            TweetContent = "I like MVC and c#",
                            TweetDate = "2018-08-01",
                            UserId = 2
                        },
                        new
                        {
                            TweetId = 3,
                            TweetContent = "Do you want to learn more about FrontEnd?",
                            TweetDate = "2012-12-01",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Twitter.Models.UserModel", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userId = 1,
                            password = "1234",
                            userEmail = "nada@hotmail.com",
                            username = "nada"
                        },
                        new
                        {
                            userId = 2,
                            password = "112233",
                            userEmail = "yasmin@hotmail.com",
                            username = "yasmin"
                        },
                        new
                        {
                            userId = 3,
                            password = "9988",
                            userEmail = "taif@hotmail.com",
                            username = "taif"
                        });
                });

            modelBuilder.Entity("Twitter.Models.FollowModel", b =>
                {
                    b.HasOne("Twitter.Models.UserModel", "follower")
                        .WithMany("UserFollowing")
                        .HasForeignKey("followerId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Twitter.Models.UserModel", "user")
                        .WithMany("UserFollowers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("follower");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Twitter.Models.ProfileModel", b =>
                {
                    b.HasOne("Twitter.Models.UserModel", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Twitter.Models.ProfileModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Models.TweetModel", b =>
                {
                    b.HasOne("Twitter.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Twitter.Models.UserModel", b =>
                {
                    b.Navigation("Profile");

                    b.Navigation("UserFollowers");

                    b.Navigation("UserFollowing");
                });
#pragma warning restore 612, 618
        }
    }
}