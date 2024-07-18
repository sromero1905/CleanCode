﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> Tasklist { get; set; }

        static void Main(string[] args)
        {
            Tasklist = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string Readline = Console.ReadLine();
            return Convert.ToInt32(Readline);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                //show current task
                ShowMenuTaskList();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;

                if (indexToRemove > (Tasklist.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("Numero de tarea seleccionado no es valido");
                }
                else
                {
                    if (indexToRemove > -1 && Tasklist.Count > 0)
                    {
                        string task = Tasklist[indexToRemove];
                        Tasklist.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");

                string task = Console.ReadLine();
                Tasklist.Add(task);
                if(task.Length<1) Console.WriteLine("debe ingresar al menos un caracter para añadir task");
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
                Console.WriteLine("hubo un error al ingresar la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (Tasklist == null || Tasklist.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                var indexTask = 1;
                Tasklist.ForEach(p => Console.WriteLine(indexTask++ + ". " + p));
                Console.WriteLine("----------------------------------------");
            }
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}