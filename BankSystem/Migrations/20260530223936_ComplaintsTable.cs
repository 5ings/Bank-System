using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ComplaintsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Clients_ClientID",
                table: "Complaint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaint",
                table: "Complaint");

            migrationBuilder.RenameTable(
                name: "Complaint",
                newName: "Complaints");

            migrationBuilder.RenameIndex(
                name: "IX_Complaint_ClientID",
                table: "Complaints",
                newName: "IX_Complaints_ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "ComplaintID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Clients_ClientID",
                table: "Complaints",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Clients_ClientID",
                table: "Complaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.RenameTable(
                name: "Complaints",
                newName: "Complaint");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_ClientID",
                table: "Complaint",
                newName: "IX_Complaint_ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaint",
                table: "Complaint",
                column: "ComplaintID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Clients_ClientID",
                table: "Complaint",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
