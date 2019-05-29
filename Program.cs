using System;
using System.Numerics;

namespace Vectors
{
    class Program
    {
        static bool inputVector(string label, out double[] data)
        {
            data = new double[3];
            bool result = true;
            
            try
            {
                Console.WriteLine(string.Format("Enter {0} 3D vector : ", label));

                string input = Console.ReadLine();

                string[] parts = input.Split(' ');

                if (parts.Length < 3) throw new Exception("Input format error");

                for (int i=0; i < 3; i++)
                {
                    data[i] = double.Parse(parts[i]);
                }
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }

        static void Main(string[] args)
        {
            var vc = new VectorClass();
            Vector3D w;
            double[] data;
            
            while(true)
            {
                try
                {
                                
                    Console.WriteLine("Vector Calculator\n\n\an");
                    
                    if (!inputVector("first", out data)) throw new Exception("Input error");

                    vc.U.Load(data);

                    if (!inputVector("second", out data)) throw new Exception("Input error");

                    vc.V.Load(data);

                    vc.Calculate();

                    Console.WriteLine(string.Format("Length of U : {0:F2}", vc.U.Length));
                    Console.WriteLine(string.Format("Length of V : {0:F2}", vc.V.Length));
                    
                    Console.WriteLine(string.Format("Angle between U and V : {0:F3}", vc.Angle));

                    Console.WriteLine(string.Format("Orthogonal Vector (W) : {0:F2} {1:F2} {2:F2}", vc.W.X, vc.W.Y, vc.W.Z));
                    Console.WriteLine(string.Format("Length of W : {0:F2}", vc.W.Length));

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Press X to quit, any other key to continue...");

                if (Console.ReadKey().Key == ConsoleKey.X) break;


            }
        }
    }
}
