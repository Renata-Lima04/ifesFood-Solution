using System;

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
    }
}