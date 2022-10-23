using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class maMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    Pseudo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    URLIMG = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.Pseudo);
                });

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
                name: "JoueurEntityPartieEntity",
                columns: table => new
                {
                    JoueursPseudo = table.Column<string>(type: "TEXT", nullable: false),
                    PartiesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoueurEntityPartieEntity", x => new { x.JoueursPseudo, x.PartiesId });
                    table.ForeignKey(
                        name: "FK_JoueurEntityPartieEntity_Joueur_JoueursPseudo",
                        column: x => x.JoueursPseudo,
                        principalTable: "Joueur",
                        principalColumn: "Pseudo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoueurEntityPartieEntity_Partie_PartiesId",
                        column: x => x.PartiesId,
                        principalTable: "Partie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    JoueurQuiPrendPseudo = table.Column<string>(type: "TEXT", nullable: false),
                    JoueurAllierPseudo = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PartieForeignKey = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manche_Joueur_JoueurAllierPseudo",
                        column: x => x.JoueurAllierPseudo,
                        principalTable: "Joueur",
                        principalColumn: "Pseudo");
                    table.ForeignKey(
                        name: "FK_Manche_Joueur_JoueurQuiPrendPseudo",
                        column: x => x.JoueurQuiPrendPseudo,
                        principalTable: "Joueur",
                        principalColumn: "Pseudo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manche_Partie_PartieForeignKey",
                        column: x => x.PartieForeignKey,
                        principalTable: "Partie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartieJoueurs",
                columns: table => new
                {
                    PartieForeignKey = table.Column<int>(type: "INTEGER", nullable: false),
                    JoueurForeignKey = table.Column<string>(type: "TEXT", nullable: false),
                    PartieId = table.Column<int>(type: "INTEGER", nullable: false),
                    JoueurPseudo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartieJoueurs", x => new { x.PartieForeignKey, x.JoueurForeignKey });
                    table.ForeignKey(
                        name: "FK_PartieJoueurs_Joueur_JoueurPseudo",
                        column: x => x.JoueurPseudo,
                        principalTable: "Joueur",
                        principalColumn: "Pseudo");
                    table.ForeignKey(
                        name: "FK_PartieJoueurs_Partie_PartieId",
                        column: x => x.PartieId,
                        principalTable: "Partie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoueurEntityPartieEntity_PartiesId",
                table: "JoueurEntityPartieEntity",
                column: "PartiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Manche_JoueurAllierPseudo",
                table: "Manche",
                column: "JoueurAllierPseudo");

            migrationBuilder.CreateIndex(
                name: "IX_Manche_JoueurQuiPrendPseudo",
                table: "Manche",
                column: "JoueurQuiPrendPseudo");

            migrationBuilder.CreateIndex(
                name: "IX_Manche_PartieForeignKey",
                table: "Manche",
                column: "PartieForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_PartieJoueurs_JoueurPseudo",
                table: "PartieJoueurs",
                column: "JoueurPseudo");

            migrationBuilder.CreateIndex(
                name: "IX_PartieJoueurs_PartieId",
                table: "PartieJoueurs",
                column: "PartieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoueurEntityPartieEntity");

            migrationBuilder.DropTable(
                name: "Manche");

            migrationBuilder.DropTable(
                name: "PartieJoueurs");

            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Partie");
        }
    }
}
