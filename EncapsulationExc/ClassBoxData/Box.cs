using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private const string Exception = "{0} cannot be zero or negative.";
       
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;

        }

        public double Length
        {
            get => length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Exception, nameof(Length)));
                }

                length = value;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Exception, nameof(Width)));
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Exception, nameof(Height)));
                }

                height = value;
            }
        }

        public double SurfaceArea() => LateralSurfaceArea() + 2 * Length * Width;

        public double LateralSurfaceArea() => 2 * Length * Height + 2 * Width * Height;

        public double Volume() => Length * Width * Height;
    }
}
