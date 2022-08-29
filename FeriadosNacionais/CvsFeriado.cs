using CsvHelper.Configuration.Attributes;

namespace FeriadosNacionais;
#pragma warning disable
/* classe gerada automaticamente por 
 * https://toolslick.com/generation/code/class-from-csv
 * (atributo Name adicionados depois pra usar com CsvHelper
 */
public class Model
{
    [Name("Data")]
    public DateTime Data { get; set; }
    [Name("Dia da Semana")]
    public string DiadaSemana { get; set; }
    [Name("Feriado")]
    public string Feriado { get; set; }
}
/*
public class ModelClassMap : ClassMap<Model>
{
    public ModelClassMap()
    {
        Map(m => m.Data).Name("Data");
        Map(m => m.DiadaSemana).Name("Dia da Semana");
        Map(m => m.Feriado).Name("Feriado");
    }
}
*/