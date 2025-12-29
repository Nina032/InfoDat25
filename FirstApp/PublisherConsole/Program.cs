using PublisherData;
using PublisherDomain;

using(PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

GetAuthors(); //Hämtar alla authors
Console.WriteLine("____________________________________________________");
GetAuthor(); //Hämtar en author enlight filter


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