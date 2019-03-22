public class ArgumentsManagement
{
    /// ATRIBUTOS
    private string[] args;

    /// CONSTRUCTORES
    public ArgumentsManagement(string[] args)
    {
        this.args = args;
    }

    /// METODOS
    private Arguments_Entity ArgumentsInitialization()
    {
        Arguments_Entity arg = new Arguments_Entity();
        arg.Salida = "";
        arg.Entrada = "";
        arg.Accion = "";
        return arg;
    }
    public Arguments_Entity getStructure()
    {
        Arguments_Entity Argumentos = this.ArgumentsInitialization();

        if ((args[0] == "c" || args[0] == "d"))
        {
            Argumentos.Accion = args[0];
        }
        else
        {
            return Argumentos;
        }
        if (args[1] == args[3])
        {
            return Argumentos;
        }

        for (int i = 1; i < args.Length; i += 2)
        {
            if (args[i] == "i")
            {
                Argumentos.Entrada = args[i + 1];
            }
            else if (args[i] == "o")
            {
                Argumentos.Salida = args[i + 1];
            }
            else
            {
                return Argumentos;
            }
        }
        return Argumentos;
    }
}