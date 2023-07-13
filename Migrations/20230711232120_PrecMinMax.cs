using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionPruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class PrecMinMax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomSelectListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserEditViewModels",
                table: "ApplicationUserEditViewModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicationUserEditViewModels");
            migrationBuilder.AddColumn<float>(
    name: "PrecioMinimo",
    table: "Productos",
    nullable: false,
    defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "PrecioMaximo",
                table: "Productos",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "ApplicationUserEditViewModels");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ApplicationUserEditViewModels");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ApplicationUserEditViewModels");

            migrationBuilder.RenameColumn(
                name: "SelectedRole",
                table: "ApplicationUserEditViewModels",
                newName: "SelectedRoleName");





            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ApplicationUserEditViewModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEditViewModels_UserId",
                table: "ApplicationUserEditViewModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEditViewModels_AspNetUsers_UserId",
                table: "ApplicationUserEditViewModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEditViewModels_AspNetUsers_UserId",
                table: "ApplicationUserEditViewModels");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserEditViewModels_UserId",
                table: "ApplicationUserEditViewModels");

        

            migrationBuilder.DropColumn(
                name: "PrecioMaximo",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioMinimo",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApplicationUserEditViewModels");

            migrationBuilder.RenameColumn(
                name: "SelectedRoleName",
                table: "ApplicationUserEditViewModels",
                newName: "SelectedRole");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ApplicationUserEditViewModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "ApplicationUserEditViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ApplicationUserEditViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ApplicationUserEditViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserEditViewModels",
                table: "ApplicationUserEditViewModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomSelectListItem",
                columns: table => new
                {
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
