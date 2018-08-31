using CasaDoCodigo.Core.Repository;
using CasaDoCodigo.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigoWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IBookRepository _bookRepository;

        public CartController(ICartService cartService, IBookRepository bookRepository)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public IActionResult Index()
        {
            var items = _cartService.GetCart();
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);
            _cartService.AddToCart(book);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);
            _cartService.RemoveFromCart(book);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);
            _cartService.DeleteFromCart(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
