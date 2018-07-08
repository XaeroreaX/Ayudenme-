using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchivosPity;



namespace Entidades
{
    public class Storage<T> : ISerializable
    {

        #region Fields

        private int _capacidad;

        private List<T> _cajon;

        private float _precioUnitario;

        private XMLfile<Storage<T>> File;

        #endregion

        public List<T> Cajon
        {
            get
            {
                return this._cajon;
            }

        }

        public float PrecioTotal
        {

            get
            {
                return this._cajon.Count * this._precioUnitario;
            }

        }

        public string RutaArchivo
        {
            get; set;
                

        }

        #region Methods

        public static Storage<T> operator +(Storage<T> S, T that)
        {
                
            int i = 0;


            if ((object)that != null && (object) S != null) ;
            { 

                

                if(S._cajon.Count >= S._capacidad)
                {
                    throw new CajonLlenoException("TROLADORA!!!");
                }
                else
                {
                    S._cajon.Add(that);
                }
                        
            }

            return S;
        }

       

        public override string ToString()
        {
            string toString = "";

            foreach (T element in this._cajon)
            {
                toString += element.ToString();
            }

            return toString;
        }

        public string SerializarXML()
        {

            string returnAux = "";

           
       
             File.Save(this, out returnAux);
           


            


            return returnAux;
        }

       
        public string DeserializarXML()
        {
            Storage<T> storage = new Storage<T>();


            string returnAux = "";
           

            //returnAux = File.Load(out storage);


            if (returnAux == "Load is succefull")
            {
                this._capacidad = storage._capacidad;

                this._precioUnitario = storage._precioUnitario;

                this._cajon = storage._cajon;
            }

            return returnAux;
            
        }

        

        #region Constructor


        public Storage() :this(5, 5.5f)
        { }

        public Storage(int length, float Precio) : this(length)
        {

            this._precioUnitario = Precio;

        }

        public Storage(int length)
        {
            this._capacidad = length;

            this.RutaArchivo = @"C:\Users\jmpit\Desktop\javier.Martin.Pitameglia.Evaluacion\Serializado";


            this._cajon = new List<T>();

            Type[] Tipo = new Type[1];

            Tipo[0] = typeof(T);


            File = new XMLfile<Storage<T>>(this.RutaArchivo);


        }

        #endregion

        #endregion

    }


    public interface ISerializable
    {

        string RutaArchivo { get; set; }

        string SerializarXML();

        string DeserializarXML();

    }

}

