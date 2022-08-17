namespace MyMicroServices.Services
{
    public class PcsrApiService : IPcsrApiService
    {

        private readonly HttpClient client;

        public PcsrApiService()
        { 
            this.client = new HttpClient();
        }

        /// <summary>
        /// demo client REST API
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetSampleUser()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync("https://reqres.in/api/users?page=1");

            var msg = await stringTask;
            
            return msg;
        }
    }
}
