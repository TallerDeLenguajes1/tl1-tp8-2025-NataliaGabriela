namespace EspacioCalculadora;

public class Calculadora
{
    private double termino;
    private bool primera = true;
    public List<Operacion> historial { get; set; } = new List<Operacion>();
    public double Resultado
    {
        get => termino;
    }
    public void Sumar(double Termino)
    {
        historial.Add(new Operacion(termino, Termino, TipoOperacion.Suma));
        termino += Termino;
        primera = false;
    }
    public void Restar(double Termino)
    {
        historial.Add(new Operacion(termino, Termino, TipoOperacion.Resta));
        termino -= Termino;
        primera = false;
    }
    public void Multiplicar(double Termino)
    {
        if (primera)
        {
            termino = Termino;
            primera = false;
        }
        else
        {
            historial.Add(new Operacion(termino, Termino, TipoOperacion.Multiplicacion));
            termino = Resultado * Termino;
        }

    }
    public void Dividir(double Termino)
    {
        if (primera)
        {
            termino = Termino;
            primera = false;
        }
        else
        {
            if (Termino != 0)
            {

                historial.Add(new Operacion(termino, Termino, TipoOperacion.Division));
                termino /= Termino;
            }
            else
            {
                Console.WriteLine("No se puede dividir por cero.");
            }
        }


    }
    public void Limpiar()
    {
        historial.Add(new Operacion(termino, 0, TipoOperacion.Limpiar));
        termino = 0;
        primera = true;
    }

    public void MostrarHistorial()
    {
        if (historial.Count == 0)
        {
            Console.WriteLine("No hay operaciones en el historial");
            return;
        }
        Console.WriteLine("\nHistorial de Operaciones: ");
        foreach (var item in historial)
        {
            Console.WriteLine(item.ToString());
        }
    }

}

