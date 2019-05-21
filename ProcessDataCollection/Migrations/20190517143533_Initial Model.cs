using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessDataCollection.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Kit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    WorkOrder = table.Column<string>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true),
                    FirstBuild = table.Column<bool>(nullable: true),
                    Opened = table.Column<bool>(nullable: false),
                    StartQty = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SocketName = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    OperatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AU_APPLICATION_LOG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATE_LOGGED = table.Column<DateTime>(nullable: false),
                    ACTION_INITIATED = table.Column<string>(nullable: true),
                    APPLICATION_ACIONS_LOGGED = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_APPLICATION_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "AU_KIT_LOG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATE_LOGGED = table.Column<DateTime>(nullable: false),
                    ACTION_INITIATED = table.Column<string>(nullable: true),
                    KIT_LOGGED = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PROCESS_LOGGED = table.Column<string>(nullable: true),
                    USER = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_KIT_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "AU_USER_LOG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATE_LOGGED = table.Column<DateTime>(nullable: false),
                    ACTION_INITIATED = table.Column<string>(nullable: true),
                    USER_LOGGED = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_USER_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "DEF_ProcessDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEF_ProcessDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RES_Reasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RES_Reasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TPL_KitTemplates",
                columns: table => new
                {
                    TemplateId = table.Column<Guid>(nullable: false),
                    TemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPL_KitTemplates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "_Processes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KitId = table.Column<Guid>(nullable: false),
                    StepOrder = table.Column<int>(nullable: false),
                    ProcessName = table.Column<string>(nullable: true),
                    In = table.Column<int>(nullable: false),
                    InCount = table.Column<int>(nullable: false),
                    ReworkQty = table.Column<int>(nullable: false),
                    ScrapQty = table.Column<int>(nullable: false),
                    WorkOrder = table.Column<string>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Processes__Kit_KitId",
                        column: x => x.KitId,
                        principalTable: "_Kit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RES_ReasonCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    ReasonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RES_ReasonCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RES_ReasonCategories_RES_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "RES_Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TPL_ProcessTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessName = table.Column<string>(nullable: true),
                    StepOrder = table.Column<int>(nullable: false),
                    KitTemplateTemplateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPL_ProcessTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPL_ProcessTemplates_TPL_KitTemplates_KitTemplateTemplateId",
                        column: x => x.KitTemplateTemplateId,
                        principalTable: "TPL_KitTemplates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_ProcessEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    In = table.Column<int>(nullable: false),
                    Out = table.Column<int>(nullable: false),
                    OperatorId = table.Column<string>(nullable: true),
                    ProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProcessEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProcessEntries__Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "_Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RES_CategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    ReasonCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RES_CategoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RES_CategoryItems_RES_ReasonCategories_ReasonCategoryId",
                        column: x => x.ReasonCategoryId,
                        principalTable: "RES_ReasonCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_ProcessItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessEntriesId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Scrap = table.Column<string>(nullable: true),
                    Rework = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProcessItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProcessItems__ProcessEntries_ProcessEntriesId",
                        column: x => x.ProcessEntriesId,
                        principalTable: "_ProcessEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__ProcessEntries_ProcessId",
                table: "_ProcessEntries",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX__Processes_KitId",
                table: "_Processes",
                column: "KitId");

            migrationBuilder.CreateIndex(
                name: "IX__ProcessItems_ProcessEntriesId",
                table: "_ProcessItems",
                column: "ProcessEntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_RES_CategoryItems_ReasonCategoryId",
                table: "RES_CategoryItems",
                column: "ReasonCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RES_ReasonCategories_ReasonId",
                table: "RES_ReasonCategories",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TPL_ProcessTemplates_KitTemplateTemplateId",
                table: "TPL_ProcessTemplates",
                column: "KitTemplateTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_ProcessItems");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "AU_APPLICATION_LOG");

            migrationBuilder.DropTable(
                name: "AU_KIT_LOG");

            migrationBuilder.DropTable(
                name: "AU_USER_LOG");

            migrationBuilder.DropTable(
                name: "DEF_ProcessDefinitions");

            migrationBuilder.DropTable(
                name: "RES_CategoryItems");

            migrationBuilder.DropTable(
                name: "TPL_ProcessTemplates");

            migrationBuilder.DropTable(
                name: "_ProcessEntries");

            migrationBuilder.DropTable(
                name: "RES_ReasonCategories");

            migrationBuilder.DropTable(
                name: "TPL_KitTemplates");

            migrationBuilder.DropTable(
                name: "_Processes");

            migrationBuilder.DropTable(
                name: "RES_Reasons");

            migrationBuilder.DropTable(
                name: "_Kit");
        }
    }
}
