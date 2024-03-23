using Finansik.Service;
using Finansik.Service.DTO;

namespace Finansik.Components.Pages;

public partial class SummaryPage : ContentPage
{
    List<Finanse> finanses = new List<Finanse>();
    float total = 0, minus ,add;
    public SummaryPage()
    {
        InitializeComponent();
        getFinanse();
        getValues();
    }

    void getValues() 
    {
        foreach (Finanse f in finanses)
        {
            if (f.Type == "Przychód")
                add += f.Price;
            else
                minus += f.Price;
        }
    }
    async void getFinanse()
    {
        finanses = await TransatcionService.GetListAsync();
    }
}