using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace CaptureScreenWithMouse
{
    public static class ScreenCapturer
    {
        public static Bitmap Capture()
        {
            var top = Screen.AllScreens.Min(scr => scr.Bounds.Top);
            var left = Screen.AllScreens.Min(scr => scr.Bounds.Left);
            var bottom = Screen.AllScreens.Max(scr => scr.Bounds.Bottom);
            var right = Screen.AllScreens.Max(scr => scr.Bounds.Right);
            var size = new Size(right - left, bottom - top);

            var bitmap = new Bitmap(size.Width, size.Height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(left, top, 0, 0, size);

                var cursorInfo = CursorInfo.Create();
                if (!GetCursorInfo(out cursorInfo))
                {
                    return bitmap;
                }

                var cursorState = cursorInfo.cursorState;
                if (cursorState != CursorState.Showing)
                {
                    return bitmap;
                }

                using (var cursorIconInfo = IconInfo.FromHIcon(cursorInfo.hCursor))
                {
                    graphics.DrawIcon(
                        Icon.FromHandle(cursorInfo.hCursor),
                        cursorInfo.ptScreenPos.X - cursorIconInfo.xHotspot - left,
                        cursorInfo.ptScreenPos.Y - cursorIconInfo.yHotspot - top
                        );
                }

                return bitmap;
            }
        }

        #region Interop

        [StructLayout(LayoutKind.Sequential)]
        struct Point
        {
            public Int32 X;
            public Int32 Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct CursorInfo
        {
            /// <summary>
            /// Specifies the size, in bytes, of the structure.
            /// The caller must set this to Marshal.SizeOf(typeof(CursorInfo)).
            /// </summary>
            public Int32 cbSize;
            public CursorState cursorState;
            public IntPtr hCursor;          // Handle to the cursor. 
            public Point ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor. 

            public static CursorInfo Create()
            {
                var cursorInfo = new CursorInfo();
                cursorInfo.cbSize = Marshal.SizeOf(typeof(CursorInfo));
                return cursorInfo;
            }
        }

        enum CursorState
        {
            Hidden,
            Showing,
            Suppressed
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CursorInfo cursorInfo);

        class IconInfo : IDisposable
        {
            private IconInfo(_IconInfo nativeIconInfo)
            {
                xHotspot = nativeIconInfo.xHotspot;
                yHotspot = nativeIconInfo.yHotspot;
                IsCursor = !nativeIconInfo.fIcon;
                if (nativeIconInfo.hbmColor != IntPtr.Zero)
                {
                    Color = Bitmap.FromHbitmap(nativeIconInfo.hbmColor);
                }
                if (nativeIconInfo.hbmMask != IntPtr.Zero)
                {
                    Mask = Bitmap.FromHbitmap(nativeIconInfo.hbmMask);
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            struct _IconInfo
            {
                /// <summary>
                /// Specifies whether this structure defines an icon or a cursor.
                /// true = icon, false = cursor
                /// </summary>
                public bool fIcon;
                public Int32 xHotspot;
                public Int32 yHotspot;
                public IntPtr hbmMask;     // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon, 
                // this bitmask is formatted so that the upper half is the icon AND bitmask and the lower half is 
                // the icon XOR bitmask. Under this condition, the height should be an even multiple of two. If 
                // this structure defines a color icon, this mask only defines the AND bitmask of the icon. 
                public IntPtr hbmColor;    // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this 
                // structure defines a black and white icon. The AND bitmask of hbmMask is applied with the SRCAND 
                // flag to the destination; subsequently, the color bitmap is applied (using XOR) to the 
                // destination by using the SRCINVERT flag. 
            }

            public int xHotspot { get; private set; }
            public int yHotspot { get; private set; }
            public bool IsCursor { get; private set; }
            public Bitmap Color { get; private set; }
            public Bitmap Mask { get; private set; }

            [DllImport("user32.dll", SetLastError = true)]
            static extern bool GetIconInfo(IntPtr hIcon, out _IconInfo iconInfo);

            public static IconInfo FromHIcon(IntPtr hIcon)
            {
                _IconInfo nativeIconInfo;
                if (!GetIconInfo(hIcon, out nativeIconInfo))
                {
                    throw new Win32Exception();
                }
                return new IconInfo(nativeIconInfo);
            }

            bool isDisposed = false;
            public void Dispose()
            {
                if (isDisposed)
                {
                    return;
                }

                if (Mask != null)
                {
                    Mask.Dispose();
                }
                if (Color != null)
                {
                    Color.Dispose();
                }

                isDisposed = true;
            }
        }

        #endregion
    }
}
