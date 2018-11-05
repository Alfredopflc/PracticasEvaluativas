using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Lista
    {
        int id = 0;

        //Lista para cada tipo de tarea
        List<Tarea> ListaGlobal = new List<Tarea>(); 
        List<Tarea> TareaPendiente = new List<Tarea>(); 
        List<Tarea> TareaEnProceso = new List<Tarea>();
        List<Tarea> TareaTerminada = new List<Tarea>();

        public void Menu()
        {
            Console.Clear(); //Limpiamos para que no salga el Menu principal

            int opc = 0;
            bool ciclo = false;

            do
            {
                Console.Clear();
                Console.Write("Que desea realizar? \n1 = Agregar Tarea Nueva \n2 = Iniciar una Tarea \n3 = Terminar una Tarea " +
                    "\n4 = Corregir una Tarea \n5 = Ver Listas" + "\n6 = Salir del Programa \nR = ");
                //Muestra las funciones que puede hacer el programa
                opc = int.Parse(Console.ReadLine());

                if (opc == 1)
                    AgregarTarea(opc, 0, " "); //Si elige 1, llamamos al Metodo Agregar Tarea en 0

                else if (opc == 2)
                    IniciarTarea(); //Si elige 2, llamamos al Metodo IniciarTarea

                else if (opc == 3)
                    TerminarTarea(); //Si elige 3, llamamos al Metodo TerminarTarea

                else if (opc == 4)
                    CorregirTarea(); //Si elige 4, llamamos al Metodo CorregirTarea

                else if (opc == 5)
                    MostrarListas(); //Si elige 5, llamamos al Metodo MostrarListas

                else if (opc == 6) //Si elige 6, cierra el programa
                    ciclo = true;

                else //Si no, cierra el programa
                    ciclo = true;

            } while (ciclo == false);  //Ciclo hasta que se cierre el programa

            Console.ReadKey();

        }

        public void AgregarTarea(int opc, int ID, string fecha) //Metodo para agregar una nueva Tarea a las Listas ListaGlobal y TareaPendiente
        {
            Console.Clear();

            Tarea NuevaTarea = new Tarea(); //Nueva Tarea

            if (opc == 1) //Si opc es 1, el ID tomara el valor de 1 al ser nueva tarea, si no se corregira
                id = id + 1;            

            NuevaTarea.ID = id; //Guardamos el ID
            Console.Write("Ingrese el Nombre de la Tarea: "); //Pedimos nombre de Tarea
            NuevaTarea.Nombre = Console.ReadLine();

            Console.Write("Ingrese la Descripción de la Tarea: "); //Pedimos la descripcion de la tarea
            NuevaTarea.Descripcion = Console.ReadLine();

            Console.Write("Ingrese la Fecha de Inicio: "); //Pedimos la Fecha de Inicia de la tarea
            NuevaTarea.FechaInicio = Console.ReadLine();

            NuevaTarea.FechaFin = fecha; //Al ser una tarea nueva, aun no tenemos fecha de finalizacion


            if (opc == 1)
            {
                NuevaTarea.Status = "Pendiente"; //Si opc es 1, se agregara a ListaGlobal y TareaPendiente, su status sera Pendiente
                TareaPendiente.Add(NuevaTarea);
                ListaGlobal.Add(NuevaTarea);
            }

            else if (opc == 2)
            {
                NuevaTarea.Status = "En Proceso";
                NuevaTarea.ID = ID; //Si opc es 2, se agregara a ListaGlobal y TareaEnProceso, con el status "En Proceso"
                TareaEnProceso.Add(NuevaTarea);
                ListaGlobal.Add(NuevaTarea);

            }

        }

        public void IniciarTarea() //Metodo para iniciar una tarea (solo cambiamos el status a "En Proceso" de una tarea
        {
            Console.Clear();
            int opc = 0;

            Console.WriteLine("Tareas Disponibles para Iniciar: ");

            foreach (Tarea Tarea in TareaPendiente) //Muestra las tareas disponibles para iniciar (si es que hay)
            {
                Console.WriteLine("ID: {0}", Tarea.ID);
                Console.WriteLine(Tarea.Nombre);
                Console.WriteLine(Tarea.Descripcion + "\n");
            }

            Console.Write("Ingrese el ID de la tarea: "); //Pide el ID de la tarea que vamos a iniciar
            opc = int.Parse(Console.ReadLine());

            var valor = (from buscar in TareaPendiente where opc == buscar.ID select buscar).ToList();
            //Si el ID existe dentro de las tareas disponibles lo buscara y lo almacenara en "valor"

            foreach (var item in valor) //Busca la Tarea que tenga el ID = valor
            {
                ListaGlobal.Remove(item); //Elimina dicha Tarea de ListaGlobal
                item.Status = "En Proceso"; //Su status cambia a "En Proceso"
                TareaEnProceso.Add(item); //Agregamos la Tarea a la lista TareaEnProceso
                ListaGlobal.Add(item); //Se agrega la tarea a ListaGlobal
                TareaPendiente.Remove(item); //Se elimina de Tareas Pendientes
            }

            valor.Clear(); //Limpiamos la lista
        }

        public void TerminarTarea() //Metodo para terminar una tarea (Siempre y cuando este "En Proceso")
        {
            Console.Clear();
            string fecha = "";
            int opc = 0;

            Console.WriteLine("Tareas Disponibles para Terminar: ");

            foreach (Tarea Tarea in TareaEnProceso) //Muestra si hay tareas en Proceso
            {
                Console.WriteLine("ID: {0}", Tarea.ID); //Muestra los datos de dichas tareas
                Console.WriteLine(Tarea.Nombre); 
                Console.WriteLine(Tarea.Descripcion + "\n");
            }

            Console.Write("Ingrese el ID de la Tarea: "); //Pedimos el ID para buscarlos como en el Metodo Anterior
            opc = int.Parse(Console.ReadLine());

            var valor = (from buscar in TareaEnProceso where opc == buscar.ID select buscar).ToList();
            //Buscamos la tarea con dicho ID

            Console.Write("Ingrese Fecha de Finalización: "); //Pide fecha de finalizacion, ya que daremos la tarea por Terminada
            fecha = Console.ReadLine();

            foreach (var item in valor)
            {
                ListaGlobal.Remove(item); //Elimina dicha tarea de ListaGlobal
                item.Status = "Terminada"; //Cambia el status a "Terminada"
                item.FechaFin = fecha; //Guarda la fecha de finalizacion
                TareaTerminada.Add(item); //Agrega la lista a TareaTerminada
                ListaGlobal.Add(item); //La agrega a ListaGlobal ahora con el status de terminada y fecha de finalizacion
                TareaEnProceso.Remove(item); //Elimina la tarea de la lista TareaEnProceso
            }

            valor.Clear(); //La limpiamos para evitar tareas iguales
        }

        public void CorregirTarea() //Metodo para corregir algun dato de tareas ya existentes
        {
            Console.Clear();
            int opc = 0;

            Console.WriteLine("Tareas Disponibles para Corregir: "); 

            foreach (Tarea Tarea in TareaTerminada) //Muestra las tareas que existen
            {
                Console.WriteLine("ID: {0}", Tarea.ID);
                Console.WriteLine(Tarea.Nombre);
                Console.WriteLine(Tarea.Descripcion + "\n");
            }

            Console.Write("Ingrese el ID de la Tarea a Corregir: "); //Se pide el ID para buscar dicha tarea
            opc = int.Parse(Console.ReadLine());

            var valor = (from buscar in TareaTerminada where opc == buscar.ID select buscar).ToList();
            //Buscamos la tarea con el ID

            foreach (var item in valor)
            {
                ListaGlobal.Remove(item); //Eliminamos la tarea de la ListaGlobal
                TareaTerminada.Remove(item); //Elimnamos la tarea de TareaTerminada
            }

            Console.Clear(); 
            valor.Clear(); //Se limpia para evitar tareas iguales
            AgregarTarea(2, opc, " "); //Mandamos a llamar al Metodo AgregarTarea para cambiar los valores de esta
        }

        public void MostrarListas() //Metodo para mostrar las listas disponibles
        {
            Console.Clear();

            int opc = 0;
            Console.Write("Que tarea desea ver? \n1 = Lista Global \n2 = Tareas Pendientes \n3 = Tareas en Proceso \n4 = Tareas Terminadas \nR = "); //Menu
            opc = int.Parse(Console.ReadLine());

            if (opc == 1) //Si elige 1, Mostrara todas las tareas de ListaGlobal
            {
                foreach (var item in ListaGlobal)
                {
                    Console.WriteLine("ID: {0}", item.ID);
                    Console.WriteLine("Nombre: {0}", item.Nombre); 
                    Console.WriteLine("Descripción: {0}", item.Descripcion);
                    Console.WriteLine("Fecha de inicio: {0}", item.FechaInicio);
                    Console.WriteLine("Status: {0} \n", item.Status);
                }
            }

            else if (opc == 2)  //Si elige 2, Mostrara las Tareas Pendientes
            {
                foreach (var item in TareaPendiente)
                {
                    Console.WriteLine("ID: {0}", item.ID);
                    Console.WriteLine("Nombre: {0}", item.Nombre); 
                    Console.WriteLine("Descripción: {0}", item.Descripcion);
                    Console.WriteLine("Fecha de inicio: {0}", item.FechaInicio);
                    Console.WriteLine("Status: {0} \n", item.Status);
                }
            }

            else if (opc == 3) //Si elige 3, Mostrara las Tareas en Proceso
            {
                foreach (var item in TareaEnProceso)
                {
                    Console.WriteLine("ID: {0}", item.ID);
                    Console.WriteLine("Nombre: {0}", item.Nombre); 
                    Console.WriteLine("Descripción: {0}", item.Descripcion);
                    Console.WriteLine("Fecha de inicio: {0}", item.FechaInicio);
                    Console.WriteLine("Status: {0} \n", item.Status);
                }
            }

            else if (opc == 4) //Si elige 4, Mostrara las tareas terminadas
            {
                foreach (var item in TareaTerminada)
                {
                    Console.WriteLine("ID: {0}", item.ID);
                    Console.WriteLine("Nombre: {0}", item.Nombre);
                    Console.WriteLine("Descripción: {0}", item.Descripcion);
                    Console.WriteLine("Fecha de inicio: {0}", item.FechaInicio);
                    Console.WriteLine("Fecha de finalización: {0} \n", item.FechaFin);
                }
            }
             
            else //Si no, habra error
                Console.WriteLine("ERROR "); 

            Console.ReadKey();           
        }    
    }
}
