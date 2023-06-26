namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
/// <summary>
/// Database operations related to 'Uzsakovas' entity.
/// </summary>
public class KlientasRepo
{
	public static List<Klientas> List()
	{
		var query = $@"SELECT * FROM `uzsakovai` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Klientas>(drc, (dre, t) => {
				t.ID = dre.From<int>("id");
				t.Vardas = dre.From<string>("vardas");
				t.Pavarde = dre.From<string>("pavarde");
                t.Amzius = dre.From<int>("amzius");
                t.Telefonas = dre.From<string>("telefononr");
				t.FKNaryste = dre.From<int>("fk_NARYSTEid");
			});

		return result;
	}
}
