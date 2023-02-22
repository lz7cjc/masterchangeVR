using System;

[Serializable]
public class JsonData<T>
{
    public bool success;
    public T json;
}