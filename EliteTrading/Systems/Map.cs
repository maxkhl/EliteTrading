using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing.Imaging;

namespace EliteTrading.Systems
{
    public partial class Map : UserControl
    {
        Image img;
        Graphics graphics;
        Timer timer = new Timer();

        public int VisibleSystems { get; private set; }

        public struct SystemDrawOptions
        {
            public Color Color;
            public string Text;
            public int Size;
            public bool ShowName;
        }
        public Dictionary<Data.System, SystemDrawOptions> Style = new Dictionary<Data.System, SystemDrawOptions>();

        public List<Data.Route> Routes = new List<Data.Route>();

        Data.Vector3 CameraPosition = new Data.Vector3(626, -118, 1741);
        double CameraZoom = (double)Screen.PrimaryScreen.Bounds.Width / 1.5;
        Image StarImage;
        Brush StarBrush;

        public Map()
        {
            InitializeComponent();
            StarImage = global::EliteTrading.Properties.Resources.Star;
            StarBrush = new Pen(Color.White, 1).Brush;
        }

        public void Refresh()
        {
            timer_Tick(null, null);
        }

        public Data.System Target
        {
            get
            {
                return _Target;
            }
            set
            {
                _Target = value;
                if(_Target != null) WorldOffset = _Target.Coordinates;
                timer_Tick(null, null);
            }
        }
        private Data.System _Target = null;

        public void InitializeMap()
        {
            img = new Bitmap(pB_Map.Width, pB_Map.Height);
            pB_Map.Image = img;
            graphics = System.Drawing.Graphics.FromImage(img);
            timer.Interval = 15;
            timer.Tick += timer_Tick;

            WorldOffset = UserData.System.Coordinates;
            CameraPosition = /*UserData.System.Coordinates + */new Data.Vector3(0, 0, 40);

            //Position = new Vector(UserData.System.Coordinates.X - (img.Width / 2), UserData.System.Coordinates.Z - (img.Height / 2));
            //Style.Add(UserData.System, new SystemDrawOptions() { Text = "You are Here", Color = Color.Red, Size = 10, ShowName = true });

            /*var testroute = new Data.Route();
            testroute.Add(UserData.System);
            testroute.Add(GlobalData.Systems[0]);
            Routes.Add(testroute);*/

            timer_Tick(null, null);
            pB_Map.MouseWheel += pB_Map_MouseWheel;

            CameraZoom = (double)pB_Map.Width / 1.5;

            pB_Map.Focus();

            OldMousePosition = pB_Map.PointToClient(Control.MousePosition);
        }

        bool RotateMode = false;
        double WorldRotationY = 0;
        Data.Vector3 WorldOffset = new Data.Vector3();
        System.Drawing.Point OldMousePosition;
        bool OldMouseInitial = true;
        void timer_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            foreach(var route in Routes)
            {
                foreach(var step in route.Steps)
                {
                    if(!Style.ContainsKey(step.System))
                    {
                        Style.Add(step.System, new SystemDrawOptions() { ShowName = true, Color = Color.BlueViolet, Size = 10 });
                    }
                }
            }

            var MousePosition = pB_Map.PointToClient(Control.MousePosition);
            if(OldMouseInitial)
            {
                OldMousePosition = MousePosition;
                OldMouseInitial = false;
            }
            var Movement = new System.Drawing.Point(OldMousePosition.X - MousePosition.X, OldMousePosition.Y - MousePosition.Y);
            //Position += new Vector(Movement.X, Movement.Y);

            if (RotateMode)
            {
                WorldRotationY += Movement.X;
                CameraPosition.Y += Movement.Y / 15 * (CameraPosition.Z * 0.1);
            }
            else if(Control.MouseButtons == System.Windows.Forms.MouseButtons.Right)
                CameraPosition += new Data.Vector3(-Movement.X, 0, Movement.Y);
            OldMousePosition = MousePosition;



            var ScreenRect = new System.Drawing.Rectangle(
                new System.Drawing.Point(0, 0),
                new System.Drawing.Size((int)(pB_Map.Width), (int)(pB_Map.Height)));


            int VisibleRectangles = 0;

            VisibleRectangles += DrawSystems(GlobalData.Systems, ScreenRect);

            DrawRoutes(ScreenRect);

            pB_Map.Image = img;
            VisibleSystems = VisibleRectangles;
            if (OnVisibleSystemsChanged != null)
                OnVisibleSystemsChanged(VisibleSystems);
        }

