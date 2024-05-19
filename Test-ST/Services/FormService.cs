using Microsoft.EntityFrameworkCore;
using Test_ST.Data;
using Test_ST.Models;
using Test_ST.ViewModels;

namespace Test_ST.Services
{
    public interface IFormService
    {
        Task<Form> CreateFormAsync(FormRequest form);
        Task<List<Form>> GetAllFormsAsync();
        Task<Form?> GetFormByIdAsync(int id);
    }

    public class FormService : IFormService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public FormService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Form?> GetFormByIdAsync(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var form = await context.Forms
                .Include(f => f.Questions)
                .FirstOrDefaultAsync(f => f.Id == id);
            return form;
        }
        public async Task<Form> CreateFormAsync(FormRequest form)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var newForm = new Form
            {
                Title = form.Title
            };
            await context.Forms.AddAsync(newForm);
            await context.SaveChangesAsync();
            return newForm;
        }
        public async Task<List<Form>> GetAllFormsAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.Forms.Include(f => f.Questions).ToListAsync();
        }
    }
}
