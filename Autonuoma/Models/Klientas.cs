namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Klientas' entity.
/// </summary>
public class Klientas
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

	[DisplayName("Amzius")]
	
	[Required]
	public int? Amzius { get; set; }

	[DisplayName("Telefonas")]
	[Required]
	public string Telefonas { get; set; }

	[DisplayName("Naryste")]
	[Required]
	public int FKNaryste { get; set; }




}
