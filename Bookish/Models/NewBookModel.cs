using System.ComponentModel.DataAnnotations;
using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class NewBookModel
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required, MaxLength(13)]
        public string ISBN { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int Copies { get; set; }

        public Book AsBook()
        {
            return new Book
            {
                Title = Title,
                Author = Author,
                ISBN = ISBN
            };
        }
    }
}