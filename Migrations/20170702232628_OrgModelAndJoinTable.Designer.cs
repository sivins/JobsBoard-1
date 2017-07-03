using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using reverseJobsBoard.Models;

namespace reverseJobsBoard.Migrations
{
    [DbContext(typeof(TDBContext))]
    [Migration("20170702232628_OrgModelAndJoinTable")]
    partial class OrgModelAndJoinTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("reverseJobsBoard.Models.Org", b =>
                {
                    b.Property<Guid>("OrgID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("OrgID");

                    b.ToTable("Orgs");
                });

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

            modelBuilder.Entity("reverseJobsBoard.Models.UserOrg", b =>
                {
                    b.Property<Guid>("UserID");

                    b.Property<Guid>("OrgID");

                    b.Property<Guid>("UserOrgID");

                    b.HasKey("UserID", "OrgID");

                    b.HasIndex("OrgID");

                    b.ToTable("UserOrg");
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

            modelBuilder.Entity("reverseJobsBoard.Models.UserOrg", b =>
                {
                    b.HasOne("reverseJobsBoard.Models.Org", "Org")
                        .WithMany("UserOrgs")
                        .HasForeignKey("OrgID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("reverseJobsBoard.Models.User", "User")
                        .WithMany("UserOrgs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
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
