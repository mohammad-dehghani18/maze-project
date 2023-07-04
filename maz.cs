using System;

class Program
{
    static void Main()
    {
        // ایجاد یک شیء از کلاس Matrix
        Matrix matrix = new Matrix(50, 50);

        // تعداد خانه‌هایی که باید جستجو شوند
        int searchCount = matrix.Search();

        Console.WriteLine("tedad khane haye jostojo shode : " + searchCount);
        Console.ReadLine();
    }
}

class Matrix
{
    private int[,] data;
    private int rowCount;
    private int columnCount;

    public Matrix(int rows, int columns)
    {
        rowCount = rows;
        columnCount = columns;

        // ایجاد ماتریس با اعداد تصادفی صفر و یک
        Random random = new Random();
        data = new int[rowCount, columnCount];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                data[i, j] = random.Next(2); // اعداد تصادفی 0 و 1
            }
        }
    }

    public int Search()
    {
        int count = 0;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                // اگر خانه فعلی مقدار 2 داشته باشد، از جستجو خارج می‌شود
                if (data[i, j] == 2)
                    break;

                // اگر خانه فعلی مقدار 1 داشته باشد، آن را جستجو کرده و به عدد 2 تغییر می‌دهیم
                if (data[i, j] == 1)
                {
                    count++;
                    SearchNeighbors(i, j);
                }
            }
        }

        return count;
    }

    private void SearchNeighbors(int row, int col)
    {
        // بررسی خانه‌های مجاور
        if (row - 1 >= 0 && data[row - 1, col] == 1)
        {
            data[row - 1, col] = 2;
            SearchNeighbors(row - 1, col); // جستجوی خانه بالا
        }

        if (row + 1 < rowCount && data[row + 1, col] == 1)
        {
            data[row + 1, col] = 2;
            SearchNeighbors(row + 1, col); // جستجوی خانه پایین
        }

        if (col - 1 >= 0 && data[row, col - 1] == 1)
        {
            data[row, col - 1] = 2;
            SearchNeighbors(row, col - 1); // جستجوی خانه چپ
        }

        if (col + 1 < columnCount && data[row, col + 1] == 1)
        {
            data[row, col + 1] = 2;
            SearchNeighbors(row, col + 1); // جستجوی خانه راست
        }
    }
}