/*
    Author: Franciszek Pietrusiak
*/
using System.Buffers;
using Newtonsoft.Json;

namespace json_calculator;

class MathOperations {
    [JsonProperty("operator")]
    public string? Operator { get; set; }
    [JsonProperty("value1")]
    public double Value1 { get; set; }
    [JsonProperty("value2")]
    public double Value2 { get; set; }

    public double Compute() {
        return Operator switch {
            "add" => Value1 + Value2,
            "sub" => Value1 - Value2,
            "mul" => Value1 * Value2,
            "sqrt" => Math.Sqrt(Value1),
            _ => throw new InvalidOperationException($"Invalid operation: {Operator}")
        };
    }
}

class Program {
    static void Main(string[] args) {
        const string read_file_path = "./input.json";
        const string write_file_path = "./output.txt";
        string file_content;
        try {
            file_content = File.ReadAllText(read_file_path);
            var data = JsonConvert.DeserializeObject<Dictionary<string, MathOperations>>(file_content);
            if (data == null || data.Count == 0) {
                Console.WriteLine("No data in JSON file");
                return;
            }

            File.WriteAllText(write_file_path, "");
            var sorted_data = data.OrderBy(entry => entry.Value.Compute()).ToList();
            foreach (var entry in sorted_data) {
                string line = $"{entry.Key}: {entry.Value.Compute()}" + Environment.NewLine;
                File.AppendAllText(write_file_path, line);
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    } 
}