
struct Vertex
{
  vec3 Position;
  vec3 Normal;
  vec2 TexCoord;
  int MaterialIndex;
  vec3 Tangent;
};

Vertex UnpackVertex(uint index, mat4 transform)
{
	const uint vertexSize = 12;
	const uint offset = index * vertexSize;
	
	Vertex v;
	
	v.Position = vec3(transform * vec4(Vertices[offset + 0], Vertices[offset + 1], Vertices[offset + 2], 1));
	v.Normal = vec3(transform * vec4(Vertices[offset + 3], Vertices[offset + 4], Vertices[offset + 5], 0));
	v.TexCoord = vec2(Vertices[offset + 6], Vertices[offset + 7]);
	v.MaterialIndex = floatBitsToInt(Vertices[offset + 8]);
	v.Tangent = vec3(Vertices[offset + 9], Vertices[offset + 10], Vertices[offset + 11]);

	return v;
}
