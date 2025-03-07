using Microsoft.Maui.Controls;
using CarWorkshopApp.ViewModels;

namespace CarWorkshopApp.Views;

public partial class InvoicePage : ContentPage
{
    public InvoicePage()
    {
        InitializeComponent();
        BindingContext = new InvoiceViewModel(); // Sikrer korrekt binding
    }
}