        private void DrawRoutes(Rectangle ScreenRectangle)
        {
            int DrawSize = 1;
            foreach (var route in Routes)
            {
                for (int i = 0; i < route.Steps.Count; i++)
                {
                    if (i + 1 < route.Steps.Count)
                    {
                        var DrawRect = GetSystemScreenRect(route.Steps[i].System, ScreenRectangle, DrawSize);
                        var CheckRect = new Rectangle(new System.Drawing.Point(ScreenRectangle.X - DrawSize, ScreenRectangle.Y - DrawSize), new System.Drawing.Size(ScreenRectangle.Width + DrawSize * 2, ScreenRectangle.Height + DrawSize * 2));
                        if (DrawRect.IntersectsWith(CheckRect))
                        {
                            var targetDrawRect = GetSystemScreenRect(route.Steps[i + 1].System, ScreenRectangle, DrawSize);

                            var SourcePos1 = new System.Drawing.Point(DrawRect.X + DrawSize / 2, DrawRect.Y + DrawSize / 2);
                            var SourcePos2 = new System.Drawing.Point((int)(targetDrawRect.X + DrawSize / 2), (int)(targetDrawRect.Y + DrawSize / 2));
                            graphics.DrawLine(new Pen(Color.Lime, 1), SourcePos1, SourcePos2);
                        }
                    }
                }
            }
        }

