using System;
using main.DataLoad;
using Microsoft.EntityFrameworkCore;

namespace main.DataSource;

class SourceContext{

    public void conn(){
        Console.WriteLine("Implemente a Source context e seus metodos de busca");

        foreach(var r in DiagnosticosClasse())
        {
            Console.WriteLine($"{r.ClasseSocial} | {r.QuantidadeDiagnosticos}");
        }
    }

    public static List<DiagnosticosPorClasse> DiagnosticosClasse()
    {
        List<Diagnostico> diagnosticos = Diagnostico.GetAll();
        List<DiagnosticosPorClasse> result = new List<DiagnosticosPorClasse>();

        var classes = Paciente.GetAll().Select(x => new
        {
            classe = x.IdClasseSocialNavigation.Id
        }).Distinct().OrderBy(x => x.classe);

        foreach ( var c in classes)
        {
            result.Add(new DiagnosticosPorClasse(diagnosticos.Where(d => d.IdPacienteNavigation.IdClasseSocial == c.classe).Count(), c.classe));
        }

        return result;

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

    //public static List<DataLoad.OcorrenciasClasseSocialRegiao> QtdCasosClasseSocialRegiao()
    //{
    //    using var context = new analytic_dataContext();

    //    var dados = context.Diagnosticos
    //    .Join(context.Doencas, di => di.IdDoenca, d => d.Id, (di, d) => new
    //    {
    //        IdPaciente = di.IdPaciente,
    //        Doenca = d.Nome
    //    })
    //    .Join(context.Pacientes, di => di.IdPaciente, p => p.Id, (di, p) => new
    //    {
    //        IdEstado = p.IdEstado,
    //        IdClasseSocial = p.IdClasseSocial,
    //        Doenca = di.Doenca
    //    })
    //    .Join(context.ClasseSocials, di => di.IdClasseSocial, c => c.Id, (di, c) => new DataLoad.NewTable
    //    {
    //        MediaIdade = di.Idade,
    //        MediaSalarial = (int)(c.SalarioPiso + c.SalarioTeto) / 2,
    //        Doenca = di.Doenca
    //    }).ToList();

    //    return dados;
    //}
}