using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
public class Encoding
{
    ///ATRIBUTOS
    Arguments_Entity Argumentos;

    /// CONSTRUCTORES
    public Encoding(Arguments_Entity Argumentos)
    {
        this.Argumentos = Argumentos;
    }
    /// METODOS
    public string encodingFile()
    {
        string message = "";

        try
        {
            using (StreamWriter writer = new StreamWriter(this.Argumentos.Salida))
            {
                writer.Write(leer());
            }
        }
        catch (Exception ex)
        {
            message = "\n***ERROR***\nHubo un error al crear el archivo '" + this.Argumentos.Salida + "\n" + "Mensaje de error: " + ex + "\n";
        }

        return message;
    }

    //pide una ruta de archivo y devuelve un string
    private string leer()
    {

        List<string> tabla64 = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-" });

        string aux = string.Empty;
        List<string> lstGrupos = new List<string>();
        List<string> lstCodificado = new List<string>();
        string salida = string.Empty;
        //leyendo bytes
        byte[] archivo = System.IO.File.ReadAllBytes(this.Argumentos.Entrada);
        //ajustando grupos a 8 elementos
        string acumulador = string.Empty;

        if (archivo.Length > 100000)
        {
            int dividir = archivo.Length / 5;
            AjustarStr ajust = new AjustarStr(archivo, 0, dividir - 1, "P1");
            AjustarStr ajust2 = new AjustarStr(archivo, dividir, (dividir * 2) - 1, "P2");
            AjustarStr ajust3 = new AjustarStr(archivo, dividir * 2, (dividir * 3) - 1, "P3");
            AjustarStr ajust4 = new AjustarStr(archivo, dividir * 3, (dividir * 4) - 1, "P4");
            AjustarStr ajust5 = new AjustarStr(archivo, dividir * 4, archivo.Length - 1, "P5");

            Thread th1 = new Thread(new ThreadStart(ajust.ajustar));
            Thread th2 = new Thread(new ThreadStart(ajust2.ajustar));
            Thread th3 = new Thread(new ThreadStart(ajust3.ajustar));
            Thread th4 = new Thread(new ThreadStart(ajust4.ajustar));
            Thread th5 = new Thread(new ThreadStart(ajust5.ajustar));
            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            th5.Start();
            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();
            th5.Join();

            string aux1 = ajust.acumulador;
            string aux2 = ajust2.acumulador;
            string aux3 = ajust3.acumulador;
            string aux4 = ajust4.acumulador;
            string aux5 = ajust5.acumulador;

            acumulador = aux1 + aux2 + aux3 + aux4 + aux5;

            //implementar hilos
            //separando en grupos de 6
            int m = 0;
            int bandera = 0;
            int pos = 0;
            if ((acumulador.Length % 6) != 0)
            {
                bandera = 1;
            }
            for (int i = 0; i < (acumulador.Length / 6); i++)
            {
                if (i == 0)
                {
                    m = 0;
                }
                else
                {
                    m = 6 * i;
                }
                aux = acumulador[m].ToString();
                aux += acumulador[m + 1].ToString();
                aux += acumulador[m + 2].ToString();
                aux += acumulador[m + 3].ToString();
                aux += acumulador[m + 4].ToString();
                aux += acumulador[m + 5].ToString();
                lstGrupos.Add(aux);
                aux = string.Empty;
                m++;
                pos = i + 1;
            }
            if (bandera == 1)
            {
                aux = string.Empty;
                m = 6 * pos;
                for (int i = m; i < acumulador.Length; i++)
                {
                    aux += acumulador[i];
                }
                while (aux.Length < 6)
                {
                    aux = aux + "0";
                }
                lstGrupos.Add(aux);
            }

            //codigicando base 64
            foreach (var item in lstGrupos)
            {
                lstCodificado.Add(tabla64[BinToDec(item)]);
            }
            //generando la salida a string
            foreach (var item in lstCodificado)
            {
                salida += item;
            }
            int valor = salida.Length % 4;
            if (valor != 0)
            {
                for (int p = 0; p < valor; p++)
                {
                    salida = salida + "=";
                }
            }
            return this.fixExcess(salida);
        }
        else
        {

            AjustarStr ajust = new AjustarStr(archivo, 0, archivo.Length - 1, "P0");
            ajust.ajustar();
            acumulador = ajust.acumulador;
            //separando en grupos de 6
            int m = 0;
            int bandera = 0;
            int pos = 0;
            if ((acumulador.Length % 6) != 0)
            {
                bandera = 1;
            }
            for (int i = 0; i < (acumulador.Length / 6); i++)
            {
                if (i == 0)
                {
                    m = 0;
                }
                else
                {
                    m = 6 * i;
                }
                aux = acumulador[m].ToString();
                aux += acumulador[m + 1].ToString();
                aux += acumulador[m + 2].ToString();
                aux += acumulador[m + 3].ToString();
                aux += acumulador[m + 4].ToString();
                aux += acumulador[m + 5].ToString();
                lstGrupos.Add(aux);
                aux = string.Empty;
                m++;
                pos = i + 1;
            }
            if (bandera == 1)
            {
                aux = string.Empty;
                m = 6 * pos;
                for (int i = m; i < acumulador.Length; i++)
                {
                    aux += acumulador[i];
                }
                while (aux.Length < 6)
                {
                    aux = aux + "0";
                }
                lstGrupos.Add(aux);
            }

            //codigicando base 64
            foreach (var item in lstGrupos)
            {
                lstCodificado.Add(tabla64[BinToDec(item)]);
            }
            //generando la salida a string
            foreach (var item in lstCodificado)
            {
                salida += item;
            }
            int valor = salida.Length % 4;
            if (valor != 0)
            {
                for (int p = 0; p < valor; p++)
                {
                    salida = salida + "=";
                }
            }
            return this.fixExcess(salida);
        }
    }

    private string fixExcess(string salida)
    {
        if (salida[salida.Length - 1] == '=' && salida[salida.Length - 2] == '=' && salida[salida.Length - 3] == '=')
        {
            salida = salida.Substring(0, salida.Length - 2);
        }
        return salida;
    }
    private static int BinToDec(string binary)
    {
        int exponente = binary.Length - 1;
        int num_decimal = 0;

        for (int i = 0; i < binary.Length; i++)
        {
            if (int.Parse(binary.Substring(i, 1)) == 1)
            {
                num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
            }
            exponente--;
        }
        return num_decimal;
    }
}