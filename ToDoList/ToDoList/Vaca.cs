using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Vaca
    {
        //Problema
        //Supongamos que Bob tiene cuatro vacas que quiere cruzar por un puente, pero solo un yugo, que puede sostener hasta dos vacas, 
        //lado a lado, atadas al yugo. El yugo es demasiado pesado para que lo lleve a través del puente, pero puede atar (y desatar) 
        //vacas a él en muy poco tiempo. De sus cuatro vacas, Mazie puede cruzar el puente en 2 minutos, Daisy puede cruzarlo en 4 minutos, 
        //Crazy puede cruzarlo en 10 minutos y Lazy puede cruzar en 20 minutos. Por supuesto, cuando dos vacas están atadas al yugo, 
        //deben ir a la velocidad de la vaca más lenta. 
        // Describe cómo Bob puede conseguir que todas sus vacas crucen el puente en 34 minutos

        Queue Nombre = new Queue();
        Queue Tiempo = new Queue(); //Se crean colas para cada vaca y su tiempo de recorrido

        int time = 0;
        int recorrido = 0;

        public void Mostrar() //Mostramos al usuario las vacas y su tiempo de recorrido
        {
            Console.WriteLine("Mazie cruza en 2 minutos \nDaisy cruza en 4 minutos \nCrazy cruza en 10 minutos \nLazy cruza en 20 \n");
        }

        public Vaca() //Ingresamos automaticamente el nombre y tiempo de recorrido de cada vaca
        {
            Nombre.Enqueue("Mazie");
            Nombre.Enqueue("Daisy");
            Nombre.Enqueue("Crazy");
            Nombre.Enqueue("Lazy"); 
            Tiempo.Enqueue(2);
            Tiempo.Enqueue(4);
            Tiempo.Enqueue(10);
            Tiempo.Enqueue(20);
        }

        public void Cruzar() //Iniciamos el Metodo para Avanzar
        {
            Console.WriteLine("Bob cruza con las vacas {0} y {1}", Nombre.ToArray().ElementAt(0), Nombre.ToArray().ElementAt(1)); 
            //Cruzamos a las primeras dos vacas
            time = time + Convert.ToInt32(Tiempo.ToArray().ElementAt(1));
            //Suma el tiempo de la vaca mas lenta entre esas dos

            Console.WriteLine("Tiempo de recorrido: {0}\n", time); //Muestra el tiempo recorrido hasta ahora
            recorrido = recorrido + 1; //Cuenta cuantas veces se ha recorrido el puente

            if (time < 34) //Un if para no pasarse de los 34 minutos
            {
                Regresar(); //Mandamos a llamar al Metodo regresar siempre y cuando aun no se hayan pasado de los 34 minutos

                if (recorrido == 2)
                {
                    Tiempo.Dequeue(); //Eliminamos a Mazie y Daisy ya que ya cruzaron
                    Nombre.Dequeue(); 
                    Nombre.Enqueue("Mazie"); //Se vuelven a agregar para cambiar el orden 
                    Tiempo.Enqueue(2); 
                    Nombre.Enqueue("Daisy");
                    Tiempo.Enqueue(4);
                }

                Cruzar(); //Se vuelve a llamar al Metodo
            }
        }

        public void Regresar() //Iniciamos el Metodo para Regresar, ya que es necesario que una vaca regrese
        {
            Console.WriteLine("Bob regresa con la vaca: {0}", Nombre.ToArray().ElementAt(Tiempo.ToArray().ToList().IndexOf(Tiempo.ToArray().Min()))); 
            //Se toma a la vaca mas lenta de las que ya cruzaron
            time = time + Convert.ToInt32(Tiempo.ToArray().Min()); 
            //Se le suma el tiempo total de dicha vaca

            Console.WriteLine("Tiempo de recorrido: {0}\n", time); //Mostramos el tiempo total

            if (recorrido == 1)
            {
                Nombre.Enqueue("Daisy"); //Si es el primer recorrido, se agrega Daisy
                Tiempo.Enqueue(4);
            }

            Nombre.Dequeue(); //Eliminamos a las vacas que ya cruzaron
            Tiempo.Dequeue();          
            Nombre.Dequeue();
            Tiempo.Dequeue();
        }

        //CODIGO BASADO EN LA SOLUCION DE: 
        //https://in.answers.yahoo.com/question/index?qid=20100207084816AAW8u2U&fbclid=IwAR1V4XZ2QRph1wFnYHNPudM_KmlRhtw7IVhEFlw-pHiUbR9Xr3snGPJg7Mo
    }
}
