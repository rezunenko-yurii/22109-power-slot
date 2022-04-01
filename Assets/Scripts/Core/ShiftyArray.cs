using System;

public class ShiftyArray<T>
{
    private readonly T[] array;
    private int front;

    public ShiftyArray(T[] array)
    {
        this.array = array;
        front = 0;
    }

    public void ShiftLeft()
    {

        /*array[front++] = default(T);
        if(front > array.Length - 1)
        {
            front = 0;
        }*/


        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }
            
            T temp = array[i - 1];
            array[i - 1] = array[i];
            array[i] = temp;
        }
    }
    
    public void ShiftRight()
    {
        T oldTemp = default(T);
        T newTemp = default(T);
        for (int i = 0; i < array.Length; i++)
        {
            if (i == 0)
            {
                oldTemp = array[i];
                array[0] = array[array.Length - 1];
                continue;
            }
            
            if (i == array.Length - 1)
            {
                array[i] = oldTemp;
            }
            else
            {
                newTemp = array[i];
                array[i] = oldTemp;
                oldTemp = newTemp;
            }
        }
    }

    public void ShiftLeft(int count)
    {
        for(int i = 0; i < count; i++)
        {
            ShiftLeft();
        }
    }

    public T this[int index]
    {
        get
        {
            if(index > array.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return array[(front + index) % array.Length];
        }
    }

    public int Length { get { return array.Length; } }
}