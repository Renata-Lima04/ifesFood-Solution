﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Services.Description;

namespace ifesFood
{
    public class ProdutoDAO
    {
        public static string CadastrarProduto(Produto produto)
        {
            string mensagem = "";

            try
            {
                var ctx = new ifesFoodDBEntities();
                ctx.Produtos.Add(produto); 
                ctx.SaveChanges();

                mensagem = "O produto " + produto.Nome +
                    " foi cadastrado com sucesso!";

            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }


            return mensagem;
        }

        public static List<Produto> ListarProdutos()
        {
            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            var lista = ctx.Produtos.ToList();

            return lista;
        }

         internal static Produto VisualizarProduto(int id)
        {
            Produto produto = null;

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex) {
                string mensagem = "";
                mensagem = ex.Message;
            }

            return produto;
        }

        public static string ExcluirProduto(int id)
        {
            string mensagem = "";

            try
            {
                using (var ctx = new ifesFoodDBEntities())
                {
                    Produto produto = ctx.Produtos.FirstOrDefault(p => p.Id == id);
                    ctx.Produtos.Remove(produto); 
                    ctx.SaveChanges();
                    mensagem = "Produto excluído com sucesso!";

                }
            }   
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }   

            return mensagem;
        }
    }
}
