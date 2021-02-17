
public class MySort
{
    public static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i += 1)
        {
            int j = i - 1;
            int val = arr[i];

            while (j >= 0 && arr[j] > val)
            {
                arr[j + 1] = arr[j];
                j -= 1;
            }
            arr[j + 1] = val;
        }
    }
}
