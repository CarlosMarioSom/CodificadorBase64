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
        string threeByteEncoding = "";

        // Reading file by bytes
        byte[] fileBytes = File.ReadAllBytes(Argumentos.Entrada);
        StringBuilder stringBuilder = new StringBuilder();

        /* Para los 3 bytes completos */
        int byteNumber = 1;
        foreach (byte b in fileBytes)
        {
            stringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            if (byteNumber % 3 == 0)
            {
                groupOf3Bytes = stringBuilder.ToString();
                threeByteEncoding = this.encode3Bytes(groupOf3Bytes);

                if (threeByteEncoding != "-1")
                {
                    codedFile += threeByteEncoding;
                }
                else
                {
                    message = "\n***ERROR***\nSe encontró un valor no válido para codificar en Base64\n";
                    break;
                }

                stringBuilder.Clear();
            }
            groupOf3Bytes = stringBuilder.ToString();
            byteNumber++;
        }

        /* Cuando no son 3 bytes completos */
        threeByteEncoding = this.encodeIncompleteBytes(groupOf3Bytes);
        if (threeByteEncoding != "-1")
        {
            codedFile += threeByteEncoding;
        }
        else
        {
            message = "\n***ERROR***\nSe encontró un valor no válido para codificar en Base64\n";
        }

        /* Crear archivo final */
        message = this.createCodedFile(codedFile);

        return message;
    }

    private string createCodedFile(string codedFile)
    {
        string message = "";
        try
        {
            System.IO.File.WriteAllText(this.Argumentos.Salida, codedFile);
        }
        catch (Exception ex)
        {
            message = "\n***ERROR***\nNo se pudo crear el archivo '" + this.Argumentos.Salida + "'\n\n" + ex;
        }

        return message;
    }

    private string encode3Bytes(string groupOf3Bytes)
    {
        string encoded = "";

        string sixBits = "";
        int valueOfBinary = 0;
        char encodedNumber;
        for (int i = 0; i < 4; i++)
        {
            sixBits = groupOf3Bytes.Substring(0, 6);
            groupOf3Bytes = groupOf3Bytes.Remove(0, 6);

            valueOfBinary = Convert.ToInt32(sixBits, 2);
            encodedNumber = this.codeNumber(valueOfBinary);

            if (encodedNumber != '-')
            {
                encoded += encodedNumber;
            }
            else
            {
                encoded = "-1";
                break;
            }
        }

        return encoded;
    }

    private string encodeIncompleteBytes(string groupOf3Bytes)
    {
        string encoded = "";

        string sixBits = "";
        int valueOfBinary = 0;
        char encodedNumber;

        if (groupOf3Bytes.Length == 0)
        {

        }
        else if (groupOf3Bytes.Length == 1 * 8)
        {
            for (int i = 0; i < 2; i++)
            {
                sixBits = groupOf3Bytes.Substring(0, 6);
                groupOf3Bytes = groupOf3Bytes.Remove(0, 6);

                if (groupOf3Bytes.Length == 2)
                {
                    groupOf3Bytes += "0000";
                }

                valueOfBinary = Convert.ToInt32(sixBits, 2);
                encodedNumber = this.codeNumber(valueOfBinary);

                if (encodedNumber != '-')
                {
                    encoded += encodedNumber;
                }
                else
                {
                    encoded = "-1";
                    break;
                }
            }
            encoded += "==";
        }
        else if (groupOf3Bytes.Length == 2 * 8)
        {
            for (int i = 0; i < 3; i++)
            {
                sixBits = groupOf3Bytes.Substring(0, 6);
                groupOf3Bytes = groupOf3Bytes.Remove(0, 6);

                if (groupOf3Bytes.Length == 4)
                {
                    groupOf3Bytes += "00";
                }

                valueOfBinary = Convert.ToInt32(sixBits, 2);
                encodedNumber = this.codeNumber(valueOfBinary);

                if (encodedNumber != '-')
                {
                    encoded += encodedNumber;
                }
                else
                {
                    encoded = "-1";
                    break;
                }
            }
            encoded += "=";
        }

        return encoded;
    }

    private char codeNumber(int valueOfBinary)
    {
        char encodingSimbol;
        switch (valueOfBinary)
        {
            case 0:
                encodingSimbol = 'A';
                break;
            case 1:
                encodingSimbol = 'B';
                break;
            case 2:
                encodingSimbol = 'C';
                break;
            case 3:
                encodingSimbol = 'D';
                break;
            case 4:
                encodingSimbol = 'E';
                break;
            case 5:
                encodingSimbol = 'F';
                break;
            case 6:
                encodingSimbol = 'G';
                break;
            case 7:
                encodingSimbol = 'H';
                break;
            case 8:
                encodingSimbol = 'I';
                break;
            case 9:
                encodingSimbol = 'J';
                break;
            case 10:
                encodingSimbol = 'K';
                break;
            case 11:
                encodingSimbol = 'L';
                break;
            case 12:
                encodingSimbol = 'M';
                break;
            case 13:
                encodingSimbol = 'N';
                break;
            case 14:
                encodingSimbol = 'O';
                break;
            case 15:
                encodingSimbol = 'P';
                break;
            case 16:
                encodingSimbol = 'Q';
                break;
            case 17:
                encodingSimbol = 'R';
                break;
            case 18:
                encodingSimbol = 'S';
                break;
            case 19:
                encodingSimbol = 'T';
                break;
            case 20:
                encodingSimbol = 'U';
                break;
            case 21:
                encodingSimbol = 'V';
                break;
            case 22:
                encodingSimbol = 'W';
                break;
            case 23:
                encodingSimbol = 'X';
                break;
            case 24:
                encodingSimbol = 'Y';
                break;
            case 25:
                encodingSimbol = 'Z';
                break;
            case 26:
                encodingSimbol = 'a';
                break;
            case 27:
                encodingSimbol = 'b';
                break;
            case 28:
                encodingSimbol = 'c';
                break;
            case 29:
                encodingSimbol = 'd';
                break;
            case 30:
                encodingSimbol = 'e';
                break;
            case 31:
                encodingSimbol = 'f';
                break;
            case 32:
                encodingSimbol = 'g';
                break;
            case 33:
                encodingSimbol = 'h';
                break;
            case 34:
                encodingSimbol = 'i';
                break;
            case 35:
                encodingSimbol = 'j';
                break;
            case 36:
                encodingSimbol = 'k';
                break;
            case 37:
                encodingSimbol = 'l';
                break;
            case 38:
                encodingSimbol = 'm';
                break;
            case 39:
                encodingSimbol = 'n';
                break;
            case 40:
                encodingSimbol = 'o';
                break;
            case 41:
                encodingSimbol = 'p';
                break;
            case 42:
                encodingSimbol = 'q';
                break;
            case 43:
                encodingSimbol = 'r';
                break;
            case 44:
                encodingSimbol = 's';
                break;
            case 45:
                encodingSimbol = 't';
                break;
            case 46:
                encodingSimbol = 'u';
                break;
            case 47:
                encodingSimbol = 'v';
                break;
            case 48:
                encodingSimbol = 'w';
                break;
            case 49:
                encodingSimbol = 'x';
                break;
            case 50:
                encodingSimbol = 'y';
                break;
            case 51:
                encodingSimbol = 'z';
                break;
            case 52:
                encodingSimbol = '0';
                break;
            case 53:
                encodingSimbol = '1';
                break;
            case 54:
                encodingSimbol = '2';
                break;
            case 55:
                encodingSimbol = '3';
                break;
            case 56:
                encodingSimbol = '4';
                break;
            case 57:
                encodingSimbol = '5';
                break;
            case 58:
                encodingSimbol = '6';
                break;
            case 59:
                encodingSimbol = '7';
                break;
            case 60:
                encodingSimbol = '8';
                break;
            case 61:
                encodingSimbol = '9';
                break;
            case 62:
                encodingSimbol = '+';
                break;
            case 63:
                encodingSimbol = '/';
                break;
            case 64:
                encodingSimbol = '=';
                break;
            default:
                Console.WriteLine("Valor inválido: '" + valueOfBinary + "'");
                encodingSimbol = '-';
                break;
        }
        return encodingSimbol;
    }
}