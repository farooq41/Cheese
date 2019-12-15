using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CheeseData;
using CheeseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CheeseService
{
    public class CheeseService : ICheeseService
    {
        private Context _context;
        private IHostingEnvironment _hostingEnvironment;

        public CheeseService(Context context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public async Task<bool> CreateCheese(Cheese cheese)
        {
            try
            {
                cheese.Picture.Picture = ConvertImageToByteArray(cheese.Picture.Image);
                cheese.CreatedDate = DateTime.Now;
                var picture = _context.Pictures.Add(cheese.Picture);
                _context.Cheese.Add(cheese);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }

        private byte[] ConvertImageToByteArray(IFormFile image)
        {
            byte[] imageBytes;
            string folderName = "Upload";
            string fileName = null;
            string fullPath = null;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (image.Length > 0)
            {
                fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
            }

            imageBytes = File.ReadAllBytes(fullPath);
            File.Delete(fullPath);
            return imageBytes;

        }

        public async Task<bool> DeleteCheese(int id)
        {
            try
            {
                var cheeseToRemove = await _context.Cheese.SingleOrDefaultAsync(c => c.Id == id);
                if(cheeseToRemove != null)
                {
                    _context.Cheese.Remove(cheeseToRemove);
                    return true;
                }
                return false;
                
            }
            catch(Exception e)
            {
                return false;
            }
         
        }

        public async Task<IEnumerable<Cheese>> GetCheeses()
        {
            var cheeses =  await _context.Cheese.Include(c => c.Picture).ToListAsync();
            foreach(var cheese in cheeses)
            {
                cheese.Picture.ImageBase64 = Convert.ToBase64String(cheese.Picture.Picture);
            }

            return cheeses;
        }

        public async Task<bool> UpdateCheese(Cheese cheese)
        {
            try
            {
                var cheeseToUpdate = await _context.Cheese.SingleOrDefaultAsync(c => c.Id == cheese.Id);
                if(cheeseToUpdate != null)
                {
                    if (cheese.Picture.Image != null)
                    {
                        cheeseToUpdate.Picture.Picture = ConvertImageToByteArray(cheese.Picture.Image);
                    }
                    var result = _context.Cheese.Update(cheeseToUpdate);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
               
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
