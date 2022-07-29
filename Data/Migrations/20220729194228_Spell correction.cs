using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PestKontroll.Data.Migrations
{
    public partial class Spellcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                table: "TicketComments");

            migrationBuilder.DropColumn(
                name: "TicktId",
                table: "TicketComments");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketComments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                table: "TicketComments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                table: "TicketComments");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketComments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TicktId",
                table: "TicketComments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_TicketId",
                table: "TicketComments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
