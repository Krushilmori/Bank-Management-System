using Microsoft.AspNetCore.Mvc;
using BankManagementSystem.Models;
using System.Linq;

namespace BankManagementSystem.Controllers
{
    public class BankController : Controller
    {
        // In-memory data
        private static List<BankAccount> accounts = new List<BankAccount>();
        private static int nextId = 1;

        // READ
        public IActionResult Index()
        {
            return View(accounts);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BankAccount account)
        {
            if (ModelState.IsValid)
            {
                account.Id = nextId++;
                accounts.Add(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
                return NotFound();

            return View(account);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BankAccount updatedAccount)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
                return NotFound();

            account.AccountHolderName = updatedAccount.AccountHolderName;
            account.AccountNumber = updatedAccount.AccountNumber;
            account.AccountType = updatedAccount.AccountType;
            account.Balance = updatedAccount.Balance;

            return RedirectToAction(nameof(Index));
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
                return NotFound();

            return View(account);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account != null)
                accounts.Remove(account);

            return RedirectToAction(nameof(Index));
        }

        // DETAILS (optional)
        public IActionResult Details(int id)
        {
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
                return NotFound();

            return View(account);
        }
    }
}
