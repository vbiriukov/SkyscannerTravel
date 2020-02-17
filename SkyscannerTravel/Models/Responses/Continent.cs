using System.Collections.Generic;

namespace SkyscannerTravel.Models.Responses.Continents
{
    public class Continent
    {
        public IList<Country> Countries { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }


    public class ListOfContinents
    {
        public IList<Continent> Continents { get; set; }
    }

    public class Country
    {
        public string CurrencyId { get; set; }
        public IList<Region> Regions { get; set; }
        public IList<City> Cities { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
            Cities = new List<City>();
            Regions = new List<Region>();
        }
    }

    public class City
    {
        public bool SingleAirportCity { get; set; }
        public IList<Airport> Airports { get; set; }
        public string CountryId { get; set; }
        public string Location { get; set; }
        public string IataCode { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public City()
        {
            Airports = new List<Airport>();
        }
    }

    public class Region
    {
        public string CountryId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Airport
    {
        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string Location { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
