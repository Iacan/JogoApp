using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace JogoApp.Util
{
    /// <summary>
    /// Conversor para ser usado em campos Entry com máscara para moeda
    /// <para>A propriedade vinculada deve ser to tipodecimal, e tem que invocar a
    /// o evento PropertyChangedEventArgs sempre que seu valor for alterado
    /// de forma que o comportamento da mascara seja mantido.</para>
    /// </summary>
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //implementação para notação 000.00
            //return Decimal.Parse(value.ToString()).ToString("C");
            //implementação local pt-br 000,00
            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;
            return Decimal.Parse(value.ToString()).ToString("C", nfi);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0m;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0m;

            if (valueLong <= 0)
                return 0m;

            return valueLong / 100m;
        }
    }
}
