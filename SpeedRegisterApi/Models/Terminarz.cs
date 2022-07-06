using System;
using System.Collections.Generic;

namespace SpeedRegisterApi.Models
{
    public partial class Terminarz
    {
        public int IdTerminarz { get; set; }
        public DateTime? Data { get; set; }
        public string? Rodzaj { get; set; }
        public string? Opis { get; set; }
        public string? Uwagi { get; set; }
        public string? Uzytkownik { get; set; }
        public string? UzytkownikWyk { get; set; }
        public DateTime? DataWykonania { get; set; }
        public string? Klient { get; set; }
        public int? KlientId { get; set; }
        public string? Tabor { get; set; }
        public int? TaborId { get; set; }
        public string? Kierowca { get; set; }
        public int? KierowcaId { get; set; }
        public string? Lokalizacja { get; set; }
        public int? Powtarzalny { get; set; }
        public int? Interwal { get; set; }
        public int? InterwalTyp { get; set; }
        public int? KontrahenciCrmId { get; set; }
        public string? KontrahenciCrm { get; set; }
        public string? TaborB { get; set; }
        public int? ObjTyp { get; set; }
        public int? ObjId { get; set; }
        public int? Zalaczniki { get; set; }
    }
}
