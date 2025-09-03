using System;
using System.Collections.Generic;
using System.Linq;

namespace ifesFood.admin
{
    public class CarouselDAO
    {
        public static string CadastrarCarousel(Carousel carousel)
        {
            string mensagem = "";

            try
            {
                ifesFoodDBEntities ctx = new ifesFoodDBEntities();
                ctx.Carousels.Add(carousel);
                ctx.SaveChanges();

                mensagem = "Carousel cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        internal static List<Carousel> ListarCarousel()
        {
            ifesFoodDBEntities ctx = new ifesFoodDBEntities();
            var lista = ctx.Carousels.ToList();

            return lista;
        }
    }
}