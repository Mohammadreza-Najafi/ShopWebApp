using _0_Framwork.Infrastructure;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _context;
        public CommentRepository(CommentContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _context.Comments
                .Select(x => new CommentViewModel
            {
                Name = x.Name,
                Id = x.Id,
                Email = x.Email,
                Message = x.Message,
                OwnerRecordId = x.OwnerRecordId,
                Type = x.Type,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,       
                CommentDate = x.CreationDate.ToString(),
                });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));    

            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
