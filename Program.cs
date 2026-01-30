using Aerospike.Client;
using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

class Program {
    static AerospikeClient client;
    static void Main(string[] args)
    {
        //1.
        client = new AerospikeClient("127.0.0.1",3000);
        ////WritePolicy writePolicy = new WritePolicy();
        ////writePolicy.expiration = 120;
        //Key key = new Key("test", "demodef", "key10");
        //client.Put(null, key, new Bin("mybinname","mybinvalue"));
        ////client.Close();
        //Console.WriteLine(client.Get(null, key));


        //2. Complex Data Ob
        //Dictionary<string, object> product = new();
        //product.Add("name", "laptop"); 
        //product.Add("productID", 123); 
        //product.Add("available", true); 

        //Bin productBin = new Bin("product",product);
        //client.Put(null,key,productBin);

        //Console.WriteLine(client.Get(null,key));

        //Record record = client.Get(null, key);
        //IDictionary item =  record.GetMap("product");

        //foreach (var rec in item)
        //{
        //    Console.WriteLine(rec);
        //}

        //3. Multiple bins against one key
        //Key myKey = new Key("test", "test_set1", 100012);
        //Bin myBin = new Bin("description", "Couch");
        //Bin mySecondBin = new Bin("price", 123.50);
        //Bin myThirdBin = new Bin("weight", 12);
        ////Write
        //client.Put(null, myKey, myBin, mySecondBin, myThirdBin);
        ////Read
        ////Record record = client.Get(null, myKey);

        ////Get the data
        //Record record = client.Get(null, myKey,"price");
        //Console.WriteLine(record);
        //int currentGeneration = record.generation; //6
        //Console.WriteLine(currentGeneration);

        ////Modify the data
        //Bin updatedBin = new Bin("price", 125.50);

        ////4.Thread safe updates
        ////Update the data
        //WritePolicy writePolicy = new WritePolicy();
        //writePolicy.generationPolicy = GenerationPolicy.EXPECT_GEN_EQUAL;
        //writePolicy.generation = currentGeneration;

        //client.Put(writePolicy, myKey, updatedBin);
        //client.Close();

        //5.Update(UPSERT) 
        //WritePolicy writePolicy = new WritePolicy();
        //writePolicy.recordExistsAction = RecordExistsAction.CREATE_ONLY;
        Key myKey = new Key("test", "test_set1", 100013);
        //Bin updatedBin = new Bin("price", 125.50);
        //client.Delete(writePolicy,myKey);
        //client.Put(writePolicy, myKey, updatedBin);

        //6.TOUCH
        //WritePolicy writePolicy = new WritePolicy();
        //writePolicy.expiration = 120;

        //client.Touch(writePolicy, myKey);

        //Operations
        Key key = new Key("test", "cart2", 1);
        //client.Delete(null, key);
        ////client.Put(null,key, new Bin ("shoes", 59.44),
        ////                     new Bin("jeans", 59.44),
        ////                     new Bin("shirts", 59.44));

        //Console.WriteLine(addItem(key, "shoes", 59.44));
        //Console.WriteLine(addItem(key, "jeans", 69.44));
        //Console.WriteLine(addItem(key, "shirts", 79.44));

        //

        AddItem(client, key, CreateItem("shoes", 59.25, "/items/item1234"));
        AddItem(client, key, CreateItem("jeans", 29.95, "/items/item2378"));
        AddItem(client, key, CreateItem("shirt", 19.95, "/items/item88293"));

        //Record record = client.Operate(null, key,
        //  ListOperation.RemoveByIndex("items", 0, ListReturnType.NONE),
        //  ListOperation.Size("items"));
        //int remaining = record.GetInt("items");
        //Console.WriteLine(remaining);

        //Record record = client.Operate(null, key,
        //ListOperation.RemoveByIndexRange("items", 0, 2, ListReturnType.COUNT));
        //int remaining = record.GetInt("items");
        //Console.WriteLine(remaining);


        Record record = client.Operate(null, key,
        ListOperation.RemoveByIndex("items", 1,
        ListReturnType.INVERTED));
        int removed = record.GetInt("items");
        Console.WriteLine(removed);
    }
    //public static double addItem(Key key, string itemDcr, double cost) {
    //    Record record = client.Operate(null, key,
    //       Operation.Append(new Bin("items", itemDcr + ",")), //oprations within one transaction
    //       Operation.Add(new Bin("totalItems", 1)),
    //       Operation.Add(new Bin("cost", cost)));
    //    Console.WriteLine(record);
    //    return record.GetDouble("cost");
    //}

   

    public static Dictionary<string, object> CreateItem(string itemDescr, double cost, string originalItem)
    {
        var result = new Dictionary<string, object>();
        result["cost"] = cost;
        result["descr"] = itemDescr;
        result["orig"] = originalItem;
        return result;
    }
    public static void AddItem(IAerospikeClient client, Key key, Dictionary<string, object> item)
    {
        client.Operate(null, key, ListOperation.Append("items", Value.Get(item)));
    }
}