﻿// <auto-generated />
using System;
using CVd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CVd.Migrations
{
    [DbContext(typeof(CvDbContext))]
    partial class CvDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("CVd.Data.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descriptor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CVd.Data.Decoration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Decorations");
                });

            modelBuilder.Entity("CVd.Data.Milestone", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("End")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EndOption")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly?>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int>("StartOption")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("CVd.Data.MilestoneDescription", b =>
                {
                    b.Property<string>("DescriptionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayTag")
                        .HasColumnType("TEXT");

                    b.Property<string>("Row1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Row2")
                        .HasColumnType("TEXT");

                    b.HasKey("DescriptionId", "LanguageCode");

                    b.ToTable("MilestoneDescriptions");
                });

            modelBuilder.Entity("CVd.Data.Project", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TagsString")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CVd.Data.ProjectDescription", b =>
                {
                    b.Property<string>("DescriptionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DescriptionId", "LanguageCode");

                    b.ToTable("ProjectDescriptions");
                });

            modelBuilder.Entity("CVd.Data.Skill", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Style")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("CVd.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CVd.Data.Contact", b =>
                {
                    b.HasOne("CVd.Data.User", null)
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVd.Data.Decoration", b =>
                {
                    b.HasOne("CVd.Data.User", null)
                        .WithMany("Decorations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVd.Data.Milestone", b =>
                {
                    b.HasOne("CVd.Data.User", null)
                        .WithMany("Milestones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVd.Data.Project", b =>
                {
                    b.HasOne("CVd.Data.User", null)
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVd.Data.Skill", b =>
                {
                    b.HasOne("CVd.Data.User", null)
                        .WithMany("Skills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CVd.Data.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Decorations");

                    b.Navigation("Milestones");

                    b.Navigation("Projects");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
