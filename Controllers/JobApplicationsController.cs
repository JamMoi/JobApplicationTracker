using JobApplicationTracker.Data;
using JobApplicationTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly ApplicationDbContext context;

        // Get the database context through dependency injection
        public JobApplicationsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var searchTerm = search?.Trim();
            var query = context.JobApplications.AsQueryable();

            // Filter in the database
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(application =>
                application.CompanyName.Contains(searchTerm) ||
                application.JobTitle.Contains(searchTerm));
            }
            // Keep the search term visible
            ViewData["Search"] = searchTerm;

            var applications = await query.ToListAsync();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Create()//ASP.NET Core muodostaa lomakkeen tiedoista JobApplication-olion.
        {
            return View();
        }

        [HttpPost]//astaanottaa HTTP POST -pyyntöjä eli lomakkeelta lähetettyjä tietoja.
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobApplication application)
        {
            if (!ModelState.IsValid)

            {
                return View(application);
            }

            if (application.Status == ApplicationStatus.Applied
            && application.ApplicationDate == null)
            {
                application.ApplicationDate = DateTime.Today;
            }
            context.JobApplications.Add(application);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var application = await context.JobApplications.FindAsync(id);//Vastaanottaa muokattavan hakemuksen Id-tunnisteen.
                                                                          //Hakee hakemuksen tietokannasta FindAsync()-metodilla.
                                                                          //Palauttaa hakemuksen tiedot Edit-näkymään.
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobApplication application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(application);
            }

            var existing =await context.JobApplications.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.CompanyName = application.CompanyName;
            existing.JobTitle = application.JobTitle;
            existing.Location = application.Location;
            existing.Deadline = application.Deadline;
            existing.Status = application.Status;

            //Save the date entered in the Eit form
            existing.ApplicationDate = application.ApplicationDate;

            //set todays´s date when first marking an application as applied
            if (existing.Status == ApplicationStatus.Applied
                && existing.ApplicationDate == null)
            {
                existing.ApplicationDate = DateTime.Today;
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]

        public async Task<IActionResult> Delete (int id)
        {
            var application = await context.JobApplications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await context.JobApplications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            context.JobApplications.Remove(application);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
    }
