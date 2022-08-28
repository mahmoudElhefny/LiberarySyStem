using Library.Models;
using Library.Repositories.publisherRepository;

namespace Library.Repositories.PublisherRepository
{
    public class PublisherRepository: IPublisherRepository
    {
        private readonly Context context;

        public PublisherRepository(Context _context)
        {
            context = _context;
        }
        public void AddPublisher(Publisher Publisher)
        {
            if (Publisher != null)
            {
                context.Publishers.Add(Publisher);
                context.SaveChanges();
            }
        }
  public  Publisher findById(int id)
        {
            return context.Publishers.FirstOrDefault(c => c.Id == id);
        }
      public  List<Publisher> GetPublishers()
        {
            return context.Publishers.ToList();
        }
       public void Edit(int id, Publisher Publisher)
        {
            Publisher old_publisher = findById(id);
            if (old_publisher != null)
            {

                old_publisher.Name = Publisher.Name;
                old_publisher.Phone = Publisher.Phone;
                old_publisher.StablishedAt = Publisher.StablishedAt;

                context.SaveChanges();
            }
        }
       public void Delete(int id)
        {
            Publisher old_publisher = findById(id);
            if (old_publisher != null)
            {
                context.Publishers.Remove(old_publisher);
                context.SaveChanges();
            }
        }
    }
}
