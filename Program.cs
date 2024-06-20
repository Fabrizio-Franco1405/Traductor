using System;

namespace Traductor
{
	class Fabrizio
	{
		
		static Dictionary<string, string> Traductor = new Dictionary<string, string>();

		static int contador = 1;

		static void Main(string[] agrs)
		{
			menu();
		}

		static void menu()
		{
			Console.Clear();
			Console.WriteLine("/----------Bienvenido al Traductor----------/\n");
			Console.WriteLine("1. Agregar Traducciones.");
			Console.WriteLine("2. Traducir.");
			Console.WriteLine("3. Eliminar Palabras.");
			Console.WriteLine("4. Lista de Traducciones.");
			Console.Write("\nSeleccione la opción que desee: ");
			int opcion = int.Parse(Console.ReadLine());

			switch (opcion)
			{
				case 1:
					Agregar();
					break;
				case 2:
					Traducir();
					break;
				case 3:
					Eliminar();
					break;
				case 4:
					VerLista();
					break;
				default:
					Console.WriteLine("\nSaliendo del Traductor...");
					return;
			}
		}

		static void Agregar()
		{
			Console.Clear();
			Console.Write("Ingrese la palabra que desee traducir (En Español): ");
			string español = Console.ReadLine();
			español = char.ToUpper(español[0]) + español.Substring(1);

			Console.Write("\nIngrese la Traducción de la palabra que acaba de ingresar (En Inglés): ");
			string ingles = Console.ReadLine();
			ingles = char.ToUpper(ingles[0]) + ingles.Substring(1);

			Traductor.Add(español, ingles);

			Console.WriteLine("\nLas traducciones fueron guardadas exitosamente.");
			contador++;
			volver();
		}

		static void Traducir()
		{
			char repetir;
			do
			{
				Console.Clear();
				Console.Write("Ingrese la palabra que desea traducir: ");
				string traducir = Console.ReadLine();
				traducir = char.ToUpper(traducir[0]) + traducir.Substring(1);

				if (Traductor.ContainsKey(traducir))
				{
					Console.WriteLine($"\nLa palabra {traducir} significa {Traductor[traducir]}");
				}
				else
				{
					Console.WriteLine("\nLa palabra que desea traducir no está registrada en el diccionario.");
				}

				Console.Write("\n¿Desea traducir alguna otra palabra? S/N: ");
				repetir = char.Parse(Console.ReadLine());
			} while (char.ToUpper(repetir) == 'S');

			volver();
		}

		static void Eliminar()
		{
			Console.Clear();
			Console.Write("Seleccione el número de la traducción que desea eliminar del diccionario: ");
			int eliminarTraduccion = int.Parse(Console.ReadLine());

			string eliminar = Traductor.ElementAt(eliminarTraduccion -1).Key;

			Traductor.Remove(eliminar);
			Console.WriteLine("\nLa traducción ha sido eliminada con éxito del diccionario.");
			contador--;

			volver();
		}

		static void VerLista()
		{
			Console.Clear();
			int numList = 1;

			foreach (var ver in Traductor)
			{
				Console.Write($"{numList}- Palabra en Español: {ver.Key}                     Palabra en Inglés: {ver.Value}\n");
				numList++;
			}

			if (Traductor.Count == 0)
			{
				Console.WriteLine("No hay palabras en el diccionario.");
			}

			volver();
		}

		static void volver()
		{
			Console.Write("\n¿Desea Volver al menú de opciones? S/N: ");
			char volver = char.Parse(Console.ReadLine());

			if (char.ToUpper(volver) == 'S')
			{
				menu();
			}
			else
			{
				return;
			}
		}
	}
}