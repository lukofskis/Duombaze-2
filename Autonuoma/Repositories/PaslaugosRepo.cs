namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;

public class PaslaugosRepo
{
	public static List<Paslaugos> List()
	{
		string query = $@"SELECT * FROM `paslaugos` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Paslaugos>(drc, (dre, t) =>
			{
				t.ID = dre.From<int>("id");
				t.Kaina = dre.From<double>("kaina");
                t.FKPaslaugosTipas = dre.From<int>("paslaugosTipas");
                t.FkSportoSale = dre.From<int>("fk_SPORTO_SALEid");
			});

		return result;
	}
}