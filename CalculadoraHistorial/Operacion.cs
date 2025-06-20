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


        public override string ToString()
        {
            return $"{resultadoAnterior} {Simbolo()} {nuevoValor} = {Resultado}";
        }
        private string Simbolo()
        {
            return operacion switch
            {
                TipoOperacion.Suma => "+",
                TipoOperacion.Resta => "-",
                TipoOperacion.Multiplicacion => "*",
                TipoOperacion.Division => "/",
                TipoOperacion.Limpiar => "-> limpiar",
                _ => "?"
            };
        }

    }
}