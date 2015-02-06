using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
	public class MCPNeuron
	{
		public List<int> ExcitatoryInputs { get; set; }
		public List<int> InhibitoryInputs { get; set; }

		// Used by the activation function
		public int Threshold { get; set; }

		public MCPNeuron()
		{
			Threshold = 1;
			ExcitatoryInputs = new List<int>();
			InhibitoryInputs = new List<int>();
		}

		public int GetOutput()
		{
			return ActivationFunction();
		}

		protected int ActivationFunction()
		{
			// MCP - inhibition is all or nothing
			int inhibitionSum = InhibitoryInputs.Sum();
			if (inhibitionSum > 0)
			{
				return 0;
			}

			int excitatorySum = ExcitatoryInputs.Sum();
			return (excitatorySum > Threshold) ? 1 : 0;
		}
	}
}