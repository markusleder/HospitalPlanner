using System;
using Blazor.Extensions;

namespace HospitalPlanner.Client.Services
{
    /// <summary>
    /// Draws the plan in a Canvas (instead of table, grid, spreadsheet, ...).
    /// 
    /// Canvas functionality (HTML) https://developer.mozilla.org/de/docs/Web/API/CanvasRenderingContext2D 
    /// Canvas functionality (Blazor) https://github.com/BlazorExtensions/Canvas/blob/master/src/Blazor.Extensions.Canvas/Canvas2dContext.cs
    /// 
    /// </summary>
    public class PlanCanvasDrawing
    {
        private readonly Canvas2dContext _canvasContext;
        private readonly int _width;   // canvas width
        private readonly int _height;  // canvas height
        private const int Cw = 20;     // cell width
        private const int Ch = 10;     // cell height

        public PlanCanvasDrawing(Canvas2dContext canvasContext, int width, int height)
        {
            _canvasContext = canvasContext;
            _width = width;
            _height = height;
        }

        public void DrawPlan()
        {
            // draw background
            _canvasContext.FillStyle = "lightblue";
            _canvasContext.FillRect(0, 0, _width, _height);

            // write header
            _canvasContext.Font = "12px";
            _canvasContext.StrokeText("Date/Time/Shift", Ch, Ch);

            // draw the grid
            _canvasContext.LineWidth = 1f;
            //_canvasContext.StrokeStyle = "stroke-width: 0.5;";
            for (int i = 0; i < _height / Ch; i++)
            {
                _canvasContext.StrokeRect(0, i * Ch, _width, Ch);
            }
            for (int i = 0; i < _width / Cw; i++)
            {
                _canvasContext.StrokeRect(i * Cw, 0, Cw, _height);
            }

            // draw some crosses when staff is assigned to a shift
            Random rng = new Random();
            for (int i = 0; i < 1000; i++)
            {
                _canvasContext.StrokeText("X", rng.Next(_width / Cw) * Cw + 8, rng.Next(_height / Ch) * Ch);
            }
        }
    }
}
