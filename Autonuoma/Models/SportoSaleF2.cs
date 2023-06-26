namespace Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2.SportoSaleF2CE;


/// <summary>
/// Model of 'Aikstele' entity.
/// </summary>
public class SportoSaleF2L
{
	 [DisplayName("Id")]
	public int Id { get; set; }

	
	
    [DisplayName("Adresas")]
	[Required]
	public string Adresas { get; set; }

	
    [DisplayName("MaxLankytojuSk")]
	[Required]
	public int MaxLankytojuSk {get; set;}

	[DisplayName("Pavadinimas")]
	[Required]
	public string Pavadinimas { get; set; }

	
	[DisplayName("Dirba nuo")]
	[DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

	public System.DateTime DarboLaikPradzia { get; set; }

	[DisplayName("Dirba iki")]
	[DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
	public System.DateTime DarboLaikPabaiga { get; set; }

	[DisplayName("TelefonoNumeris")]
	[Required]
	public string TelefonoNumeris { get; set; }

	[DisplayName("ElPastas")]
	[Required]
	public string ElPastas { get; set; }

	[DisplayName("internetineSvetaine")]
	
	public string internetineSvetaine { get; set; }

	[DisplayName("Miestas")]
	public int FkMiestas { get; set; }
	

}
/// <summary>
/// 'Product' in create and edit forms.
/// </summary>
public class SportoSaleF2CE
{
	/// <summary>
	/// Entity data.
	/// </summary>
	public class SportoSaleF2M
	{

		
	 [DisplayName("Id")]
	public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		[Required]
		public string Pavadinimas { get; set; }

		[DisplayName("Adresas")]
		[Required]
		public string Adresas { get; set; }

		
    [DisplayName("MaxLankytojuSk")]
	[Required]
	public int MaxLankytojuSk {get; set;}

		

		[DisplayName("Miestas")]
		[Required]
		public int fk_Miestasid { get; set; }

	}

	
	/// <summary>
	/// Representation of 'UzsakytasGerimas' entity in 'Uzsakymas' edit form.
	/// </summary>
	public class PaslaugaF2M
	{
		/// <summary>
		/// ID of the record in the form. Is used when adding and removing records.
		/// </summary>
		/// 
		
	public int InListId { get; set; }

		[DisplayName("Kaina")]
		[Required]
		[Range(1, 99999999.99)]
		public double Kaina { get; set; }

		

		[DisplayName("Paslauga")]
		[Required]
		public int Paslaugai { get; set; }

		// [DisplayName("Kiekis")]
		// [Required]
		// [Range(1, int.MaxValue)]
		// public int Kiekis { get; set; }


		[DisplayName("Sporto Sale")]
		[Required]

		public int FkSportoSaleid { get; set; }

	}
/// <summary>
	/// Select lists for making drop downs for choosing values of entity fields.
	/// </summary>
	public class ListsM
	{
		public IList<SelectListItem> Paslaugos { get; set; }
	
		public IList<SelectListItem> Miestas { get; set; }
	}


	/// <summary>
	/// Uzsakymas.
	/// </summary>
	public SportoSaleF2M SportoSale { get; set; } = new SportoSaleF2M();

	/// <summary>
	/// Related 'UzsakytasGerimas' records.
	/// </summary>
	public IList<PaslaugaF2M> Paslauga { get; set;  } = new List<PaslaugaF2M>();

	/// <summary>
	/// Lists for drop down controls.
	/// </summary>
	public ListsM Lists { get; set; } = new ListsM();






}






	
	
	
	