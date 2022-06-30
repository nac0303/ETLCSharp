using System;

using main.DataLoad;

using main.DataSource;

namespace main;

class main{
    public static void Main(string[] args){

        LoadContext lc = new LoadContext();

        SourceContext sc = new SourceContext();


        using var context = new DataLoad.ets_dadosContext();
        context.Database.EnsureCreated();

        sc.conn();

        lc.conn();
    }
}