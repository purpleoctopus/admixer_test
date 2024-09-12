using HedgehogTask;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть кількість їжачків для кожного з трьох кольорів (через пробіл): ");

        int[] inputColors = new int[3];

        string[] input = Console.ReadLine().Split(" ");

        int i = 0;
        foreach (string s in input.Length == 3 ? input : throw new Exception("Некоректно введено кольори"))
        {
            inputColors[i++] = int.Parse(s);
        }

        Console.Write("Введіть колір, яким мають стати їжачки (0-2): ");

        int color = int.Parse(Console.ReadLine());

        var (result, path) = HedgehogCalculator.CalculateMinMeetingsToUnify(inputColors, 
            color >= 0 && color <= 2 ? color : throw new Exception("Вибрано неправильний колір"));

        Console.WriteLine(result);

        if (result != -1)
        {
            Console.WriteLine("Шлях:");
            foreach (var step in path)
            {
                Console.WriteLine($"Red: {step.red}, Green: {step.green}, Blue: {step.blue}");
            }
        }
    }
}