using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace main.DataSource
{
    public partial class Diagnostico
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoenca { get; set; }
        public DateTime DataDiagnostico { get; set; }

        public virtual Doenca IdDoencaNavigation { get; set; } = null!;
        public virtual Paciente IdPacienteNavigation { get; set; } = null!;

        private Diagnostico() { }
        public Diagnostico(int id, Paciente paciente, Doenca doenca, DateTime data)
        {
            Id = id;
            IdPacienteNavigation = paciente;
            IdDoencaNavigation = doenca;
            DataDiagnostico = data;
        }

        public static List<Diagnostico> GetAll()
        {
            var list = new List<Diagnostico>();
            using (var context = new analytic_dataContext())
            {
                var query = context.Diagnosticos.Include(d => d.IdDoencaNavigation).Include(p => p.IdPacienteNavigation);
                foreach (var q in query)
                {
                    list.Add(new Diagnostico()
                    {
                        Id = q.Id,
                        IdPacienteNavigation = q.IdPacienteNavigation,
                        IdDoencaNavigation = q.IdDoencaNavigation,
                        DataDiagnostico = q.DataDiagnostico
                    });
                }
            }

            return list;

        }
    }
}
