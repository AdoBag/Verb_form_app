using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetaisyklingiVeiksmaz
{
    class Zodis
    {
        int pasikeitimai;
        string lietuviskai, forma1, forma2, forma3;

        public Zodis(int pasikeitimai, string lietuviskai, string forma1, string forma2, string forma3)
        {
            this.pasikeitimai = pasikeitimai;
            this.lietuviskai = lietuviskai;
            this.forma1 = forma1;
            this.forma2 = forma2;
            this.forma3 = forma3;
        }

        public int Pasikeitimai() => pasikeitimai;

        public string Lietuviskas() => lietuviskai;

        public string Forma1() => forma1;

        public string Forma2() => forma2;

        public string Forma3() => forma3;
    }
}
