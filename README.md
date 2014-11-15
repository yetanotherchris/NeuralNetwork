NeuralNetwork
=============

A C# implementation of a Rosenblatt Peceptron,  (a simple neural network).

###Background

**McCulloch and Pitts** wanted to know how arrays of simple "computers" such as neurons were capable of carrying out the complex computation that they were sure underpin thought. Their 1943 paper became enormously influential, they simplified the neuron in the MCP (McCulloch and Pitts) neuron:

- It ignored spikes and spike trains, and frequency. It fires or it doesn’t
- Operates in discrete time. It has a certain fixed time period to accumulate excitation and by the end of this fires or does not.
- Excitatory adds up but inhibitory doesn’t.
- Death of neurons and LTP are ignored.

**Hebb** was a psychologist in the 1940s and reacted against the behaviourist theories of his time, which linked sensation to action and stimulus to response.

He speculated on the excitatory and inhibitory mechanisms and believed LTP (long term potentiation aka muscle memory or memory through repetition) was the basis for memory and learning. He was interested in how neurons acted together spread across the brain. He believed memory was distributed across the brain, e.g. the grandmother cell.

**Frank Rosenblatt** was a 1950s and 1960s computer scientist at Cornell. He built on MCP and Hebb and came up with the Peceptron, "A probabilistic model for information storage and organization in the brain". The ideas were based on:

- People’s nervous systems are random from birth (ignores genetic mechanisms)
- The connection strengths change as a result of the experiences of each organism
- As the organism experiences more stimuli, the nervous system changes to respond in roughly the same way to stimuli that are similar.
- Growth + strength of connections are reinforced positively or negatively.
