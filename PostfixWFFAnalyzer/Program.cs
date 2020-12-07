using System; 
using System.Collections.Generic; 
using System.Text.RegularExpressions; 

namespace PostfixWFFAnalyzer
{
    class Program
    {
        static void Main(string[] args) 
        {
            bool repeat = true;
            string postFixExp = string.Empty;
            string[] casosPrueba = new string[6] { "pq^rs%&", "pq^", "p", "pq", "r^^", "rs&ab" };
            
            Console.WriteLine("POSTFIX WFF ANALYZER\n");
            Console.WriteLine("Creado por:\n-Ricardo Ramirez\n");
            Console.WriteLine("Pulse cualquier tecla para iniciar...");
            Console.ReadKey();
            Console.Clear();

            while (repeat)
            {
                Console.WriteLine("MENU DE OPCIONES\n");
                Console.WriteLine("1. CASOS PRUEBA\n2. INGRESAR EXPRESION\n3. SALIR\n");
                Console.WriteLine("Opcion:");
                int opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("CASOS PRUEBA:\n");
                        Console.WriteLine("Leyenda:\nConjuncion = ^\nDisyuncion = %\nCondicional = &\n");
                        Console.WriteLine("Positivos:\n1. p q ^ r s % &\n2. p q ^\n3. p\n");
                        Console.WriteLine("Negativos:\n4. p q\n5. r ^ ^\n6. r s & a b\n");
                        Console.WriteLine("Opcion:");
                        int opcion2 = Convert.ToInt32(Console.ReadLine());
                        
                        switch (opcion2)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Expresion: p q ^ r s % &\n");
                                postFixExp = casosPrueba[0];
                                List<char> caracteres1 = Splitter(postFixExp);
                                
                                if (ValidarExp(caracteres1))
                                    Console.WriteLine("Su expresión es VALIDA\n");
                                else Console.WriteLine("Su expresion es INVALIDA\n");
                                
                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Expresion: p q ^\n");
                                postFixExp = casosPrueba[1];
                                List<char> caracteres2 = Splitter(postFixExp);
                                
                                if (ValidarExp(caracteres2))
                                    Console.WriteLine("Su expresión es VALIDA\n");
                                else Console.WriteLine("Su expresion es INVALIDA\n");
                                
                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("Expresion: p\n");
                                postFixExp = casosPrueba[2];
                                List<char> caracteres3 = Splitter(postFixExp);

                                if (ValidarExp(caracteres3))
                                    Console.WriteLine("Su expresión es VALIDA\n");
                                else Console.WriteLine("Su expresion es INVALIDA\n");

                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("Expresion: p q\n");
                                postFixExp = casosPrueba[3];
                                List<char> caracteres4 = Splitter(postFixExp);

                                if (ValidarExp(caracteres4))
                                    Console.WriteLine("Su expresión es VALIDA\n");
                                else Console.WriteLine("Su expresion es INVALIDA\n");

                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Expresion: r ^ ^\n");
                                postFixExp = casosPrueba[4];
                                List<char> caracteres5 = Splitter(postFixExp);

                                if (ValidarExp(caracteres5))
                                    Console.WriteLine("Su expresión es VALIDA\n");
                                else Console.WriteLine("Su expresion es INVALIDA\n");

                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Expresion: r s & a b\n");
                                postFixExp = casosPrueba[5];
                                List<char> caracteres6 = Splitter(postFixExp);

                                if (ValidarExp(caracteres6))
                                    Console.WriteLine("Su expresión es VALIDA\n");
                                else Console.WriteLine("Su expresion es INVALIDA\n");

                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Opcion invalida...");
                                Console.WriteLine("\nPulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                        break;
                    
                    case 2:
                        Console.Clear();
                        Console.WriteLine("INGRESE SU EXPRESION POSTFIJA PARA EVALUAR\n");
                        Console.WriteLine("NOTA: la expresion debe de estar compuesta por letras minusculas del abedecario\nConectores logicos de conjuncion, disyuncion o condicional");
                        Console.WriteLine("Y cada letra y conector deben estar separados por un espacio (no se puede incluir espacio al final)\n");
                        Console.WriteLine("Leyenda:\nConjuncion = ^\nDisyuncion = %\nCondicional = &\n");
                        Console.WriteLine("Expresion:");
                        
                        postFixExp = Console.ReadLine();
                        
                        if (!ValidarInput(postFixExp))
                        {
                            Console.WriteLine("Tiene que ingresar una expresion valida para poder evaluarla...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else 
                        {
                            List<char> caracteresInput = Splitter(postFixExp);
                            if (ValidarExp(caracteresInput))
                            {
                                Console.WriteLine("\nSu expresion es VALIDA\n");
                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else 
                            {
                                Console.WriteLine("\nSu expresion es INVALIDA\n");
                                Console.WriteLine("Pulse cualquier tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;

                    case 3:
                        repeat = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion invalida...");
                        Console.WriteLine("\nPulse cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static bool ValidarInput(string input) 
        {
            if (input[input.Length - 1] == ' ') 
                return false;

            if (input.Length == 1 && input[0] >= 'a' && input[0] <= 'z') 
                return true;

            for (int i = 0; i < input.Length; i++) 
            {
                if (input == input.Replace(" ", ""))
                    return false;

                if (input[i] == ' ' && input[i + 1] == ' ')
                    return false;
            }

            
            if (Regex.IsMatch(input, @"^[ ^%&]+$") == true) 
                return false;

            if (Regex.IsMatch(input, @"^[a-z^%& ]+$") == true) 
                return true;
            else
                return false;
        }

        static List<char> Splitter(string input) 
        {
            List<char> caracteres = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ') 
                {
                    caracteres.Add(input[i]);
                }
            }

            return caracteres;
        }

        static bool ValidarExp(List<char> lista) 
        {
            Stack<char> s = new Stack<char>(); 
            int size = lista.Count; 

            if (lista.Count == 1 && (lista[0] >= 'a' && lista[0] <= 'z'))
                return true; 
            else if (lista[size - 1] >= 'a' && lista[size - 1] <= 'z')
                return false; 

            for (int i = 0; i < size; i++) 
            {
                char caract = lista[i]; 

                if (caract >= 'a' && caract <= 'z') 
                    s.Push(caract);
                else if (caract == '^' || caract == '%' || caract == '&') 
                {
                    if (s.Count >= 2) 
                    {
                        s.Pop(); 
                        s.Pop(); 
                        s.Push('*'); 
                    }
                    else return false; 
                }
            }

            if (s.Count == 1 && s.Peek() == '*') 
                return true; 
            else return false; 
        }

    }
}
