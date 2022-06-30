using System;
using main.DataSource;
using Microsoft.EntityFrameworkCore;

namespace main.DataLoad;

class LoadContext {

    public void conn(){
        Console.WriteLine("implemente o load context e seus metodos de cargas");
        DiagClassAdd();
    }

    public void DiagClassAdd()
    {
        foreach(var item in DataSource.SourceContext.DiagnosticosClasse())
        {
            item.Save();
        }
    }

}