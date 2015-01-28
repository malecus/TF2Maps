﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;

namespace DecalGenerator
{
   public static class DecalGenerator
   {
      public static Image Create( int number )
      {
         const int width = 256;
         const int height = 256;
         const int borderThickness = 12;
         const float fontSize = 64;
         const float gap = 4;

         var bitmap = new Bitmap( width, height );
         string text = number.ToString( CultureInfo.InvariantCulture );

         using ( Graphics g = Graphics.FromImage( bitmap ) )
         {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using ( var transparentBrush = new SolidBrush( Color.FromArgb( 0, 0, 0, 0 ) ) )
            {
               // Fill the entire image with transparency first
               // Not sure if necessary... playing it safe since I don't feel like testing it :D
               g.FillRectangle( transparentBrush, 0, 0, width, height );
            }

            // Draw the number using Segoe UI (I like the font)
            // Use a half-opaque black brush to create a see-through dark color

            using ( var blackBrush = new SolidBrush( Color.FromArgb( 128, 0, 0, 0 ) ) )
            {
               using ( var font = new Font( "Segoe UI", fontSize ) )
               {
                  var textSize = g.MeasureString( text, font );

                  float x = (width - textSize.Width) / 2;
                  float y = (height - textSize.Height) / 2;

                  g.DrawString( text, font, blackBrush, x, y );
               }
            }
         }

         return bitmap;
      }
   }
}
