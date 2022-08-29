using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace FeriadosNacionais;
public static class DiasUteis
{
    static readonly List<CsvFeriado> Feriados = LerCsv();
    static List<CsvFeriado> LerCsv(string csv_path = "feriados_nacionais.csv")
    {
        var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("en-US"))
        {
            HasHeaderRecord = true,
            Delimiter = ",",
            Encoding = System.Text.Encoding.UTF8,
            BadDataFound = null,
            AllowComments = true,
            Comment = '#',
        };
        using var streamReader = new StreamReader(csv_path);
        using var csvReader = new CsvReader(streamReader, csvConfig);
        var csv_orders = csvReader.GetRecords<CsvFeriado>();
        return csv_orders.ToList();
    }
    static bool DataNaLista(DateTime data)
    {
        return Feriados.Find(x => x.Data.Date == data.Date) != null;
    }
    static bool IsFDS(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday ||
            date.DayOfWeek == DayOfWeek.Sunday)
        {
            return true;
        }
        return false;
    }
    public static bool IsFeriado(DateTime date)
    {
        if (IsFDS(date))
        {
            return true;
        }
        return DataNaLista(date);
    }
    public static bool IsDiaUtil(DateTime date)
    {
        if (IsFDS(date))
        {
            return false;
        }
        return !DataNaLista(date);
    }
    public static DateTime? SomarDiasUteis(DateTime start, int count)
    {
        if (count <= 0)
        {
            return null;
        }
        int somados = 0;
        while (somados < count)
        {
            start = start.AddDays(1);
            if (IsDiaUtil(start))
            {
                somados++;
            }
        }
        return start;
    }
}
