﻿using System.Drawing;

namespace NumberGenerator
{
   public static class NumberDecalGenerator
   {
      private const int _decalSize = 256;

      public static Image Draw( int number, int max )
      {
         var bitmap = new Bitmap( _decalSize, _decalSize );

         using ( Graphics g = Graphics.FromImage( bitmap ) )
         {
         }

         return bitmap;
      }
   }
}
