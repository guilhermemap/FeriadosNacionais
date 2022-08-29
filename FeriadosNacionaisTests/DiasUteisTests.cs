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
}