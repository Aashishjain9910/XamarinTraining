using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops.Loaders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoSepareteArcs : ContentView
    {
        SKCanvasView canvas;
        Stopwatch stopwatch = new Stopwatch();

        float OvalStartAngle = 90; 
        float OvalSweepAngle = 150; 
        float InnerOvalStartAngle = 90; 
        float InnerOvalSweepAngle = 150;
        
        SKPaint firstArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.FromHsl(216, 92,175,255),
            StrokeWidth = 15,
            IsAntialias = true

        };
        SKPaint secondArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.FromHsl(216, 69, 78),
            StrokeWidth = 15,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round

        };



        public TwoSepareteArcs()
        {
            InitializeComponent();
            canvas = new SKCanvasView();
            canvas.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvas;
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(16), OnTimerClik);
        }

        public bool OnTimerClik()
        {
            OvalStartAngle += 5;
            InnerOvalStartAngle -= 5;
            canvas.InvalidateSurface();
            return true;
        }


        public void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            float left, right;
            float top, bottom;
            right = left = (info.Width - 200) / 2;
            top = bottom = (info.Height - 200) / 2;

            
            SKRect rect = new SKRect(left, top, info.Width - right, info.Height - bottom);
            SKRect innerRect = new SKRect(left + 30, top + 30, (info.Width - right) - 30, (info.Height - bottom) - 30);
            //canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, firstArcPaint);
            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, OvalStartAngle, OvalSweepAngle);
                canvas.DrawPath(path, firstArcPaint);
            }

            using (SKPath path = new SKPath())
            {
                path.AddArc(innerRect, InnerOvalStartAngle, InnerOvalSweepAngle);
                canvas.DrawPath(path, secondArcPaint);
            }
        }
    }
}