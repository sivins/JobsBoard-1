using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace reverseJobsBoard.Migrations
{
    public partial class OrgModelAndJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orgs",
                columns: table => new
                {
                    OrgID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgs", x => x.OrgID);
                });

            migrationBuilder.CreateTable(
                name: "UserOrg",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    OrgID = table.Column<Guid>(nullable: false),
                    UserOrgID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrg", x => new { x.UserID, x.OrgID });
                    table.ForeignKey(
                        name: "FK_UserOrg_Orgs_OrgID",
                        column: x => x.OrgID,
                        principalTable: "Orgs",
                        principalColumn: "OrgID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrg_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOrg_OrgID",
                table: "UserOrg",
                column: "OrgID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOrg");

            migrationBuilder.DropTable(
                name: "Orgs");
        }
    }
}
