using System;

using Microsoft.EntityFrameworkCore;

namespace main.DataLoad;

class LoadContext {

    public void conn(){
        SalarioDoencaIdade();
        Console.WriteLine("implemente o load context e seus metodos de cargas");
    }

    public void SalarioDoencaIdade()
    {
        using var context = new ets_dadosContext();

        var source = DataSource.SourceContext.SalarioDoencaIdade();

        var table = new List<NewTable>();

        var group = source.GroupBy(di => di.Doenca);

        foreach (var row in group)
        {
            table.Add(new NewTable
            {
                MediaSalarial = (int)row.Average(r => r.MediaSalarial),
                Doenca = row.Key,
                MediaIdade = (int)row.Average(r => r.MediaIdade)
            });
        }

        foreach (var r in table)
            Console.WriteLine($"{r.Doenca}, {r.MediaIdade}, {r.MediaSalarial}");

        Console.WriteLine("\n\n");
    }
}