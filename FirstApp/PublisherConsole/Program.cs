using PublisherData;

using(PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}