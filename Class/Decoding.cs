using System;
using System.Numerics;
using System.IO;
public class Decoding
{
    /// ATRIBUTOS
    private Arguments_Entity Argumentos;

    /// CONSTRUCTORES
    public Decoding(Arguments_Entity Argumentos)
    {
        this.Argumentos = Argumentos;
    }

    /// METODOS
    public string decodingFile()
    {
        string message = "";
        string binaryFileContent = ""; // AQUI SE ALMACENA TODO EL NUMERO BINARIO DEL ARCHIVO

        // Read line of file
        System.IO.StreamReader file = new System.IO.StreamReader(this.Argumentos.Entrada);
        string line = "";
        while ((line = file.ReadLine()) != null)
        {

            for (int i = 0; i < line.Length; i++)
            {
                /* Ignora simbolo de relleno = */
                if (line[i] == '=')
                {
                    continue;
                }

                string decodedNumber = this.getDecodingNumber(line[i]);

                /* Detecta formato incorrecto */
                if (decodedNumber == "-1")
                {
                    message = "\n***ERROR***\nEl archivo a codificar '" + this.Argumentos.Entrada + "' no corresponde a un archivo base64 o está dañado\n";
                    return message;
                }
                binaryFileContent += decodedNumber;
            }
        }

        /* Si hubo un error al crear el archivo */
        string errorMessage = this.createFile(binaryFileContent);
        if (errorMessage != "")
        {
            message = "\n***ERROR***\nHubo un error al crear el archivo '" + this.Argumentos.Salida + "\n" + "Mensaje de error: " + errorMessage + "\n";
        }

        return message;
    }

    private string createFile(string binaryFileContent)
    {
        byte[] bytes = this.binaryStrToBytes(binaryFileContent);
        try
        {
            using (Stream file = File.OpenWrite(this.Argumentos.Salida))
            {
                file.Write(bytes, 0, bytes.Length);
            }
        }
        catch (Exception ex)
        {
            return "" + ex;
        }


        return "";
    }

    private byte[] binaryStrToBytes(string binaryFileContent)
    {
        int numberOfBytes = binaryFileContent.Length / 8;
        byte[] bytes = new byte[numberOfBytes]; // Aqui queda el arreglo de bytes que componen el archivo
        for (int i = 0; i < numberOfBytes; ++i)
        {
            bytes[i] = Convert.ToByte(binaryFileContent.Substring(8 * i, 8), 2);
        }
        return bytes;
    }

    private string getDecodingNumber(char encodingNumber)
    {
        int valueOf6Bit = this.getValueOf6Bits(encodingNumber);
        string binaryNumber = this.getBinaryNumber(valueOf6Bit);
        string decodeNumber = this.formatBinaryNumber(binaryNumber);

        /* Verify incorrect format */
        if (valueOf6Bit == -1)
        {
            decodeNumber = "-1";
        }

        return decodeNumber;
    }

    private string formatBinaryNumber(string binaryNumber)
    {
        string decodeNumber = binaryNumber;
        if (binaryNumber.Length != 6)
        {
            for (int i = binaryNumber.Length; i < 6; i++)
            {
                decodeNumber = "0" + decodeNumber;
            }
        }
        return decodeNumber;
    }

    private string getBinaryNumber(int valueOf6Bit)
    {
        string binaryNumber = "";
        if (valueOf6Bit == 64)
        {
            binaryNumber = "000000";
        }
        else
        {
            binaryNumber = Convert.ToString(valueOf6Bit, 2);
        }
        return binaryNumber;
    }

