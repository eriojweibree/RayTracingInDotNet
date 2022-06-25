
struct UniformBufferObject
{
	mat4 ModelView;
	mat4 Projection;
	mat4 ModelViewInverse;
	mat4 ProjectionInverse;
	vec4 SkyColor1;
	vec4 SkyColor2;
	float Aperture;
	float FocusDistance;
	uint TotalNumberOfSamples;
	uint NumberOfSamples;
	uint NumberOfBounces;
	uint RandomSeed;
	float Exposure;
	bool ShowHeatmap;
	float HeatmapScale;
};
