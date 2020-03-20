using System;
using System.Runtime.InteropServices;

namespace QuantumLineSharp
{
    public class QuantumLineState
    {
        private IntPtr m_state;
        private bool m_validState = false;
        public QuantumLineState()
        {
            m_state = quantum_line_state_init();
            m_validState = true;
        }

        ~QuantumLineState() {
            Dispose();
        }

        public void Dispose() {
            if (m_validState) {
                quantum_line_state_deinit(m_state);
                m_validState = false;
            }
        }

        public double[] Data
        {
            get {
                double[] result = new double[DataSize];
                Marshal.Copy(quantum_line_state_get_data(m_state), result, 0, result.Length);
                return result;
            }

            set => quantum_line_state_set_data(m_state, value, value.Length);
        }

        public int DataSize => quantum_line_state_get_data_size(m_state);

        public void Simulate(double interference) => quantumline_simulate(m_state, interference);
        

        [DllImport("QuantumLine.dll")]
        private static extern IntPtr quantum_line_state_init();
        
        [DllImport("QuantumLine.dll")]
        private static extern IntPtr quantum_line_state_get_data(IntPtr state);
        
        [DllImport("QuantumLine.dll")]
        private static extern void quantum_line_state_set_data(IntPtr state, double[] data, int element_count);
        
        [DllImport("QuantumLine.dll")]
        private static extern void quantum_line_state_deinit(IntPtr state);
        
        [DllImport("QuantumLine.dll")]
        private static extern int quantum_line_state_get_data_size(IntPtr state);
        
        [DllImport("QuantumLine.dll")]
        private static extern void quantumline_simulate(IntPtr state, double interference);
    }
}