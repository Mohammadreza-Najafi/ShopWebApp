using _01_ShopQuery.Contracts.Product;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopWebApp.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery , ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetDetails(id);
            //Console.WriteLine();
        }

        public IActionResult OnPost(AddComment command, string productSlug)
        {
            command.Type = CommentType.Product;
            var result = _commentApplication.Add(command);

            return RedirectToPage("/Product", new { Id = productSlug});

        }

    }
}