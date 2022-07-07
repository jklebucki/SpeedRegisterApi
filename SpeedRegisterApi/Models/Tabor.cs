namespace SpeedRegisterApi.Models
{
    public partial class Tabor
    {
        public int IdTaboru { get; set; }
        public string? KodKreskowy { get; set; }
        public int? Obcy { get; set; }
        public int? ObcyUmowa { get; set; }
        public string NrRej { get; set; } = null!;
        public string? NrRejNaczepy { get; set; }
        public int? IdNaczepy { get; set; }
        public int? HistTaborId { get; set; }
        public int? Hist { get; set; }
        public int? IsAdr { get; set; }
        public int? IsWinda { get; set; }
        public int? Aktywny { get; set; }
        public int? Dzierzawa { get; set; }
        public int? Telematyka { get; set; }
        public string? KatPoj { get; set; }
        public string? Grupa { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public int? RokProdukcji { get; set; }
        public string? NrSilnika { get; set; }
        public string? NrPodwozia { get; set; }
        public string? NrInwent { get; set; }
        public string? Norma { get; set; }
        public double? PojSilnika { get; set; }
        public double? MocSilnika { get; set; }
        public double? PojZbiornika { get; set; }
        public double? PojDodZbiornika { get; set; }
        public string? TypPojazduId { get; set; }
        public string? TypPojazdu { get; set; }
        public string? TypPojazduExt { get; set; }
        public string? TypPojazduExt2 { get; set; }
        public double? MasaWlasna { get; set; }
        public double? Dmc { get; set; }
        public double? DmcZesp { get; set; }
        public double? NaciskOsi { get; set; }
        public double? Ladownosc { get; set; }
        public double? Dlugosc { get; set; }
        public double? Wysokosc { get; set; }
        public double? Szerokosc { get; set; }
        public int? MiejscaPaletowe { get; set; }
        public string? WypDod { get; set; }
        public int? LiczbaOsi { get; set; }
        public int? Nadgabaryty { get; set; }
        public double? WysPrzesBok { get; set; }
        public double? WysPrzesTyl { get; set; }
        public int? LiczbaKomor { get; set; }
        public int? ObjKom1 { get; set; }
        public int? ObjKom2 { get; set; }
        public int? ObjKom3 { get; set; }
        public int? ObjKom4 { get; set; }
        public int? ObjKom5 { get; set; }
        public int? ObjKom6 { get; set; }
        public int? ObjKom7 { get; set; }
        public int? ObjCalkowita { get; set; }
        public double? WartoscPolisy { get; set; }
        public DateTime? DataPolisy { get; set; }
        public DateTime? DataRozpUzytk { get; set; }
        public int? PoczStanLicznika { get; set; }
        public DateTime? DataZakupu { get; set; }
        public double? CenaZakupu { get; set; }
        public string? DokZakupu { get; set; }
        public string? NrSrTrwalego { get; set; }
        public DateTime? DataSprzedazy { get; set; }
        public double? CenaSprzedazy { get; set; }
        public string? DokSprzedazy { get; set; }
        public DateTime? DataCzasWycof { get; set; }
        public DateTime? DataWyrejestrowania { get; set; }
        public DateTime? DataPonDop { get; set; }
        public DateTime? GwarancjaTermin { get; set; }
        public int? GwarancjaLimitKm { get; set; }
        public DateTime? GwarancjaUklNap { get; set; }
        public DateTime? GwarancjaLakier { get; set; }
        public DateTime? GwarancjaZbGl { get; set; }
        public DateTime? DataPRejestracji { get; set; }
        public DateTime? DataRejestracji { get; set; }
        public int? CennikFtlId { get; set; }
        public string? CennikFtl { get; set; }
        public string? RodzPaliwa { get; set; }
        public int? OsobnyLicznikKm { get; set; }
        public int? OsobnyZbPaliwa { get; set; }
        public int? Agregat { get; set; }
        public int? KabinaOgrzPaliwem { get; set; }
        public double? NormaZuzOleju { get; set; }
        public double? NormaZuzPaliwaPu { get; set; }
        public double? NormaZuzPaliwaZ { get; set; }
        public double? NormaZuzPaliwaBez { get; set; }
        public double? NormaDodObc { get; set; }
        public double? NormaDodMiasto { get; set; }
        public double? NormaOgrzKabiny { get; set; }
        public double? NormaMth { get; set; }
        public double? NormaAgregat { get; set; }
        public double? NormaAdblue { get; set; }
        public double? KorZuzPalGps { get; set; }
        public int? AdrZestawId { get; set; }
        public string? AdrZestaw { get; set; }
        public string? AdrZestawSymbol { get; set; }
        public string? AdrKodPojazdu { get; set; }
        public string? Lokalizacja { get; set; }
        public string? Dzial { get; set; }
        public string? LokalizacjaPrzekDo { get; set; }
        public string? KontoFk { get; set; }
        public int? StanLicznika { get; set; }
        public DateTime? StanLicznikaData { get; set; }
        public double? StanLicznikaMtg { get; set; }
        public DateTime? StanLicznikaMtgData { get; set; }
        public int? WlascicielId { get; set; }
        public string? Wlasciciel { get; set; }
        public int? KierowcaObcyId { get; set; }
        public string? KierowcaObcy { get; set; }
        public DateTime? Kierowca1Data { get; set; }
        public int? Kierowca1Id { get; set; }
        public string? Kierowca1 { get; set; }
        public DateTime? Kierowca2Data { get; set; }
        public int? Kierowca2Id { get; set; }
        public string? Kierowca2 { get; set; }
        public string? SymbolKabiny { get; set; }
        public string? RodzajKabiny { get; set; }
        public int? IloscMiejsc { get; set; }
        public string? Kolor { get; set; }
        public string? RodzajTarczyTacho { get; set; }
        public string? TypZabudowy { get; set; }
        public string? SposobLadowania { get; set; }
        public int? Paleciarka { get; set; }
        public int? DecyzSanepid { get; set; }
        public int? DecyzWeteryn { get; set; }
        public int? Adblue { get; set; }
        public double? PojZbiornikaAdblue { get; set; }
        public int? UzytkownikId { get; set; }
        public string? Uzytkownik { get; set; }
        public string? PoleDod1 { get; set; }
        public string? PoleDod2 { get; set; }
        public string? PoleDod3 { get; set; }
        public string? Uwagi { get; set; }
        public double? ProgKm { get; set; }
        public double? ProgFracht { get; set; }
        public string? ProgFrachtWal { get; set; }
        public double? SrZaKm { get; set; }
        public string? SrZaKmWal { get; set; }
        public double? KmPremia { get; set; }
        public double? KmPremiaProcLad { get; set; }
        public double? SrCenaPaliwa { get; set; }
        public double? SrCenaAdblue { get; set; }
        public int? SrCenaPaliwaPwId { get; set; }
        public int? ProfilId { get; set; }
        public string? Profil { get; set; }
        public string? KlasyAdr { get; set; }
        public int? IsZastaw { get; set; }
        public int? IsLeasing { get; set; }
        public int? LeasingIleMies { get; set; }
        public DateTime? LeasingDataOd { get; set; }
        public DateTime? LeasingDataDo { get; set; }
        public double? LeasingKwotaWykupu { get; set; }
        public double? LeasingRataMies { get; set; }
        public string? LeasingWal { get; set; }
        public double? LimitKwotaSzkoda { get; set; }
        public int? SfmTermId { get; set; }
        /// <summary>
        /// 0/1 - czy aktywny korytarz dla pojazdu ?
        /// </summary>
        public short? MapCcActive { get; set; }
        /// <summary>
        /// data od której uwzględniać punkty z GPS (aby nie kontrolować zbyt starych) - zwykle bieżąca
        /// </summary>
        public DateTime? MapCcDtStart { get; set; }
        /// <summary>
        /// data do (jak MAP_CC_DT_START) - zwykle maksymalne zaplanowane juz zdarzenie na trasie
        /// </summary>
        public DateTime? MapCcDtStop { get; set; }
        /// <summary>
        /// data ostatnio zarejestrowanego opuszczenia korytarza (jest czyszczona jeśli pojazd powróci na obszar korytarza)
        /// </summary>
        public DateTime? MapCcDtAlert { get; set; }
        /// <summary>
        /// identyfikator trasy
        /// </summary>
        public string? MapCcRouteid { get; set; }
        public int? TachoDrogaPik1 { get; set; }
        public int? TachoDrogaPik2 { get; set; }
        public int? DrCenaZaAktywny { get; set; }
        public double? DrCenaZaKm { get; set; }
        public string? DrCenaZaKmWal { get; set; }
        public double? DrCenaZaKmPuste { get; set; }
        public string? DrCenaZaKmPusteWal { get; set; }
        public double? DrCenaZaMZawy { get; set; }
        public string? DrCenaZaMZawyWal { get; set; }
        public double? DrCenaZaKg { get; set; }
        public string? DrCenaZaKgWal { get; set; }
        public int? Zalaczniki { get; set; }
        public byte[]? Zdjecie { get; set; }
        /// <summary>
        /// Relacja do użytkownika tworzącego rekord - tab: UZYTKOWNIK
        /// </summary>
        public int? CreateIdUser { get; set; }
        /// <summary>
        /// Nazwa użytkownika tworzącego rekord
        /// </summary>
        public string? CreateUserName { get; set; }
        /// <summary>
        /// Data utworzenia
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Godzina utworzenia
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// Relacja do użytkownika który ostatni modyfikował rekord - tab: UZYTKOWNIK
        /// </summary>
        public int? ModifyIdUser { get; set; }
        /// <summary>
        /// Nazwa użytkownika modyfikującego rekord
        /// </summary>
        public string? ModifyUserName { get; set; }
        /// <summary>
        /// Data ostatniej modyfikacji
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// Godzina ostatniej modyfikacji
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        public int? EnaPrzeplywomierz { get; set; }
        public int? EnaPrzeplTylkoZuz { get; set; }
        public int? EnaBezLicznMth { get; set; }
        public int? FtlCenaZaAktywny { get; set; }
        public double? FtlCenaZaKmP { get; set; }
        public double? FtlCenaZaWagaP { get; set; }
        public double? FtlCenaZaWagaKmP { get; set; }
        public int? PlanZgodaInnaLok { get; set; }
        public int? PlanZgodaInnyDzial { get; set; }
        public string? AgregatNrSer { get; set; }
        public string? AgregatTyp { get; set; }
        public string? AgregatMarka { get; set; }
        public int? IloscOpon { get; set; }
        public string? LeasingNrUmowy { get; set; }
        public int? FrmId { get; set; }
        public int? GrupaId { get; set; }
        public double? Obj { get; set; }
        public int? KontenerId { get; set; }
        public int? UzytkowanyPrzezId { get; set; }
        public string? UzytkowanyPrzez { get; set; }
        public int? UzytkowanyPrzezOId { get; set; }
        public string? UzytkowanyPrzezO { get; set; }
        public int? WlascicielOpiekunId { get; set; }
        public string? WlascicielOpiekun { get; set; }
        public int? PodatekDrog { get; set; }
        public double? PodatekDrogStawka { get; set; }
        public int? PodatekDrogDoId { get; set; }
        public string? PodatekDrogDo { get; set; }
        public double? CzynszKwota { get; set; }
        public string? CzynszKwotaWal { get; set; }
        public DateTime? PlanWymiana { get; set; }
        public double? AmortKwota { get; set; }
        public string? AmortKwotaWal { get; set; }
        public string? Strefa { get; set; }
        public string? IluCode { get; set; }
        public int? TempPlus { get; set; }
        /// <summary>
        /// czy modyfikacja z INELO
        /// </summary>
        public int? IneloUpdate { get; set; }
        public int? Haccp { get; set; }
        public int? EmiOrgId { get; set; }
        public double? NormaDodZimowe { get; set; }
        public int? UwzglWageNacz { get; set; }
        public int? PodwykonawcaId { get; set; }
        public string? Podwykonawca { get; set; }
        public string? NrLokalizatoraGps { get; set; }
        /// <summary>
        /// info(1) wyświetlane w Aktualnym planie
        /// </summary>
        public string? SfmInfo1 { get; set; }
        /// <summary>
        /// info(2) wyświetlane w Aktualnym planie
        /// </summary>
        public string? SfmInfo2 { get; set; }
        public string? Rejon { get; set; }
        /// <summary>
        /// Flaga, czy VIP
        /// </summary>
        public int? Vip { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// Status - SLOT 1
        /// </summary>
        public string? Slot1 { get; set; }
        /// <summary>
        /// Status - SLOT 2
        /// </summary>
        public string? Slot2 { get; set; }
        /// <summary>
        /// Status - SLOT 3
        /// </summary>
        public string? Slot3 { get; set; }
        /// <summary>
        /// Status - SLOT 4
        /// </summary>
        public string? Slot4 { get; set; }
        /// <summary>
        /// Status - SLOT 5
        /// </summary>
        public string? Slot5 { get; set; }
    }
}
