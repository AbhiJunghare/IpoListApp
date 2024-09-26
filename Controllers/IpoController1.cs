using IpoList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IpoList.Controllers
{
    public class IpoController1 : Controller
    {
        private readonly IpoRepository _ipoRepository;
        public IpoController1(IpoRepository ipoRepository)
        {
            _ipoRepository = ipoRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _ipoRepository.GetAllIposAsync()) ;
        }
        

        // GET: IpoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IpoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IpoModel ipo)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    await _ipoRepository.AddIpoDetailAsync(ipo);
                    TempData["Success"] = "IPO Added successfully!";
                    return RedirectToAction(nameof(Index)); 
                }
                return View(ipo); 
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var ipo = await _ipoRepository.GetIpoByIdAsync(id); 
                if (ipo == null)
                {
                    return NotFound(); 
                }

                return View(ipo); 
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IpoModel ipo)
        {
            if (ipo == null || ipo.Id != id)
            {
                TempData["Error"] = "Invalid IPO data";
                return BadRequest("Invalid IPO data.");
            }

            try
            {
                await _ipoRepository.EditIpoDetailAsync(ipo);
                TempData["Success"] = "IPO Updated successfully!";

                return RedirectToAction("Index"); // Redirect after successful edit
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return View();
            }
        }


        // GET: IpoController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ipo = await _ipoRepository.GetIpoByIdAsync(id);
            if (ipo == null)
            {
                return NotFound();
            }

            return View(ipo);
        }

        // POST: IpoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _ipoRepository.DeleteIpoAsync(id);
                TempData["Success"] = "IPO Deleted successfully!";

                return RedirectToAction(nameof(Index)); 
            }
            catch (Exception ex)
            {
                
                TempData["Error"] = ex.Message;
                return View();
            }
        }

    }
}
