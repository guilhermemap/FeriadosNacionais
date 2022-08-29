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
    public static bool IsFeriado(DateTime date)
    {
        return Feriados.Find(x => x.Data.Date == date.Date) != null;
    }
    public static bool IsDiaUtil(DateTime date)
    {
        return Feriados.Find(x => x.Data.Date == date.Date) == null;
    }
}
