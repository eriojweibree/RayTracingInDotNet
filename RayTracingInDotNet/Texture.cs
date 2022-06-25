using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace RayTracingInDotNet
{
	record Texture(int Width, int Height, int Channels, byte[] Pixels)
	{
		public static Texture LoadTexture(string filename)
		{
			// Load the texture in normal host memory.
			int width, height, channels;

			var image = SixLabors.ImageSharp.Image.Load<Rgba32>(filename);
			width = image.Width;
			height = image.Height;
			channels = 4;

			byte[] pixelBytes = new byte[image.Width * image.Height * Unsafe.SizeOf<Rgba32>()];
			image.CopyPixelDataTo(pixelBytes);

			return new Texture(width, height, channels, pixelBytes);
		}

		public static Texture LoadTexture(ReadOnlySpan<byte> data)
		{
			// Load the texture in normal host memory.
			int width, height, channels;

			var image = SixLabors.ImageSharp.Image.Load<Rgba32>(data);
			width = image.Width;
			height = image.Height;
			channels = 4;

			byte[] pixelBytes = new byte[image.Width * image.Height * Unsafe.SizeOf<Rgba32>()];
			image.CopyPixelDataTo(pixelBytes);

			return new Texture(width, height, channels, pixelBytes);
		}

		public static Texture LoadTexture(byte[] pixels, int width, int height)
		{
			int channels = 4;

			return new Texture(width, height, channels, pixels);
		}
	}
}
