// See https://aka.ms/new-console-template for more information
using System.Data;

void printarray(int[] tab)
{
    for(int i = 0; i<tab.Length; i++)
    {
        Console.Write(tab[i] + " ");
    }
}
void bubble(int[] tab)
{
    for(int i = 0; i< tab.Length; i++)
    {
        for(int j = 1; j<tab.Length; j++)
        {
            if (tab[j] < tab[j - 1])
            {
                int temp = (int)tab[j];
                tab[j] = tab[j - 1];
                tab[j - 1] = temp;
            }
        }
    }
}

void insertion(int[] tab)
{
    for(int i = 1; i<tab.Length; i++)
    {
        int key = tab[i];
        int j = i - 1;
        while (j >= 0 && tab[j] > key)
        {
            tab[j + 1] = tab[j];
            j--;
        }
        tab[j + 1] = key;
    }
}

void counting(int[] tab)
{
    int min = tab.Min();
    int max = tab.Max();
    int range = max - min + 1;

    int[] count = new int[range];

    for(int i = 0; i < tab.Length; i++)
    {
        count[tab[i] - min]++;
    }
    
    for(int i = 1; i < count.Length; i++)
    {
        count[i] += count[i - 1];
    }

    int[] output  = new int[tab.Length];

    for (int i = tab.Length - 1; i >= 0; i--)
    {
        output[count[tab[i] - min]-1] = tab[i];
        count[tab[i] - min]--;
    }
    for (int i = 0; i < tab.Length; i++)
    {
        tab[i] = output[i];
    }

}

void quicksort(int[] tab, int left, int right)
{
    if (left < right)
    {
        int pivotIndex = Partition(tab, left, right);

        quicksort(tab, left, pivotIndex - 1);
        quicksort(tab, pivotIndex + 1, right);
    }
}

int Partition(int[] tab, int left, int right)
{
    int pivot = tab[right];
    int i = left - 1;

    for(int j = left; j < right; j++)
    {
        if (tab[j] <= pivot)
        {
            i++;
            Swap(tab, i, j);
        }
    }
    Swap(tab, i + 1, right);
    return i + 1;
}
void Swap(int[] tab, int i, int j)
{
    int temp = tab[i];
    tab[i] = tab[j];
    tab[j] = temp;
}


void mergesort(int[] tab, int left, int right)
{
    if (left < right)
    {
        int middle = (left + right) / 2;
        mergesort(tab, left, middle);
        mergesort(tab, middle+1, right);

        merge(tab, left, middle, right);
        
    }
}

void MergeSort(int[] array, int left, int right)
{
    if (left < right)
    {
        // Znajdź środek tablicy
        int middle = (left + right) / 2;

        // Rekurencyjne sortowanie lewej połowy
        MergeSort(array, left, middle);

        // Rekurencyjne sortowanie prawej połowy
        MergeSort(array, middle + 1, right);

        // Scalanie obu połówek
        Merge(array, left, middle, right);
    }
}

void Merge(int[] array, int left, int middle, int right)
{
    // Rozmiary obu podtablic
    int leftSize = middle - left + 1;
    int rightSize = right - middle;

    // Tymczasowe tablice
    int[] leftArray = new int[leftSize];
    int[] rightArray = new int[rightSize];

    // Kopiowanie danych do tymczasowych tablic
    for (int i = 0; i < leftSize; i++)
        leftArray[i] = array[left + i];
    for (int i = 0; i < rightSize; i++)
        rightArray[i] = array[middle + 1 + i];

    // Indeksy do iterowania
    int iLeft = 0, iRight = 0, iMerged = left;

    // Scalanie tablic
    while (iLeft < leftSize && iRight < rightSize)
    {
        if (leftArray[iLeft] <= rightArray[iRight])
        {
            array[iMerged] = leftArray[iLeft];
            iLeft++;
        }
        else
        {
            array[iMerged] = rightArray[iRight];
            iRight++;
        }
        iMerged++;
    }

    // Kopiowanie pozostałych elementów
    while (iLeft < leftSize)
    {
        array[iMerged] = leftArray[iLeft];
        iLeft++;
        iMerged++;
    }

    while (iRight < rightSize)
    {
        array[iMerged] = rightArray[iRight];
        iRight++;
        iMerged++;
    }
}




Console.WriteLine("Hello, World!");
int[] tab = { 6, 4, 3, 2, 6, 7 };
MergeSort(tab, 0, tab.Length - 1);

printarray(tab);

