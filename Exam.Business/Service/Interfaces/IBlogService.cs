using Exam.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Service.Interfaces
{
    public interface IBlogService
    {
        
        Task CreateAsync(Blog entity);
        Task Delete(int id);
        Task UpdateAsync (Blog entity);
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
    }
}
