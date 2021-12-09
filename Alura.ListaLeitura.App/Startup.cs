using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            //Usando o roteamento do ASP.NET
            var builder = new RouteBuilder(app);

            builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            //Faz com que só receba id inteiro.
            builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);
            builder.MapRoute("Cadastro/NovoLivro/{Nome}/{autor}", CadastroLogica.NovoLivro);                               
            builder.MapRoute("Cadastro/ExibeFormulario", CadastroLogica.ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);
            var rotas = builder.Build();
            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }


        //Não mais utilizado.
        //------------------------------------------------------------------
        //public Task Roteamento(HttpContext context) //HttpContext obj.Request.Path reponsável pelas rotas.
        //{
        //    var _repo = new LivroRepositorioCSV();
        //    /* Caminhos  >/Livros/ParaLer< >/Livros/Lendo< >/Livros/Lidos< */
        //    var caminhosAtendidos = new Dictionary<string, RequestDelegate>
        //    {
        //        {"/Livros/ParaLer",  LivrosParaLer},
        //        {"/Livros/Lendo",  LivrosLendo},
        //        {"/Livros/Lidos", LivrosLidos}
        //    };

        //    if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //    {
        //        var metodo = caminhosAtendidos[context.Request.Path];
        //        return metodo.Invoke(context);
        //    }

        //    context.Response.StatusCode = 404;
        //    return context.Response.WriteAsync("Caminho Inexistente");
        //}
        //------------------------------------------------------------------
    }
}