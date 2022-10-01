using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinectinho.CarouselControl
{
    internal interface ICarouselControl
    {
        double Rotate(double startXInScreenCoordinates, double endXInScreenCoordinates);
        void RotateIncrement(int increment);
        void RotateRight();
        void RotateLeft();
        bool ShowRotation { get; set; }
    }
}
