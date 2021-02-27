namespace Infrastructure.ViewModels
{
    public partial class VehicleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Odometers { get; set; }
        public string Vin { get; set; }
        public string RegistrationPlate { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
        public string Body { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string EngineSize { get; set; }
        public string Cylinders { get; set; }
        public string Type { get; set; }
        public bool IsFavourite { get; set; }

        public decimal price { get; set; }
    }
}
