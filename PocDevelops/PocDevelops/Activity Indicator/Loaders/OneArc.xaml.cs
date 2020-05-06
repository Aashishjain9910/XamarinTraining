using System;
using System.Collections.Generic;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops.Loaders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneArc : ContentView
    {

        SKCanvasView canvas;
        Stopwatch stopwatch = new Stopwatch();

        float OvalStartAngle = 90;
        float OvalSweepAngle = 50;

        SKPaint firstArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.FromHsl(50, 125, 200, 255),
            StrokeWidth = 10,
            IsAntialias = true

        };

        SKPaint secondArcPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,

            Color = SKColor.FromHsl(178, 70, 31, 255),
            StrokeWidth = 15,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round

        };

        public OneArc()
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
            OvalStartAngle += 18;
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
            right = left = (info.Width - 300) / 2;
            top = bottom = (info.Height - 300) / 2;

            SKRect rect = new SKRect(left, top, info.Width - right, info.Height - bottom);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, firstArcPaint);
            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, OvalStartAngle, OvalSweepAngle);
                canvas.DrawPath(path, secondArcPaint);
            }
        }
    }
}