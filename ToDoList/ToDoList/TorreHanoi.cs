using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class TorreHanoi
    {
        int Movimientos, discos, posicion, discoTomado;
        bool activo;

        public TorreHanoi() //Constructor 
        {
            Movimientos = 0;
            discoTomado = 0;
            posicion = 5; //Se inicia en 5 para tener una posicion por default
            activo = true;
        }

        public void Hanoi() // Metodo para iniciar el juego
        {
            Console.Write("Ingrese Cantidad de Discos: "); //Pide cantidad de discos
            discos = int.Parse(Console.ReadLine());

            if (discos > 100) //No puede haber mas de 100 discos ya que fue solicitado por el profe, asi que creamos una excepcion
                throw new OverflowException("Sobrepasa la cantidad solicitada por el profe");

            Disco TH = new Disco(discos); //Creamos objeto de la clase Disco
            TH.Torres(); //Llamamos al metodo Torres
            Console.Clear();

            do
            {
                Console.SetCursorPosition(25, 0);
                //La funcion Console.SetCursorPosition nos deja mover un cursor creado teniendo los valores de X y Y ingresandolos entre
                //los parentesis, con esta podemos visualizar en que torre esta el numero que agarramos
                Console.Write("Movimientos: {0}", Movimientos); //Muestra cuantos movimientos llevamos 

                TH.Cursor(posicion, discoTomado); //Llamamos al Metodo Cursor, con el valor inicial de la posicion y el disco tomado
                TH.Imprimir(); //Llamamos al metodo Imprimir para mostrar las torres

                ConsoleKeyInfo Control = Console.ReadKey(true);
                //La funcion de ConsoleKeyInfo nos ayudara a establecer que teclas cumpliran cada funcion

                switch (Control.Key) //Tomando en cuenta la variable Control
                {
                    case ConsoleKey.LeftArrow: //Si presionamos la flecha Izquierda, el cursor va a retroceder a la torre anterior (-15)

                        if (posicion > 5)                       
                            posicion = posicion - 15;  
                        
                        break;

                    case ConsoleKey.RightArrow: //Si presionamos la flecha Derecha, el cursor va a avanzar a la torre siguiente (+15)

                        if (posicion < 30)                        
                            posicion = posicion + 15;    
                        
                        break;

                    case ConsoleKey.Enter: //Si presionamos Enter, se agregara otro movimiento
                        Movimientos++;

                        if (discoTomado == 0) // Si el disco tomado es 0                    
                            discoTomado = TH.Pieza(posicion); //El disco tomado sera igual al Metodo Pieza en dicha posicion
                        
                        else
                        {
                            int numero = discoTomado; //iniciamos nueva variable para llamar al metodo colocar segun la posicion y disco tomado
                            discoTomado = TH.Colocar(posicion, numero);
                        }
                        break;

                    default:
                        Console.WriteLine("ERROR "); //Si no, habra error
                        break;
                }

                activo = TH.Ganado(); //Activo sera igual a lo que el Metodo Ganado regrese, y asi establecer si terminamos

                Console.Clear();

            } while (activo == true); //Si ganamos, se cierra el ciclo      

            Console.WriteLine("\tFelicidades! Cantidad de Movimientos: {0}", Movimientos); //Habremos ganado y nos mostrara cuantos movimientos hicimos

            //LOGICA DEL PROBLEMA BASADO EN:
            //https://www.youtube.com/watch?v=hxSzJCnJ4z4&fbclid=IwAR2gBNI1i93lAs_zDREI5sv1AmOAbhGJTnlXvXtSsSVsuSkM9u3aeUH9EZo
        }
    }
}
