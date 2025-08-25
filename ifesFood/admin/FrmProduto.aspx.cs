using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ifesFood.admin
{
    public partial class FrmProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
            }

        }

        private void AtualizarLvProdutos(List<Produto> produtos)
        {
            var lista = produtos.OrderBy(p => p.Nome);
            lvProdutos.DataSource = lista;
            lvProdutos.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.Nome = txtNome.Value;
            produto.Descricao = txtDescricao.Value;
            produto.Imagem = txtImagem.Value;
            produto.Preco = Convert.ToDecimal(txtPreco.Value);
            produto.DataCadastro = DateTime.Now;

            string mensagem = ProdutoDAO.CadastrarProduto(produto);

            LimparCampos(mensagem);

            

            AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
        }

        private void LimparCampos(string mensagem)
        {
            lblMensagem.InnerText = mensagem;
            txtNome.Value = "";
            txtDescricao.Value = "";
            txtImagem.Value = "";
            txtPreco.Value = "";
            
        }

        protected void lvProdutos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string comando = e.CommandName;

            int id = Convert.ToInt32(e.CommandArgument);

            if (comando == "Deletar")
            {

                //Iremos excluir o produto

                string mensagem = ProdutoDAO.ExcluirProduto(id);
                AtualizarLvProdutos(ProdutoDAO.ListarProdutos());
                lblMensagem.InnerText = mensagem;
            }

        }
    }
}