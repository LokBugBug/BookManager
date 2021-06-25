using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookContext context = new BookContext();
            var listbook = context.Books.ToList();
            return View(listbook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookContext context = new BookContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            BookContext context = new BookContext();
            context.Books.AddOrUpdate(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
        
        public ActionResult Edit(int id)
        {
            BookContext context = new BookContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book ==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]

       public ActionResult Edit(Book book)
        {
            BookContext context = new BookContext();
            Book bookUpdate = context.Books.SingleOrDefault(p => p.ID == book.ID);
            if(bookUpdate !=null)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            BookContext context = new BookContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if( book == null )
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            BookContext context = new BookContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book !=null)
            {
                context.Books.Remove(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }
    }
}