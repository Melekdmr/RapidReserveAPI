using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
	/// <inheritdoc />
	public partial class migfor : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// Önce MessageCategoryID kolonunu ekle
			migrationBuilder.AddColumn<int>(
				name: "MessageCategoryID",
				table: "Contacts",
				type: "int",
				nullable: false,
				defaultValue: 1);

			// Index oluştur
			migrationBuilder.CreateIndex(
				name: "IX_Contacts_MessageCategoryID",
				table: "Contacts",
				column: "MessageCategoryID");

			// Foreign key ekle
			migrationBuilder.AddForeignKey(
				name: "FK_Contacts_MessageCategories_MessageCategoryID",
				table: "Contacts",
				column: "MessageCategoryID",
				principalTable: "MessageCategories",
				principalColumn: "MessageCategoryID",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			// Foreign key sil
			migrationBuilder.DropForeignKey(
				name: "FK_Contacts_MessageCategories_MessageCategoryID",
				table: "Contacts");

			// Index sil
			migrationBuilder.DropIndex(
				name: "IX_Contacts_MessageCategoryID",
				table: "Contacts");

			// Kolonu sil
			migrationBuilder.DropColumn(
				name: "MessageCategoryID",
				table: "Contacts");
		}
	}
}
