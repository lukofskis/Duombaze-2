namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.SportoSaleF2;
using System.Security.Policy;


/// <summary>
/// Controller for working with 'Sutartis' entity. Implementation of F2 version.
/// </summary>
public class SportoSaleF2Controller : Controller
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(SportoSaleF2Repo.ListSportoSale());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in a browser.
	/// </summary>
	/// <returns>Entity creation form.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		var sportCE = new SportoSaleF2CE();

		

		PopulateLists(sportCE);

		return View(sportCE);
	}


	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="sutCE">Entity view model filled with latest data.</param>
	/// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Create(int? save, int? add, int? remove, SportoSaleF2CE sportCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new SportoSaleF2CE.PaslaugaF2M {
					InListId =
						sportCE.Paslauga.Count > 0 ? sportCE.Paslauga.Max(it => it.InListId) + 1 : 0,

					
					Paslaugai = 0,
					
					Kaina = 0,
					FkSportoSaleid = 1
				};
			sportCE.Paslauga.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sportCE);
			return View(sportCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{

			if(sportCE.Paslauga.Count <= 1) {
				ViewData["0paslaugu"] = true;
				return View("Delete",sportCE);
			}

			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			sportCE.Paslauga =
				sportCE
					.Paslauga
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sportCE);
			return View(sportCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for( var i = 0; i < sportCE.Paslauga.Count-1; i ++ )
			{
				var refUp = sportCE.Paslauga[i];

				for( var j = i+1; j < sportCE.Paslauga.Count; j++ )
				{
					var testUp = sportCE.Paslauga[j];
					
					if( testUp.InListId == refUp.InListId )
						ViewData["sameID"] = true;
						return View("Delete", sportCE);
				}
			}

			if (sportCE.Paslauga.Count == 0)
			{
				ViewData["emptypaslauga"] = true;
				return View("Delete", sportCE);
			}
			//form field validation passed?
			if( ModelState.IsValid )
			{
				//create new 'Sutartis'
				sportCE.SportoSale.Id = SportoSaleF2Repo.InsertSportoSale(sportCE);

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in sportCE.Paslauga )
					SportoSaleF2Repo.InsertPaslauga(sportCE.SportoSale.Id, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(sportCE);
				return View(sportCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var sporCE = SportoSaleF2Repo.FindSportoSalesCE(id);
		
		sporCE.Paslauga = SportoSaleF2Repo.ListPaslauga(id);			
		PopulateLists(sporCE);

		return View(sporCE);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>
	/// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
	/// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
	/// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
	/// <param name="sutCE">Entity view model filled with latest data.</param>
	/// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
	[HttpPost]
	public ActionResult Edit(int id, int? save, int? add, int? remove, SportoSaleF2CE sportCE)
	{
		//addition of new 'UzsakytosPaslaugos' record was requested?
		if( add != null )
		{
			//add entry for the new record
			var up =
				new SportoSaleF2CE.PaslaugaF2M {
					InListId =
						sportCE.Paslauga.Count > 0 ?
						sportCE.Paslauga.Max(it => it.InListId) + 1 :
						0,

						
					Paslaugai = 0,
				
					Kaina = 0,
					FkSportoSaleid = 1
				};
			sportCE.Paslauga.Add(up);

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sportCE);
			return View(sportCE);
		}

		//removal of existing 'UzsakytosPaslaugos' record was requested?
		if( remove != null )
		{
			if (sportCE.Paslauga.Count <= 1)
			{
				ViewData["0paslaugu"] = true;
				return View("Delete", sportCE);
			}
			//filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
			sportCE.Paslauga =
				sportCE
					.Paslauga
					.Where(it => it.InListId != remove.Value)
					.ToList();

			//make sure @Html helper is not reusing old model state containing the old list
			ModelState.Clear();

			//go back to the form
			PopulateLists(sportCE);
			return View(sportCE);
		}

		//save of the form data was requested?
		if( save != null )
		{
			//check for attemps to create duplicate 'UzsakytaPaslauga'records
			for( var i = 0; i < sportCE.Paslauga.Count-1; i ++ )
			{
				var refUp = sportCE.Paslauga[i];

				for( var j = i+1; j < sportCE.Paslauga.Count; j++ )
                {
                    var testUp = sportCE.Paslauga[j];

                    if (testUp.InListId == refUp.InListId)
                    {
                        ViewData["sameID"] = true;
                        return View("Delete", sportCE);
                    }

                }
			}

			if (sportCE.Paslauga.Count == 0)
			{
				ViewData["emptypaslauga"] = true;
				return View("Delete", sportCE);
			}


			//form field validation passed?
			if( ModelState.IsValid )
			{
				//update 'Sutartis'
				SportoSaleF2Repo.UpdateSportoSale(sportCE);

				//delete all old 'UzsakytosPaslaugos' records
				SportoSaleF2Repo.DeleteUzsakytaPaslauga(sportCE.SportoSale.Id);

				//create new 'UzsakytosPaslaugos' records
				foreach( var upVm in sportCE.Paslauga )
					SportoSaleF2Repo.InsertPaslauga(sportCE.SportoSale.Id, upVm);

				//save success, go back to the entity list
				return RedirectToAction("Index");
			}
			//form field validation failed, go back to the form
			else
			{
				PopulateLists(sportCE);
				return View(sportCE);
			}
		}

		//should not reach here
		throw new Exception("Should not reach here.");
	}

	/// <summary>
	/// This is invoked when deletion form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var sportCe = SportoSaleF2Repo.FindSportoSalesCE(id);
		return View(sportCe);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view on error, redirects to Index on success.</returns>
	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		//load 'Sutartis'
		var sporCE = SportoSaleF2Repo.FindSportoSalesCE(id);

		//'Sutartis' is in the state where deletion is permitted?
		// if( sporCE.SportoSale.fk_Miestasid == 1 || sporCE.SportoSale.fk_Miestasid == 3 )
		{
			//delete the entity
			SportoSaleF2Repo.DeleteUzsakytaPaslauga(id);
			SportoSaleF2Repo.DeleteSportoSale(id);

			//redired to list form
			return RedirectToAction("Index");
		}
		//'Sutartis' is in state where deletion is not permitted
		// else
		// {
		// 	//enable explanatory message and show delete form
		// 	ViewData["deletionNotPermitted"] = true;
		// 	return View("Delete", sutCE);
		// }
	}

	/// <summary>
	/// Populates select lists used to render drop down controls.
	/// </summary>
	/// <param name="sutCE">'Sutartis' view model to append to.</param>
	private void PopulateLists(SportoSaleF2CE sporCE)
	{
		//load entities for the select lists
		var miest = MiestasRepo.List();
		var pasl = PaslaugosRepo.List();
		//build select lists
		
sporCE.Lists.Miestas =
		  miest
			.Select(it =>
			{
				return
			  new SelectListItem
				{
					Value = Convert.ToString(it.Id),
					Text = $"{it.Pavadinimas}"
				};
			})
			.ToList();

		sporCE.Lists.Paslaugos =
		  pasl
			.Select(it =>
			{
				return
			  new SelectListItem
				{
					Value = Convert.ToString(it.ID),
					Text = $"{it.FKPaslaugosTipas}"
				};
			})
			.ToList();
	}
}
