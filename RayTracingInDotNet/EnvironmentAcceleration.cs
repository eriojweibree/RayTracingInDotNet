using System.Numerics;
using System.Runtime.InteropServices;

namespace RayTracingInDotNet
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EnvironmentAcceleration
    {
        public uint alias;
        public float q;
        public float pdf;
        public float aliasPdf;
    }
}
