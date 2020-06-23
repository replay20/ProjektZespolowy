using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPracownik.Models
{
    public class Pracownik
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
    }
}