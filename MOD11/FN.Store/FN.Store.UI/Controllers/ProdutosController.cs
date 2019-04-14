using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace FN.Store.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        //private readonly StoreDataContext _ctx;
        //public ProdutosController(IConfiguration config) => _ctx = new StoreDataContext(config);

        public ProdutosController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public ViewResult Index()
        {
            //var data = _ctx.Produtos.Include(nameof(Categoria)).ToList();
            //var data = _ctx.Produtos
            //        .Include(p => p.Categoria)
            //        .ToList();
            var data = _produtoRepository.Get();
            data.ToList().ForEach(d => d.Categoria = _categoriaRepository.Get(d.CategoriaId));
            return View(data);
        }

        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            Produto produto = null;
            if (id != null)
                //produto = _ctx.Produtos.Find(id);
                produto = _produtoRepository.Get(id);

            //ViewBag.Categorias = _ctx.Categorias
            //        .ToList()
            //        .Select(c => new SelectListItem
            //        {
            //            Value = c.Id.ToString(),
            //            Text = c.Nome.ToString()
            //        });
            ViewBag.Categorias = _categoriaRepository.Get().Select(
                c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                });

            return View(produto);
        }

        [HttpPost]
        public IActionResult AddEdit(Produto produto)
        {
            if (!ModelState.IsValid)
                return View();

            var msg = $"Produto {produto.Nome} ";
            if (produto.Id == 0)
            {
                //_ctx.Add(produto);
                _produtoRepository.Add(produto);
                msg += "adicionado";
            }

            else
            {
                //_ctx.Update(produto);
                _produtoRepository.Update(produto);
                msg += "atualizado";
            }
            msg += " com sucesso!";
            //_ctx.SaveChanges();

            TempData["msg"] = msg;

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //var produto = _ctx.Produtos.Find(id);
            var produto = _produtoRepository.Get(id);

            if (produto == null)
                return BadRequest("Esse cara não existe!");

            //_ctx.Produtos.Remove(produto);
            //_ctx.SaveChanges();
            _produtoRepository.Delete(produto);

            return Ok();
        }

    }
}
