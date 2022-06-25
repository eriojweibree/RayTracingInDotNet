
using System.Collections.Generic;
using System.Numerics;

namespace RayTracingInDotNet.Scene
{
	interface IScene
	{
		public List<Model> Models { get; }
		public List<Texture> Textures { get; }
		public string EnvironmentTexture { get; }

		public void Load(CameraInitialState camera)
        {
			Models.Clear();
			Textures.Clear();
			if(EnvironmentTexture != null) Textures.Add(Texture.LoadTexture(EnvironmentTexture));
			else Textures.Add(Texture.LoadTexture("./assets/textures/white.png"));
			Reset(camera);
        }

		public void Reset(CameraInitialState camera);

		public bool UpdateTransforms(double delta, UserSettings userSettings, Matrix4x4[] transforms)
		{
			return false;
		}
	}
}
