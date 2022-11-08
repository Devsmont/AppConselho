using System;
using System.Collections.Generic;
using System.Text;

namespace AppConselho.Model
{
    public class Conselhos
    {
        
        public string Slip_Id { get; set; }
        public string Conselho { get; set; }

        public Conselhos()
        {
           
            this.Slip_Id = " ";
            this.Conselho = " ";
        }
    }
}
