using Finansik.Classes;
using Finansik.Service;
using Finansik.Service.DTO;

namespace Finansik.Components.Pages;

public partial class SummaryPage : ContentPage
{
    List<Finanse> finanses = new List<Finanse>();
    float total = 0, minus, add;
    Finances _finanses = new Finances();
    public SummaryPage()
    {
        InitializeComponent();
        getFinanse();
    }

    void updateLabels()
    {
        lbPrzychody.Text = $"{_finanses.income} z³";
        lbWydatki.Text = $"{_finanses.outgo} z³";
        lbSuma.Text = $"{_finanses.income - _finanses.outgo} z³";
    }
    void getValues() 
    {
        foreach (Finanse f in finanses)
        {
            if (f.Type == "Przychód")
                _finanses.income += f.Price;
            else
                _finanses.outgo += f.Price;
        }
        updateLabels();
    }
    async void getFinanse()
    {
        finanses = await TransatcionService.GetListAsync();
        getValues();
    }
}