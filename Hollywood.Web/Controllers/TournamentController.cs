using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hollywood.Models;
using Hollywood.Web.Data;
using Newtonsoft.Json;
using static Holywood.Resources.APIOperation;

namespace Hollywood.Web.Controllers
{
    public class TournamentController : Controller
    {

        APIData data;

        public TournamentController()
        {
            data = new APIData();
            data.APIUrl = "http://localhost:63586/api/Tournament/";
            data.Client = new System.Net.Http.HttpClient();
        }

        // GET: Tournament
        public IActionResult Index()
        {
            data.APIUrl += "GetAll/";

            var res = GetData<TournamentModel>(data);

            return View(res);
        }

        // GET: Tournament/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            data.APIUrl += "Get/" + id;

            var res = GetData<TournamentModel>(data);

            return View(res);
        }

        // GET: Tournament/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournament/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TournamentName")] TournamentModel tournamentModel)
        {
            if (ModelState.IsValid)
            {
                data.APIUrl += "Create";

                PostData<TournamentModel>(data, tournamentModel);

                return RedirectToAction(nameof(Index));
            }
            return View(tournamentModel);
        }

        // GET: Tournament/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            data.APIUrl = "Get/" + id;

            var tournamentModel = GetData<TournamentModel>(data);

            if (tournamentModel == null)
            {
                return NotFound();
            }
            return View(tournamentModel);
        }

        // POST: Tournament/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("TournamentName")] TournamentModel tournamentModel)
        {
            if (id != tournamentModel.TournamentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    data.APIUrl = "Update";

                    PutData<TournamentModel>(data, tournamentModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentModelExists(tournamentModel.TournamentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tournamentModel);
        }

        // GET: Tournament/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            data.APIUrl += "Get/" + id;

            var tournamentModel = GetData<TournamentModel>(data);
               
            if (tournamentModel == null)
            {
                return NotFound();
            }

            return View(tournamentModel);
        }

        // POST: Tournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            data.APIUrl += "Delete/" + id;

            DeleteData<TournamentModel>(data);

            return RedirectToAction(nameof(Index));
        }

        private bool TournamentModelExists(long id)
        {
            data.APIUrl += "Get/" + id;

            return (GetData<TournamentModel>(data) != null) ? true : false;
        }
    }
}
