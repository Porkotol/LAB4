using System;

class Program
{
    static void Main(string[] args)
    {
        int sizearray;
        Console.WriteLine("Введiть номер студента:");
        int studnum = Convert.ToInt32(Console.ReadLine());
        sizearray = (int)(20 + 0.6 * studnum);
        int[] nums = new int[sizearray];
        Random random = new Random();
        Console.WriteLine("Масив до сортування:");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = random.Next(10, 100);
            Console.Write($"{nums[i]}|");
        }
        SortArray(nums);
        PrintArray(nums);
    }

    static void SortArray(int[] nums)
    {
        if (nums.Length < 2)
        {
            return;
        }
        int column = nums.Length / 2;
        int[] arrayone = new int[column];
        int[] arraytwo = new int[nums.Length - column];
        for (int i = 0; i < column; i++)
        {
            arrayone[i] = nums[i];
        }
        for (int i = column; i < nums.Length; i++)
        {
            arraytwo[i - column] = nums[i];
        }
        SortArray(arrayone);  //// використав рекурciю
        SortArray(arraytwo);
        Sort(nums, arrayone, arraytwo);
    }
    static void Sort(int[] nums, int[] arrayone, int[] arraytwo)
    {
        int i = 0; // 1 масив
        int j = 0; // 2 масив 
        int k = 0; // 3 або головний масив 
        while (i < arrayone.Length && j < arraytwo.Length)
        {
            if (arrayone[i] <= arraytwo[j])
            {
                nums[k] = arrayone[i];
                i++;
            }
            else
            {
                nums[k] = arraytwo[j];
                j++;
            }
            k++;
        }
        while (i < arrayone.Length) //знаходження залишкiв у масивi 
        {
            nums[k] = arrayone[i];
            i++;
            k++;
        }
        while (j < arraytwo.Length) //знаходження залишкiв у масивi 
        {
            nums[k] = arraytwo[j];
            j++;
            k++;
        }
    }
    static int BSearch(int[] nums, int numberSearch, int one, int two)
    {
        int povt = 0; //кiлькicть повторювань
        while (one <= two)
        {
            int cns = (one + two) / 2;
            int midval = nums[cns];
            if (midval == numberSearch)
            {
                povt++;
            }
            if (midval > numberSearch)
            {
                two = cns - 1;
            }
            else
            {
                one = cns + 1;
            }
        }
        return povt;
    }
    static void PrintArray(int[] nums)
    {
        Console.WriteLine("\nВiдсортований масив:");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write($"{nums[i]}|");
        }
        Console.WriteLine("\nВведiть число,для пошуку у масивi:");
        int searc = Convert.ToInt32(Console.ReadLine());
        int result = BSearch(nums, searc, 0, nums.Length - 1);
        Console.WriteLine($"Число {searc} повторилось {result} разiв у масивi");
    }
}
