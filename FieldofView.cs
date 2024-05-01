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
