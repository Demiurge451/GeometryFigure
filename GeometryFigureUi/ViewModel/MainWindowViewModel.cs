using System.Collections.ObjectModel;
using System.ComponentModel;
using GeometryFigureLib;

namespace GeometryFigureUi.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private GeometricFigure _selectedFigure;
    public ObservableCollection<GeometricFigure> Figures { get; set; }

    public GeometricFigure SelectedFigure
    {
        get => _selectedFigure;
        set
        {
            if (_selectedFigure != value)
            {
                _selectedFigure = value;
                OnPropertyChanged(nameof(SelectedFigure));
                OnPropertyChanged(nameof(FigureInfo));
                OnPropertyChanged(nameof(Center));
                OnPropertyChanged(nameof(Area));
            }
        }
    }

    public string FigureInfo => _selectedFigure?.ToString();

    public string Center => _selectedFigure != null ? $"({_selectedFigure.X}, {_selectedFigure.Y})" : "(0.0, 0.0)";

    public string Area => _selectedFigure != null ? _selectedFigure.GetArea().ToString() : "0.0";

    public MainWindowViewModel()
    {
        Figures = new ObservableCollection<GeometricFigure>();
        
        Figures.Add(new Point(2.0, 2.0));
        Figures.Add(new Line(4.0, 4.0, 10.0, 10.0));
        Figures.Add(new Line(-2.0, -2.0, 10.0, 15.0));
        Figures.Add(new Ellipse(-1.0, 2.0, 7.0, 4.0));
        Figures.Add(new Polygon(
            new []
            {
                (0.0, 0.0),
                (0.0, 7.0),
                (7.0, 7.0),
                (7.0, 0.0)
            }));
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}