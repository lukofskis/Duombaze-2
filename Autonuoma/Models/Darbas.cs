namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Darbuotojas' entity.
/// </summary>
public class Darbas
{
	[DisplayName("ID")]
	[Required]
	public int ID { get; set; }

	[DisplayName("Darbo valnados")]
	[DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

	public System.DateTime DarboValandos { get; set; }

	[DisplayName("Sumoketa")]
	[Required]
	public double Sumoketa { get; set; }

	[DisplayName("Poziija")]
	[Required]
	public int FKPozicija { get; set; }



}
