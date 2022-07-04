using System;
using System.Collections.Generic;

namespace main.DataSource
{
    public partial class ClasseSocial
    {
        public ClasseSocial()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public decimal SalarioPiso { get; set; }
        public decimal SalarioTeto { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }

        public static List<object> GetAll()
        {
            var list = new List<object>();
            using (var context = new analytic_dataContext())
            {
                var query = context.ClasseSocials;
                foreach (var q in query)
                {
                    list.Add(new
                    {
                        Id = q.Id,
                        SalarioPiso = q.SalarioPiso,
                        SalarioTeto = q.SalarioTeto
                    });
                }
            }

            return list;

        }
    }
}
