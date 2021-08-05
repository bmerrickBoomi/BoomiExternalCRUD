using CustomBoomi.Models;
using System.Text.Json;

namespace CustomBoomi.CRUD
{
    public static class BoomiCRUD
    {
        public static CreateResponse Create(string request)
        {
            var json = JsonSerializer.Deserialize<CreateRequest>(request);
            return new CreateResponse
            {
                Message = "BoomiCRUD Hello: " + string.Join(",", json.Messages)
            };
        }
    }
}
