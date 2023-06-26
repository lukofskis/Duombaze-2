namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Darbuotojas' entity.
/// </summary>
public class Paslaugos
{
	[DisplayName("ID")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Kaina")]
	[Required]
	public double Kaina { get; set; }

	[DisplayName("Paslaugos tipas")]
	[Required]
	public int FKPaslaugosTipas { get; set; }

    
	[DisplayName("Sporto sale")]
	[Required]
	public int FkSportoSale { get; set; }


}
