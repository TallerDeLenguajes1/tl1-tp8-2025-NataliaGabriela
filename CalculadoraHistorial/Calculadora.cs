namespace EspacioCalculadora
{
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }

    public class Operacion
    {
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion operacion;

        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
        {
            this.resultadoAnterior = resultadoAnterior;
            this.nuevoValor = nuevoValor;
            this.operacion = operacion;
        }

        public double Resultado
        {
            get
            {
                switch (operacion)
                {
                    case TipoOperacion.Suma:
                        return resultadoAnterior + nuevoValor;
                    case TipoOperacion.Resta:
                        return resultadoAnterior - nuevoValor;
                    case TipoOperacion.Multiplicacion:
                        return resultadoAnterior * nuevoValor;
                    case TipoOperacion.Division:
                        return nuevoValor != 0 ? resultadoAnterior / nuevoValor : double.NaN;
                    case TipoOperacion.Limpiar:
                        return 0;
                    default:
                        return 0;
                }
            }
        }

        public double NuevoValor => nuevoValor;
        public TipoOperacion OperacionTipo => operacion;

        public override string ToString()
        {
            string simbolo = operacion switch
            {
                TipoOperacion.Suma => "+",
                TipoOperacion.Resta => "-",
                TipoOperacion.Multiplicacion => "*",
                TipoOperacion.Division => "/",
                TipoOperacion.Limpiar => "Limpiar",
                _ => ""
            };
            return operacion == TipoOperacion.Limpiar
                ? $"Operación: {simbolo}, Resultado: 0"
                : $"{resultadoAnterior} {simbolo} {nuevoValor} = {Resultado}";
        }
    }

    public class Calculadora
    {
        private double termino;
        private List<Operacion> historial = new List<Operacion>();

        public double Resultado => termino;

        public IReadOnlyList<Operacion> Historial => historial.AsReadOnly();

        private void AgregarOperacion(double valor, TipoOperacion tipo)
        {
            var operacion = new Operacion(termino, valor, tipo);
            termino = operacion.Resultado;
            historial.Add(operacion);

            if (tipo == TipoOperacion.Limpiar)
            {
                historial.Clear();
                termino = 0;
            }
        }

        public void Sumar(double valor) => AgregarOperacion(valor, TipoOperacion.Suma);
        public void Restar(double valor) => AgregarOperacion(valor, TipoOperacion.Resta);
        public void Multiplicar(double valor) => AgregarOperacion(valor, TipoOperacion.Multiplicacion);
        public void Dividir(double valor) => AgregarOperacion(valor, TipoOperacion.Division);
        public void Limpiar() => AgregarOperacion(0, TipoOperacion.Limpiar);
    }
}
