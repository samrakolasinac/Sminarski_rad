using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class Inicijalnoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DodatneUsluge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatneUsluge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojRacuna = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jelo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAdministrator = table.Column<bool>(nullable: false),
                    IsKlijent = table.Column<bool>(nullable: false),
                    IsUposlenik = table.Column<bool>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipDogadjaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDogadjaja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipSobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipSobe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipUplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipZaposlenika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZaposlenika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogadjaj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Kraj = table.Column<DateTime>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    TipDogadjajaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogadjaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogadjaj_TipDogadjaja_TipDogadjajaID",
                        column: x => x.TipDogadjajaID,
                        principalTable: "TipDogadjaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Dostupna = table.Column<bool>(nullable: false),
                    Naziv = table.Column<string>(nullable: false),
                    Sprat = table.Column<int>(nullable: false),
                    TipSobeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soba_TipSobe_TipSobeID",
                        column: x => x.TipSobeID,
                        principalTable: "TipSobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gost",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojTelefona = table.Column<string>(nullable: true),
                    FirmaID = table.Column<int>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    NalogID = table.Column<int>(nullable: false),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gost", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gost_Firma_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gost_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gost_KorisnickiNalog_NalogID",
                        column: x => x.NalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojTelefona = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    DatumZaposelenja = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: false),
                    JMBG = table.Column<string>(nullable: false),
                    NalogID = table.Column<int>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    TekuciRacun = table.Column<double>(nullable: true),
                    TipUposlenikaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.id);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_KorisnickiNalog_NalogID",
                        column: x => x.NalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_TipZaposlenika_TipUposlenikaID",
                        column: x => x.TipUposlenikaID,
                        principalTable: "TipZaposlenika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iznos = table.Column<decimal>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false),
                    datum = table.Column<DateTime>(nullable: false),
                    godina = table.Column<int>(nullable: false),
                    mjesec = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plata", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plata_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktivna = table.Column<bool>(nullable: false),
                    DatumDolaska = table.Column<DateTime>(nullable: false),
                    DatumOdlska = table.Column<DateTime>(nullable: false),
                    GostID = table.Column<int>(nullable: false),
                    _ZaposlenikId = table.Column<int>(nullable: false),
                    datumRezervacije = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Gost_GostID",
                        column: x => x.GostID,
                        principalTable: "Gost",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Zaposlenik__ZaposlenikId",
                        column: x => x._ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DodatneUslugeRezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumVrijeme = table.Column<DateTime>(nullable: false),
                    DodatneUslugeID = table.Column<int>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false),
                    Trajanje = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatneUslugeRezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DodatneUslugeRezervacija_DodatneUsluge_DodatneUslugeID",
                        column: x => x.DodatneUslugeID,
                        principalTable: "DodatneUsluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DodatneUslugeRezervacija_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaDogadjaj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dogadjajID = table.Column<int>(nullable: false),
                    rezervacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaDogadjaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervacijaDogadjaj_Dogadjaj_dogadjajID",
                        column: x => x.dogadjajID,
                        principalTable: "Dogadjaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervacijaDogadjaj_Rezervacija_rezervacijaID",
                        column: x => x.rezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaJela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRezervacije = table.Column<DateTime>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaJela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervacijaJela_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervisanaSoba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RezervacijaID = table.Column<int>(nullable: false),
                    SobaID = table.Column<int>(nullable: false),
                    pusenje = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervisanaSoba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervisanaSoba_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervisanaSoba_Soba_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Soba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    FirmaID = table.Column<int>(nullable: true),
                    Iznos = table.Column<double>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false),
                    TipUplateId = table.Column<int>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_Firma_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uplata_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplata_TipUplate_TipUplateId",
                        column: x => x.TipUplateId,
                        principalTable: "TipUplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplata_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeRezervacijeJela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JeloID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    RezervacijaJelaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeRezervacijeJela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeRezervacijeJela_Jelo_JeloID",
                        column: x => x.JeloID,
                        principalTable: "Jelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeRezervacijeJela_RezervacijaJela_RezervacijaJelaID",
                        column: x => x.RezervacijaJelaID,
                        principalTable: "RezervacijaJela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmjeteniGosti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojPasosa = table.Column<string>(nullable: true),
                    GostID = table.Column<int>(nullable: false),
                    RezervisanaSobaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmjeteniGosti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmjeteniGosti_Gost_GostID",
                        column: x => x.GostID,
                        principalTable: "Gost",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmjeteniGosti_RezervisanaSoba_RezervisanaSobaID",
                        column: x => x.RezervisanaSobaID,
                        principalTable: "RezervisanaSoba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DodatneUslugeRezervacija_DodatneUslugeID",
                table: "DodatneUslugeRezervacija",
                column: "DodatneUslugeID");

            migrationBuilder.CreateIndex(
                name: "IX_DodatneUslugeRezervacija_RezervacijaID",
                table: "DodatneUslugeRezervacija",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dogadjaj_TipDogadjajaID",
                table: "Dogadjaj",
                column: "TipDogadjajaID");

            migrationBuilder.CreateIndex(
                name: "IX_Gost_FirmaID",
                table: "Gost",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Gost_GradID",
                table: "Gost",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Gost_NalogID",
                table: "Gost",
                column: "NalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_ZaposlenikID",
                table: "Plata",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_GostID",
                table: "Rezervacija",
                column: "GostID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija__ZaposlenikId",
                table: "Rezervacija",
                column: "_ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaDogadjaj_dogadjajID",
                table: "RezervacijaDogadjaj",
                column: "dogadjajID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaDogadjaj_rezervacijaID",
                table: "RezervacijaDogadjaj",
                column: "rezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaJela_RezervacijaID",
                table: "RezervacijaJela",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanaSoba_RezervacijaID",
                table: "RezervisanaSoba",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanaSoba_SobaID",
                table: "RezervisanaSoba",
                column: "SobaID");

            migrationBuilder.CreateIndex(
                name: "IX_SmjeteniGosti_GostID",
                table: "SmjeteniGosti",
                column: "GostID");

            migrationBuilder.CreateIndex(
                name: "IX_SmjeteniGosti_RezervisanaSobaID",
                table: "SmjeteniGosti",
                column: "RezervisanaSobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_TipSobeID",
                table: "Soba",
                column: "TipSobeID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRezervacijeJela_JeloID",
                table: "StavkeRezervacijeJela",
                column: "JeloID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRezervacijeJela_RezervacijaJelaID",
                table: "StavkeRezervacijeJela",
                column: "RezervacijaJelaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_FirmaID",
                table: "Uplata",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_RezervacijaID",
                table: "Uplata",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_TipUplateId",
                table: "Uplata",
                column: "TipUplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_ZaposlenikID",
                table: "Uplata",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_GradID",
                table: "Zaposlenik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_NalogID",
                table: "Zaposlenik",
                column: "NalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_TipUposlenikaID",
                table: "Zaposlenik",
                column: "TipUposlenikaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DodatneUslugeRezervacija");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "RezervacijaDogadjaj");

            migrationBuilder.DropTable(
                name: "SmjeteniGosti");

            migrationBuilder.DropTable(
                name: "StavkeRezervacijeJela");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "DodatneUsluge");

            migrationBuilder.DropTable(
                name: "Dogadjaj");

            migrationBuilder.DropTable(
                name: "RezervisanaSoba");

            migrationBuilder.DropTable(
                name: "Jelo");

            migrationBuilder.DropTable(
                name: "RezervacijaJela");

            migrationBuilder.DropTable(
                name: "TipUplate");

            migrationBuilder.DropTable(
                name: "TipDogadjaja");

            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "TipSobe");

            migrationBuilder.DropTable(
                name: "Gost");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "TipZaposlenika");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
