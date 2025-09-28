using Microsoft.AspNetCore.Mvc;
using Walgreens.Models;
using System.Linq;

namespace Walgreens.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly WalgreensContext _context;

        public PrescriptionController(WalgreensContext context)
        {
            _context = context;
        }

        // GET: Prescription/Add
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var prescription = new Prescription
            {
                MedicationName = string.Empty,
                FillStatus = string.Empty
            };
            return View("Edit", prescription);
        }

        // GET: Prescription/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);

            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescription/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Prescription prescription)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = (prescription.PrescriptionId == 0) ? "Add" : "Edit";
                return View(prescription);
            }

            if (prescription.PrescriptionId == 0)
            {
                _context.Prescriptions.Add(prescription);
            }
            else
            {
                _context.Prescriptions.Update(prescription);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Prescription/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);

            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescription/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);

            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
