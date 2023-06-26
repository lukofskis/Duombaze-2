namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Database operations related to 'Darbuotojas' entity.
/// </summary>
public class DarbuotojasRepo
{
	public static List<Darbuotojas> List()
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}darbuotojai` ORDER BY tabelio_nr ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Darbuotojas>(drc, (dre, t) => {
				t.ID = dre.From<int>("id");
				t.Vardas = dre.From<string>("vardas");
				t.Pavarde = dre.From<string>("pavarde");
				t.TelefonoNumeris = dre.From<string>("telNumeris");
				t.FkLytis = dre.From<int>("lytis");
				t.FkSportoSale = dre.From<int>("fk_SPORTO_SALEid");
				
			});

		return result;
	}


}
