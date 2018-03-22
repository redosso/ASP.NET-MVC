using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pogodynka.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WeatherInfo
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public City City { get; set; }
        public List<List> List { get; set; }
    }

    public class City
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Temperature
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public double Day { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Night { get; set; }
    }

    public class Weather
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class List
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public Temperature Temperature { get; set; }
        public int Humidity { get; set; }
        public List<Weather> WeatherList { get; set; }
    }
}