using CommunityToolkit.Mvvm.ComponentModel;

namespace CarWorkshopApp.ViewModels;

public partial class InvoiceViewModel : ObservableObject
{
    [ObservableProperty]
    private string mechanicName;

    [ObservableProperty]
    private string materialsUsed;

    [ObservableProperty]
    private double materialCost;

    [ObservableProperty]
    private double hoursWorked;

    [ObservableProperty]
    private double hourlyRate;

    public string TotalCost => $"{MaterialCost + (HoursWorked * HourlyRate):C} DKK";

    partial void OnMaterialCostChanged(double value) => OnPropertyChanged(nameof(TotalCost));
    partial void OnHoursWorkedChanged(double value) => OnPropertyChanged(nameof(TotalCost));
    partial void OnHourlyRateChanged(double value) => OnPropertyChanged(nameof(TotalCost));
}
