using Library.Models;
using Library.Repositories;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository publisher;

        public PublisherController(IPublisherRepository _publisher)
        {
            publisher = _publisher;
        }
        public IActionResult Index()
        {
            return View("AllPublishers", publisher.GetPublishers());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(PublisherVM model)
        {
            Publisher publish = new Publisher();
            if (ModelState.IsValid)
            {
                publish.Name = model.Name;
                publish.Phone = model.Phone;
                publish.StablishedAt = model.StablishedAt;
                publisher.AddPublisher(publish);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {


            return View( publisher.findById(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, PublisherVM publisherVM)
        {
            Publisher publish = new Publisher();
            if (ModelState.IsValid)
            {
                publish.Name = publisherVM.Name;
                publish.Phone = publisherVM.Phone;
                publish.StablishedAt = publisherVM.StablishedAt;
                publisher.Edit(id, publish);
                return RedirectToAction("Index");
            }
            return View(publisher.findById(id));
        }
        public IActionResult Delete(int id)
        {
            publisher.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