    private int getValueOf6Bits(char encodingNumber)
    {
        int valueOf6Bit = -1;
        switch (encodingNumber)
        {
            case 'A':
                valueOf6Bit = 0;
                break;
            case 'B':
                valueOf6Bit = 1;
                break;
            case 'C':
                valueOf6Bit = 2;
                break;
            case 'D':
                valueOf6Bit = 3;
                break;
            case 'E':
                valueOf6Bit = 4;
                break;
            case 'F':
                valueOf6Bit = 5;
                break;
            case 'G':
                valueOf6Bit = 6;
                break;
            case 'H':
                valueOf6Bit = 7;
                break;
            case 'I':
                valueOf6Bit = 8;
                break;
            case 'J':
                valueOf6Bit = 9;
                break;
            case 'K':
                valueOf6Bit = 10;
                break;
            case 'L':
                valueOf6Bit = 11;
                break;
            case 'M':
                valueOf6Bit = 12;
                break;
            case 'N':
                valueOf6Bit = 13;
                break;
            case 'O':
                valueOf6Bit = 14;
                break;
            case 'P':
                valueOf6Bit = 15;
                break;
            case 'Q':
                valueOf6Bit = 16;
                break;
            case 'R':
                valueOf6Bit = 17;
                break;
            case 'S':
                valueOf6Bit = 18;
                break;
            case 'T':
                valueOf6Bit = 19;
                break;
            case 'U':
                valueOf6Bit = 20;
                break;
            case 'V':
                valueOf6Bit = 21;
                break;
            case 'W':
                valueOf6Bit = 22;
                break;
            case 'X':
                valueOf6Bit = 23;
                break;
            case 'Y':
                valueOf6Bit = 24;
                break;
            case 'Z':
                valueOf6Bit = 25;
                break;
            case 'a':
                valueOf6Bit = 26;
                break;
            case 'b':
                valueOf6Bit = 27;
                break;
            case 'c':
                valueOf6Bit = 28;
                break;
            case 'd':
                valueOf6Bit = 29;
                break;
            case 'e':
                valueOf6Bit = 30;
                break;
            case 'f':
                valueOf6Bit = 31;
                break;
            case 'g':
                valueOf6Bit = 32;
                break;
            case 'h':
                valueOf6Bit = 33;
                break;
            case 'i':
                valueOf6Bit = 34;
                break;
            case 'j':
                valueOf6Bit = 35;
                break;
            case 'k':
                valueOf6Bit = 36;
                break;
            case 'l':
                valueOf6Bit = 37;
                break;
            case 'm':
                valueOf6Bit = 38;
                break;
            case 'n':
                valueOf6Bit = 39;
                break;
            case 'o':
                valueOf6Bit = 40;
                break;
            case 'p':
                valueOf6Bit = 41;
                break;
            case 'q':
                valueOf6Bit = 42;
                break;
            case 'r':
                valueOf6Bit = 43;
                break;
            case 's':
                valueOf6Bit = 44;
                break;
            case 't':
                valueOf6Bit = 45;
                break;
            case 'u':
                valueOf6Bit = 46;
                break;
            case 'v':
                valueOf6Bit = 47;
                break;
            case 'w':
                valueOf6Bit = 48;
                break;
            case 'x':
                valueOf6Bit = 49;
                break;
            case 'y':
                valueOf6Bit = 50;
                break;
            case 'z':
                valueOf6Bit = 51;
                break;
            case '0':
                valueOf6Bit = 52;
                break;
            case '1':
                valueOf6Bit = 53;
                break;
            case '2':
                valueOf6Bit = 54;
                break;
            case '3':
                valueOf6Bit = 55;
                break;
            case '4':
                valueOf6Bit = 56;
                break;
            case '5':
                valueOf6Bit = 57;
                break;
            case '6':
                valueOf6Bit = 58;
                break;
            case '7':
                valueOf6Bit = 59;
                break;
            case '8':
                valueOf6Bit = 60;
                break;
            case '9':
                valueOf6Bit = 61;
                break;
            case '+':
                valueOf6Bit = 62;
                break;
            case '/':
                valueOf6Bit = 63;
                break;
            case '=':
                valueOf6Bit = 64;
                break;
            default:
                Console.WriteLine("Caracter incorrecto: '" + encodingNumber + "'");
                valueOf6Bit = -1;
                break;
        }
        return valueOf6Bit;
    }
}