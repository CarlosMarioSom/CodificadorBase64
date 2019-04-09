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
        string codedFile = "";
        string groupOf3Bytes = "";

        // Reading file by bytes
        byte[] fileBytes = File.ReadAllBytes(Argumentos.Entrada);
        StringBuilder stringBuilder = new StringBuilder();

        int byteNumber = 1;
        foreach (byte b in fileBytes)
        {
            stringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            if (byteNumber % 3 == 0)
            {
                groupOf3Bytes = stringBuilder.ToString();
                codedFile += this.encode3Bytes(groupOf3Bytes);
                stringBuilder.Clear();
                Console.WriteLine(groupOf3Bytes);
            }
            byteNumber++;
        }
        codedFile += this.encodeIncompleteBytes(stringBuilder);
        Console.WriteLine(stringBuilder.ToString());

        return message;
    }

    private string encode3Bytes(string groupOf3Bytes)
    {
        string encoded = "";
        return encoded;
    }

    private string encodeIncompleteBytes(StringBuilder stringBuilder)
    {
        string encoded = "";
        return encoded;
    }
}