namespace AtmPinService.Models
{
    public class NewAtmPin
    {
        public string AccountNumber { get; set; }
        public int oldAtmPin { get; set; }
        public int newAtmPin { get; set; }

    }
}
