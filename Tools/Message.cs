public class Message
{
    /// ATRIBUTOS
    private Arguments_Entity Argumentos;
    private string Mensaje;

    /// CONSTRUCTORES
    public Message(Arguments_Entity argumentos, string mensaje)
    {
        this.Argumentos = argumentos;
        this.Mensaje = mensaje;
    }

    /// METODOS
    public string getMessage()
    {
        string MensajeSalida = "";

        /* ---- Cuando se completó la tarea satisfactoriamente  ---- */
        if (Mensaje == "")
        {
            /* ---- Mensaje para codificacion */
            if (this.Argumentos.Accion == "c")
            {
                MensajeSalida = "\n==============================\n---- Codificador Base 64 ----\n==============================\n-> Codificación exitosa\nEntrada: " + Argumentos.Entrada + "\nSalida: " + Argumentos.Salida + "\n";
            }
            /* ---- Mensaje para decodificacion */
            else if (this.Argumentos.Accion == "d")
            {
                MensajeSalida = "\n==============================\n---- Codificador Base 64 ----\n==============================\n-> Decodificación exitosa\nEntrada: " + Argumentos.Entrada + "\nSalida: " + Argumentos.Salida + "\n";
            }
        }
        /* ---- Mensaje de error */
        else
        {
            MensajeSalida = this.Mensaje;
        }

        return MensajeSalida;
    }
}