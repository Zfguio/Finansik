using Finansik.Service;
using Finansik.Service.DTO;
using System.Collections.ObjectModel;
namespace Finansik.Components.Pages;
 
public partial class HistoryPage : ContentPage
{
    List<Finanse> finanses = new List<Finanse>();
    ObservableCollection<Finanse> _finanses = new ObservableCollection<Finanse>();
    public ObservableCollection<Finanse> Finanses { get { return _finanses; } }

    public HistoryPage()
	{
		InitializeComponent();
        loadTable();
    }

    void getValues() 
    {
        foreach (Finanse f in finanses)
        {
            _finanses.Add(AddFinanse(f.Title, f.Price));
        }
        FruitListView.ItemsSource = _finanses;
    }
    async void  loadTable() 
    {
        finanses = await TransatcionService.GetListAsync();
        getValues();
    }
    Finanse AddFinanse(string title, float price) 
    {
        Finanse yep = new Finanse();
        yep.Title=title;
        yep.Price=price;
        return yep;
    }
}