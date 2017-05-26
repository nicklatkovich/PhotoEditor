using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoEditor.Controls
{
    public class Layer : Canvas
    {
        protected bool isDragging;
        public Point clickPosition;

        public string LayerName { get; set; }
        public Point LayerPosition;

        public SolidColorBrush layerColorBrush { get; set; }
        public ImageBrush layerImageBrush { get; set; }
        public BitmapFrame layerBmpFrame { get; set; }
        public LayerWidget Widget { get; set; }

        public Layer(string name, double width, double height, double opacity, int col, int colspan, int row)
        {
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Control_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(Control_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(Control_MouseMove);

            LayerName = Name = name;
            Height = height;
            Width = width;
            MinHeight = 100;
            MinWidth = 100;
            Opacity = opacity;
            if (col != 0) Grid.SetColumn(this, col);
            if (row != 0) Grid.SetRow(this, row);
            if (colspan != 0) Grid.SetColumnSpan(this, colspan);
            SetZIndex(this, GlobalState.LayersCount++);

            Widget = new LayerWidget(this, name);
        }

        public void refreshBrush()
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = layerBmpFrame;
            layerImageBrush = brush;

            Widget.refreshPreviewCanvas();
            Background = brush;
        }


        // DRAGGING LAYER


        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GlobalState.CurrentTool == GlobalState.Instruments.Arrow)
            {
                isDragging = true;
                var draggableControl = sender as Canvas;
                clickPosition = e.GetPosition(this);
                draggableControl.CaptureMouse();
                var widgetIndex = MainWindow.LayersWidgets.IndexOf(this.Widget);
                GlobalState.currentLayerIndex = widgetIndex;
                ((MainWindow)Application.Current.MainWindow).widgetsCanvas.SelectedIndex = widgetIndex;
            }
        }

        private void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (GlobalState.CurrentTool == GlobalState.Instruments.Arrow)
            {
                isDragging = false;
                var draggable = sender as Canvas;
                draggable.ReleaseMouseCapture();
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as Canvas;

            if (isDragging && draggableControl != null)
            {
                Point currentPosition = e.GetPosition(this.Parent as UIElement);

                var transform = draggableControl.RenderTransform as TranslateTransform;
                if (transform == null)
                {
                    transform = new TranslateTransform();
                    draggableControl.RenderTransform = transform;
                }

                transform.X = currentPosition.X - clickPosition.X;
                transform.Y = currentPosition.Y - clickPosition.Y;
                LayerPosition.X = transform.X;
                LayerPosition.Y = transform.Y;
                Console.WriteLine("layer " + LayerPosition.X + " " + LayerPosition.Y);
            }
        }

        public List<byte> ToBytes()
        {
            List<byte> result = new List<byte>();
            result.AddRange(this.LayerName.ToBytes());
            result.AddRange(this.LayerPosition.ToBytes());
            if (this.layerBmpFrame == null)
            {
                result.AddRange(BitConverter.GetBytes(0u));
            }
            else
            {
                result.AddRange(BitConverter.GetBytes(this.layerBmpFrame.PixelWidth));
                result.AddRange(BitConverter.GetBytes(this.layerBmpFrame.PixelHeight));

                int stride = layerBmpFrame.PixelWidth * (layerBmpFrame.Format.BitsPerPixel / 8);
                byte[] data = new byte[layerBmpFrame.PixelHeight * stride];

                result.AddRange(BitConverter.GetBytes(data.Length));

                layerBmpFrame.CopyPixels(data, stride, 0);
                result.AddRange(data);
            }
            return result;
        }

        public static Layer FromBytes(Queue<byte> q)
        {
            string layerName = Utils.FromBytesString(q);
            Point layerPosition = Utils.FromBytesPoint(q);
            int width = Utils.FromBytesInt(q);
            if (width != 0)
            {
                int height = Utils.FromBytesInt(q);
                //Layer result = new Layer(layerName, width, height, 1, 1, 2, 1);
                Layer result = new Layer(layerName, 350, 350, 1, 1, 2, 1);
                int bytesPerImage = Utils.FromBytesInt(q);
                byte[] imageData = new byte[bytesPerImage];
                for (uint i = 0; i < bytesPerImage; i++)
                {
                    imageData[i] = q.Dequeue();
                }
                WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
                bitmap.WritePixels(new Int32Rect(0, 0, width, height), imageData, width * (bitmap.Format.BitsPerPixel / 8), 0);
                result.layerBmpFrame = BitmapFrame.Create(bitmap);
                // TODO: позиция записывается верная, но рендерится картинка всё-равно в начале координат
                result.LayerPosition = layerPosition;
                result.refreshBrush();
                return result;
            }
            return null;
        }
    }
}