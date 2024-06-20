using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CreateCommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CreateCommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comentModel)
        {
            await _context.Comments.AddAsync(comentModel);
            await _context.SaveChangesAsync();
            return comentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}
