using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializer
{
    private const string path = "./GameData.dat";

    private Hashtable data;

    public void SaveData()
    {
        if (data == null)
        {
            Console.WriteLine("Data is null, load data before saving");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);


        try
        {
            bf.Serialize(file, data);
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            try
            {
                data = (Hashtable)bf.Deserialize(file);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                file.Close();
            }
        }
        else
        {
            Console.WriteLine("Not found file. Create New.");
            SetDefaultData();
            SaveData();
        }

    }

    public void ResetData()
    {
        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
                Console.WriteLine("C удалением файла что то пошло не так");
            }
            SetDefaultData();
            SaveData();
        }
    }


    public ref Hashtable GetData()
    {
        return ref data;
    }

    public void SetDefaultData()
    {
        data = new Hashtable()
        {
            {"login", ""},
            {"password", ""}
        };

    }
}
