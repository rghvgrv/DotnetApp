using DotnetWithMongo.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetWithMongo.Services
{
    public class BooksServices
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BooksServices(IOptions<BookDatabaseSettings> bookDatabaseSettings)
        {
            var mongoclient = new MongoClient(bookDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoclient.GetDatabase(bookDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(bookDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetBooksAsync () => await _booksCollection.Find(_ =>  true).ToListAsync();
        public async Task<Book?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
