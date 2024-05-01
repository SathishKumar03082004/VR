using System;

public class VirtualRealityCamera
{
    public static double CalculateFOV(double focalLength, double sensorSize)
    {
        double sensorSizeRad = sensorSize * Math.PI / 180.0;
        double fov = 2 * Math.Atan(sensorSizeRad / (2 * focalLength));
        return fov * 180.0 / Math.PI;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter focal length (in millimeters):");
        double focalLength = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter sensor size (in degrees):");
        double sensorSize = Convert.ToDouble(Console.ReadLine());

        double fov = CalculateFOV(focalLength, sensorSize);

        Console.WriteLine("Field of View: " + fov.ToString("0.00") + " degrees");
    }
}


/*
The FOV (θ) can be calculated using the Formula:

PI=2*arctan(s/2*f)


focal length (f): The distance from the lens to the camera sensor.
sensor size (s): The size of the camera sensor.


we divide the sensor size by 2 X f to get the tangent of half the FOV angle, and then take the arctan to get the angle itself.
Since the FOV is typically given in degrees, you might want to convert the result from radians to degrees using the conversion factor 180/PI.


This formula calculates the FOV horizontally. If you need the FOV vertically, you can use the same formula but with the vertical sensor size instead.
If your camera's sensor is not square, you might need separate formulas for the horizontal and vertical FOV.
*/