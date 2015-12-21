using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAS_App.Model
{
    public class Pregunta
    {
        public int id { get; set; }
        public string text { get; set; }
        public string res1 { get; set; }
        public string res2 { get; set; }
        public string res3 { get; set; }
        public string res4 { get; set; } //Para marco normativo es opcion, para estigma es el texto a mostrar en el intermedio.
        public string correcta { get; set; }
        public string before_next { get; set; }
        public int rad_checked {get; set;}
        public bool its_correct { get; set; }

        public Pregunta()
        { id = 0; text = res1 = res2 = res3 = res4 = before_next = ""; correcta = ""; rad_checked = 0; its_correct = false; }
        public Pregunta(int id, string text, string res1, string res2, string res3, string res4, string before_next)
        {
            this.id = id; this.text = text; this.res1 = res1; this.res2 = res2; this.res3 = res3; this.res4 = res4;this.before_next = before_next; this.rad_checked = 0;
        }
        public Pregunta(int a,int id,string text) // Para estigma a = 1
        {
            if(a == 1)
            {
                this.id = id;
                this.text = text;
                res1 = "De acuerdo";
                res2 = "Ni de acuerdo, ni en desacuerdo";
                res3 = "En desacuerdo";
                res4 = "";
                this.rad_checked = 1;
            }

        }

    }

}
