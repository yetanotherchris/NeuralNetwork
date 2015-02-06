C# Neural Network
=============

A C# implementation of an MCP Neuron and Rosenblatt Peceptron, plus a simple neural network.

###Background

#### MCP Neuron

**McCulloch and Pitts** wanted to know how arrays of simple "computers" such as neurons were capable of carrying out the complex computation that they were sure underpin thought. Their 1943 paper became enormously influential, they simplified the neuron in the MCP (McCulloch and Pitts) neuron:

- It ignored spikes and spike trains, and frequency. It fires or it doesn’t
- Operates in discrete time. It has a certain fixed time period to accumulate excitation and by the end of this fires or does not.
- Death of neurons and LTP are ignored.
- Excitatory inputs are summed up, and have to exceed a threshold value. Any inhibitory input will stop the neuron firing.

**Hebb** was a psychologist in the 1940s and reacted against the behaviourist theories of his time, which linked sensation to action and stimulus to response.

He speculated on the excitatory and inhibitory mechanisms and believed LTP (long term potentiation aka muscle memory or memory through repetition) was the basis for memory and learning. He was interested in how neurons acted together spread across the brain. He believed memory was distributed across the brain, e.g. the grandmother cell.

**Frank Rosenblatt** was a 1950s and 1960s computer scientist at Cornell. He built on MCP and Hebb and came up with the Peceptron, "A probabilistic model for information storage and organization in the brain". The ideas were based on:

- People’s nervous systems are random from birth (ignores genetic mechanisms)
- The connection strengths change as a result of the experiences of each organism
- As the organism experiences more stimuli, the nervous system changes to respond in roughly the same way to stimuli that are similar.
- Growth + strength of connections are reinforced positively or negatively.

#### Peceptron
The Peceptron built on the ideas of the MCP Neuron, using weights instead of the binary nature of the inhibitary inputs.

Each input has a weight value. Like the MCP, the inputs are totalled up and should exceed a threshold, however each input value is also multiplied by its weight. 

On its own a Peceptron doesn't hold much value as McCulloch and Pitts realised - but when part of a network it becomes more powerful. The networks can be:

- Layered: a layer of neurons feeds its output values into the next layer of neurons as inputs.
- Lattices: like floors in a building, each floor contain a set of neurons that feed into the next floor or lattice.
- Recurrent: the output value of a neuron or layer feeds back into a previous layer in the network.
 
The networks can either be supervised (supervised learning) where training data is provided, and the weights adjusted until the output matches the data; or un-supervised where the threshold function(s) adjust the values to reinforce them where needed.
   
