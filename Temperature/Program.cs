using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{


    public class TemperatureChangeEventArgs : EventArgs
    {
        public double OldTemp { get; set; }
        public double NewTemp { get; set; }

        public double Differnce { get; }

        public TemperatureChangeEventArgs(double OldTemp , double NewTemp)
        {

            this.OldTemp = OldTemp;
            this.NewTemp = NewTemp;
            this.Differnce = OldTemp - NewTemp;
        }

    }


    public class TermoState
    {

        private double OldTemp;


        private double Current;


        public void SetTemp(double NewTemp)
        {

            if (OldTemp != NewTemp)
            {

                this.OldTemp = Current;
                this.Current = NewTemp;

            }


            RaiseTempChanged();


        }




        public event EventHandler<TemperatureChangeEventArgs> Changed;


        private void RaiseTempChanged()
        {

            RaiseTempChanged(new TemperatureChangeEventArgs(this.OldTemp, this.Current));


        } 


        protected virtual void RaiseTempChanged(TemperatureChangeEventArgs e)
        {

            if(OldTemp != Current)
            {

                Changed?.Invoke(this, e);

            }

        }



    }

    public class Display
    {


        public void SetSub(TermoState termoState)
        {

            termoState.Changed += HandlerTemperatureChanged;

        }

        public void HandlerTemperatureChanged(object sender, TemperatureChangeEventArgs e)
        {
            Console.WriteLine($"\n\nTemperature Changed :");
            Console.WriteLine($"__________________________________________");
            Console.WriteLine($"Temperature Changed from {e.OldTemp}   °C");
            Console.WriteLine($"Temperature Changed to   {e.NewTemp}   °C");
            Console.WriteLine($"Temperature Diffrence to {e.Differnce} °C");
            Console.WriteLine($"__________________________________________");

        }



    }



    public class Program
    {
        static void Main(string[] args)
        {

            TermoState state = new TermoState();

            Display display = new Display();

            display.SetSub(state);

            state.SetTemp(11.1);
            state.SetTemp(12);

            state.SetTemp(11.3);
            state.SetTemp(15);

        }
    }
}
