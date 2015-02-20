using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class PeceptronNeuron
    {
        public List<Input> Inputs { get; set; }
        public int Threshold { get; set; }

        public PeceptronNeuron()
        {
            Threshold = 1;
            Inputs = new List<Input>();
        }

        public int SumInputs()
        {
            // An alternative is to multiply the values (so a 0 value "gates" all the other inputs to zero),
            // "This is rare in neural networks".
            int total = Inputs.Sum(x => x.Value * x.Weight);
            return total;
        }

        public double SigmoidTotal(double inputTotal)
        {
            // This is the value passed onto the next neuron, e.g. the output or Y value of the unit/neuron.

            // Sigmoid function (S graph):
            //
            // y = 
            //           1
            // ---------------------
            //   1 + E -netinput
            //
            // Example: http://fooplot.com/#W3sidHlwZSI6MCwiZXEiOiIxLygxK01hdGgucG93KDIuNzE4MjgsLXgpKSIsImNvbG9yIjoiIzAwMDAwMCJ9LHsidHlwZSI6MTAwMH1d
            // 

            double eToNegativeNetinput = (Math.Pow(Math.E, -inputTotal));
            double y = 1 / (1 + eToNegativeNetinput);
            return Math.Round(y, 3, MidpointRounding.ToEven);
        }
    }
}