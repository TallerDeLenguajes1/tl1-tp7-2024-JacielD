/*public class Calculadora
{
    public double dato;

    public Calculadora(double valorInicial)
    {
        dato = valorInicial;
    }
    public void Sumar(double termino){

        dato += termino;
    }
    public void Restar(double termino){

        dato -= termino;
     }
    public void Multiplicar(double termino){

        dato *= termino;
    }
     public void Dividir(double termino){

        dato /= termino;
     }
    public void Limpiar(){

        dato = 0;
     }

     public double obtenerResultado(){

        return dato;
     }

     public double Resultado{

        get{return dato;}
     }
}
class Program
{
    static void Main()
    {
        Calculadora miCalculadora = new Calculadora(10);

        miCalculadora.Sumar(5);
        miCalculadora.Restar(3);
        miCalculadora.Multiplicar(2);
        miCalculadora.Dividir(4);

        double resultado = miCalculadora.obtenerResultado();

        Console.WriteLine("el resultado final es:"+ resultado);

        double resultadoPropiedad = miCalculadora.Resultado;
        Console.WriteLine("El resultado obtenido a través de la propiedad Resultado es: " + resultadoPropiedad);
    }
}*/
public class Calculadoraconsola{

    private Calculadora calculadora;

    public Calculadoraconsola(){

        calculadora = new Calculadora();
    }

    public void start(){

        Console.WriteLine("calculadora -- ingrese exit para salir");

        while (true)
        {
            Console.Write("Ingrese operación (+, -, *, /) seguido del número:");

            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            string[] parts = input.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Formato incorrecto. Por favor, ingrese la operación seguida del número.");
                continue;
            }

            double number;
            if (!double.TryParse(parts[1], out number))
            {
                Console.WriteLine("Número inválido. Por favor, ingrese un número válido.");
                continue;
            }
            switch (parts[0])
            {
                case "+":
                    calculadora.Sumar(number);
                    break;
                case "-":
                    calculadora.Restar(number);
                    break;
                case "*":
                    calculadora.Multiplicar(number);
                    break;
                case "/":
                    calculadora.Dividir(number);
                    break;
                default:
                    Console.WriteLine("Operación no válida. Por favor, ingrese una operación válida (+, -, *, /).");
                    break;
            }
                   Console.WriteLine("Resultado actual: " + calculadora.Resultado);

        }

    }

}
class Program
{
    static void Main()
    {
        Calculadoraconsola calculator = new Calculadoraconsola();
        calculator.Start();
    }
}