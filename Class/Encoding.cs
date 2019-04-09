using System;
using System.Text;
using System.Numerics;
using System.IO;
public class Encoding
{
    /// ATRIBUTOS
    private Arguments_Entity Argumentos;

    /// CONSTRUCTORES
    public Encoding(Arguments_Entity Argumentos)
    {
        this.Argumentos = Argumentos;
    }

    /// METODOS
    public string encodingFile()
    {
        string message = "";
        string binaryOfFile = "";

        // Reading file by bytes
        byte[] fileBytes = File.ReadAllBytes(Argumentos.Entrada);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (byte b in fileBytes)
        {
            stringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }
        binaryOfFile = stringBuilder.ToString();

        //Console.WriteLine(binaryOfFile);

        message = binaryOfFile;
        return message;
    }
}