using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace migControls
{
   public  class globalMig
    {


[DllImport("gdi32.dll")]
private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static Color stdBlue = Color.FromArgb(255, 0, 85, 169);

        public static Brush stdWhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

        public static Brush stdBlueBrush = new System.Drawing.SolidBrush(stdBlue);
        public static Brush stdBlackBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 0, 0, 0));
        public static Brush stdOrangeBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        public static Pen stdWhitePen = new Pen(System.Drawing.Color.White);
        public static PrivateFontCollection fonts;

        public static Font topaz_std12;
        public static Font topaz_std14;
        public static Font topaz_std10;
        public static IntPtr fontBuffer;

        public static void LoadFont()
        {

            if (fonts == null)
            {

                fonts = new PrivateFontCollection();
            // Use this if you can not find your resource System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            string resource = "AmigaControls.Amiga Topaz.ttf";
            // receive resource stream
            Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);

            //create an unsafe memory block for the data
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            //create a buffer to read in to
            Byte[] fontData = new Byte[fontStream.Length];
            //fetch the font program from the resource
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            //copy the bytes to the unsafe memory block
            Marshal.Copy(fontData, 0, data, (int)fontStream.Length);

            // We HAVE to do this to register the font to the system (Weird .NET bug !)
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

                //pass the font to the font collection
                fonts.AddMemoryFont(data, (int)fontStream.Length);
            //close the resource stream
            fontStream.Close();
            //free the unsafe memory
            Marshal.FreeCoTaskMem(data);

                topaz_std14 = new Font(globalMig.fonts.Families[0], 14);
                topaz_std12 = new Font(globalMig.fonts.Families[0], 12);

                topaz_std10 = new Font(globalMig.fonts.Families[0], 10);
            }

        }
       
        

     
    }
}
