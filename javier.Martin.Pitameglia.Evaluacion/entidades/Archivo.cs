using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Entidades;





namespace ArchivosPity
{

    public delegate string SaveFileText<T>(T item);

    public delegate T ConstructorOutArgument<T>();

    public class XMLfile<T>
    {

        public string _path;

        public XmlSerializer _serializador;

        public event ConstructorOutArgument<T> Construct;

        public XMLfile(string path, Type []tipo)
        {

            this._path = path;



            this._serializador = new XmlSerializer(typeof(T), tipo);
            
            

            

        }


        public XMLfile(string path)
        {
            this._path = path;

            

            this._serializador = new XmlSerializer(typeof(T));

            

            

        }

        public void Save(T Element, out string messageException)
        {

            messageException = "Save is successfully";


            try
            {

                XmlTextWriter Arch = new XmlTextWriter(this._path, Encoding.ASCII);


                this._serializador.Serialize(Arch, Element);

                Arch.Close();
            }


            #region CatchException




            catch (ArgumentException EX)
            {

                messageException = EX.Message;
            }

            catch (UnauthorizedAccessException EX)
            {

                messageException = EX.Message;
            }

            catch (DirectoryNotFoundException EX)
            {

                messageException = EX.Message;
            }

            catch (IOException EX)
            {

                messageException = EX.Message;
            }

            catch (InvalidOperationException EX)
            {

                messageException = EX.Message;
            }

            catch (Exception EX)
            {

                messageException = EX.Message;
            }



            #endregion

        }



        public T Load(out string messageException)
        {
            messageException = "Load is successfully";

            object asignador = new object();


            T var = (T)asignador;

                   
            



            try
            {


                XmlTextReader Arch = new XmlTextReader(this._path);

                var = (T)this._serializador.Deserialize(Arch);

            

                Arch.Close();

            }



            #region CatchException


            catch (FileNotFoundException EX)
            {

                messageException = EX.Message;
            }

  
            catch (DirectoryNotFoundException EX)
            {

                messageException = EX.Message;
            }

            catch (UriFormatException EX)
            {

                messageException = EX.Message;
            }

            catch (InvalidOperationException EX)
            {

                messageException = EX.Message;
            }

            catch (Exception EX)
            {

                messageException = EX.Message;
            }



            #endregion


            return var;


        }


    }

    public static class TEXTFile
    {

        public static string Escribir(this string texto, string archivo, bool noSobrescribir)
        {
            string message = "Save is succefull";


            try
            {

                StreamWriter file = new StreamWriter(archivo, noSobrescribir);

                file.WriteLine(texto);

                file.Close();
            }


            #region Catch

            catch (UnauthorizedAccessException EX)
            {
                message = EX.Message;

            }

            catch (ArgumentException EX)
            {
                message = EX.Message;
            }

            catch (DirectoryNotFoundException EX)
            {
                message = EX.Message;
            }

            catch (PathTooLongException EX)
            {
                message = EX.Message;
            }

            catch (IOException EX)
            {
                message = EX.Message;
            }

            catch (System.Security.SecurityException EX)
            {
                message = EX.Message;
            }

            catch (ObjectDisposedException EX)
            {
                message = EX.Message;
            }

            catch (Exception EX)
            {
                message = EX.Message;
            }
            #endregion


            return message;

        }

        public static string Leer(this string texto, string archivo)
        {

            string message = "OK";

            try
            {
                StreamReader reader = new StreamReader(archivo);

                message = reader.ReadToEnd();

                reader.Close();
            }


            #region Catch

            

            catch (ArgumentException EX)
            {
                message = EX.Message;
            }

           

            catch (IOException EX)
            {
                message = EX.Message;
            }
                
            catch(OutOfMemoryException EX)
            {
                message = EX.Message;
            }

            catch (Exception EX)
            {
                message = EX.Message;
            }
            #endregion

            return message;
        }

        public static string EscribirItem<T>(T item, SaveFileText<T> Metodo, string archivo)
        {

            string message = "Save is succefull";


            try
            {

                StreamWriter file = new StreamWriter(archivo);

                file.WriteLine(Metodo.Invoke(item));

                file.Close();
            }


            #region Catch

            catch (UnauthorizedAccessException EX)
            {
                message = EX.Message;

            }

            catch (ArgumentException EX)
            {
                message = EX.Message;
            }

            catch (DirectoryNotFoundException EX)
            {
                message = EX.Message;
            }

            catch (PathTooLongException EX)
            {
                message = EX.Message;
            }

            catch (IOException EX)
            {
                message = EX.Message;
            }

            catch (System.Security.SecurityException EX)
            {
                message = EX.Message;
            }

            catch (ObjectDisposedException EX)
            {
                message = EX.Message;
            }

            catch (Exception EX)
            {
                message = EX.Message;
            }
            #endregion


            return message;

        }



    }


    public static class BINARIFile
    {

        public static bool Serializar<T>(string path, T item)
        {

            bool returnAux = true;

            try
            {

                FileStream File = new FileStream(@path, FileMode.Create);

                BinaryFormatter Serializador = new BinaryFormatter();

                Serializador.Serialize(File, item);

                File.Close();

            }

            #region Catch
                catch (ArgumentException e)
                {
                    
                    returnAux = false;
                    throw e;
                }

                catch(NotSupportedException e)
                {

                    
                    returnAux = false;
                    throw e;

                }
                
                catch(System.Security.SecurityException e)
                {

                    
                    returnAux = false;
                    throw e;

                }

                catch(FileNotFoundException e)
                {

                    
                    returnAux = false;
                    throw e;

                }

                catch(IOException e)
                {
                    
                    returnAux = false;
                    throw e;

                }


                catch(Exception e)
                {

                    
                    returnAux = false;
                    throw e;

                }
            #endregion

            return returnAux;

        }

        public static bool Deserializar<T>(string path, ConstructorOutArgument<T> constructor, out T variable)
        {

            bool returnAux = true;

            try
            { 
                FileStream File = new FileStream(@path, FileMode.Open);

                BinaryFormatter deSerializador = new BinaryFormatter();

                variable = (T)deSerializador.Deserialize(File);

                File.Close();
            }

            #region Catch
                catch (ArgumentException e)
                {
                    variable = constructor.Invoke();
                    returnAux = false;
                    throw e;
                }

                catch (NotSupportedException e)
                {

                    variable = constructor.Invoke();
                    returnAux = false;
                    throw e;

                }

                catch (System.Security.SecurityException e)
                {

                    variable = constructor.Invoke();
                    returnAux = false;
                    throw e;

                }

                catch (FileNotFoundException e)
                {

                    variable = constructor.Invoke();
                    returnAux = false;
                    throw e;

                }

                catch (IOException e)
                {

                    variable = constructor.Invoke();
                    returnAux = false;
                    throw e;

                }


                catch (Exception e)
                {

                    variable = constructor.Invoke();
                    returnAux = false;
                    throw e;

                }
            #endregion

            return returnAux;
        }

    }



}