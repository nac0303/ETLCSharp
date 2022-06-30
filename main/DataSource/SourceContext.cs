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
}