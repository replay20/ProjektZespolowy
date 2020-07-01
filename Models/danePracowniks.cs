using System;
using System.ComponentModel.DataAnnotations;

namespace MvcdanePracowniks.Models
{
    public class danePracowniks
    {
        public int Id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string stanowisko { get; set; }
        public string uprawnienia { get; set; }
    }
}