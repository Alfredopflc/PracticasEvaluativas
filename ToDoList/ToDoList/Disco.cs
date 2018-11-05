using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Disco
    {
        int TotalDiscos; //Iniciamos una pila para cada torre
        Stack<int> torre1;
        Stack<int> torre2;
        Stack<int> torre3;

        public Disco(int discos) //Constructor 
        {
            TotalDiscos = discos;
            torre1 = new Stack<int>();
            torre2 = new Stack<int>();
            torre3 = new Stack<int>();
        }

        public void Torres() //Metodo para agregar valores a las torres
        {
            torre1.Push(100); //Agregamos a las listas el valor de 100
            torre2.Push(100);
            torre3.Push(100);

            for (int i = TotalDiscos; i > 0; i--) //Agrega los datos del mayor al menor dependiendo de cuantos Discos solicito    
                torre1.Push(i);
            
        }

        public int Pieza(int posicion) //Metodo para quitar la pieza seleccionada
        {
            switch (posicion) //Dependiendo de la posicion 
            {
                case 5: //Quitamos el ultimo elemento de la torre 1
                    if (torre1.Peek() > 0 && torre1.Peek() != 100)                    
                        return torre1.Pop();
                    
                    else                   
                        return 0;
                    
                case 20: //Quitamos el ultimo elemento de la torre 2
                    if (torre2.Peek() > 0 && torre2.Peek() != 100)                   
                        return torre2.Pop();
                    
                    else                   
                        return 0;
                    
                case 35: //Quitamos el ultimo elemento de la torre 3
                    if (torre3.Peek() > 0 && torre3.Peek() != 100)                  
                        return torre3.Pop();
                    
                    else                    
                        return 0;
                    
                default: //Si no, regresa 0 
                    return 0;
            }
        }

        public int Colocar(int posicion, int num) //Metodo para agregar elemento a otra pila (torre)
        {
            if (num == 0) //Si es 0, regresara 0       
                return 0;
            
            else
            {
                switch (posicion) 
                {
                    case 5: //Si esta en la posicion 5, agregamos dicho elemento a la torre 1 (debe ser menor al ultimo elemento de la torre 1)
                        if (torre1.Peek() > num)
                        {
                            torre1.Push(num);
                            return 0;
                        }

                        else                        
                            return num;
                        
                    case 20: //Si esta en la posicion 20, agregamos dicho elemento a la torre 2 (debe ser menor)
                        if (torre2.Peek() > num)
                        {
                            torre2.Push(num);
                            return 0;
                        }

                        else                       
                            return num;
                        
                    case 35: //Si esta en la posicion 35, agregamos dicho elemento a la torre 3 (debe ser menor)
                        if (torre3.Peek() > num)
                        {
                            torre3.Push(num);
                            return 0;
                        }

                        else                      
                            return num;
                        
                    default:
                        return 0;
                }
            }
        }

        public bool Ganado() //Metodo para saber si ganamos
        {
            if (torre3.Count == TotalDiscos + 1) //Si la torre 3 tiene todos los elementos, habremos ganado
                return false;

            else //De lo contrario, no hemos ganado aun
                return true; 
        }

        public void Cursor(int posicion, int disco) //Metodo apra indicar el lugar del cursor
        {
            Console.SetCursorPosition(posicion, 2); //Iniciamos en la posicion seleccionada, a una altura de 2, para no tapar elementos (X,Y)
            Console.Write("V"); //Lo usamos como indicador
            Console.SetCursorPosition(posicion, 3); //Este sera la posicion del elemento que seleccionaremos, a una altura de 3, para no tapar elementos
            Console.WriteLine(disco); 
        }

        public void Imprimir()
        {
            int y = 4; //La altura del ultimo elemento sera de 4 

            foreach (int i in torre1) //Mostraremos los datos de la torre 1 de menor a mayor
            {
                Console.SetCursorPosition(5, y); //Iniciado en el eje (5,y)

                if (i == 100) //No puede haber 100 elementos
                    Console.WriteLine();

                else //Si no los hay, imprimimos los valores
                    Console.Write(i);

                y = y + 1; //Agregamos un espacio
            }

            //Se repetira el proceso en la torre 2 y 3
            y = 4;

            foreach (int i in torre2)
            {
                Console.SetCursorPosition(20, y);

                if (i == 100)
                    Console.WriteLine();

                else
                    Console.Write(i);

                y = y + 1;
            }

            y = 4;

            foreach (int i in torre3)
            {
                Console.SetCursorPosition(35, y);

                if (i == 100)
                    Console.WriteLine();

                else
                    Console.Write(i);

                y = y + 1;
            }
        }


    }
}
