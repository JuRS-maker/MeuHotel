using MeuHotel.Models;

namespace MeuHotel.Wiews;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

		dtpck_checkin.MinimumDate = DateTime.Now;
		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Hospedagem h = new Hospedagem
			{
				QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
				QtdeAdultos = Convert.ToInt32(stp_adultos.Value),
				QtdeCriancas = Convert.ToInt32(stp_criancas.Value),
				DataCheckIn = dtpck_checkin.Date.Value,
				DataCheckOut = dtpck_checkout.Date.Value,
			};
			
			
			await Navigation.PushAsync(new HospedagemContratada()
			{
                BindingContext = h
			});

		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
    }

	private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
	{
		DatePicker elementos = sender as DatePicker;

		DateTime data_selecionada_checkin = elementos.Date.Value;

		dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
		dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
	}
}

