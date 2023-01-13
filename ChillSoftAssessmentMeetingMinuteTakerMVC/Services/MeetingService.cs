using ChilliSoftAssessmentMeetingMinuteTakerDLL.DomainModels;
using System.Text;

namespace GenericBaseMVC.Services;

public class MeetingService
{
    public async Task<List<Meeting>> Get()
    {
        IEnumerable<Meeting> meetings = null;


        string apiUrl = "https://localhost:7071/api/Meeting";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Meeting>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Meeting>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public async Task<List<MeetingDto>> GetAll()
    {
        IEnumerable<MeetingDto> meetings = null;


        string apiUrl = "https://localhost:7071/api/Meeting/GetAll";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<MeetingDto>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<MeetingDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public async Task<List<CreateMeetingDto>> Create(CreateMeetingDto newBooking)
    {
        IEnumerable<CreateMeetingDto> meetings = null;

        string apiUrl = "https://localhost:7071/api/Meeting/CreateDto";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var newbarberJson = Newtonsoft.Json.JsonConvert.SerializeObject(newBooking);
            var payload = new StringContent(newbarberJson, Encoding.UTF8, "application/json");

            HttpResponseMessage result = await client.PostAsync(apiUrl, payload);

            //result.EnsureSuccessStatusCode();

            var apiresponse = new List<CreateMeetingDto>();

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsAsync<List<CreateMeetingDto>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
            }

            return apiresponse;
        }

    }

    public async Task<List<Meeting>> Cancel()
    {
        IEnumerable<Meeting> meetings = null;


        string apiUrl = "https://localhost:7071/api/Meeting";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Meeting>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Meeting>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

    public async Task<List<Meeting>> Update()
    {
        IEnumerable<Meeting> meetings = null;


        string apiUrl = "https://localhost:7071/api/Meeting";

        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            var apiresponse = new List<Meeting>();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<List<Meeting>>();
                //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                apiresponse = data;
                //Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            }

            return apiresponse;
        }

    }

}
    //private readonly string _baseUrl;
    //private readonly IAuthenticationManager _authenticationManager;

    //public BookingService(IOptions<SiteSettings> siteSettings, IAuthenticationManager authenticationManager)
    //{
    //    _authenticationManager = authenticationManager;
    //    _baseUrl = siteSettings.Value.URL;
    //}

    //public async Task<ApiResponse> Create(MeetingDto reservation)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PostJsonAsync(reservation).ReceiveJson<ApiResponse>();
    //}

    //public async Task<ApiResponse> Update(MeetingDto reservation)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PutJsonAsync(reservation).ReceiveJson<ApiResponse>();
    //}

    //public async Task<ApiResponse> UpdateOld(MeetingDto reservation)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", _authenticationManager.GetTenant()).AppendPathSegment("/v1/Booking/").WithOAuthBearerToken(await _authenticationManager.GetToken()).PutJsonAsync(reservation).ReceiveJson<ApiResponse>();
    //}

    //public async Task<ApiResponse> Get(int id)
    //{
    //    return await _baseUrl.WithHeader("X-TENANT-ID", AppendPathSegments("/v1/Booking/").AppendPathSegment(id).WithOAuthBearerToken(await _authenticationManager.GetToken()).GetJsonAsync<ApiResponse>();
    //}


    //}
    //}


