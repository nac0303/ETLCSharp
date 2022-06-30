using System;
using System.Collections.Generic;

namespace main.DataSource
{
    public partial class Estado
    {
        public Estado()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? IdRegiao { get; set; }

        public virtual Regio? IdRegiaoNavigation { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }


        public void SetFromDB(int id)
        {
            using (var context = new analytic_dataContext())
            {
                var query = context.Estados.Where(e => e.Id == id).Single();

                this.Id = query.Id;
                this.Nome = query.Nome;
                this.IdRegiao = query.IdRegiao;
            }
        }

        public static List<object> GetAll()
        {
            var list = new List<object>();
            using (var context = new analytic_dataContext())
            {
                var query = context.Estados;
                foreach (var q in query)
                {
                    list.Add(new
                    {
                        Id = q.Id,
                        Nome = q.Nome,
                        IdRegiao = q.IdRegiao,
                    });

                }

            }

            return list;

        }
    }
}
