using System;

namespace CodificadorBase64
{
    class Program
    {
        /*
        * Correct format of params
        * @param: {String} - [0]: c | d : codificar | decodificar
        * @param: {String} - [1]: i | o : archivoEntrada | archivoSalida
        * @param: {String} - [2]: nameFile
        * @param: {String} - [3]: i | o : archivoEntrada | archivoSalida
        * @param: {String} - [4]: nameFile
        */
        static void Main(string[] args)
        {
            String mensajeAyuda = "================================================\n ---- ---- AYUDA CODIFICADOR BASE 64 ---- ----\n================================================\nSe espera la siguiente sintaxis para el comando: \nAcción que quiere realizar:\n	c: codificar\n	d: decodificar\nDirección de archivo:\n	o: archivo de salida\n	i: archivo de entrada\nRuta y nombre del archivo:\n	ruta/nombreArchivo\n\nEjemplos:\n	CodificadorBase64 c i Documents/ArchivoEntrada.txt o Documents/ArchivoSalida.code\n	CodificadorBase64 d o Documents/ArchivoSalida.txt i Documents/ArchivoEntrada.code";
            if (args.Length == 5)
            {
                /* ---- ---- ---- ---- Validando argumentos ---- ---- ---- ---- */
                string[] argumentos = new string[5] { args[0], args[1], args[2], args[3], args[4] };
                ArgumentsManagement ArgManagement = new ArgumentsManagement(argumentos);
                Arguments_Entity Argumentos = ArgManagement.getStructure();

                /* ---- ---- ---- ---- Acepta comando ingresado ---- ---- ---- ---- */
                if (Argumentos.Entrada != "" && Argumentos.Salida != "" && Argumentos.Accion != "")
                {
                    string outputMessage = "";
                    
                    /* ---- Codifica ---- */
                    if (Argumentos.Accion == "c")
                    {

                    }
                    
                    /* ---- Decodifica ---- */
                    else if (Argumentos.Accion == "d")
                    {
                        Decoding decoding = new Decoding(Argumentos);
                        outputMessage = decoding.decodingFile();
                    }

                    /* ---- Mensaje de salida ---- */
                    Message mensaje = new Message(Argumentos, outputMessage);
                    outputMessage = mensaje.getMessage();
                    Console.WriteLine(outputMessage);
                    return;
                }
                /* ---- ---- ---- ---- Rechaza comando ingresado ---- ---- ---- ---- */
                else
                {
                    Console.WriteLine(mensajeAyuda);
                    return;
                }
            }
            else
            {
                Console.WriteLine("No se recibieron los parametros esperados.\n");
                Console.WriteLine(mensajeAyuda);
                return;
            }

        }
    }
}
