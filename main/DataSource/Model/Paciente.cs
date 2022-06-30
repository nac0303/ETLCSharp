using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace main.DataSource
{
    public partial class Paciente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public int IdEstado { get; set; }
        public int IdClasseSocial { get; set; }

        public virtual ClasseSocial IdClasseSocialNavigation { get; set; } = null!;
        public virtual Estado IdEstadoNavigation { get; set; } = null!;

        private Paciente() { }

        public static List<Paciente> GetAll()
        {
            var list = new List<Paciente>();
            using (var context = new analytic_dataContext())
            {
                var query = context.Pacientes.Include(e => e.IdEstadoNavigation).Include(c => c.IdClasseSocialNavigation);
                foreach (var q in query)
                {
                    list.Add(new Paciente()
                    {
                        Id = q.Id,
                        Nome = q.Nome,
                        IdEstadoNavigation = q.IdEstadoNavigation,
                        IdClasseSocialNavigation = q.IdClasseSocialNavigation
                    });
                }
            }

            return list;

        }
    }
}
