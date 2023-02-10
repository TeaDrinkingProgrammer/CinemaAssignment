using System.Text.Json;

namespace Domain;
public class JsonExport: ExportMethod
{

    override public void export(Order order){
            System.IO.File.WriteAllText(
                @"export.json",
                JsonSerializer.Serialize(
                    order,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true }
                    )
                );
    }
}
