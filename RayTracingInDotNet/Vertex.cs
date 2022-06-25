using System.Numerics;
using System.Runtime.InteropServices;

namespace RayTracingInDotNet
{
	[StructLayout(LayoutKind.Sequential)]
	struct Vertex
	{
		public Vector3 Position;
		public Vector3 Normal;
		public Vector2 TexCoord;
		public int MaterialIndex;
		public Vector3 Tangent;

		public Vertex(Vector3 position, Vector3 normal, Vector2 texCoord, int materialIndex, Vector3 tangent) =>
			(Position, Normal, TexCoord, MaterialIndex, Tangent) = (position, normal, texCoord, materialIndex, tangent);

		public Vertex(Vector3 position, Vector3 normal, Vector2 texCoord, int materialIndex) =>
			(Position, Normal, TexCoord, MaterialIndex, Tangent) = (position, normal, texCoord, materialIndex, new Vector3(1, 0, 0));

		public override bool Equals(object obj) => base.Equals(obj);
		public bool Equals(in Vertex p) =>
			Position == p.Position && Normal == p.Normal && TexCoord == p.TexCoord && MaterialIndex == p.MaterialIndex && Tangent == p.Tangent;
		public override int GetHashCode() =>
			(Position, Normal, TexCoord, MaterialIndex, Tangent).GetHashCode();
		public static bool operator ==(in Vertex lhs, in Vertex rhs) => lhs.Equals(rhs);
		public static bool operator !=(in Vertex lhs, in Vertex rhs) => !(lhs == rhs);
	}
}
