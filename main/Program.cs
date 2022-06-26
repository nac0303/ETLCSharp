using System;

using main.DataLoad;

using main.DataSource;

namespace main;

class main{
    public static void Main(string[] args){

       LoadContext lc = new LoadContext();

       SourceContext sc = new SourceContext();


       lc.conn();

       sc.conn();
    }
}