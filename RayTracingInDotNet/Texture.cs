using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using StbiSharp;
using System.IO;

namespace RayTracingInDotNet
{
	record Texture(int Width, int Height, int Channels, byte[] Pixels)
	{
		private static StbiImage LoadImageFile(string filename)
        {
			using (var stream = File.OpenRead(filename))
			using (var memoryStream = new MemoryStream())
			{
				stream.CopyTo(memoryStream);
				StbiImage image = Stbi.LoadFromMemory(memoryStream, 4);
				return image;
			}
		}

		public static Texture LoadTexture(string filename)
		{
			// Load the texture in normal host memory.
			int width, height, channels;

			//var image = SixLabors.ImageSharp.Image.Load<Rgba32>(filename);
			var image = LoadImageFile(filename);
			width = image.Width;
			height = image.Height;
			channels = 4;

			//byte[] pixelBytes = new byte[image.Width * image.Height * Unsafe.SizeOf<Rgba32>()];
			//image.CopyPixelDataTo(pixelBytes);
			byte[] pixelBytes = image.Data.ToArray();

			return new Texture(width, height, channels, pixelBytes);
		}

		public static Texture LoadTexture(byte[] pixels, int width, int height)
		{
			int channels = 4;

			return new Texture(width, height, channels, pixels);
		}
	}
}
