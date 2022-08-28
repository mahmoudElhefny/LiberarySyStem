using Library.Models;
namespace Library.Repositories;

public interface IPublisherRepository
{
    void AddPublisher(Publisher Publisher);
    Publisher findById(int id);
    List<Publisher> GetPublishers();
    void Edit(int id, Publisher Publisher);
    void Delete(int id);
}
