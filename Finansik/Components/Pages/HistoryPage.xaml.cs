using Finansik.Classes;
using Finansik.Service;
using Finansik.Service.DTO;
using System.Collections.ObjectModel;
using Finansik.Service.DTO;
namespace Finansik.Components.Pages;
 
public partial class HistoryPage : ContentPage
{
    public class Fruit
    {
        public string FruitName { get; set; }
    }
    List<Finanse> finanses = new List<Finanse>();
    ObservableCollection<Finanse> fruits = new ObservableCollection<Finanse>();
    public ObservableCollection<Finanse> Fruits { get { return fruits; } }

    public HistoryPage()
	{
		InitializeComponent();
        loadTable();
    }

    void getValues() 
    {
        foreach (Finanse f in finanses)
        {
            fruits.Add(AddFinanse(f.Title, f.Price));
        }
        FruitListView.ItemsSource = fruits;
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