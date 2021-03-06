﻿using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IRNN.WPF.Utils {

    internal class ImageHelper {

        //TODO: passare path e salvare immagine
        internal static BitmapImage InkCanvasToBitmap(InkCanvas canvas) {
            //RENDERING
            int width = (int)canvas.ActualWidth;
            int height = (int)canvas.ActualHeight;
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
            renderBitmap.Render(canvas);

            //ENCODING
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            //SAVING TO BITMAP OBJECT
            BitmapImage ret;
            FileStream fs = new FileStream("tmp.bmp", FileMode.Create);
            encoder.Save(fs);
            //MemoryStream ms = new MemoryStream();
            //fs.CopyTo(ms);
            //ms.Position = 0;
            //ret = new BitmapImage();
            //ret.BeginInit();
            //ret.StreamSource = ms;
            //ret.EndInit();
            fs.Close();
            //BitmapImage bmp = new BitmapImage(new Uri("tmp.bmp",UriKind.Relative));

            /* non va un bidone di nulla bisoagna ridimensionare l'immagine
             * EDIT: lascio che salva solo il bmp almeno è meglio di nulla
            */

            //ret = new TransformedBitmap(bmp, new ScaleTransform(130/ width, 130 / height));
            //ret.BeginInit();
            //fs.Position = 0;
            //fs.CopyTo(ret.StreamSource);
            //ret.DecodePixelWidth = width;
            //ret.DecodePixelHeight = height;
            //ret.EndInit();
            //fs.Close();
            return ret = new BitmapImage(new Uri("tmp.bmp", UriKind.Relative));
        }

        internal static Color[,] BitmapToColorMatrix(TransformedBitmap image) {
            throw new NotImplementedException();
        }

        internal static PBMImage ColorMatrixToPBMImage(Color[,] image) {
            throw new NotImplementedException();
        }
    }
}