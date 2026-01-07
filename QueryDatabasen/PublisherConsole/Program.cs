using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using PubContext _context = new();

//QueryFilter();
//FindIt();
//AddSomeMoreAuthors();
//SkipAndTakeAuthors();
//SortAuthors();
//QueryAggregate();
//InsertAuthor();
//RetrieveAndUpdateAuthor();
//RetrieveAndUpdateAuthorMultipleAuthors();
//VariousOperations();
DeleteAnAuthor();

void DeleteAnAuthor()
{
    var extraAuthor = _context.Authors.Find(9);
    if (extraAuthor != null)
    {
        _context.Authors.Remove(extraAuthor);

        _context.SaveChanges();
    }
}

void VariousOperations()
{
    var author = _context.Authors.Find(3);
    author.LastName = "NewIvarsson";

    var newauthor = new Author { LastName = "Alvsson", FirstName = "Dan" };
    _context.Authors.Add(newauthor);

    _context.SaveChanges();
}

void RetrieveAndUpdateAuthorMultipleAuthors()
{
    var kicanovicAuthors = _context.Authors.Where(a => a.LastName == "Hofman").ToList();
    foreach (var k in kicanovicAuthors)
    {
        k.LastName = "Efternamn";
    }

    Console.WriteLine($"Before:\r\n {_context.ChangeTracker.DebugView.ShortView}");
    _context.ChangeTracker.DetectChanges();
    Console.WriteLine($"After:\r\n {_context.ChangeTracker.DebugView.ShortView}");

    _context.SaveChanges();
}

void RetrieveAndUpdateAuthor()
{
    var author = _context.Authors.FirstOrDefault(a => a.FirstName == "Nevena" && a.LastName == "Kicanovic");

    author.FirstName = "Nina";

    _context.SaveChanges();
}

void InsertAuthor()
{
    var author = new Author { FirstName = "Anna", LastName = "Hofman" };
    _context.Authors.Add(author);

    _context.SaveChanges();
}

void QueryAggregate()
{
    var authorsDesc = _context.Authors.OrderByDescending(a => a.FirstName).ToList();

    foreach (var a in authorsDesc)
    {
        Console.WriteLine($"{a.FirstName} {a.LastName}");
    }
    Console.WriteLine("____________________________________________");
    var author = _context.Authors.OrderByDescending(a => a.FirstName)
        .FirstOrDefault(a => a.LastName == "Kicanovic");

    Console.WriteLine($"{author.FirstName} {author.LastName}");

}

void SortAuthors()
{
    var authorsByLastName = _context.Authors
                                    .OrderByDescending(a => a.LastName)
                                    .ThenByDescending(a=> a.FirstName)
                                    .ToList();
    authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + " " + a.FirstName));
    //foreach (var author in authorsByLastName)
    //{
    //    Console.WriteLine($"{author.FirstName} {author.LastName}");
    //}
}

void SkipAndTakeAuthors()
{
    var groupSize = 2;
    for(int i= 0; i<4; i++)
    {
        var authors = _context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
        Console.WriteLine($"Group {i + 1}:");
        
        foreach (var author in authors)
        {
            Console.WriteLine($"{author.FirstName} {author.LastName}");
        }
        Console.WriteLine("__________________________________________________________");
    }
    
}

void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { FirstName = "Rastko", LastName = "Kicanovic" });
    _context.Authors.Add(new Author { FirstName = "Dusan", LastName = "Jovic" });
    _context.Authors.Add(new Author { FirstName = "Jovan", LastName = "Cvijic" });
    _context.Authors.Add(new Author { FirstName = "Stefan", LastName = "Hvar" });

    _context.SaveChanges();
}

void FindIt()
{
    var authorIdTwo = _context.Authors.Find(2);
    Console.WriteLine(authorIdTwo.FirstName + " " + authorIdTwo.LastName);
}

void QueryFilter()
{
    //var firstname = "Nevena";
    //var authors = _context.Authors.Where(a => a.FirstName == firstname).ToList();
    //var filter = "R%";
    //var authors = _context.Authors.Where(a => EF.Functions.Like(a.LastName, filter)).ToList();
    var filter2 = "R";
    var authors = _context.Authors.Where(a => a.LastName.Contains(filter2)).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}