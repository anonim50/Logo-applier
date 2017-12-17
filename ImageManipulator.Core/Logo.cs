using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using Image = System.Drawing.Image;
using Parallel = System.Threading.Tasks.Parallel;

namespace ImageManipulator.Core
{
    public class Logo
    {
        private readonly Bitmap _logo;

        public Logo(Bitmap logo)
        {
            _logo = logo;
        }

        public Bitmap ApplyTo(Bitmap image)
        {
            Blob[] blobs;
            var blobCounter = BlobsForImage(image, out blobs);
            var shapeChecker = new SimpleShapeChecker();

            using (var graphics = Graphics.FromImage(image))
            {
                for (int i = 0; i < blobs.Length; i++)
                {
                    List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                    List<IntPoint> cornerPoints;

                    if (IsValid(image, shapeChecker, edgePoints, out cornerPoints))
                    {
                        graphics.DrawImage(_logo, cornerPoints[0].X, cornerPoints[0].Y);
                    }
                }
            }
            return image;
        }

        private BlobCounter BlobsForImage(Bitmap image, out Blob[] blobs)
        {
            var blobCounter = new BlobCounter
            {
                FilterBlobs = true,
                MinHeight = 5,
                MinWidth = 5
            };

            blobCounter.ProcessImage(image);
            blobs = blobCounter.GetObjectsInformation();
            return blobCounter;
        }

        private bool IsValid(Bitmap image, SimpleShapeChecker shapeChecker, List<IntPoint> blobEdgePoints,
            out List<IntPoint> cornerPoints)
        {
            if (!shapeChecker.IsQuadrilateral(blobEdgePoints, out cornerPoints))
                return false;
            if (shapeChecker.CheckPolygonSubType(cornerPoints) != PolygonSubType.Rectangle)
                return false;
            if (!IsSameSizeAsLogo(cornerPoints))
                return false;
            if (!IsWhiteRectangle(image, cornerPoints))
                return false;

            return true;
        }

        private bool IsSameSizeAsLogo(IReadOnlyList<IntPoint> rectangleCoords)
        {
            if (rectangleCoords[1].X - rectangleCoords[0].X != _logo.Width - 1)
                return false;
            if (rectangleCoords[2].X - rectangleCoords[3].X != _logo.Width - 1)
                return false;
            if (rectangleCoords[3].Y - rectangleCoords[0].Y != _logo.Height - 1)
                return false;
            if (rectangleCoords[2].Y - rectangleCoords[1].Y != _logo.Height - 1)
                return false;

            return true;
        }

        private bool IsWhiteRectangle(Bitmap image, IReadOnlyList<IntPoint> rectanglePoints)
        {
            BitmapData data =
                image.LockBits(
                    new Rectangle(rectanglePoints[0].X, rectanglePoints[0].Y,
                        rectanglePoints[1].X - rectanglePoints[0].X,
                        rectanglePoints[3].Y - rectanglePoints[0].Y),
                    ImageLockMode.ReadWrite, image.PixelFormat);

            var bytesPerPixel = Image.GetPixelFormatSize(image.PixelFormat) / 8;
            var isWhiteRectangle = true;

            unsafe
            {
                //Nr. de pixeli pe linie * bytesPerPixel
                int width = (data.Width ) * bytesPerPixel;
                byte* firstPixel = (byte*) data.Scan0;
                Parallel.For(0, data.Height + 1, (y, state) =>
                {
                    byte* currentLine = firstPixel + y * data.Stride;
                    for (int x = 0; x < width; x += bytesPerPixel)
                    {
                        currentLine[x] = 0;
                        currentLine[x + 1] = 0;
                        currentLine[x + 2] = 255;
                        if (currentLine[x] != 255 && currentLine[x + 1] != 255 && currentLine[x + 2] != 255)
                        {
                            isWhiteRectangle = false;
                            state.Break();
                        }
                    }
                });
            }
            image.UnlockBits(data);
            return isWhiteRectangle;
        }
    }
}