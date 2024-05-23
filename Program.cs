public enum Cargos
{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}
public class Empleado
{
   public string nombre{get;set;}
   public string apellido{get;set;}
   public DateTime FechaNacimiento{get;set;}
   public char Civil{get;set;}
   public DateTime FechaIngreso{get;set;}
   public double sueldo{get;set;}
   public Cargos Cargo { get; set; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public Empleado(string nombre, string apellido, DateTime fechaNacimiento, char estadoCivil, DateTime fechaIngreso, double sueldoBasico, Cargos cargo)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    {
        this.nombre = nombre;
        this.apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        Civil = Civil;
        FechaIngreso = fechaIngreso;
        sueldo = sueldoBasico;
        Cargo = cargo;
    }
    public int CalcularAntiguedad(){

        TimeSpan antiguedad = DateTime.Today - FechaIngreso;
        return antiguedad.Days / 365;

    }

    public int edadEmpleado(){

        DateTime fechaActual = DateTime.Today;
        int edad = fechaActual.Year - FechaNacimiento.Year;
        if (FechaNacimiento.Date > fechaActual.AddYears(-edad)) 
        {
            edad--;
        }
        return edad;
    }
    public int AniosParaJubilarse()
    {
        int edadActual = edadEmpleado();
        int aniosJubilacion = 65;
        int aniosRestantes = aniosJubilacion - edadActual;
        return aniosRestantes;
    }

    public double CalcularSalario()
    {
        double adicional = 0;
        int antiguedad = CalcularAntiguedad();
        
        // Calcular adicional por antigüedad
        if (antiguedad <= 20)
        {
            adicional = sueldo * (antiguedad * 0.01);
        }
        else
        {
            adicional = sueldo* 0.25;
        }

        // Incrementar adicional si es Ingeniero o Especialista
        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
        {
            adicional *= 1.5;
        }

        // Incrementar adicional si es casado
        if (Civil == 'C')
        {
            adicional += 150000;
        }

        return sueldo + adicional;
    }
}
class Program{
static void main(){

    Empleado[] empleados = new Empleado[3];

    empleados[0] = new Empleado("juan carlos","bodoque",new DateTime(1990, 5, 15),'S',new DateTime(2010, 3, 20),2500.50,Cargos.Especialista);
    empleados[1] = new Empleado("Tulio","Triviño",new DateTime(1999,4,23),'C',new DateTime(2015,3,10),3000.20,Cargos.Ingeniero);
    empleados[2] = new Empleado("Pedro", "Rodriguez", new DateTime(1995, 8, 20), 'C', new DateTime(2015, 6, 5), 1800.25, Cargos.Auxiliar);

    double salarioTotal = 0;

    foreach (Empleado empleado in empleados)
    {
        salarioTotal += empleado.CalcularSalario();
    }

    Console.WriteLine("el salario total que se le paga a los empleados es: " + salarioTotal);

        Empleado ProximoJubilarse = empleados[0];
        int MinimosJubilacion = ProximoJubilarse.AniosParaJubilarse();

        foreach (Empleado empleado in empleados)
        {
            int JubilacionActual = empleado.AniosParaJubilarse();
            if (JubilacionActual < MinimosJubilacion && JubilacionActual >= 0){

                ProximoJubilarse = empleado;
                MinimosJubilacion = JubilacionActual;
            }
        }

         Console.WriteLine("Datos del empleado más próximo a jubilarse:");
        Console.WriteLine($"Nombre: {ProximoJubilarse.nombre} {ProximoJubilarse.apellido}");
        Console.WriteLine($"Edad: {ProximoJubilarse.edadEmpleado()} años");
        Console.WriteLine($"Años para jubilarse: {ProximoJubilarse.AniosParaJubilarse()}");
        Console.WriteLine($"Salario: {ProximoJubilarse.CalcularSalario()}");
        


}
}