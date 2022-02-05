using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    //Save and load Factories
    public static void SaveFactories(factoriesClass factory)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/factories.yeet";
        FileStream stream = new FileStream(path, FileMode.Create);

        IndivFactory dataf = new IndivFactory(factory);

        formatter.Serialize(stream, dataf);
        stream.Close();
    }

    public static IndivFactory LoadFactories()
    {
        string path = Application.persistentDataPath + "/factories.yeet";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            IndivFactory dataf = formatter.Deserialize(stream) as IndivFactory;
            stream.Close();

            return dataf;
        }
        else
        {
            Debug.LogError("Save file not found for factories in " + path);
            return null;
        }
    }


    //Save and load Companies
    public static void SaveCompanies(companiesClass company)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/companies.yeet";
        FileStream stream = new FileStream(path, FileMode.Create);

        IndivCompany datac = new IndivCompany(company);

        formatter.Serialize(stream, datac);
        stream.Close();
    }

    public static IndivCompany LoadCompanies()
    {
        string path = Application.persistentDataPath + "/companies.yeet";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            IndivCompany datac = formatter.Deserialize(stream) as IndivCompany;
            stream.Close();

            return datac;
        }
        else
        {
            Debug.LogError("Save file not found for factories in " + path);
            return null;
        }
    }
}
