using Newtonsoft.Json;

namespace CarsbyAPI.Middleware
{
    public class ErrorResponseModel
    {

        public int Code { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

        // other fields
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
