namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;

public class MiestasRepo
{
	public static List<Miestas> List()
	{
		string query = $@"SELECT * FROM `miestai` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<Miestas>(drc, (dre, t) =>
			{
				t.Id = dre.From<int>("id");
				t.Pavadinimas = dre.From<string>("pavadinimas");
				
			});

		return result;
	}

	public static Miestas Find(int id)
	{
		var query = $@"SELECT * FROM `miestai` WHERE id=?id";
		var drc =
			Sql.Query(query, args =>
			{
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<Miestas>(drc, (dre, t) =>
			{
				t.Id = dre.From<int>("id");
				t.Pavadinimas = dre.From<string>("pavadinimas");
			});

		return result;
	}

	public static void Update(Miestas gamintojas)
	{
		var query =
			$@"UPDATE `miestai` 
			SET 
				pavadinimas=?pavadinimas 
			WHERE 
				id=?id";

		Sql.Update(query, args =>
		{
			args.Add("?pavadinimas", gamintojas.Pavadinimas);
			args.Add("?id", gamintojas.Id);
		});
	}

	//public static void Insert(Miestas gamintojas)
	//{
	//	var query = $@"INSERT INTO `{Config.TblPrefix}gamintojai` ( pavadinimas, id_MIESTAS ) VALUES ( ?pavadinimas, ?id_MIESTAS )";
	//	Sql.Insert(query, args =>
	//	{
	//		args.Add("?pavadinimas", gamintojas.Pavadinimas);
	//		args.Add("?id_MIESTAS", List().Count + 1);
	//	});
	//}
	public static void Insert(Miestas gamintojas)
	{
		var query = $@"INSERT INTO `miestai` ( pavadinimas ) VALUES ( ?pavadinimas)";
		Sql.Insert(query, args =>
		{
			args.Add("?pavadinimas", gamintojas.Pavadinimas);
		});
	}

	public static void Delete(int id)
	{
		var query = $@"DELETE FROM `miestai` where id=?id";
		Sql.Delete(query, args =>
		{
			args.Add("?id", id);
		});
	}
}

