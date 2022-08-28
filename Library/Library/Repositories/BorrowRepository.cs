using Library.Models;

namespace Library.Repositories
{
    public class BorrowRepository: IBorrowRepository
    {
        private readonly Context context;

        public BorrowRepository(Context context)
        {
            this.context = context;
        }
        
    }
}
