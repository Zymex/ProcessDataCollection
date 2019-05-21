using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessDataCollection.Migrations
{
    public partial class KitIdonProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPL_ProcessTemplates_TPL_KitTemplates_KitTemplateTemplateId",
                table: "TPL_ProcessTemplates");

            migrationBuilder.DropIndex(
                name: "IX_TPL_ProcessTemplates_KitTemplateTemplateId",
                table: "TPL_ProcessTemplates");

            migrationBuilder.DropColumn(
                name: "KitTemplateTemplateId",
                table: "TPL_ProcessTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "KitTemplateId",
                table: "TPL_ProcessTemplates",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TPL_ProcessTemplates_KitTemplateId",
                table: "TPL_ProcessTemplates",
                column: "KitTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPL_ProcessTemplates_TPL_KitTemplates_KitTemplateId",
                table: "TPL_ProcessTemplates",
                column: "KitTemplateId",
                principalTable: "TPL_KitTemplates",
                principalColumn: "TemplateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPL_ProcessTemplates_TPL_KitTemplates_KitTemplateId",
                table: "TPL_ProcessTemplates");

            migrationBuilder.DropIndex(
                name: "IX_TPL_ProcessTemplates_KitTemplateId",
                table: "TPL_ProcessTemplates");

            migrationBuilder.DropColumn(
                name: "KitTemplateId",
                table: "TPL_ProcessTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "KitTemplateTemplateId",
                table: "TPL_ProcessTemplates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TPL_ProcessTemplates_KitTemplateTemplateId",
                table: "TPL_ProcessTemplates",
                column: "KitTemplateTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPL_ProcessTemplates_TPL_KitTemplates_KitTemplateTemplateId",
                table: "TPL_ProcessTemplates",
                column: "KitTemplateTemplateId",
                principalTable: "TPL_KitTemplates",
                principalColumn: "TemplateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
