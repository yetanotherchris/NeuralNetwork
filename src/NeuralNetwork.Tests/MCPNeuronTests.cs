using System;
using NUnit.Framework;

namespace NeuralNetwork.Tests
{
	public class MCPNeuronTests
	{
		[Test]
		public void getoutput_should_return_0_when_inhibitory_value_is_greater_than_1()
		{
			// Arrange
			int expectedOutput = 0;
			MCPNeuron neuron = new MCPNeuron();

			neuron.ExcitatoryInputs.Add(1);
			neuron.ExcitatoryInputs.Add(2);
			neuron.InhibitoryInputs.Add(1);

			// Act
			int actualOutput = neuron.GetOutput();

			// Assert
			Assert.That(expectedOutput, Is.EqualTo(actualOutput));
		}

		[Test]
		public void getoutput_should_return_1_when_no_inhibitory_value()
		{
			// Arrange
			int expectedOutput = 1;
			MCPNeuron neuron = new MCPNeuron();

			neuron.ExcitatoryInputs.Add(1);
			neuron.ExcitatoryInputs.Add(2);

			// Act
			int actualOutput = neuron.GetOutput();

			// Assert
			Assert.That(expectedOutput, Is.EqualTo(actualOutput));
		}

		[Test]
		public void getoutput_should_return_0_when_theshold_value_is_not_reached()
		{
			// Arrange
			int expectedOutput = 0;
			MCPNeuron neuron = new MCPNeuron();

			neuron.Threshold = 4;
			neuron.ExcitatoryInputs.Add(1);
			neuron.ExcitatoryInputs.Add(2);

			// Act
			int actualOutput = neuron.GetOutput();

			// Assert
			Assert.That(expectedOutput, Is.EqualTo(actualOutput));
		}

		// Excitatory values can also be used for truth tables
	}
}
