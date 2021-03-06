using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<EmptyParameters>(
				"������� ������",
				(original, parameters) => {
					var lightness = original.R + original.G + original.B;
					lightness /= 3;
					return new Pixel(lightness, lightness, lightness);
				}
				));
			window.AddFilter (new PixelFilter<LightningParameters>(
				"����������/����������",
				 (original, parameters) => original * parameters.Coeficient
				));
			window.AddFilter(new TransformFilter<EmptyParameters>(
				"�������� �� �����������",
				 (size,param) => size,
				 (size, point, param) => new Point(size.Width-point.X-1,point.Y)
				));
			window.AddFilter(new TransformFilter<EmptyParameters>(
				"��������� ������ �.�.",
				 (size, param) => new Size(size.Height,size.Width),
				 (size, point, param) => new Point(point.Y, point.X)
				));

			Func<Size, RotationParameters, Size> sizeRotator =
			  (size, parameters) =>
			  {
				  var angle = Math.PI * parameters.Angle / 180;
				  return new Size(
					  (int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
					  (int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle))));
			  };

			Func<Size, Point, RotationParameters, Point?> pointRotator = (oldSize, point, parameters) =>
			{
				var newSize = sizeRotator(oldSize, parameters);
				var angle = Math.PI * parameters.Angle / 180;
				point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);
				var x = oldSize.Width / 2 + (int)(point.X * Math.Cos(angle) + point.Y * Math.Sin(angle));
				var y = oldSize.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));
				if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height) return null;
				return new Point(x, y);
			};

			window.AddFilter(new TransformFilter<RotationParameters>(
			 "��������� �������� ", sizeRotator, pointRotator
				));
			Application.Run(window);
		}
	}
}
