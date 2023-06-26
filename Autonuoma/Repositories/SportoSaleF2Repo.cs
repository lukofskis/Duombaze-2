namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2;

/// <summary>
/// Database operations related to 'Sutartis' entity.
/// </summary>
public class SportoSaleF2Repo
{
	public static List<SportoSaleF2L> ListSportoSale()
	{
		var query =
			$@"SELECT
				s.id,
				s.adresas,
				s.maksimalusLankytojusk,
				s.pavadinimas,
				s.darboLaikoPradzia,
				s.darboLaikoPabaiga,
				s.telefonoNumeris,
				s.elPastas,
				s.intenetineSvetaine
			FROM
				`sporto_sale` s
			ORDER BY s.id ASC";

		var drc = Sql.Query(query);

		var result =
			Sql.MapAll<SportoSaleF2L>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Adresas = dre.From<string>("adresas");
				t.MaxLankytojuSk = dre.From<int>("maksimalusLankytojusk");
				t.Pavadinimas = dre.From<string>("pavadinimas");
				t.DarboLaikPradzia = dre.From<DateTime>("darboLaikoPradzia");
				t.DarboLaikPabaiga = dre.From<DateTime>("darboLaikoPabaiga");
				t.TelefonoNumeris = dre.From<string>("telefonoNumeris");
				t.ElPastas = dre.From<string>("elPastas");
				t.internetineSvetaine = dre.From<string>("intenetineSvetaine");

			});

		return result;
	}

	public static SportoSaleF2CE FindSportoSalesCE(int id)
	{
		var query = $@"SELECT * FROM `sporto_sale` WHERE id=?id";
		var drc =
			Sql.Query(query, args => {
				args.Add("?id", id);
			});

		var result =
			Sql.MapOne<SportoSaleF2CE>(drc, (dre, t) => {
				//make a shortcut
				var sut = t.SportoSale;

				//

				sut.Pavadinimas = dre.From<string>("pavadinimas");
				sut.Adresas = dre.From<string>("adresas");
				sut.MaxLankytojuSk = dre.From<int>("maksimalusLankytojusk");
				sut.Id = dre.From<int>("id");
				sut.fk_Miestasid = dre.From<int>("fk_Miestaiid");

			});

		return result;
	}

	public static Paslaugos FindPaslaugos(int id)
	{
		var query = $@"SELECT * FROM `paslaugos` WHERE id=?id";
		var drc =
		  Sql.Query(query, args =>
		  {
			  args.Add("?id", id);
		  });

		var result =
		  Sql.MapOne<Paslaugos>(drc, (dre, prod) =>
		  {
			  //make a shortcut
			  prod.ID = dre.From<int>("id");
			  prod.Kaina = dre.From<double>("kaina");
			  prod.FKPaslaugosTipas = dre.From<int>("paslaugosTipas");


		  });

		return result;
	}

	public static int InsertSportoSale(SportoSaleF2CE sportCe)
	{
		var query =
		  $@"INSERT INTO `sporto_sale`
			(
				`id`,
				`adresas`,
				`maksimalusLankytojusk`,
				`pavadinimas`,
				`darboLaikoPradzia`,
				`darboLaikoPabaiga`,
				`telefonoNumeris`,
				`elPastas`,
				`intenetineSvetaine`,
				`fk_Miestaiid`
			)
			VALUES(
				?id,
				?adresas,
				?maksimalusLankytojusk,
				?pavadinimas,
				?darboLaikoPradzia,
				?darboLaikoPabaiga,
				?telefonoNumeris,
				?elPastas,
				?intenetineSvetaine,
				?fk_Miestaiid
				
			)";

		var id =
		  Sql.Insert(query, args =>
		  {
			  //make a shortcut
			  var prod = sportCe.SportoSale;

			  //
			  args.Add("?id",prod.Id);
			  args.Add("?adresas", prod.Adresas);
			   args.Add("?pavadinimas", prod.Pavadinimas);
			   args.Add("?darboLaikoPradzia", prod.Pavadinimas);
			   args.Add("?darboLaikoPabaiga", prod.Pavadinimas);
			   args.Add("?telefonoNumeris", prod.Pavadinimas);
			   args.Add("?elPastas", prod.Pavadinimas);
			   args.Add("?intenetineSvetaine", prod.Pavadinimas);
			  args.Add("?maksimalusLankytojusk",prod.MaxLankytojuSk);
			  args.Add("?fk_Miestaiid", prod.fk_Miestasid);
		  });

		return (int)id;
	}
	public static void UpdateSportoSale(SportoSaleF2CE sutCE)
	{
		var query =
			$@"UPDATE `sporto_sale`
			SET
				`id` = ?id,
				`adresas` = ?adresas,
				`pavadinimas` = ?pavadinimas,
				`maksimalusLankytojusk` = ?maksimalusLankytojusk,
				`fk_Miestaiid` = ?fk_Miestaiid
				
			WHERE id=?id";

		Sql.Update(query, args => {
			//make a shortcut
			var sut = sutCE.SportoSale;

            //
            args.Add("?id", sut.Id);
            args.Add("?adresas", sut.Adresas);
            args.Add("?pavadinimas", sut.Pavadinimas);
            args.Add("?maksimalusLankytojusk,", sut.MaxLankytojuSk);
            args.Add("?fk_Miestaiid", sut.fk_Miestasid);
		});
	}

	public static void DeleteSportoSale(int id)
	{
		var query = $@"DELETE FROM `sporto_sale` where id=?id";
		Sql.Delete(query, args => {
			args.Add("?nr", id);
		});
	}

	// public static List<SportoSaleF2CE.PaslaugaF2M> ListPaslauga()
	// {
	// 	var query = $@"SELECT * FROM `paslaugos` ORDER BY id ASC";
	// 	var drc = Sql.Query(query);

	// 	var result =
	// 		Sql.MapAll<SutartiesBusena>(drc, (dre, t) => {
	// 			t.Id = dre.From<int>("id");
	// 			t.Name = dre.From<string>("name");
	// 		});

	// 	return result;
	// }
	

	//Klausimas del where ka rasyti string paslaugos

	public static List<SportoSaleF2CE.PaslaugaF2M> ListPaslauga(int sutartisId)
	{
		var query =
			$@"SELECT *
			FROM `paslaugos`
			WHERE fk_SPORTO_SALEid = ?sutartisId
			ORDER BY id ASC";

		var drc =
			Sql.Query(query, args => {
				args.Add("?sutartisId", sutartisId);
			});

		var result =
			Sql.MapAll<SportoSaleF2CE.PaslaugaF2M>(drc, (dre, t) => {
				
				t.Paslaugai = dre.From<int>("paslaugosTipas");
				
				t.Kaina = dre.From<double>("kaina");
				t.FkSportoSaleid = dre.From<int>("fk_SPORTO_SALEid");
			});

		for (int i = 0; i < result.Count; i++)
			result[i].InListId = i;

		return result;
	}

	public static void InsertPaslauga(int paslaugosId, SportoSaleF2CE.PaslaugaF2M up)
	{
		
		var query =
			$@"INSERT INTO `paslaugos`
				(
					id,
					kaina,
					paslaugosTipas,
					fk_SPORTO_SALEid
				)
				VALUES(
					?id,
					?kaina,
					?paslaugosTipas,
					?fk_SPORTO_SALEid
				)";

		Sql.Insert(query, args => {
			args.Add("?id",up.InListId );
			args.Add("?kaina", up.Kaina);
			args.Add("?paslaugosTipas", up.Paslaugai);
			args.Add("?fk_SPORTO_SALEid", up.FkSportoSaleid);
			
		});
	}

	public static void DeleteUzsakytaPaslauga(int paslauga)
	{
		var query =
			$@"DELETE FROM a
			USING `paslaugos` as a
			WHERE a.id=?id";

		Sql.Delete(query, args => {
			args.Add("?id", paslauga);
		});
	}
}