        double ViewDistance = 0.9;
        private int DrawSystems(List<Data.System> Systems, Rectangle ScreenRectangle)
        {
            var DefaultOption = new SystemDrawOptions();
            int DrawnSystems = 0;
            List<Data.System> SystemsWithText = new List<Data.System>();

            var bitmap = new Bitmap(img);
            var bitmapData = bitmap.LockBits(
                new Rectangle(System.Drawing.Point.Empty, img.Size),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            var bitsPerPixel = (((int)bitmapData.PixelFormat >> 8) & 0xFF) / 8;
            int bWidth = bitmap.Width,
                bHeight = bitmap.Height;

            unsafe
            {
                var pixelDataPointer = (byte*)bitmapData.Scan0;

                foreach (var system in Systems)
                {
                    var Options = DefaultOption;
                    if (Style.ContainsKey(system))
                        Options = Style[system];

                    /*int Value = ((int)(((WorldOffset - system.Coordinates).Length * ViewDistance) * -2) + 255).Clamp(50, 255);
                    if (Value == 0)
                        return false;

                    var DrawSize = (int)((double)Value / 255 * 20);
                    if (DrawSize < 10)
                        DrawSize = 10;*/
                    int DrawSize = 2;
                    if (Options.Size > 0)
                        DrawSize = Options.Size;



                    var DrawRect = GetSystemScreenRect(system, ScreenRectangle, DrawSize);
                    var CheckRect = new Rectangle(new System.Drawing.Point(ScreenRectangle.X - DrawSize, ScreenRectangle.Y - DrawSize), new System.Drawing.Size(ScreenRectangle.Width + DrawSize * 2, ScreenRectangle.Height + DrawSize * 2));
                    if (DrawRect.IntersectsWith(CheckRect))
                    {
                        // (DrawRect.X < 0 || DrawRect.Y < 0 || DrawRect.Width < 0 || DrawRect.Height < 0) return false;



                        //var sColor = Color.FromArgb(255, 255, 255, 255);
                        //if (Options.Color.A != 0)
                        //    sColor = Options.Color;

                        if (DrawRect.X > 0 && DrawRect.X < bWidth &&
                            DrawRect.Y > 0 && DrawRect.Y < bHeight)
                        {

                            var target = bitmapData.Stride * DrawRect.Y + 0 + DrawRect.X * bitsPerPixel;
                            pixelDataPointer[target] = (byte)(255 + pixelDataPointer[target]); //Blue
                            pixelDataPointer[target + 1] = (byte)(255 + pixelDataPointer[target + 1]); //Green
                            pixelDataPointer[target + 2] = (byte)(255 + pixelDataPointer[target + 2]); //Red

                        }
                        //System.Drawing.
                        //graphics.DrawImage(StarImage, DrawRect, );
                        //graphics.FillRectangle(StarBrush, DrawRect);
                        /*for(int x = -(DrawRect.Width / 2); x < DrawRect.Width / 2; x++)
                        {
                            for (int y = -(DrawRect.Height / 2); y < DrawRect.Height / 2; y++)
                            {
                                int tX = DrawRect.X + x,
                                    tY = DrawRect.Y + y;

                                if (tX > 0 && tX < bWidth &&
                                    tY > 0 && tY < bHeight)
                                {
                                    var target = bitmapData.Stride * tY + 0 + tX * bitsPerPixel;
                                    pixelDataPointer[target] = 255; //Blue
                                    pixelDataPointer[target + 1] = 255; //Green
                                    pixelDataPointer[target + 2] = 255; //Red
                                }
                            }
                        }*/
                        //pixelDataPointer[target + 3] = 0; // Alpha
                        //img.
                        if (Options.ShowName || Options.Text != null)
                            SystemsWithText.Add(system);

                        DrawnSystems++;
                    }
                }


                const int BlurSize = 3;
                const int BlurHalf = 1;
                double[,] blurMatrix = new double[BlurSize, BlurSize]
                {
                    {0, 0.5, 0},
                    {0.5, 1, 0.5},
                    {0, 0.5, 0}
                };
                // Blur
                /*for (int x = 0; x < bWidth; x++)
                {
                    for (int y = 0; y < bHeight; y++)
                    {
                        for(int sX = 0; sX < BlurSize; sX++)
                        {
                            for(int sY = 0; sY < BlurSize; sY++)
                            {
                                int tX = x + (sX - BlurHalf),
                                    tY = y + (sY - BlurHalf);

                                if (tX < 0 || tX >= bWidth ||
                                    tY < 0 || tY >= bHeight)
                                    continue;

                                var target = bitmapData.Stride * tY + 0 + tX * bitsPerPixel;
                                var value = blurMatrix[sX, sY] * 255;
                                pixelDataPointer[target] = (byte)(value + pixelDataPointer[target]); //Blue
                                pixelDataPointer[target + 1] = (byte)(value + pixelDataPointer[target + 1]); //Green
                                pixelDataPointer[target + 2] = (byte)(value + pixelDataPointer[target + 2]); //Red
                            }
                        }
                    }
                }*/

    }
    bitmap.UnlockBits(bitmapData);
    img = bitmap;
    graphics = Graphics.FromImage(img);
    foreach (var system in SystemsWithText)
    {
        var Options = DefaultOption;
        if (Style.ContainsKey(system))
            Options = Style[system];

        /*int Value = ((int)(((WorldOffset - system.Coordinates).Length * ViewDistance) * -2) + 255).Clamp(50, 255);
        if (Value == 0)
            return false;

        var DrawSize = (int)((double)Value / 255 * 20);
        if (DrawSize < 10)
            DrawSize = 10;*/
                int DrawSize = 1;
                if (Options.Size > 0)
                    DrawSize = Options.Size;



                var DrawRect = GetSystemScreenRect(system, ScreenRectangle, DrawSize);
                var CheckRect = new Rectangle(new System.Drawing.Point(ScreenRectangle.X - DrawSize, ScreenRectangle.Y - DrawSize), new System.Drawing.Size(ScreenRectangle.Width + DrawSize * 2, ScreenRectangle.Height + DrawSize * 2));
                if (DrawRect.IntersectsWith(CheckRect))
                {

                    var Pos = DrawRect.Location + DrawRect.Size;
                    if (Options.ShowName)
                    {
                        graphics.DrawString(system.name, System.Drawing.SystemFonts.DefaultFont, StarBrush, Pos);
                        Pos.Y += 15;
                    }

                    if (Options.Text != null)
                    {
                        graphics.DrawString(Options.Text, System.Drawing.SystemFonts.DefaultFont, StarBrush, Pos);
                    }
                }
            }


            return DrawnSystems;
        }

        public delegate void OnVisibleSystemsChangedHandler(int Amount);
        public event OnVisibleSystemsChangedHandler OnVisibleSystemsChanged;

        private Rectangle GetSystemScreenRect(Data.System system, Rectangle ScreenRectangle, int DrawSize)
        {
            var WorldPosition = (system.Coordinates - WorldOffset).RotateY(WorldRotationY);
            var ScreenPos = Translate(WorldPosition) +new Vector((ScreenRectangle.Width), (ScreenRectangle.Height)); //new Vector(system.Coordinates.Z, system.Coordinates.X) - Position;

            return new Rectangle((int)((ScreenPos.X - ScreenRectangle.Width / 2)), (int)((ScreenPos.Y - ScreenRectangle.Height / 2)), DrawSize, DrawSize);
        }

        private Vector Translate(Data.Vector3 Point)
        {
            Vector returnVec = new Vector();
            if (Point.Z - CameraPosition.Z >= 0)
            {
                returnVec.X = (int)((double)-(Point.X - CameraPosition.X) / (-0.1f) * CameraZoom);
                returnVec.Y = (int)((double)(Point.Y - CameraPosition.Y) / (-0.1f) * CameraZoom);
            }
            else
            {
                //tmpOrigin.X = (int)((double)(cubeOrigin.X - CameraPosition.X) / (double)(cubeOrigin.Z - CameraPosition.Z) * CameraZoom);
                //tmpOrigin.Y = (int)((double)-(cubeOrigin.Y - CameraPosition.Y) / (double)(cubeOrigin.Z - CameraPosition.Z) * CameraZoom);

                returnVec.X = (float)((Point.X - CameraPosition.X) / (Point.Z - CameraPosition.Z) * CameraZoom);
                returnVec.Y = (float)(-(Point.Y - CameraPosition.Y) / (Point.Z - CameraPosition.Z) * CameraZoom);

                //returnVec.X = (int)point3D[i].X;
                //returnVec.Y = (int)point3D[i].Y;
            }
            return returnVec;
        }

        DateTime LastMouseDown;
        private void pB_Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                RotateMode = true;
            else
                RotateMode = false;

            OldMousePosition = pB_Map.PointToClient(Control.MousePosition);
            timer.Start();
            LastMouseDown = DateTime.Now;
        }

