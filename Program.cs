for(int i = 6; i<7 ;i++)
{
    int cube = i * i * i;
    string strcube = cube.ToString();
    int countNumberOfCube = 0;
    int copeCube = cube;
    while(copeCube>0)
    {
        copeCube/=10;
        countNumberOfCube++;
    }
    int[] arrayCubeNumbers = new int[countNumberOfCube];
    copeCube = cube;
    int count = 0;
    while(copeCube>1)
    {
        arrayCubeNumbers[count] = copeCube%10;
        copeCube/=10;
        count++;
    }
    int[][] arrayFactorial = Permute(arrayCubeNumbers, 0, countNumberOfCube); 
    int countCube = 0;
    for(int k =0; k< arrayFactorial.Length; k++)
    {
        int chislo = 0;
        int countDes = arrayCubeNumbers.Length;
        Console.WriteLine(string.Join(" ", arrayFactorial[k]));
        for(int j =0; j< arrayCubeNumbers.Length; j++)
        {
            int countdesJ= countDes;
            while(countdesJ>0)
            {
                arrayFactorial[k][j] *=10;
                countdesJ--;
            }
            countDes--;
            chislo += arrayFactorial[k][j];
        }
        if(IsCube(chislo))
        {
            countCube++;
        }
    }
    if(copeCube==3)
    {
        Console.WriteLine(i);
        break;
    }
}
static int[][] Permute(int[] a, int i, int n)
{
    int j;
    int[][] arrayF = new int[Factorial(n)][];
    int count =0;
    if (i == n)
    {
        arrayF[count] = a;
    }
    else
    {
        int temp;
        for (j = i; j < n; j++)
        {     
            temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            Permute(a, i + 1, n);
            temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
    return arrayF;
}
bool IsCube(int num)
{
    for (var i = 2; i < int.MaxValue; i++)
    {
        if (num / i == 0) return false;
        var tmp = num;
        var power = 0;
        while (tmp % i == 0)
        {
            tmp /= i;
            power++;
        }

        if (tmp == 1 && power == 3) return true;
    }
    return false;
}
static int Factorial(int n)
{
    int f = 1;
    for(int i = 1; i<=n; i++)
    {
        f *=i;
    }
    return f;
}