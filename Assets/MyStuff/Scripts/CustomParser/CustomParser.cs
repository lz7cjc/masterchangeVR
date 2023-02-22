using UnityEngine;

public static class CustomParser
{
    /// <summary>
    /// Converts a string data into a JSON class based on T type.
    /// You can check if the data was parsed correctly by checking the 
    /// bool variable success before using
    /// </summary>
    /// <typeparam name="T">The type of the class that will be generated if the string is valid</typeparam>
    /// <param name="p_data">The string data that will be converted</param>
    /// <returns></returns>
    public static JsonData<T> FromJson<T>(string p_data) where T : new()
    {
        try
        {
            // If success, will return the JsonData class that has the parsed data insdide the json var
            var result = JsonUtility.FromJson<T>(p_data);

            return new JsonData<T>()
            {
                success = true,
                json = result
            };
        }
        catch
        {
            // In case of failure, will return an empty data.
            return new JsonData<T>
            {
                success = false,
                json = new T()
            };
        }
    }
}