        private void pB_Map_MouseUp(object sender, MouseEventArgs e)
        {
            if (DateTime.Now - LastMouseDown < TimeSpan.FromMilliseconds(250))
                Click();

            timer.Stop();
            RotateMode = false;
        }

        private void Click()
        {
            var ScreenRectangle = new System.Drawing.Rectangle(
                new System.Drawing.Point(0, 0),
                new System.Drawing.Size((int)(pB_Map.Width), (int)(pB_Map.Height)));

            var MousePosition = pB_Map.PointToClient(Control.MousePosition);

            foreach (var system in GlobalData.Systems)
            {
                var Options = new SystemDrawOptions();
                if (Style.ContainsKey(system))
                    Options = Style[system];


                int Value = ((int)(((WorldOffset - system.Coordinates).Length * ViewDistance) * -1) + 255).Clamp(0, 255);

                var WorldPosition = (system.Coordinates - WorldOffset).RotateY(WorldRotationY);

                var DrawSize = (int)(Value / 50);

                if (Options.Size > 0)
                    DrawSize = Options.Size;

                var ScreenPos = Translate(WorldPosition) + new Vector((ScreenRectangle.Width), (ScreenRectangle.Height)); //new Vector(system.Coordinates.Z, system.Coordinates.X) - Position;

                var DrawRect = new Rectangle((int)((ScreenPos.X - ScreenRectangle.Width / 2)), (int)((ScreenPos.Y - ScreenRectangle.Height / 2)), DrawSize, DrawSize);

                if(DrawRect.Contains(MousePosition))
                {
                    WorldOffset = system.Coordinates;
                    if(!Style.ContainsKey(system)) 
                        Style.Add(system, new SystemDrawOptions() { ShowName = true, Color = Color.Blue });
                    CameraPosition = /*UserData.System.Coordinates + */new Data.Vector3(0, 0, 40);
                }
            }
            timer_Tick(null, null);
        }

        private void pB_Map_MouseLeave(object sender, EventArgs e)
        {
            timer.Stop();
            RotateMode = false;
        }

        private void pB_Map_SizeChanged(object sender, EventArgs e)
        {
            img = new Bitmap(pB_Map.Width, pB_Map.Height);
            pB_Map.Image = img;
            graphics = System.Drawing.Graphics.FromImage(img);
            //CameraZoom = (double)pB_Map.Width / 1.5;

            timer_Tick(null, null);
        }


        void pB_Map_MouseWheel(object sender, MouseEventArgs e)
        {
            CameraPosition.Z -= e.Delta / 15 * (CameraPosition.Z * 0.02);

            if (CameraPosition.Z <= 0)
                CameraPosition.Z = 1;
            timer_Tick(null, null);
        }

        private void pB_Map_MouseHover(object sender, EventArgs e)
        {
            pB_Map.Focus();
        }
    }
    public static class IntExtension
    {
        public static int Clamp(this int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            else
                return val;
        }
    }
}
