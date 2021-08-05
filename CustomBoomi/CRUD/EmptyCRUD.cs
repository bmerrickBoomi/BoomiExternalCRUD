using CustomBoomi.Models;

namespace CustomBoomi.CRUD
{
    public static class EmptyCRUD
    {
        public static CreateResponse Create()
        {
            return new CreateResponse
            {
                Message = "EmptyCRUD Hello"
            };
        }
    }
}
