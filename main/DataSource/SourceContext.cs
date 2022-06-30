using System;

using Microsoft.EntityFrameworkCore;

namespace main.DataSource;

class SourceContext{

    public void conn(){
        Console.WriteLine("Implemente a Source context e seus metodos de busca");
    }

    // NewTable
    public static List<DataLoad.NewTable> SalarioDoencaIdade()
    {
        using var context = new analytic_dataContext();

        var dados = context.Diagnosticos
        .Join(context.Doencas, di => di.IdDoenca, d => d.Id, (di, d) => new
        {
            IdPaciente = di.IdPaciente,
            Doenca = d.Nome
        })
        .Join(context.Pacientes, di => di.IdPaciente, p => p.Id, (di, p) => new
        {
            Idade = p.Idade,
            IdClasseSocial = p.IdClasseSocial,
            Doenca = di.Doenca
        })
        .Join(context.ClasseSocials, di => di.IdClasseSocial, c => c.Id, (di, c) => new DataLoad.NewTable
        {
            MediaIdade = di.Idade,
            MediaSalarial = (int)(c.SalarioPiso + c.SalarioTeto) / 2,
            Doenca = di.Doenca
        }).ToList();

        return dados;
    }

    public static List<DataLoad.OcorrenciasClasseSocialRegiao> QtdCasosClasseSocialRegiao()
    {
        using var context = new analytic_dataContext();

        var dados = context.Diagnosticos
        .Join(context.Doencas, di => di.IdDoenca, d => d.Id, (di, d) => new
        {
            IdPaciente = di.IdPaciente,
            Doenca = d.Nome
        })
        .Join(context.Pacientes, di => di.IdPaciente, p => p.Id, (di, p) => new
        {
            IdEstado = p.IdEstado,
            IdClasseSocial = p.IdClasseSocial,
            Doenca = di.Doenca
        })
        .Join(context.ClasseSocials, di => di.IdClasseSocial, c => c.Id, (di, c) => new DataLoad.NewTable
        {
            MediaIdade = di.Idade,
            MediaSalarial = (int)(c.SalarioPiso + c.SalarioTeto) / 2,
            Doenca = di.Doenca
        }).ToList();

        return dados;
    }
}