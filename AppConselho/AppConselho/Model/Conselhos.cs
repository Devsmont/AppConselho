using System;
using System.Collections.Generic;
using System.Text;

namespace AppConselho.Model
{
    class Conselhos
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Conselho { get; set; }

        public Conselhos()
        {
            this.Title = " ";
            this.Id = " ";
            this.Conselho = " ";
        }
    }
}
