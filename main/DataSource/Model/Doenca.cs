using System;
using System.Collections.Generic;

namespace main.DataSource
{
    public partial class Doenca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;


        public static List<object> GetAll()
        {
            var list = new List<object>();
            using (var context = new analytic_dataContext())
            {
                var query = context.Doencas;
                foreach (var q in query)
                {
                    list.Add(new
                    {
                        Id = q.Id,
                        Nome = q.Nome
                    });

                }

            }

            return list;

        }
    }
}
