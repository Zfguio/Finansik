namespace Finansik.Components;

using Finansik.Components.Pages;
using Finansik.Service;

public partial class NavBar : ContentView
{
  // TransatcionService ts = new TransatcionService();
	public NavBar()
	{
		InitializeComponent();
	}

    private void BtnHistory_Clicked(object sender, EventArgs e)
    {
        var historyView = new HistoryPage();
        Navigation.PushAsync(historyView);
    }

    private void BtnSummary_Clicked(object sender, EventArgs e)
    {
        var summaryView = new SummaryPage();    
        Navigation.PushAsync(summaryView);
    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
        var addView = new AddPage();    
        Navigation.PushAsync(addView);
    }
}