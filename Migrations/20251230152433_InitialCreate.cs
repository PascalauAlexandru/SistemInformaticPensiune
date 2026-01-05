using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemInformaticPensiune.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Facilitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeFacilitate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilitate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipCamera",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCamera", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    TipCameraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Camera_TipCamera_TipCameraID",
                        column: x => x.TipCameraID,
                        principalTable: "TipCamera",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FacilitateCamera",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraID = table.Column<int>(type: "int", nullable: false),
                    FacilitateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitateCamera", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FacilitateCamera_Camera_CameraID",
                        column: x => x.CameraID,
                        principalTable: "Camera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitateCamera_Facilitate_FacilitateID",
                        column: x => x.FacilitateID,
                        principalTable: "Facilitate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    CameraID = table.Column<int>(type: "int", nullable: true),
                    DateInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervare_Camera_CameraID",
                        column: x => x.CameraID,
                        principalTable: "Camera",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rezervare_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camera_TipCameraID",
                table: "Camera",
                column: "TipCameraID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitateCamera_CameraID",
                table: "FacilitateCamera",
                column: "CameraID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitateCamera_FacilitateID",
                table: "FacilitateCamera",
                column: "FacilitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_CameraID",
                table: "Rezervare",
                column: "CameraID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ClientID",
                table: "Rezervare",
                column: "ClientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitateCamera");

            migrationBuilder.DropTable(
                name: "Rezervare");

            migrationBuilder.DropTable(
                name: "Facilitate");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TipCamera");
        }
    }
}
