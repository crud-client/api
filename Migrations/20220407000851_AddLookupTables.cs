using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudClients.Migrations
{
    public partial class AddLookupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telphones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telphones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Telphones_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientID",
                table: "Addresses",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CPF",
                table: "Clients",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Facebook",
                table: "Clients",
                column: "Facebook",
                unique: true,
                filter: "[Facebook] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Instagram",
                table: "Clients",
                column: "Instagram",
                unique: true,
                filter: "[Instagram] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Linkedin",
                table: "Clients",
                column: "Linkedin",
                unique: true,
                filter: "[Linkedin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RG",
                table: "Clients",
                column: "RG",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Twitter",
                table: "Clients",
                column: "Twitter",
                unique: true,
                filter: "[Twitter] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Telphones_ClientID",
                table: "Telphones",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Telphones_Number",
                table: "Telphones",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Telphones");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
