/*ParallaxEffect*/

/*formula of ParallaxEffect is P=D⋅tan(θ)*/


using System;

public class ParallaxEffect
{
    public static void Main(string[] args)
    {
        // Distance between the eyes (in meters)
        float interocularDistance = 0.06f; // Typical interocular distance for humans

        // Distance from the viewer to the object (in meters)
        float distanceToObject = 10f;

        // Angle between the viewer's line of sight and the object (in degrees)
        float angle = 10f; // Example angle, adjust as needed

        // Convert angle to radians
        float angleRadians = angle * (float)Math.PI / 180f;

        // Calculate the parallax effect using the formula: P = D * tan(theta)
        float parallax = interocularDistance * (float)Math.Tan(angleRadians);

        // Apply the parallax effect by moving the object horizontally
        float objectPositionX = distanceToObject * (float)Math.Tan(angleRadians);
        
        Console.WriteLine("Parallax Effect: " + parallax);
        Console.WriteLine("Object Position X: " + objectPositionX);
    }
}
