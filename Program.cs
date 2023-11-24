using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

public class Program
{
    private static void Main(string[] args)
    {
        List<employee> empList = new List<employee>
        {
            new employee
            {
                id = 1,
                Fname = "John",
                Lname = "Doe",
                Benefits = new List<string> { "Health", "Dental", "Vision" }
            },
            new employee
            {
                id = 2,
                Fname = "Yahia",
                Lname = "",
                Benefits = new List<string> { "Health", "Dental", "Vision" }
            },
            new employee
            {
                id = 3,
                Fname = "gana",
                Lname = "Doe",
                Benefits = new List<string> { "Health", "Dental", "Vision" }
            }
        };  
           
        //var xmlString = SerializeToXmlString(empList);
        //Console.WriteLine(xmlString);
        //File.WriteAllText("xmlfile.xml", xmlString);
        
        var jsonString = SerializeToJson(empList);
        Console.WriteLine(jsonString);
        File.WriteAllText("jsonfile.json", jsonString);
      
    }

    private static string SerializeToXmlString(List<employee> emp)
    {
        var result = "";
        var xmlSerializer = new XmlSerializer(emp.GetType());
        using (var sw = new StringWriter())
        {
            using (var writer = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
            {
                xmlSerializer.Serialize(writer, emp);
                result = sw.ToString();
            }
        }
        return result;
    }
    // JSON //

    static string SerializeToJson(List<employee> emp)
    {
        var result = "";
        result= JsonSerializer.Serialize(emp ,
            new JsonSerializerOptions { WriteIndented=true});
        return result;
    }
    

    public class employee
    {
        public int id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public List<string> Benefits { get; set; }
    }
}
