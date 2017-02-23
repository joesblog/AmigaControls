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

        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        [DllImport("user32.dll", EntryPoint = "CreateIconIndirect")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);



        const int
            IDC_ARROW = 32512,
            IDC_IBEAM = 32513,
            IDC_WAIT = 32514,
            IDC_CROSS = 32515,
            IDC_UPARROW = 32516,
            IDC_SIZE = 32640,
            IDC_ICON = 32641,
            IDC_SIZENWSE = 32642,
            IDC_SIZENESW = 32643,
            IDC_SIZEWE = 32644,
            IDC_SIZENS = 32645,
            IDC_SIZEALL = 32646,
            IDC_NO = 32648,
            IDC_HAND = 32649,
            IDC_APPSTARTING = 32650,
            IDC_HELP = 32651;
        enum IDC_STANDARD_CURSORS
        {
            IDC_ARROW = 32512,
            IDC_IBEAM = 32513,
            IDC_WAIT = 32514,
            IDC_CROSS = 32515,
            IDC_UPARROW = 32516,
            IDC_SIZE = 32640,
            IDC_ICON = 32641,
            IDC_SIZENWSE = 32642,
            IDC_SIZENESW = 32643,
            IDC_SIZEWE = 32644,
            IDC_SIZENS = 32645,
            IDC_SIZEALL = 32646,
            IDC_NO = 32648,
            IDC_HAND = 32649,
            IDC_APPSTARTING = 32650,
            IDC_HELP = 32651
        }


        public static Color stdColorBlue = Color.FromArgb(255, 0, 85, 169);
        public static Color stdColorWhite = Color.FromArgb(255, 255, 255, 255);


        public static Brush stdWhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        public static Cursor amiCur = getamiCur();
        public static Brush stdBlueBrush = new System.Drawing.SolidBrush(stdColorBlue);
        public static Brush stdBlackBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 0, 0, 0));
        public static Brush stdOrangeBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        public static Pen stdWhitePen = new Pen(System.Drawing.Color.White);
        public static Pen thickWhitePen = new Pen(System.Drawing.Color.White,2);
        public static Pen thickOrangePen = new Pen(System.Drawing.Color.Orange, 3);


        public static Pen stdBluePen = new Pen(stdColorBlue);

        public static PrivateFontCollection fonts;

        public static Font topaz_std12;
        public static Font topaz_std12_italic;

        public static Font topaz_std14;
        public static Font topaz_std14_italic;

        public static Font topaz_std10;
        public static Font topaz_std10_italic;

        public static IntPtr fontBuffer;
        internal static Color stdColorOrange = Color.Orange;
        internal static Pen stdBlackPen = new Pen(stdBlackBrush);

        public static bool loadBoringWindows { get; set; }

        public static void LoadFont()
        {



            if (loadBoringWindows)
            { return; }
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

                topaz_std14_italic = new Font(globalMig.fonts.Families[0], 14,FontStyle.Italic);
                topaz_std12_italic = new Font(globalMig.fonts.Families[0], 12,FontStyle.Italic);

                topaz_std10_italic = new Font(globalMig.fonts.Families[0], 10, FontStyle.Italic);
            }

        }

        private static Cursor getamiCur() {
            Cursor r = null;

            if (amiCur == null)
            {
                string resource = "AmigaControls.amigacur.png";
                Stream curStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);

                using (Bitmap img = (Bitmap)Image.FromStream(curStream, true))
                {
                    IntPtr ptr = img.GetHicon();
                    IconInfo tmp = new IconInfo();
                    GetIconInfo(ptr, ref tmp);
                    tmp.xHotspot = 2;
                    tmp.yHotspot = 2;
                    tmp.fIcon = false;
                    ptr = CreateIconIndirect(ref tmp);
                    r=  new Cursor(ptr);
                }


                //img.Dispose();
            }

            return r;
        }

        public struct IconInfo { public bool fIcon; public int xHotspot; public int yHotspot; public IntPtr hbmMask; public IntPtr hbmColor; }

        public static int getTextWidth(string text) {
            return TextRenderer.MeasureText(text, globalMig.topaz_std10).Width;
        }

        public static int getTextHeight(string text)
        {
            return TextRenderer.MeasureText(text, globalMig.topaz_std10).Height;
        }


        public enum FormStyle
        {
            wbmono = 0,
            wb1 = 1,
            wb2 = 2,
            wb3 = 3
        }
    }
}
