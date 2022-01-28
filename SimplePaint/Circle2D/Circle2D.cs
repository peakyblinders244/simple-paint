using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Circle2D
{
    class Circle2D : IShape
    {
        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();

        public string Name => "Circle";

        public Color Color = Colors.Black;
        public double StrokeThickness = 1;
        public double Border = 5;

       
        public UIElement Draw()
        {
            Ellipse circle;
            if (Border != 0)
            {
                circle = new Ellipse()
                {
                    Width = Math.Abs(_rightBottom.X - _leftTop.X),
                    Height = Math.Abs(_rightBottom.X - _leftTop.X),
                    Stroke = new SolidColorBrush(Color),
                    StrokeThickness = StrokeThickness,
                    StrokeDashArray = DoubleCollection.Parse(Border.ToString())
                };
            }
            else
            {
                circle = new Ellipse()
                {
                    Width = Math.Abs(_rightBottom.X - _leftTop.X),
                    Height = Math.Abs(_rightBottom.X - _leftTop.X),
                    Stroke = new SolidColorBrush(Color),
                    StrokeThickness = StrokeThickness,
                    
                };
            }
            if (_leftTop.X - _rightBottom.X < 0 && _leftTop.Y - _rightBottom.Y < 0)
            {
                Canvas.SetLeft(circle, _leftTop.X);
                Canvas.SetTop(circle, _leftTop.Y);
            }
            else if (_leftTop.X - _rightBottom.X > 0 && _leftTop.Y - _rightBottom.Y > 0)
            {
                Canvas.SetLeft(circle, _rightBottom.X);
                Canvas.SetTop(circle, _rightBottom.Y);
            }
            else if (_leftTop.X - _rightBottom.X < 0 && _leftTop.Y - _rightBottom.Y > 0)
            {
                Canvas.SetLeft(circle, _leftTop.X);
                Canvas.SetTop(circle, _rightBottom.Y);
            }
            else if (_leftTop.X - _rightBottom.X > 0 && _leftTop.Y - _rightBottom.Y < 0)
            {
                Canvas.SetLeft(circle, _rightBottom.X);
                Canvas.SetTop(circle, _leftTop.Y);
            }

            return circle;
        }

        public void HandleStart(double x, double y)
        {
            _leftTop.X = x;
            _leftTop.Y = y;
        }

        public void HandleEnd(double x, double y)
        {
            _rightBottom.X = x;
            _rightBottom.Y = y;
        }

        public IShape Clone()
        {
            return new Circle2D();
        }

        public void  setValue(Color color, double strokeThickness,double border)
        {
            Color = color;
            StrokeThickness = strokeThickness;
            Border = border;
        }

        public void getValueSave(ref Color color, ref Point2D leftTop, ref Point2D rightBottom, ref double strokeThickness, ref double border)
        {
            color = Color;
            leftTop = _leftTop;
            rightBottom = _rightBottom;
            strokeThickness = StrokeThickness;
            border = Border;
        }

        public void setValueSave(ref Color color, ref Point2D leftTop, ref Point2D rightBottom, ref double strokeThickness, ref double border)
        {
            _leftTop = leftTop;
            _rightBottom = rightBottom;
            Color = color;
            StrokeThickness = strokeThickness;
            Border = border;
        }
    }
}
