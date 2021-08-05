using CustomBoomi.Models;
using System.Text.Json;

namespace CustomBoomi.CRUD
{
    public static class BoomiMoreCRUD
    {
        public static CreateResponse Create(string request)
        {
            var json = JsonSerializer.Deserialize<CreateRequest>(request);
            return new CreateResponse
            {
                Message = "BoomiMoreCRUD Hello: " + string.Join(",", json.Messages)
            };
        }
    }
}
