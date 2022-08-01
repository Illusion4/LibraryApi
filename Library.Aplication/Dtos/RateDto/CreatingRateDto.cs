using System.ComponentModel.DataAnnotations;

namespace Library.Aplication.Dtos.RateDto;

public class CreatingRateDto
{
    [Range(1,5)]
    public double Score { get; set; }
}