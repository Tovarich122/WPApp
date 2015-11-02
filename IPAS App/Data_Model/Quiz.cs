using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAS_App
{
    class Question
    {
        public String question;
        public int answer_a;
        public int answer_b;
        public int answer_c;
        public int selected = 0;
        public String special;
    }

    class QuestionMarcoNormativo
    {
        public String question;
        public String answer_a;
        public String answer_b;
        public String answer_c;
        public String answer_d;
        public int selected = 0;
        public String special;
        public String correcta;
    }


    class MarcoNormativo
    {
        public QuestionMarcoNormativo[] myQuiz = new QuestionMarcoNormativo[5];
        public int CuentaFinal = 0;

        public int calcularQuiz()
        {
            CuentaFinal = 0;
            foreach(var question in myQuiz) {
                CuentaFinal += question.selected;
            }
            return CuentaFinal;
        }

        public MarcoNormativo()
        {
            myQuiz[0].question = "1. ¿Por cuál de las siguientes razones una mujer puede abortar de forma legal en cualquier estado de la República Mexicana?";
            myQuiz[0].answer_a = "1. Grave daño a la salud de la mujer";
            myQuiz[0].answer_b = "2. Peligro de muerte de la mujer";
            myQuiz[0].answer_c = "3. Violación de la mujer";
            myQuiz[0].answer_d = "4. Malformaciones en el producto";
            myQuiz[0].special = "La violación es la única causal permitida en todos los estados de la República Mexicana. La Ley General de Víctimas establece que todas las mujeres que han sido violadas tienen derecho a abortar si así lo deciden. Se trata de un servicio de emergencia médica obligatoria que no puede condicionarse bajo ninguna circunstancia.";
            myQuiz[0].correcta = "3";

            myQuiz[1].question = "2. ¿En qué estados de la República Mexicana el aborto es legal por razones económicas?";
            myQuiz[1].answer_a = "1. Michoacán y Yucatán";
            myQuiz[1].answer_b = "2. Oaxaca y Veracruz";
            myQuiz[1].answer_c = "3. Veracruz y Distrito Federal";
            myQuiz[1].answer_d = "4. Hidalgo y Estado de México";
            myQuiz[1].special = "En Michoacán y Yucatán el aborto es legal por razones económicas.  Prohibir el aborto a las mujeres que se encuentran en situación de pobreza, agrava su condición de vulnerabilidad y atenta contra sus derechos humanos.";
            myQuiz[1].correcta = "1";

            myQuiz[2].question = "3. ¿En qué estado de la República Mexicana el aborto voluntario es legal, hasta las 12 semanas de embarazo?";
            myQuiz[2].answer_a = "1. Estado de México";
            myQuiz[2].answer_b = "2. Hidalgo";
            myQuiz[2].answer_c = "3. Distrito Federal";
            myQuiz[2].answer_d = "4. Tabasco";
            myQuiz[2].special = "Desde 2007, Interrumpir el embarazo es legal en el Distrito Federal. Año con año miles de mujeres de distintos estados de la República acuden a los servicios públicos de salud para poder ejercer su derecho a decidir, con absoluta seguridad.";
            myQuiz[2].correcta = "3";

            myQuiz[3].question = "4. Si a tu centro de salud llegara una mujer solicitando una ILE por violación tú decidirías…";
            myQuiz[3].answer_a = "1. Investigar primero si es verdad que la mujer fue violada para darle el servicio";
            myQuiz[3].answer_b = "2. Negarte a hacer el aborto y decirle a la mujer que busque otro proveedor";
            myQuiz[3].answer_c = "3. Referirla con un médico privado que conozcas";
            myQuiz[3].answer_d = "4. Darle el servicio si cuentas con las habilidades para hacerlo";
            myQuiz[3].special = "El personal médico puede decidir legalmente proteger la intimidad de su usuaria, aunque encuentre secuelas de aborto inducido. La ley reconoce que ciertos vínculos profesionales, dificultan comunicar la comisión de un delito o revelar la identidad del autor del mismo. Los proveedores de servicios de salud deben a sus usuarias confidencialidad. Por ello,pueden negarse a proporcionar información sobre un aborto presumiblemente provocado por ella.";
            myQuiz[4].correcta = "4";

            myQuiz[4].question = "5. ¿Quiénes pueden negarse a practicar una interrupción legal del embarazo por argumentos morales?";
            myQuiz[4].answer_a = "1. Todo el personal que labora en un servicio de  salud";
            myQuiz[4].answer_b = "2.  La institución de salud";
            myQuiz[4].answer_c = "3. El  personal médico capacitado para realizarlo";
            myQuiz[4].answer_d = "";
            myQuiz[4].special = "Con la objeción de conciencia el único que puede negarse a practicar la interrupción legal del embarazo  es la/el  médico, aunque éste tendría que asegurar el derecho de la mujer a recibir el servicio.  La objeción de conciencia es personal, no institucional, por ello el personal médico tiene la obligación de canalizar a otro proveedor de servicios, siempre y cuando la demora no ponga en riesgo la salud o la vida de la mujer.";
            myQuiz[4].correcta = "3";

        }

    }

    class Quiz
    {
        public Question[] myQuiz = new Question[10];
        public int CuentaFinal = 0;
        public static string Rojo = "Detente. Reflexiona sobre las acciones y respuestas que podrían estigmatizar a las mujeres afectando la calidad de la atención brindada y poniendo en riesgo su salud.";
        public static string Amarillo = "Precaución. Realizas tu trabajo con compromiso, sin embargo hay algunas acciones y respuestas que puedes seguir mejorando para incrementar la calidad de la atención y la salud de las mujeres.";
        public static string Verde = "Adelante. Continúa siendo un prestador de servicios de salud libre de estigma, atendiendo a las mujeres con calidad y protegiendo su salud.";

        public int calcularQuiz()
        {
            CuentaFinal = 0;
            foreach(var question in myQuiz) {
                CuentaFinal += question.selected;
            }
            return CuentaFinal;
        }

        public Quiz()
        {
            myQuiz[0] = new Question();
            myQuiz[0].question = "1. Las mujeres que quieren tener hijos/as son más felices que las que no quieren tenerlos/as.";
            myQuiz[0].answer_a = 3;
            myQuiz[0].answer_b = 2;
            myQuiz[0].answer_c = 1;
            myQuiz[0].special =  "Existe el estereotipo de que las mujeres deben de ser madres, sin embargo elegir no tener hijos es una opción válida y legítima que no impide a las mujeres alcanzar la felicidad. ";

            myQuiz[1] = new Question();
            myQuiz[1].question = "2. Una mujer que decide abortar es irresponsable.";
            myQuiz[1].answer_a = 3;
            myQuiz[1].answer_b = 2;
            myQuiz[1].answer_c = 1;
            myQuiz[1].special = "Una idea frecuente ha sido considerar que las mujeres se embarazan sin planearlo por no haber utilizado anticonceptivos, sin embargo, existen un sinnúmero de razones como la falla del anticonceptivo, haber sido presionadas por la pareja para no usar algún método y por violencia sexual, entre otras. Considerar a las mujeres como irresponsables es una etiqueta ligada a un prejuicio.";
            
            myQuiz[2] = new Question();
            myQuiz[2].question = "3. Una mujer que ha tenido un aborto es un mal ejemplo ya que podría inducir a otras mujeres a tener abortos";
            myQuiz[2].answer_a = 3;
            myQuiz[2].answer_b = 2;
            myQuiz[2].answer_c = 1;
            myQuiz[2].special = "La decisión de abortar no se contagia porque no se trata de una enfermedad, cada mujer tiene la libertad de decidir lo mejor para ella y como sociedad debemos respetar las decisiones que las mujeres toman sobre sus cuerpos y sus vidas";

            myQuiz[3] = new Question();
            myQuiz[3].question = "4. Si tuviera la opción, preferiría no atender a una mujer que ha tenido un aborto.";
            myQuiz[3].answer_a = 3;
            myQuiz[3].answer_b = 2;
            myQuiz[3].answer_c = 1;
            myQuiz[3].special = "A las mujeres que buscan interrumpir un embarazo se les dificulta llegar a los servicios de salud para pedir ayuda porque piensan que las van a tratar mal por la decisión que han tomado, cuando un prestador de servicios de salud deja de atender o referir a un servicio seguro a una mujer en situación de aborto la está discriminando y quitándole el derecho a contar con opciones seguras de atención. " ;

            myQuiz[4] = new Question();
            myQuiz[4].question = "5. Un prestador de servicios de salud que atiende a una mujer que ha tenido un aborto debe avisar  a su pareja (novio o esposo) y/o a sus padres.";
            myQuiz[4].answer_a = 3;
            myQuiz[4].answer_b = 2;
            myQuiz[4].answer_c = 1;
            myQuiz[4].special = "El prestador de servicio de salud debe proteger la confidencialidad de las mujeres para asegurar que puedan tomar decisiones libres e informadas, por lo que no se debe notificar a ninguna persona a menos que la mujer misma lo solicite o pida apoyo para comunicarlo." ;

            myQuiz[5] = new Question();
            myQuiz[5].question = "6. Si una mujer me preguntara sobre opciones frente a un embarazo no planeado, yo le recomendaría que continuara con el embarazo.";
            myQuiz[5].answer_a = 3;
            myQuiz[5].answer_b = 2;
            myQuiz[5].answer_c = 1;
            myQuiz[5].special = "De acuerdo con los lineamientos para la prestación del servicios de Interrupción Legal del Embarazo la información que le demos a las mujeres debe ser objetiva y mostrándoles todas las opciones posibles para tomar una decisión informada.  Si sólo le damos una opción estaremos interfiriendo en su libertad  de elegir." ;

            myQuiz[6] = new Question();
            myQuiz[6].question = "7. Las mujeres que abortan siempre tienen alguna consecuencia negativa en su salud ";
            myQuiz[6].answer_a = 3;
            myQuiz[6].answer_b = 2;
            myQuiz[6].answer_c = 1;
            myQuiz[6].special = "El aborto es uno de los procedimientos médicos de menor riesgo. El riesgo de muerte asociado al parto es aproximadamente 14 veces mayor que con el aborto . La salud mental tampoco se ve afectada por la decisión de abortar como lo muestra la evidencia científica.";

            myQuiz[7] = new Question();
            myQuiz[7].question = "8. Si una mujer me solicitara apoyo para interrumpir su embarazo, yo trataría de ayudarla para que lo hiciera de manera segura.";
            myQuiz[7].answer_a = 1;
            myQuiz[7].answer_b = 2;
            myQuiz[7].answer_c = 3;
            myQuiz[7].special = "Es importante aprovechar la llegada de estas mujeres a los servicios para asegurar que reciban un servicio de calidad  y no ponerlas en riesgo forzándolas a buscar atención con  prestadores de servicios de salud no calificados y además ofrecerles métodos anticonceptivos para prevenir futuros embarazos no planeados." ;

            myQuiz[8] = new Question();
            myQuiz[8].question = "9. Un prestador de servicios de salud debe denunciar a una mujer si sospecha que tuvo un aborto inducido.";
            myQuiz[8].answer_a = 3;
            myQuiz[8].answer_b = 2;
            myQuiz[8].answer_c = 1;
            myQuiz[8].special = "La prestación de servicios de salud se rige por el principio ético de confidencialidad, amparado por el derecho al Secreto Profesional. La denuncia orilla a las mujeres a recurrir a procedimientos inseguros y retrasa su acercamiento a los servicios de urgencias, comprometiendo su salud o su vida y en algunos casos, criminaliza a la mujer y pone en riesgo su recuperación.";

            myQuiz[9] = new Question();
            myQuiz[9].question = "10. Si conociera a un/a colega que realizara abortos, no me gustaría que me relacionaran con él/ella.";
            myQuiz[9].answer_a = 3;
            myQuiz[9].answer_b = 2;
            myQuiz[9].answer_c = 1;
            myQuiz[9].special = "El no querer que nos relacionen con personal que hace abortos refleja una actitud de rechazo y de devaluación hacia los colegas que lo realizan, lo cual minimiza su labor afectando su  salud emocional. Se debe evitar estigmatizar y discriminar a los profesionales de la salud que prestan servicios de aborto, ya que éstos realizan acciones legítimas que protegen la salud y los derechos de las mujeres.";


        }
    }
}
