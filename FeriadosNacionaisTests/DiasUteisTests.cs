using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeriadosNacionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriadosNacionais.Tests;

[TestClass()]
public class DiasUteisTests
{
    [TestMethod()]
    public void IsFeriadoTest()
    {
        var date = DateTime.Parse("2022/08/28");
        Assert.IsTrue(DiasUteis.IsDiaUtil(date));
        var date2 = DateTime.Parse("2022/09/07");
        Assert.IsFalse(DiasUteis.IsDiaUtil(date2));
    }

    [TestMethod()]
    public void IsDiaUtilTest()
    {
        var date = DateTime.Parse("2023/01/01");
        Assert.IsFalse(DiasUteis.IsDiaUtil(date));
        var date2 = DateTime.Parse("2022/02/02");
        Assert.IsTrue(DiasUteis.IsDiaUtil(date2));
    }

    [TestMethod()]
    public void SomarDiasUteisTest()
    {
        DateTime inicial = DateTime.Parse("2022/08/29");
        Console.WriteLine($"{inicial.Date} + 4 dias úteis: {DiasUteis.SomarDiasUteis(inicial, 4).Value.Date} (esperado 2/9/22)");
        Console.WriteLine($"{inicial.Date} + 6 dias úteis: {DiasUteis.SomarDiasUteis(inicial, 6).Value.Date} (esperando 6/9/22");
        Console.WriteLine($"{inicial.Date} + 8 dias úteis: {DiasUteis.SomarDiasUteis(inicial, 8).Value.Date} (esperando 9/9/22");
    }
}