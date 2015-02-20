using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NeuralNetwork.Tests
{
    public class LayerTests
	{
        [Test]
        public void AddNeuron_should_add_neuron_to_layer()
        {
            // Arrange
            Layer layer = new Layer();

            // Act
            layer.AddNeuron();
            layer.AddNeuron();

            // Assert
            Assert.That(layer.Neurons.Count, Is.EqualTo(2));
        }

		[Test]
        public void AddNeuron_should_return_new_neuron()
		{
            // Arrange
            Layer layer = new Layer();

            // Act
            PeceptronNeuron peceptron1 = layer.AddNeuron();
            PeceptronNeuron peceptron2 = layer.AddNeuron();

            // Assert
            Assert.That(peceptron1, Is.Not.EqualTo(peceptron2));
		}

        [Test]
        public void AddNeuron_should_add_weights_and_values_to_neurons()
        {
            // Arrange
            Layer layer = new Layer();

            // Act
            PeceptronNeuron peceptron = layer.AddNeuron(new Input(10, 20), new Input(33, 44));

            // Assert
            List<Input> inputs = peceptron.Inputs.ToList();
            
            Assert.That(inputs[0].Value, Is.EqualTo(10));
            Assert.That(inputs[0].Weight, Is.EqualTo(20));

            Assert.That(inputs[1].Value, Is.EqualTo(33));
            Assert.That(inputs[1].Weight, Is.EqualTo(44));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNextLayer_should_throw_exception_when_passed_null_layer()
        {
            // Arrange
            Layer layer = new Layer();

            // Act + Assert
            layer.SetNextLayer(null);
        }

        [Test]
        public void SetNextLayer_should_set_nextlayer_property_to_provided_layer()
        {
            // Arrange
            Layer layer1 = new Layer();
            layer1.AddNeuron();
            Layer layer2 = new Layer();
            layer2.AddNeuron();

            // Act
            layer1.SetNextLayer(layer2);

            // Assert
            Assert.That(layer1.NextLayer, Is.EqualTo(layer2));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateNextLayer_should_throw_exception_when_SetNextLayer_is_not_called_first()
        {
            // Arrange
            Layer layer = new Layer();

            // Act + Assert
            layer.UpdateNextLayer();
        }

        [Test]
        public void UpdateNextLayer_should_link_neurons_to_next_layer()
        {
            // Arrange
            Layer layer1 = new Layer();
            layer1.AddNeuron();
            layer1.AddNeuron();

            Layer layer2 = new Layer();
            layer2.AddNeuron();
            layer2.AddNeuron();

            // Act
            layer1.SetNextLayer(layer2);
            layer1.UpdateNextLayer();

            // Assert
            Assert.That(layer2.Neurons[0].Inputs.Count(), Is.EqualTo(2));
            Assert.That(layer2.Neurons[1].Inputs.Count(), Is.EqualTo(2));
        }

        [Test]
        public void UpdateNextLayer_should_update_inputs_in_next_layer_with_previous_layer_sigmoid_totals()
        {
            // Arrange
            Layer layer1 = new Layer();
            PeceptronNeuron layer1Neuron1 = layer1.AddNeuron(new Input(5, 1));
            PeceptronNeuron layer1Neuron2 = layer1.AddNeuron(new Input(5, 1));

            double expectedNeuron1Sum = layer1Neuron1.SigmoidTotal(layer1Neuron1.SumInputs()) * 2; // as there's 2 neurons pointing to the next layer,
            double expectedNeuron2Sum = layer1Neuron2.SigmoidTotal(layer1Neuron2.SumInputs()) * 2;

            Layer layer2 = new Layer();
            PeceptronNeuron layer2Neuron1 = layer2.AddNeuron();
            PeceptronNeuron layer2Neuron2 = layer2.AddNeuron();

            // Act
            layer1.SetNextLayer(layer2);
            layer1.UpdateNextLayer();

            // Assert
            Assert.That(layer2Neuron1.SumInputs(), Is.EqualTo(expectedNeuron1Sum));
            Assert.That(layer2Neuron2.SumInputs(), Is.EqualTo(expectedNeuron2Sum));
        }

        // Feed forward diagram: http://www.yukool.com/nn/images/image038.gif
	}
}
