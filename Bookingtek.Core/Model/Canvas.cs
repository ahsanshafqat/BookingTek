using System.ComponentModel;
using System.Text;

namespace Bookingtek.Core.Model
{
    public class Canvas
    {
        private static Canvas _canvasInstance;

        public static Canvas Instance
        {
            get
            {
                if (_canvasInstance == null)
                    _canvasInstance = new Canvas();
                return _canvasInstance;
            }
        }

        public readonly char horizontalChar = '-';
        public readonly char verticalChar = '|';
        public readonly char lineChar = 'x';

        public int Width { get; set; }
        public int Height { get; set; }
        
        public char[,] cells;

        public bool CanvasInitialzed { get; set; }

        public void SetCanvas(int width = 0, int height = 0)
        {
            Width = width + 2;
            Height = height + 2;
            cells = new char[Width, Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1)
                        cells[j, i] = horizontalChar;
                    else if (j == 0 || j == Width - 1)
                        cells[j, i] = verticalChar;
                }
            }

            CanvasInitialzed = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(cells[j, i]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
