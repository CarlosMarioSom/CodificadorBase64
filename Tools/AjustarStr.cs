using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AjustarStr
{
    private byte[] archivo;
    private int inicio;
    private int fin;
    public string acumulador;
    public string name;
    public AjustarStr(byte[] arc, int ini, int finn, string nombre)
    {
        archivo = arc;
        inicio = ini;
        fin = finn;
        acumulador = string.Empty;
        name = nombre;
    }

    public void ajustar()
    {

        string aux = string.Empty;

        for (int i = inicio; i <= fin; i++)
        {
            aux = Convert.ToString(archivo[i], 2);
            if (aux.Length != 8)
            {
                while (aux.Length < 8)
                {
                    aux = "0" + aux;
                }
            }
            acumulador += aux;
        }



    }
}
