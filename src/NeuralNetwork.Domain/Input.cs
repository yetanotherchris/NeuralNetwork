namespace NeuralNetwork
{
    public class Input
    {
        public double Value { get; set; }
        public double Weight { get; set; }

        public Input(double value, double weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}