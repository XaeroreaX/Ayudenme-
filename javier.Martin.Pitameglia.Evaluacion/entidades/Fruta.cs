using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Fruta
    {

        protected ConsoleColor _color;

        protected float _peso;

        public abstract bool TieneCarozo { get; }

        public Fruta() : this(ConsoleColor.Black, 10.00f) { }

        public Fruta(ConsoleColor color, float peso)
        {

            this._color = color;

            this._peso = peso;

        }

        protected virtual string FrutaToString()
        {

            string toString = "Color: " + this._color.ToString()+"\n";

            toString += "Peso: " + this._peso+"\n";

            string aux = "Tiene Carozo\n";

            if (this.TieneCarozo == false) aux = "no tiene carozo\n";

            toString += aux;

            return toString;
        }

    }


    public class Platano : Fruta
    {

        private string _paisOrigen;


        public override bool TieneCarozo { get { return false; } }

        public string Tipo { get { return "que se yo"; } }

        public Platano() : this(ConsoleColor.Yellow, 0.28f, "Argentina") { }

        public Platano(ConsoleColor color, float peso, string paisOrigen) : base(color, peso)
        {

            this._paisOrigen = paisOrigen;


        }

        protected override string FrutaToString()
        {

            string toString = ""+this.Tipo+":\n" + base.FrutaToString();

            return toString;
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }

    public class Manzana : Fruta
    {
        private string _distribuidora;

        public string Tipo { get { return "Manzana"; } }

        public override bool TieneCarozo { get { return true; } }

        protected override string FrutaToString()
        {
            string toString = "" + this.Tipo + ":\n" + base.FrutaToString();

            return toString;
        }

        public Manzana() : this(ConsoleColor.Red, 0.58f, "Argentina") { }

        public Manzana(ConsoleColor color, float peso, string distribuidora) : base(color, peso)
        {
            this._distribuidora = distribuidora;
        }

        public override string ToString()
        {
            return base.FrutaToString();
        }
    }





}
