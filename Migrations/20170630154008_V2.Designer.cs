using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using reverseJobsBoard.Models;

namespace reverseJobsBoard.Migrations
{
    [DbContext(typeof(TDBContext))]
    [Migration("20170630154008_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
        }
    }
}
