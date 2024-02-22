namespace Finansik.Components;

using Finansik.Components.Pages;

public partial class NavBar : ContentView
{
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

    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {

    }
}