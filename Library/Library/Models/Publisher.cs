namespace Library.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int StablishedAt { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
