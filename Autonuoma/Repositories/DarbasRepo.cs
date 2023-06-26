namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


/// <summary>
/// Database operations related to 'Pareiga' entity.
/// </summary>
public class DarbasRepo
{
	public static List<Darbas> List()
	{
		var query = $@"SELECT * FROM `pareigos` ORDER BY id_PAREIGA ASC";
		var drc = Sql.Query(query);

		var result =
		  Sql.MapAll<Darbas>(drc, (dre, t) =>
		  {
            
			  t.ID = dre.From<int>("id");
			  t.DarboValandos = dre.From<System.DateTime>("darboValnados");
			  t.Sumoketa = dre.From<double>("sumoketa");
              t.FKPozicija = dre.From<int>("pozicija");
		  });

		return result;
	}



	
}
