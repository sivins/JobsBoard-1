using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using reverseJobsBoard.Models;

namespace reverseJobsBoard.Migrations
{
    [DbContext(typeof(TDBContext))]
    [Migration("20170702231240_RoleModelAndJoinTable")]
    partial class RoleModelAndJoinTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("reverseJobsBoard.Models.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("reverseJobsBoard.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("reverseJobsBoard.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserID");

                    b.Property<Guid>("RoleID");

                    b.Property<Guid>("UserRoleID");

                    b.HasKey("UserID", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("reverseJobsBoard.Models.UserRole", b =>
                {
                    b.HasOne("reverseJobsBoard.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("reverseJobsBoard.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
