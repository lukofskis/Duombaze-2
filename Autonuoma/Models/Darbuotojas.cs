namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Darbuotojas' entity.
/// </summary>
public class Darbuotojas
{
	[DisplayName("ID")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Vardas")]
	[Required]
	public string Vardas { get; set; }

	[DisplayName("Pavardė")]
	[Required]
	public string Pavarde { get; set; }

	[DisplayName("TelefonoNumeris")]
	[Required]
	public string TelefonoNumeris { get; set; }

	[DisplayName("Lytis")]
	[Required]
	public int FkLytis { get; set; }

	[DisplayName("Sporto sale")]
	[Required]
    public int FkSportoSale { get; set; }

}
