using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int Opc = 0;

                Vaca v = new Vaca();
                Lista ToDoList = new Lista(); //Objetos de cada programa
                TorreHanoi TH = new TorreHanoi();
                

                Console.WriteLine("Que programa quiere Iniciar? \n1 = Vacas \n2 = Torre de Hanoi \n3 = To Do List"); //Menu de Programas
                Opc = int.Parse(Console.ReadLine());

                if (Opc == 1) //Programa Vacas de Bob
                {
                    Console.Clear();
                    v.Mostrar();
                    v.Cruzar();
                }

                else if (Opc == 2) //Programa Torres de Hanoi
                {
                    Console.Clear();
                    TH.Hanoi();
                }

                else if (Opc == 3) //Programa To Do List
                {
                    Console.Clear();
                    ToDoList.Menu();
                }

                else //Opcion no valida, marcara error
                    Console.WriteLine("ERROR"); 
            }
            
            catch(Exception e) //Atrapa excepcion
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
