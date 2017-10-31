using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoInicial.Models
{

    public enum Genero { Homem, Mulher}
    public class Modelos
    {
        public int ModelosID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public  Genero genero  { get; set; }
        public int  Peso { get; set; }
        public int Altura { get; set; }
        
    }
}