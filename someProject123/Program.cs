Console.Write("Введите координаты пушки x;y >> ");
string[] cannonCoord = Console.ReadLine().Split(";");
Console.Write("Введите начальную скорость снаряда>> ");
int initialV = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите угол вылета снаряда в градусах>> ");
int departureAngle = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите время прошедшее с момента выстрела в секундах>> ");
int pastTense = Convert.ToInt32(Console.ReadLine());

string path = "C:\\Users\\prdb\\Desktop\\someProject123\\answer.txt";
string contents;

StreamWriter writer = new StreamWriter(path, true);

double vX = initialV * Math.Cos(departureAngle * 3.14 / 180);
double vY = initialV * Math.Sin(departureAngle * 3.14 / 180);

List<double> answerX = [];
List<double> answerY = [];

for (int i = 0; i <= pastTense; i++) 
{
    double x = Math.Round(Convert.ToDouble(cannonCoord[0]) + vX * i);
    double y = Math.Round(Convert.ToDouble(cannonCoord[1]) + vY * i - (9.81 * Math.Pow(i, 2)) / 2);
    if (y < 0) break;
    else 
    {
        answerX.Add(x);
        answerY.Add(y);
    }
}

for (int i = 0; i <= answerY.Count()-1; i++) 
{
    if (i == 0)
    {
        contents = $"[{answerX[i]};{answerY[i]}] <- первые координаты после выстрела\n";
    }
    else if (answerY[i] == answerY.Max())
    {
        contents = $"[{answerX[i]};{answerY[i]}] <- координаты наивысшей точки траектории полёта\n";
    }
    else if (answerY[i] == answerY.Min())
    {
        contents = $"[{answerX[i]};{answerY[i]}] <- координаты падения\n";
    }
    else
    {
        contents = $"[{answerX[i]};{answerY[i]}]\n";
    }
    writer.Write(contents);
    Console.Write(contents);
}
Console.WriteLine($"\nРезультат был записан в {path}");