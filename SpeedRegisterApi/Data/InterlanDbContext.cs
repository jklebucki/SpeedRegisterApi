using Microsoft.EntityFrameworkCore;
using SpeedRegisterApi.Models;

namespace SpeedRegisterApi.Data
{
    public partial class InterlanDbContext : DbContext
    {
        public InterlanDbContext()
        {
        }

        public InterlanDbContext(DbContextOptions<InterlanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tabor> Tabor { get; set; } = null!;
        public virtual DbSet<Terminarz> Terminarz { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tabor>(entity =>
            {
                entity.HasKey(e => e.IdTaboru);

                entity.ToTable("TABOR");

                entity.HasIndex(e => e.UzytkownikId, "TABOR_IDX1");

                entity.HasIndex(e => e.Kierowca2Id, "TABOR_IDX10");

                entity.HasIndex(e => e.IsLeasing, "TABOR_IDX11");

                entity.HasIndex(e => e.WlascicielId, "TABOR_IDX2");

                entity.HasIndex(e => e.Aktywny, "TABOR_IDX3");

                entity.HasIndex(e => e.SfmTermId, "TABOR_IDX4");

                entity.HasIndex(e => e.Obcy, "TABOR_IDX5");

                entity.HasIndex(e => e.Lokalizacja, "TABOR_IDX6");

                entity.HasIndex(e => e.Hist, "TABOR_IDX7");

                entity.HasIndex(e => e.IdNaczepy, "TABOR_IDX8");

                entity.HasIndex(e => e.Kierowca1Id, "TABOR_IDX9");

                entity.HasIndex(e => e.Profil, "TABOR_SFM1");

                entity.HasIndex(e => new { e.IdTaboru, e.TypPojazduExt, e.Aktywny }, "TABOR_SFMEXT_IDX1");

                entity.HasIndex(e => e.Aktywny, "TABOR_SFMEXT_IDX2");

                entity.HasIndex(e => new { e.Obcy, e.Aktywny }, "TABOR_SFMEXT_IDX3");

                entity.Property(e => e.IdTaboru)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TABORU");

                entity.Property(e => e.Adblue).HasColumnName("ADBLUE");

                entity.Property(e => e.AdrKodPojazdu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ADR_KOD_POJAZDU");

                entity.Property(e => e.AdrZestaw)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADR_ZESTAW");

                entity.Property(e => e.AdrZestawId)
                    .HasColumnName("ADR_ZESTAW_ID")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AdrZestawSymbol)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ADR_ZESTAW_SYMBOL");

                entity.Property(e => e.Agregat).HasColumnName("AGREGAT");

                entity.Property(e => e.AgregatMarka)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AGREGAT_MARKA");

                entity.Property(e => e.AgregatNrSer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AGREGAT_NR_SER");

                entity.Property(e => e.AgregatTyp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AGREGAT_TYP");

                entity.Property(e => e.Aktywny)
                    .HasColumnName("AKTYWNY")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AmortKwota).HasColumnName("AMORT_KWOTA");

                entity.Property(e => e.AmortKwotaWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("AMORT_KWOTA_WAL");

                entity.Property(e => e.CenaSprzedazy).HasColumnName("CENA_SPRZEDAZY");

                entity.Property(e => e.CenaZakupu).HasColumnName("CENA_ZAKUPU");

                entity.Property(e => e.CennikFtl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CENNIK_FTL");

                entity.Property(e => e.CennikFtlId).HasColumnName("CENNIK_FTL_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasComment("Data utworzenia");

                entity.Property(e => e.CreateIdUser)
                    .HasColumnName("CREATE_ID_USER")
                    .HasComment("Relacja do użytkownika tworzącego rekord - tab: UZYTKOWNIK");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_TIME")
                    .HasComment("Godzina utworzenia");

                entity.Property(e => e.CreateUserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_NAME")
                    .HasComment("Nazwa użytkownika tworzącego rekord");

                entity.Property(e => e.CzynszKwota).HasColumnName("CZYNSZ_KWOTA");

                entity.Property(e => e.CzynszKwotaWal)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CZYNSZ_KWOTA_WAL");

                entity.Property(e => e.DataCzasWycof)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CZAS_WYCOF");

                entity.Property(e => e.DataPRejestracji)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_P_REJESTRACJI");

                entity.Property(e => e.DataPolisy)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_POLISY");

                entity.Property(e => e.DataPonDop)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_PON_DOP");

                entity.Property(e => e.DataRejestracji)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_REJESTRACJI");

                entity.Property(e => e.DataRozpUzytk)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_ROZP_UZYTK");

                entity.Property(e => e.DataSprzedazy)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_SPRZEDAZY");

                entity.Property(e => e.DataWyrejestrowania)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_WYREJESTROWANIA");

                entity.Property(e => e.DataZakupu)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_ZAKUPU");

                entity.Property(e => e.DecyzSanepid).HasColumnName("DECYZ_SANEPID");

                entity.Property(e => e.DecyzWeteryn).HasColumnName("DECYZ_WETERYN");

                entity.Property(e => e.Dlugosc).HasColumnName("DLUGOSC");

                entity.Property(e => e.Dmc).HasColumnName("DMC");

                entity.Property(e => e.DmcZesp).HasColumnName("DMC_ZESP");

                entity.Property(e => e.DokSprzedazy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOK_SPRZEDAZY");

                entity.Property(e => e.DokZakupu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOK_ZAKUPU");

                entity.Property(e => e.DrCenaZaAktywny).HasColumnName("DR_CENA_ZA_AKTYWNY");

                entity.Property(e => e.DrCenaZaKg).HasColumnName("DR_CENA_ZA_KG");

                entity.Property(e => e.DrCenaZaKgWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DR_CENA_ZA_KG_WAL");

                entity.Property(e => e.DrCenaZaKm).HasColumnName("DR_CENA_ZA_KM");

                entity.Property(e => e.DrCenaZaKmPuste).HasColumnName("DR_CENA_ZA_KM_PUSTE");

                entity.Property(e => e.DrCenaZaKmPusteWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DR_CENA_ZA_KM_PUSTE_WAL");

                entity.Property(e => e.DrCenaZaKmWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DR_CENA_ZA_KM_WAL");

                entity.Property(e => e.DrCenaZaMZawy).HasColumnName("DR_CENA_ZA_M_ZAWY");

                entity.Property(e => e.DrCenaZaMZawyWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DR_CENA_ZA_M_ZAWY_WAL");

                entity.Property(e => e.Dzial)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DZIAL");

                entity.Property(e => e.Dzierzawa)
                    .HasColumnName("DZIERZAWA")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EmiOrgId).HasColumnName("EMI_ORG_ID");

                entity.Property(e => e.EnaBezLicznMth).HasColumnName("ENA_BEZ_LICZN_MTH");

                entity.Property(e => e.EnaPrzeplTylkoZuz).HasColumnName("ENA_PRZEPL_TYLKO_ZUZ");

                entity.Property(e => e.EnaPrzeplywomierz).HasColumnName("ENA_PRZEPLYWOMIERZ");

                entity.Property(e => e.FrmId).HasColumnName("FRM_ID");

                entity.Property(e => e.FtlCenaZaAktywny).HasColumnName("FTL_CENA_ZA_AKTYWNY");

                entity.Property(e => e.FtlCenaZaKmP).HasColumnName("FTL_CENA_ZA_KM_P");

                entity.Property(e => e.FtlCenaZaWagaKmP).HasColumnName("FTL_CENA_ZA_WAGA_KM_P");

                entity.Property(e => e.FtlCenaZaWagaP).HasColumnName("FTL_CENA_ZA_WAGA_P");

                entity.Property(e => e.Grupa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GRUPA");

                entity.Property(e => e.GrupaId).HasColumnName("GRUPA_ID");

                entity.Property(e => e.GwarancjaLakier)
                    .HasColumnType("datetime")
                    .HasColumnName("GWARANCJA_LAKIER");

                entity.Property(e => e.GwarancjaLimitKm).HasColumnName("GWARANCJA_LIMIT_KM");

                entity.Property(e => e.GwarancjaTermin)
                    .HasColumnType("datetime")
                    .HasColumnName("GWARANCJA_TERMIN");

                entity.Property(e => e.GwarancjaUklNap)
                    .HasColumnType("datetime")
                    .HasColumnName("GWARANCJA_UKL_NAP");

                entity.Property(e => e.GwarancjaZbGl)
                    .HasColumnType("datetime")
                    .HasColumnName("GWARANCJA_ZB_GL");

                entity.Property(e => e.Haccp).HasColumnName("HACCP");

                entity.Property(e => e.Hist).HasColumnName("HIST");

                entity.Property(e => e.HistTaborId).HasColumnName("HIST_TABOR_ID");

                entity.Property(e => e.IdNaczepy).HasColumnName("ID_NACZEPY");

                entity.Property(e => e.IloscMiejsc).HasColumnName("ILOSC_MIEJSC");

                entity.Property(e => e.IloscOpon).HasColumnName("ILOSC_OPON");

                entity.Property(e => e.IluCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ILU_CODE");

                entity.Property(e => e.IneloUpdate)
                    .HasColumnName("INELO_UPDATE")
                    .HasDefaultValueSql("('0')")
                    .HasComment("czy modyfikacja z INELO");

                entity.Property(e => e.IsAdr)
                    .HasColumnName("IS_ADR")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsLeasing).HasColumnName("IS_LEASING");

                entity.Property(e => e.IsWinda)
                    .HasColumnName("IS_WINDA")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsZastaw).HasColumnName("IS_ZASTAW");

                entity.Property(e => e.KabinaOgrzPaliwem).HasColumnName("KABINA_OGRZ_PALIWEM");

                entity.Property(e => e.KatPoj)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KAT_POJ");

                entity.Property(e => e.Kierowca1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KIEROWCA1");

                entity.Property(e => e.Kierowca1Data)
                    .HasColumnType("datetime")
                    .HasColumnName("KIEROWCA1_DATA");

                entity.Property(e => e.Kierowca1Id).HasColumnName("KIEROWCA1_ID");

                entity.Property(e => e.Kierowca2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KIEROWCA2");

                entity.Property(e => e.Kierowca2Data)
                    .HasColumnType("datetime")
                    .HasColumnName("KIEROWCA2_DATA");

                entity.Property(e => e.Kierowca2Id).HasColumnName("KIEROWCA2_ID");

                entity.Property(e => e.KierowcaObcy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KIEROWCA_OBCY");

                entity.Property(e => e.KierowcaObcyId).HasColumnName("KIEROWCA_OBCY_ID");

                entity.Property(e => e.KlasyAdr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KLASY_ADR");

                entity.Property(e => e.KmPremia).HasColumnName("KM_PREMIA");

                entity.Property(e => e.KmPremiaProcLad).HasColumnName("KM_PREMIA_PROC_LAD");

                entity.Property(e => e.KodKreskowy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KOD_KRESKOWY");

                entity.Property(e => e.Kolor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KOLOR");

                entity.Property(e => e.KontenerId).HasColumnName("KONTENER_ID");

                entity.Property(e => e.KontoFk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KONTO_FK");

                entity.Property(e => e.KorZuzPalGps).HasColumnName("KOR_ZUZ_PAL_GPS");

                entity.Property(e => e.Ladownosc).HasColumnName("LADOWNOSC");

                entity.Property(e => e.LeasingDataDo)
                    .HasColumnType("datetime")
                    .HasColumnName("LEASING_DATA_DO");

                entity.Property(e => e.LeasingDataOd)
                    .HasColumnType("datetime")
                    .HasColumnName("LEASING_DATA_OD");

                entity.Property(e => e.LeasingIleMies).HasColumnName("LEASING_ILE_MIES");

                entity.Property(e => e.LeasingKwotaWykupu).HasColumnName("LEASING_KWOTA_WYKUPU");

                entity.Property(e => e.LeasingNrUmowy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LEASING_NR_UMOWY");

                entity.Property(e => e.LeasingRataMies).HasColumnName("LEASING_RATA_MIES");

                entity.Property(e => e.LeasingWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("LEASING_WAL");

                entity.Property(e => e.LiczbaKomor)
                    .HasColumnName("LICZBA_KOMOR")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LiczbaOsi)
                    .HasColumnName("LICZBA_OSI")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LimitKwotaSzkoda).HasColumnName("LIMIT_KWOTA_SZKODA");

                entity.Property(e => e.Lokalizacja)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOKALIZACJA");

                entity.Property(e => e.LokalizacjaPrzekDo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOKALIZACJA_PRZEK_DO");

                entity.Property(e => e.MapCcActive)
                    .HasColumnName("MAP_CC_ACTIVE")
                    .HasDefaultValueSql("('0')")
                    .HasComment("0/1 - czy aktywny korytarz dla pojazdu ?");

                entity.Property(e => e.MapCcDtAlert)
                    .HasColumnType("datetime")
                    .HasColumnName("MAP_CC_DT_ALERT")
                    .HasComment("data ostatnio zarejestrowanego opuszczenia korytarza (jest czyszczona jeśli pojazd powróci na obszar korytarza)");

                entity.Property(e => e.MapCcDtStart)
                    .HasColumnType("datetime")
                    .HasColumnName("MAP_CC_DT_START")
                    .HasComment("data od której uwzględniać punkty z GPS (aby nie kontrolować zbyt starych) - zwykle bieżąca");

                entity.Property(e => e.MapCcDtStop)
                    .HasColumnType("datetime")
                    .HasColumnName("MAP_CC_DT_STOP")
                    .HasComment("data do (jak MAP_CC_DT_START) - zwykle maksymalne zaplanowane juz zdarzenie na trasie");

                entity.Property(e => e.MapCcRouteid)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MAP_CC_ROUTEID")
                    .HasComment("identyfikator trasy");

                entity.Property(e => e.Marka)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MARKA");

                entity.Property(e => e.MasaWlasna).HasColumnName("MASA_WLASNA");

                entity.Property(e => e.MiejscaPaletowe).HasColumnName("MIEJSCA_PALETOWE");

                entity.Property(e => e.MocSilnika).HasColumnName("MOC_SILNIKA");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFY_DATE")
                    .HasComment("Data ostatniej modyfikacji");

                entity.Property(e => e.ModifyIdUser)
                    .HasColumnName("MODIFY_ID_USER")
                    .HasComment("Relacja do użytkownika który ostatni modyfikował rekord - tab: UZYTKOWNIK");

                entity.Property(e => e.ModifyTime)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFY_TIME")
                    .HasComment("Godzina ostatniej modyfikacji");

                entity.Property(e => e.ModifyUserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODIFY_USER_NAME")
                    .HasComment("Nazwa użytkownika modyfikującego rekord");

                entity.Property(e => e.NaciskOsi).HasColumnName("NACISK_OSI");

                entity.Property(e => e.Nadgabaryty).HasColumnName("NADGABARYTY");

                entity.Property(e => e.Norma)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NORMA");

                entity.Property(e => e.NormaAdblue).HasColumnName("NORMA_ADBLUE");

                entity.Property(e => e.NormaAgregat).HasColumnName("NORMA_AGREGAT");

                entity.Property(e => e.NormaDodMiasto).HasColumnName("NORMA_DOD_MIASTO");

                entity.Property(e => e.NormaDodObc).HasColumnName("NORMA_DOD_OBC");

                entity.Property(e => e.NormaDodZimowe).HasColumnName("NORMA_DOD_ZIMOWE");

                entity.Property(e => e.NormaMth).HasColumnName("NORMA_MTH");

                entity.Property(e => e.NormaOgrzKabiny).HasColumnName("NORMA_OGRZ_KABINY");

                entity.Property(e => e.NormaZuzOleju).HasColumnName("NORMA_ZUZ_OLEJU");

                entity.Property(e => e.NormaZuzPaliwaBez).HasColumnName("NORMA_ZUZ_PALIWA_BEZ");

                entity.Property(e => e.NormaZuzPaliwaPu).HasColumnName("NORMA_ZUZ_PALIWA_PU");

                entity.Property(e => e.NormaZuzPaliwaZ).HasColumnName("NORMA_ZUZ_PALIWA_Z");

                entity.Property(e => e.NrInwent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NR_INWENT");

                entity.Property(e => e.NrLokalizatoraGps)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NR_LOKALIZATORA_GPS");

                entity.Property(e => e.NrPodwozia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NR_PODWOZIA");

                entity.Property(e => e.NrRej)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NR_REJ")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NrRejNaczepy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NR_REJ_NACZEPY");

                entity.Property(e => e.NrSilnika)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NR_SILNIKA");

                entity.Property(e => e.NrSrTrwalego)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NR_SR_TRWALEGO");

                entity.Property(e => e.Obcy).HasColumnName("OBCY");

                entity.Property(e => e.ObcyUmowa).HasColumnName("OBCY_UMOWA");

                entity.Property(e => e.Obj).HasColumnName("OBJ");

                entity.Property(e => e.ObjCalkowita)
                    .HasColumnName("OBJ_CALKOWITA")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom1)
                    .HasColumnName("OBJ_KOM_1")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom2)
                    .HasColumnName("OBJ_KOM_2")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom3)
                    .HasColumnName("OBJ_KOM_3")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom4)
                    .HasColumnName("OBJ_KOM_4")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom5)
                    .HasColumnName("OBJ_KOM_5")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom6)
                    .HasColumnName("OBJ_KOM_6")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ObjKom7)
                    .HasColumnName("OBJ_KOM_7")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OsobnyLicznikKm).HasColumnName("OSOBNY_LICZNIK_KM");

                entity.Property(e => e.OsobnyZbPaliwa).HasColumnName("OSOBNY_ZB_PALIWA");

                entity.Property(e => e.Paleciarka).HasColumnName("PALECIARKA");

                entity.Property(e => e.PlanWymiana)
                    .HasColumnType("datetime")
                    .HasColumnName("PLAN_WYMIANA");

                entity.Property(e => e.PlanZgodaInnaLok).HasColumnName("PLAN_ZGODA_INNA_LOK");

                entity.Property(e => e.PlanZgodaInnyDzial).HasColumnName("PLAN_ZGODA_INNY_DZIAL");

                entity.Property(e => e.PoczStanLicznika).HasColumnName("POCZ_STAN_LICZNIKA");

                entity.Property(e => e.PodatekDrog).HasColumnName("PODATEK_DROG");

                entity.Property(e => e.PodatekDrogDo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PODATEK_DROG_DO");

                entity.Property(e => e.PodatekDrogDoId).HasColumnName("PODATEK_DROG_DO_ID");

                entity.Property(e => e.PodatekDrogStawka).HasColumnName("PODATEK_DROG_STAWKA");

                entity.Property(e => e.Podwykonawca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PODWYKONAWCA");

                entity.Property(e => e.PodwykonawcaId).HasColumnName("PODWYKONAWCA_ID");

                entity.Property(e => e.PojDodZbiornika).HasColumnName("POJ_DOD_ZBIORNIKA");

                entity.Property(e => e.PojSilnika).HasColumnName("POJ_SILNIKA");

                entity.Property(e => e.PojZbiornika).HasColumnName("POJ_ZBIORNIKA");

                entity.Property(e => e.PojZbiornikaAdblue).HasColumnName("POJ_ZBIORNIKA_ADBLUE");

                entity.Property(e => e.PoleDod1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POLE_DOD_1");

                entity.Property(e => e.PoleDod2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POLE_DOD_2");

                entity.Property(e => e.PoleDod3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POLE_DOD_3");

                entity.Property(e => e.Profil)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROFIL");

                entity.Property(e => e.ProfilId).HasColumnName("PROFIL_ID");

                entity.Property(e => e.ProgFracht).HasColumnName("PROG_FRACHT");

                entity.Property(e => e.ProgFrachtWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PROG_FRACHT_WAL");

                entity.Property(e => e.ProgKm).HasColumnName("PROG_KM");

                entity.Property(e => e.Rejon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REJON");

                entity.Property(e => e.RodzPaliwa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RODZ_PALIWA");

                entity.Property(e => e.RodzajKabiny)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RODZAJ_KABINY");

                entity.Property(e => e.RodzajTarczyTacho)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RODZAJ_TARCZY_TACHO");

                entity.Property(e => e.RokProdukcji).HasColumnName("ROK_PRODUKCJI");

                entity.Property(e => e.SfmInfo1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SFM_INFO_1")
                    .HasComment("info(1) wyświetlane w Aktualnym planie");

                entity.Property(e => e.SfmInfo2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SFM_INFO_2")
                    .HasComment("info(2) wyświetlane w Aktualnym planie");

                entity.Property(e => e.SfmTermId).HasColumnName("SFM_TERM_ID");

                entity.Property(e => e.Slot1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SLOT_1")
                    .HasComment("Status - SLOT 1");

                entity.Property(e => e.Slot2)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SLOT_2")
                    .HasComment("Status - SLOT 2");

                entity.Property(e => e.Slot3)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SLOT_3")
                    .HasComment("Status - SLOT 3");

                entity.Property(e => e.Slot4)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SLOT_4")
                    .HasComment("Status - SLOT 4");

                entity.Property(e => e.Slot5)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SLOT_5")
                    .HasComment("Status - SLOT 5");

                entity.Property(e => e.SposobLadowania)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SPOSOB_LADOWANIA");

                entity.Property(e => e.SrCenaAdblue).HasColumnName("SR_CENA_ADBLUE");

                entity.Property(e => e.SrCenaPaliwa).HasColumnName("SR_CENA_PALIWA");

                entity.Property(e => e.SrCenaPaliwaPwId).HasColumnName("SR_CENA_PALIWA_PW_ID");

                entity.Property(e => e.SrZaKm).HasColumnName("SR_ZA_KM");

                entity.Property(e => e.SrZaKmWal)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SR_ZA_KM_WAL");

                entity.Property(e => e.StanLicznika).HasColumnName("STAN_LICZNIKA");

                entity.Property(e => e.StanLicznikaData)
                    .HasColumnType("datetime")
                    .HasColumnName("STAN_LICZNIKA_DATA");

                entity.Property(e => e.StanLicznikaMtg).HasColumnName("STAN_LICZNIKA_MTG");

                entity.Property(e => e.StanLicznikaMtgData)
                    .HasColumnType("datetime")
                    .HasColumnName("STAN_LICZNIKA_MTG_DATA");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasComment("Status");

                entity.Property(e => e.Strefa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STREFA");

                entity.Property(e => e.SymbolKabiny)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SYMBOL_KABINY");

                entity.Property(e => e.Szerokosc).HasColumnName("SZEROKOSC");

                entity.Property(e => e.TachoDrogaPik1).HasColumnName("TACHO_DROGA_PIK_1");

                entity.Property(e => e.TachoDrogaPik2).HasColumnName("TACHO_DROGA_PIK_2");

                entity.Property(e => e.Telematyka).HasColumnName("TELEMATYKA");

                entity.Property(e => e.TempPlus).HasColumnName("TEMP_PLUS");

                entity.Property(e => e.TypPojazdu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYP_POJAZDU");

                entity.Property(e => e.TypPojazduExt)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TYP_POJAZDU_EXT");

                entity.Property(e => e.TypPojazduExt2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TYP_POJAZDU_EXT2");

                entity.Property(e => e.TypPojazduId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYP_POJAZDU_ID");

                entity.Property(e => e.TypZabudowy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TYP_ZABUDOWY");

                entity.Property(e => e.Uwagi)
                    .HasColumnType("text")
                    .HasColumnName("UWAGI");

                entity.Property(e => e.UwzglWageNacz).HasColumnName("UWZGL_WAGE_NACZ");

                entity.Property(e => e.UzytkowanyPrzez)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UZYTKOWANY_PRZEZ");

                entity.Property(e => e.UzytkowanyPrzezId).HasColumnName("UZYTKOWANY_PRZEZ_ID");

                entity.Property(e => e.UzytkowanyPrzezO)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("UZYTKOWANY_PRZEZ_O");

                entity.Property(e => e.UzytkowanyPrzezOId).HasColumnName("UZYTKOWANY_PRZEZ_O_ID");

                entity.Property(e => e.Uzytkownik)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UZYTKOWNIK");

                entity.Property(e => e.UzytkownikId).HasColumnName("UZYTKOWNIK_ID");

                entity.Property(e => e.Vip)
                    .HasColumnName("VIP")
                    .HasComment("Flaga, czy VIP");

                entity.Property(e => e.WartoscPolisy).HasColumnName("WARTOSC_POLISY");

                entity.Property(e => e.Wlasciciel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WLASCICIEL");

                entity.Property(e => e.WlascicielId).HasColumnName("WLASCICIEL_ID");

                entity.Property(e => e.WlascicielOpiekun)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("WLASCICIEL_OPIEKUN");

                entity.Property(e => e.WlascicielOpiekunId).HasColumnName("WLASCICIEL_OPIEKUN_ID");

                entity.Property(e => e.WypDod)
                    .HasMaxLength(248)
                    .IsUnicode(false)
                    .HasColumnName("WYP_DOD");

                entity.Property(e => e.WysPrzesBok).HasColumnName("WYS_PRZES_BOK");

                entity.Property(e => e.WysPrzesTyl).HasColumnName("WYS_PRZES_TYL");

                entity.Property(e => e.Wysokosc).HasColumnName("WYSOKOSC");

                entity.Property(e => e.Zalaczniki).HasColumnName("ZALACZNIKI");

                entity.Property(e => e.Zdjecie)
                    .HasColumnType("image")
                    .HasColumnName("ZDJECIE");
            });

            modelBuilder.Entity<Terminarz>(entity =>
            {
                entity.HasKey(e => e.IdTerminarz);

                entity.ToTable("TERMINARZ");

                entity.HasIndex(e => e.Data, "TERMINARZ_IDX1");

                entity.HasIndex(e => e.DataWykonania, "TERMINARZ_IDX2");

                entity.HasIndex(e => e.KlientId, "TERMINARZ_IDX3");

                entity.HasIndex(e => e.KontrahenciCrmId, "TERMINARZ_IDX4");

                entity.HasIndex(e => e.TaborId, "TERMINARZ_IDX5");

                entity.HasIndex(e => e.KierowcaId, "TERMINARZ_IDX6");

                entity.HasIndex(e => e.Lokalizacja, "TERMINARZ_IDX7");

                entity.HasIndex(e => new { e.ObjTyp, e.ObjId }, "TERMINARZ_IDX8");

                entity.Property(e => e.IdTerminarz)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TERMINARZ");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA");

                entity.Property(e => e.DataWykonania)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_WYKONANIA");

                entity.Property(e => e.Interwal).HasColumnName("INTERWAL");

                entity.Property(e => e.InterwalTyp).HasColumnName("INTERWAL_TYP");

                entity.Property(e => e.Kierowca)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("KIEROWCA");

                entity.Property(e => e.KierowcaId).HasColumnName("KIEROWCA_ID");

                entity.Property(e => e.Klient)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KLIENT");

                entity.Property(e => e.KlientId).HasColumnName("KLIENT_ID");

                entity.Property(e => e.KontrahenciCrm)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("KONTRAHENCI_CRM");

                entity.Property(e => e.KontrahenciCrmId).HasColumnName("KONTRAHENCI_CRM_ID");

                entity.Property(e => e.Lokalizacja)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOKALIZACJA");

                entity.Property(e => e.ObjId).HasColumnName("OBJ_ID");

                entity.Property(e => e.ObjTyp).HasColumnName("OBJ_TYP");

                entity.Property(e => e.Opis)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("OPIS");

                entity.Property(e => e.Powtarzalny).HasColumnName("POWTARZALNY");

                entity.Property(e => e.Rodzaj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RODZAJ");

                entity.Property(e => e.Tabor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TABOR");

                entity.Property(e => e.TaborB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TABOR_B");

                entity.Property(e => e.TaborId).HasColumnName("TABOR_ID");

                entity.Property(e => e.Uwagi)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("UWAGI");

                entity.Property(e => e.Uzytkownik)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UZYTKOWNIK");

                entity.Property(e => e.UzytkownikWyk)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UZYTKOWNIK_WYK");

                entity.Property(e => e.Zalaczniki).HasColumnName("ZALACZNIKI");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
