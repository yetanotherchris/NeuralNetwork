namespace NeuralNetwork
{
    public class Input
    {
        public int Value { get; set; }
        public int Weight { get; set; }

        public Input(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}