using System;
using System.Globalization;
using System.Windows.Data;
using GeometryFigureLib;

namespace GeometryFigureUi.ViewModel;

public class FigureNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is GeometricFigure figure)
        {
            return figure.GetName();
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}