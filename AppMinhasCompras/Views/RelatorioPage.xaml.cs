using AppMinhasCompras.Helpers;
using AppMinhasCompras.Models;

namespace AppMinhasCompras.Views
{
    public partial class RelatorioPage : ContentPage
    {
        public RelatorioPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CarregarRelatorio();
        }

        private async Task CarregarRelatorio()
        {
            List<Produto> produtos = await App.Db.GetAll();

            // Agrupa os produtos por Categoria e calcula o valor total de cada uma
            var relatorio = produtos
                .GroupBy(p => string.IsNullOrEmpty(p.Categoria) ? "Sem Categoria" : p.Categoria)
                .Select(g => new RelatorioCategoria
                {
                    Categoria = g.Key,
                    TotalGasto = g.Sum(p => p.Total)
                })
                .ToList();

            cv_relatorio.ItemsSource = relatorio;
        }
    }
}