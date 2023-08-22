using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Project_20.Data;
using Project_20.Models;
using System;
using System.IO;
using System.Linq;

namespace Project_20.Controllers
{
    public class HomeController : Controller
    {
        DbContextOptions<ContactContext> options;

        public HomeController()
        {
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\Data\\HomeWorkDb.mdf"));
            options = new DbContextOptionsBuilder<ContactContext>()
                .UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename=\"{path}\";Integrated Security=True;Connect Timeout=30")
                .Options;
        }

        public IActionResult Index()
        {
            var contacts = new ContactContext(options).Contacts;
            return View(contacts);
        }

        public IActionResult GeneratedContactList()
        {
            var contacts = Repository.GetContacts();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View(Repository.GetContact());
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Contact contact = new ContactContext(options).Contacts.Where(x => x.Id == Id).FirstOrDefault();
            return View(contact);
        }

        public IActionResult Edit(int Id)
        {
            Contact contact = new ContactContext(options).Contacts.Where(x => x.Id == Id).FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            using (var db = new ContactContext(options))
            {
                db.Contacts.Update(contact);
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult CreateNewContact(Contact contact)
        {
            using (var db = new ContactContext(options))
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        public IActionResult Delete(int id)
        {
            using (var db = new ContactContext(options))
            {
                db.Contacts.Remove(db.Contacts.Find(id));
                db.SaveChanges();
            }
            return Redirect("~/");
        }
    }
}
