using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pogodynka.Models
{
    // Modele zwracane przez akcje elementu MeController.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}