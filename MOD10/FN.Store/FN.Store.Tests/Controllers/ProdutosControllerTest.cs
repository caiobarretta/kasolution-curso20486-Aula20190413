using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using FN.Store.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Tests.Controllers
{
    [TestClass]
    [TestCategory("ProdutosController")]
    public class ProdutosControllerTest
    {
        //Dado um produtos controller
        [TestMethod]
        public void OMetodoIndexDeveraRetornarUmaViewComProdutos()
        {
            //a
            var produtosCtrl = new ProdutosController(new ProdutoRepository(), new CategoriaRepository());

            //a
            var result = produtosCtrl.Index();
            var model = result.Model as IEnumerable<Produto>;

            //a
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            Assert.IsNotNull(model);
        }

        private class ProdutoRepository : IProdutoRepository
        {
            public void Add(Produto entity)
            {
                throw new NotImplementedException();
            }

            public void Delete(Produto entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Produto> Get()
            {
                return new List<Produto>();
            }

            public Produto Get(object id)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Produto> GetByName(string contains)
            {
                throw new NotImplementedException();
            }

            public void Update(Produto entity)
            {
                throw new NotImplementedException();
            }
        }

        private class CategoriaRepository : ICategoriaRepository
        {
            public void Add(Categoria entity)
            {
                throw new NotImplementedException();
            }

            public void Delete(Categoria entity)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Categoria> Get()
            {
                throw new NotImplementedException();
            }

            public Categoria Get(object id)
            {
                throw new NotImplementedException();
            }

            public void Update(Categoria entity)
            {
                throw new NotImplementedException();
            }
        }
    }
}
