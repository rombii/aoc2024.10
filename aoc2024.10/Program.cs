var input = File.ReadAllLines(Path.Join(Directory.GetCurrentDirectory(), "input.txt"));
int part1Answer = 0, part2Answer = 0;
var reachablePeaks = new HashSet<(int, int)>();
for (var i = 0; i < input.Length; i++)
{
    for (var j = 0; j < input[i].Length; j++)
    {
        if (input[i][j] == '0')
        {
            part2Answer += HowManyCorrectPaths(i, j);
            part1Answer += reachablePeaks.Count;
            reachablePeaks.Clear();
        }
    }
}

Console.WriteLine($"First part: {part1Answer}");
Console.WriteLine($"Second part: {part2Answer}");
return;

int HowManyCorrectPaths(int y, int x)
{
    var directions = new[] { (-1, 0), (0, 1), (1, 0), (0, -1) };
    var answer = 0;
    for (var i = 0; i < directions.Length; i++)
    {
        var newY = y + directions[i].Item1;
        var newX = x + directions[i].Item2;
        if (newY < 0 || newY >= input.Length || newX < 0 || newX >= input.Length) continue;
        if (input[newY][newX] != input[y][x] + 1) continue;
        if (input[newY][newX] == '9')
        {
            reachablePeaks.Add((newY, newX));
            answer++;
        }
        else
        {
            answer += HowManyCorrectPaths(newY, newX);
        }
    }
    return answer;
}