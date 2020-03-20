# QuantumLineSharp
C# interface for QuantumLine C++ library (.dll included)
Copyright 2020 Bit By Byte Creations Ltd. under MIT license

# Quantumline c++ Library
Copyright 2020 IBM under Apache License.
https://www.apache.org/licenses/LICENSE-2.0


# Sample usage
```QuantumLineState state = new QuantumLineState();
state.Data = new double[]{0.3, 0.2, 0.1, 0.0}
double interf = 0.001;
state.Simulate(interf)
//Do something with simulated data
DisplayData(state.Data);```
