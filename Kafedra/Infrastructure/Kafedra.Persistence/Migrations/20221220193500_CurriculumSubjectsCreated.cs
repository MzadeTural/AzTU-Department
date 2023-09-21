using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kafedra.Persistence.Migrations
{
    public partial class CurriculumSubjectsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectQualifications_Qualifications_QualificationId1",
                table: "SubjectQualifications");

            migrationBuilder.DropIndex(
                name: "IX_SubjectQualifications_QualificationId1",
                table: "SubjectQualifications");

            migrationBuilder.DropColumn(
                name: "QualificationId1",
                table: "SubjectQualifications");

            migrationBuilder.DropColumn(
                name: "SubejectID",
                table: "SubjectQualifications");

            migrationBuilder.AlterColumn<int>(
                name: "QualificationId",
                table: "SubjectQualifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CurriculumSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjects_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurriculumSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectQualifications_QualificationId",
                table: "SubjectQualifications",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjects_CurriculumId",
                table: "CurriculumSubjects",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumSubjects_SubjectId",
                table: "CurriculumSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectQualifications_Qualifications_QualificationId",
                table: "SubjectQualifications",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectQualifications_Qualifications_QualificationId",
                table: "SubjectQualifications");

            migrationBuilder.DropTable(
                name: "CurriculumSubjects");

            migrationBuilder.DropIndex(
                name: "IX_SubjectQualifications_QualificationId",
                table: "SubjectQualifications");

            migrationBuilder.AlterColumn<string>(
                name: "QualificationId",
                table: "SubjectQualifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QualificationId1",
                table: "SubjectQualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubejectID",
                table: "SubjectQualifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectQualifications_QualificationId1",
                table: "SubjectQualifications",
                column: "QualificationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectQualifications_Qualifications_QualificationId1",
                table: "SubjectQualifications",
                column: "QualificationId1",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
