using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;
        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
           return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }       
   
        public LibraryAsset GetById(int id)
        {
            // These lined already used so we reduce the repetitive code from method - GetAll()
            return GetAll().FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            //Again reduce the repetitive code.
            // return _context.LibraryAssets.FirstOrDefault(asset => asset.Id == id).Location;
            return GetById(id).Location;
           
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            else
                return "";
        }

        public string GetIsbn(int id)
        {
            //Any is to find if any element is their or not.
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).ISBN;
            }
            else
                return "";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.Id == id)
                .Title;
        }

        public string GetType(int id)
        {
            //     return _context.LibraryAssets.OfType<Book>().Where(a => a.Id == id);
            return "";   
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                 .Where(asset => asset.Id == id).Any();

            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            //The below code use is coalescing operator: a??b
            return isBook?
                _context.Books.FirstOrDefault(book =>book.Id == id).Author :
                _context.Videos.FirstOrDefault(video => video.Id == id).Director
            ?? "Unknown";
        }
    }
}
