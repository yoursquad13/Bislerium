﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Entities.Models.BlogImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("Entities.Models.BlogLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("BlogLogs");
                });

            modelBuilder.Entity("Entities.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BlogId")
                        .HasColumnType("int");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCommentForBlog")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCommentForComment")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CommentId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entities.Models.CommentLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("CommentLogs");
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Entities.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BlogId")
                        .HasColumnType("int");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReactedForBlog")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReactedForComment")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("ReactionId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CommentId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("LastModifiedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.Blog", b =>
                {
                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("Blogs")
                        .HasForeignKey("UserId");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.BlogImage", b =>
                {
                    b.HasOne("Entities.Models.Blog", "Blog")
                        .WithMany("BlogImages")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("BlogImages")
                        .HasForeignKey("UserId");

                    b.Navigation("Blog");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.BlogLog", b =>
                {
                    b.HasOne("Entities.Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("BlogLogs")
                        .HasForeignKey("UserId");

                    b.Navigation("Blog");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.Comment", b =>
                {
                    b.HasOne("Entities.Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");

                    b.HasOne("Entities.Models.Comment", "Comments")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Blog");

                    b.Navigation("Comments");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.CommentLog", b =>
                {
                    b.HasOne("Entities.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("CommentLogs")
                        .HasForeignKey("UserId");

                    b.Navigation("Comment");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.HasOne("Entities.Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("Blog");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.Reaction", b =>
                {
                    b.HasOne("Entities.Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");

                    b.HasOne("Entities.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("Entities.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.Models.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.Models.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedBy");

                    b.HasOne("Entities.Models.User", null)
                        .WithMany("Reactions")
                        .HasForeignKey("UserId");

                    b.Navigation("Blog");

                    b.Navigation("Comment");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.HasOne("Entities.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entities.Models.Blog", b =>
                {
                    b.Navigation("BlogImages");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("BlogImages");

                    b.Navigation("BlogLogs");

                    b.Navigation("Blogs");

                    b.Navigation("CommentLogs");

                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
