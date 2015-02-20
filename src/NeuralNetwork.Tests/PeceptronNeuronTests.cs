using System;
using System.Linq;
using NUnit.Framework;

namespace NeuralNetwork.Tests
{
	public class PeceptronNeuronTests
	{
		[Test]
		[TestCase(1, 1, 1)]
		[TestCase(1, -1, -1)]
		[TestCase(1, 0, 0)]
		public void SumInputs_should_sum_single_values_and_weights(int value, int weight, int expectedSum)
		{
			// Arrange
			PeceptronNeuron neuron = new PeceptronNeuron();
            neuron.AddInput(value, weight);

			// Act
            double actualSum = neuron.SumInputs();

			// Assert
			Assert.That(actualSum, Is.EqualTo(expectedSum));
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 1, 1 }, 6)]
		public void SumInputs_should_sum_all_values_and_weights(int[] values, int[] weights, int expectedSum)
		{
			// Arrange
			PeceptronNeuron neuron = new PeceptronNeuron();

			for (int i = 0; i < values.Length; i++)
			{
				neuron.AddInput(values[i], weights[i]);
			}

			// Act
            double actualSum = neuron.SumInputs();

			// Assert
			Assert.That(actualSum, Is.EqualTo(expectedSum));
		}

		[Test]
		[TestCase(0.84, 0.698)]
		public void SigmoidTotal_should_return_known_value(double input, double expectedValue)
		{
			// Arrange
			PeceptronNeuron neuron = new PeceptronNeuron();
			
			// Act
			double actualValue = neuron.SigmoidTotal(input);

			// Assert
			Assert.That(actualValue, Is.EqualTo(expectedValue));
		}

        [Test]
        public void ClearInputs_should_remove_all_inputs()
        {
            // Arrange
            PeceptronNeuron neuron = new PeceptronNeuron();
            neuron.AddInput(1, 1);
            neuron.AddInput(2, 1);

            // Act
            neuron.ClearInputs();

            // Assert
            Assert.That(neuron.Inputs.Count(), Is.EqualTo(0));
        }

        [Test]
        public void AddInput_should_add_to_inputs_with_correct_values()
        {
            // Arrange
            PeceptronNeuron neuron = new PeceptronNeuron();

            // Act
            neuron.AddInput(1, 2);

            // Assert
            Assert.That(neuron.Inputs.Count(), Is.EqualTo(1));
            Assert.That(neuron.Inputs.First().Value, Is.EqualTo(1));
            Assert.That(neuron.Inputs.First().Weight, Is.EqualTo(2));
        }
	}
}
