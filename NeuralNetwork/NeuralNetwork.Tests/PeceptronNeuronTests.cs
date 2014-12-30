using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			neuron.Inputs.Add(new Input(value, weight));

			// Act
			int actualSum = neuron.SumInputs();

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
				neuron.Inputs.Add(new Input(values[i], weights[i]));
			}

			// Act
			int actualSum = neuron.SumInputs();

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
	}
}
