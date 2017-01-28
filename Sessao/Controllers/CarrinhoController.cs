using Sessao.Models;
using System.Web.Mvc;

namespace Sessao.Controllers
{
    public class CarrinhoController : Controller
    {
        public ActionResult Index()
        {
            return View(PegaCarrinhoDaSessao());
        }

        public ActionResult Cancelar()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Produtos");
        }

        public ActionResult Adicionar(int id = 0)
        {
            K19Context ctx = new K19Context();
            Produto p = ctx.Produtos.Find(id);

            if(p == null)
            {
                return HttpNotFound();
            }

            Carrinho carrinho = PegaCarrinhoDaSessao();
            carrinho.Produtos.Add(p);

            TempData["Mensagem"] = "Produto adicionado ao carrinho com sucesso";

            return RedirectToAction("Index", "Produtos");
        }

        public ActionResult Remover(int id = 0)
        {
            Carrinho carrinho = this.PegaCarrinhoDaSessao();
            carrinho.Produtos.RemoveAt(id);

            return RedirectToAction("Index");
        }

        private Carrinho PegaCarrinhoDaSessao()
        {
            if(Session["Carrinho"] == null)
            {
                Session["Carrinho"] = new Carrinho();
            }

            return (Carrinho)Session["Carrinho"];
        }
    }
}