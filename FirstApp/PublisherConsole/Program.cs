using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

//GetAuthors(); //Hämtar alla authors
//Console.WriteLine("____________________________________________________");
//GetAuthor(); //Hämtar en author enlight filter
//Console.WriteLine("____________________________________________________");
//AddAuthor();

//AddAuthorsWithBook();

//GetAuthorsWithBooks();

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);

        foreach (var book in author.Books)
        {
            Console.WriteLine(book.Title);
        }
        Console.WriteLine("_____________________________________________");
    }
}

void AddAuthorsWithBook()
{
    var author = new Author { FirstName = "Miroslav", LastName = "Radmi" };
    author.Books.Add(new Book
    {
        Title = "Programming 1", PublishDate = new DateOnly(2012,1,1)
    });
    author.Books.Add(new Book
    {
        Title = "Programming 2",
        PublishDate = new DateOnly(2015, 2, 1)
    });

    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void AddAuthor()
{
    var author = new Author { FirstName = "Anna", LastName = "Ivarsson" };
    using var context = new PubContext();
    context.Authors.Add(author); //Skapar SQL query som ska göra insert into
    context.SaveChanges(); //Sparar till DB
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

void GetAuthor()
{
    using var context = new PubContext();
    var author = context.Authors.Where(a => a.FirstName == "Nina").ToList();

    foreach (var a in author)
    {
        Console.WriteLine(a.FirstName + " " + a.LastName);
    }
}