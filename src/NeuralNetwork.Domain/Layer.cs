using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Layer
    {
        private Dictionary<Guid, List<PeceptronNeuron>> _neuronLinks;
        public List<PeceptronNeuron> Neurons { get; set; }
        public Layer NextLayer { get; set; }

        public Layer()
        {
            Neurons = new List<PeceptronNeuron>();
        }

        public PeceptronNeuron AddNeuron(params Input[] inputs)
        {
            var neuron = new PeceptronNeuron();
            foreach (Input inputItem in inputs)
            {
                neuron.AddInput(inputItem);
            }

            Neurons.Add(neuron);
            return neuron;
        }

        /// <summary>
        /// Links all neurons in this layer to a second layer (forward layer).
        /// </summary>
        /// <param name="secondLayer">The layer to set as the next layer.</param>
        public void SetNextLayer(Layer secondLayer)
        {
            if (secondLayer == null)
                throw new ArgumentNullException("secondLayer");

            _neuronLinks = new Dictionary<Guid, List<PeceptronNeuron>>();
            foreach (PeceptronNeuron peceptronNeuron in Neurons)
            {
                // Link to every neuron in the new layer.
                _neuronLinks.Add(peceptronNeuron.Id, secondLayer.Neurons);
            }

            NextLayer = secondLayer;
        }

        /// <summary>
        /// Goes from left to right, 'firing' the neurons/peceptrons to get their sigmoid (threshold) values, updating the next layer's input values.
        /// </summary>
        public void UpdateNextLayer()
        {
            if (_neuronLinks == null)
                throw new InvalidOperationException("Cannot update the layer, as this layer isn't attached to a second layer. Use SetNextLayer() to associate it with a forward layer.");

            foreach (PeceptronNeuron neuron in NextLayer.Neurons)
            {
                neuron.ClearInputs();
            }

            foreach (PeceptronNeuron currentNeuron in Neurons)
            {
                double sum = currentNeuron.SumInputs();
                double sigmoidTotal = currentNeuron.SigmoidTotal(sum);

                IEnumerable<PeceptronNeuron> nextLayer = _neuronLinks[currentNeuron.Id];
                foreach (PeceptronNeuron targetNeurons in nextLayer)
                {
                    targetNeurons.AddInput(sigmoidTotal, 1);
                }
            }
        }
    }
}
