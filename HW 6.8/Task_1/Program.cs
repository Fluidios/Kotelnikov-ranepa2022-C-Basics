int x, y, rValue, summ = 0;
int[,] matrix;
Random r = new Random();

Console.WriteLine("Set horizontal matrix length...");
x = int.Parse(Console.ReadLine());

Console.WriteLine("Set vertical matrix length...");
y = int.Parse(Console.ReadLine());

matrix =  new int[x,y];
for (int i = 0; i < x; i++)
{
	for (int j = 0; j < y; j++)
	{
		rValue = r.Next(0, 99);
		summ += rValue;
		matrix[i,j] = rValue;
		Console.Write("{0,3}|", rValue);
	}
    Console.WriteLine();
    for (int j = 0; j < y*4; j++)
		Console.Write("-");
	Console.WriteLine();
}
Console.WriteLine("Summ = {0}", summ);