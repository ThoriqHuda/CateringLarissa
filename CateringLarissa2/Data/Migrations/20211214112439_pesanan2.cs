using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CateringLarissa2.Data.Migrations
{
    public partial class pesanan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pesan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomorhp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesan", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            {
                migrationBuilder.DropTable(
                    name: "Pesan");
            }
        }
    }
}
