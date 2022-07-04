using System;
using System.Collections.Generic;

namespace main.DataLoad
{
    public partial class DiagnosticosPorClasse
    {
        public int Id { get; set; }
        public int QuantidadeDiagnosticos { get; set; }
        public int ClasseSocial { get; set; }

        public DiagnosticosPorClasse(int qtd, int classe) { QuantidadeDiagnosticos = qtd; ClasseSocial = classe; }
        private DiagnosticosPorClasse() { }


        public void Save()
        {
            using (var context = new ets_dadosContext())
            {
                context.DiagnosticosPorClasses.Add(this);
                context.SaveChanges();
            }
        }
    }
}
