using System;

public class VirtualRealityCamera
{
    public static double[,] CalculatePOV(double[] cameraPosition, double[] targetPosition, double[] upVector)
    {
        double[] forward = Normalize(Subtract(targetPosition, cameraPosition));
        
        double[] right = Normalize(Cross(upVector, forward));
        
        double[] up = Cross(forward, right);
        
        double[,] transformationMatrix = new double[4, 4];
        for (int i = 0; i < 3; i++)
        {
            transformationMatrix[i, 0] = right[i];
            transformationMatrix[i, 1] = up[i];
            transformationMatrix[i, 2] = -forward[i];
            transformationMatrix[i, 3] = cameraPosition[i];
        }
        transformationMatrix[3, 3] = 1.0;

        return transformationMatrix;
    }

    public static double[] Cross(double[] a, double[] b)
    {
        double[] result = new double[3];
        result[0] = a[1] * b[2] - a[2] * b[1];
        result[1] = a[2] * b[0] - a[0] * b[2];
        result[2] = a[0] * b[1] - a[1] * b[0];
        return result;
    }

    public static double[] Subtract(double[] a, double[] b)
    {
        double[] result = new double[3];
        for (int i = 0; i < 3; i++)
        {
            result[i] = a[i] - b[i];
        }
        return result;
    }

    public static double[] Normalize(double[] vector)
    {
        double magnitude = Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1] + vector[2] * vector[2]);
        double[] normalized = new double[3];
        for (int i = 0; i < 3; i++)
        {
            normalized[i] = vector[i] / magnitude;
        }
        return normalized;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter camera position (x, y, z):");
        double[] cameraPosition = Array.ConvertAll(Console.ReadLine().Split(','), Double.Parse);

        Console.WriteLine("Enter target position (x, y, z):");
        double[] targetPosition = Array.ConvertAll(Console.ReadLine().Split(','), Double.Parse);

        Console.WriteLine("Enter up vector (x, y, z):");
        double[] upVector = Array.ConvertAll(Console.ReadLine().Split(','), Double.Parse);

        double[,] povMatrix = CalculatePOV(cameraPosition, targetPosition, upVector);

        Console.WriteLine("Point of View Matrix:");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(povMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

/*

The mathematical formula for the point of view (POV) matrix, also known as the view matrix, can be derived as follows:

Let f, r, and u represent the forward, right, and up vectors, respectively, in the camera's local coordinate system.

The forward vector f is calculated as the normalized vector pointing from the camera's position (C) towards its target (T):

f=normalize(T−C)


The right vector r is calculated as the normalized vector perpendicular to the forward vector and the camera's up vector (up):

r=normalize(up×f)

The up vector u is calculated as the cross product of the forward and right vectors:

u=f×r

The POV matrix is then constructed as follows:

f = normalize(targetPosition - cameraPosition)  // Forward vector
r = normalize(cross(upVector, f))              // Right vector
u = cross(f, r)                                // Up vector

POV Matrix:
|  rx   ry   rz   -dot(r, cameraPosition) |
|  ux   uy   uz   -dot(u, cameraPosition)  |
| -fx  -fy  -fz   dot(f, cameraPosition)   |
|  0    0    0               1             |

Where:
- rx, ry, rz = components of the right vector
- ux, uy, uz = components of the up vector
- fx, fy, fz = components of the forward vector
- dot(a, b) = dot product of vectors a and b


*/
