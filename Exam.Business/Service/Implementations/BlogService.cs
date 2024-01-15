using Exam.Business.CustomExceptions;
using Exam.Business.Service.Interfaces;
using Exam.Core.Models;
using Exam.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Service.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IWebHostEnvironment _env;

        public BlogService(IBlogRepository blogRepository,IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _env = env;
        }
        public async Task CreateAsync(Blog entity)
        {
            //var blog = await _blogRepository.Table.FindAsync( entity.Id );
            //if (blog == null) throw new Exception();

            if(entity.FormFile.FileName != null)
            {
                if(entity.FormFile.ContentType != "image/png" &&  entity.FormFile.ContentType != "image/jpeg")
                {
                    throw new ContentTypeException("FormFile","png or jpeg file");
                }
                if(entity.FormFile.Length > 2097000)
                {
                    throw new FileLengthException("FormFile","less than 2 mb");
                }

                entity.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath, "Uploads/Blogs", entity.FormFile);
            }

            await _blogRepository.CreateAsync(entity);
            await _blogRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(x => x.Id == id);
            if (blog == null) throw new BlogNotFound();
            if(blog != null)
            {
                _blogRepository.Delete(blog);
                await _blogRepository.CommitAsync();

            }
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync();
        }

        public async Task UpdateAsync(Blog entity)
        {
            var blg  = await _blogRepository.GetByIdAsync(x=>x.Id == entity.Id);
            if(blg == null) throw new BlogNotFound();

            if (entity.FormFile != null)
            {
                if (entity.FormFile.ContentType != "image/png" && entity.FormFile.ContentType != "image/jpeg")
                {
                    throw new ContentTypeException("FormFile", "png or jpeg file");
                }
                if (entity.FormFile.Length > 2097000)
                {
                    throw new FileLengthException("FormFile", "less than 2 mb");
                }

                string oldPath = Path.Combine(_env.WebRootPath, "Uploads/Blogs", blg.ImageUrl);

                if (!File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }

                blg.ImageUrl = Helper.Helper.SaveFile(_env.WebRootPath, "Uploads/Blogs", entity.FormFile);
            }

            blg.PublishedBy = entity.PublishedBy;
            blg.Title = entity.Title;
            blg.Description = entity.Description;

            await _blogRepository.CommitAsync();
        }

    }
}
