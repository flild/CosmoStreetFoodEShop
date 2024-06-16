using static Cosmo.Web.Utility.SD;

namespace Cosmo.Web.Models
{
    public class RequestDto
    {
        public ApiType Apitype { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken {  get; set; }
    }
}
