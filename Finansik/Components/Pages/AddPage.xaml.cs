using Finansik.Service;

namespace Finansik.Components.Pages;
public partial class AddPage : ContentPage
{
    string? price, title, descreption, type;
    public AddPage()
    {
        InitializeComponent();
        picker.SelectedIndex = 0;
    }

    private void TbTytul_TextChanged(object sender, TextChangedEventArgs e) => title = TbTytul.Text;


    private void TbCena_TextChanged(object sender, TextChangedEventArgs e) => price = TbCena.Text;


    private void tbOpis_TextChanged(object sender, TextChangedEventArgs e) => descreption = tbOpis.Text;

    bool checkIfPriceValid() => float.TryParse(price, out float i);
    bool checkIfTextInputNotNull()
    {
        if (title != null && type != null)
            return true;
        return false;
    }
    async void clearDataInputs()
    {
        await DisplayAlert("Sukces", "Dane zosta³y zapisane", "OK");
        TbTytul.Text = string.Empty;
        tbOpis.Text = string.Empty;
        TbCena.Text = string.Empty;
        picker.SelectedIndex = 0;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        type = picker.SelectedItem as string;
        if (!checkIfPriceValid() || !checkIfTextInputNotNull())
        {
            await DisplayAlert("Z³a dane", "Zly format danych", "OK");
            return;
        }

        float priceF = Convert.ToSingle(price);
        if (priceF < 0f)
        {
            await DisplayAlert("Z³a dane", "Zly format danych", "OK");
            return;
        }
        await TransatcionService.addTransatcion(title!, priceF, type!, descreption!);
        clearDataInputs();
    }
}