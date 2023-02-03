using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class myFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pseudo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    URLIMG = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    PartieEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueur_Partie_PartieEntityId",
                        column: x => x.PartieEntityId,
                        principalTable: "Partie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Manche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    NbJoueur = table.Column<int>(type: "INTEGER", nullable: false),
                    Contrat = table.Column<byte>(type: "INTEGER", nullable: false),
                    Bonus = table.Column<byte>(type: "INTEGER", nullable: false),
                    JoueurQuiPrendId = table.Column<int>(type: "INTEGER", nullable: false),
                    JoueurAllierId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PartieForeignKey = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manche_Joueur_JoueurAllierId",
                        column: x => x.JoueurAllierId,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manche_Joueur_JoueurQuiPrendId",
                        column: x => x.JoueurQuiPrendId,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manche_Partie_PartieForeignKey",
                        column: x => x.PartieForeignKey,
                        principalTable: "Partie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Joueur_PartieEntityId",
                table: "Joueur",
                column: "PartieEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Manche_JoueurAllierId",
                table: "Manche",
                column: "JoueurAllierId");

            migrationBuilder.CreateIndex(
                name: "IX_Manche_JoueurQuiPrendId",
                table: "Manche",
                column: "JoueurQuiPrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Manche_PartieForeignKey",
                table: "Manche",
                column: "PartieForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manche");

            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Partie");
        }
    }
}
