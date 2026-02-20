using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Starter_CleanArch_UAA2.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Newsletter_Sign_Up",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Is_News = table.Column<bool>(type: "bit", nullable: false),
                    Is_Monthly = table.Column<bool>(type: "bit", nullable: false),
                    Is_Day_Fact = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter_Sign_Up", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Newsletter__Email",
                table: "Newsletter_Sign_Up",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newsletter_Sign_Up");
        }
    }
}
