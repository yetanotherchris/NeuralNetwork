using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    public class PeceptronNeuron
    {
        private readonly List<Input> _inputs;

        public Guid Id { get; private set; }
        public IEnumerable<Input> Inputs { get { return _inputs; } }
        public double Threshold { get; set; }

        public PeceptronNeuron()
        {
            _inputs = new List<Input>();
            Id = Guid.NewGuid();
            Threshold = 1;
        }

        /// <summary>
        /// Sums all the inputs, multiplying them by their values.
        /// An alternative is to multiply the values (so a 0 value "gates" all the other inputs to zero),
        /// "This is rare in neural networks".
        /// </summary>
        /// <returns></returns>
        public double SumInputs()
        {
            double total = Inputs.Sum(x => x.Value * x.Weight);
            return total;
        }

        /// <summary>
        /// This is the value passed onto the next neuron, e.g. the output or Y value of the unit/neuron.
        /// </summary>
        /// <param name="inputTotal"></param>
        /// <returns></returns>
        public double SigmoidTotal(double inputTotal)
        {
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

        public void ClearInputs()
        {
            _inputs.Clear();
        }

        public void AddInput(double value, int weight)
        {
            AddInput(new Input(value, weight));
        }

        internal void AddInput(Input input)
        {
            _inputs.Add(input);
        }
    }
}