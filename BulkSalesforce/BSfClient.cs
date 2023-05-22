using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BulkSalesforce; 

public class BSfClient {
    public RestClient Client { get; set; }

    public ApiCredentials Credential { get; set; }



    public BSfClient() {
        Client = new RestClient();
        Credential = new ApiCredentials();
    }
    
    public async Task<string> GetSalesforceToken()
    {

        var request = new RestRequest(Credential.SandboxEndPoint,Method.Post);
        request.AddParameter("grant_type", "password");
        request.AddParameter("client_id", Credential.ClientId);
        request.AddParameter("client_secret", Credential.ClientSecret);
        request.AddParameter("username", Credential.Username);
        request.AddParameter("password", Credential.Password );

        var response = await Client.ExecuteAsync(request);
    
        if (response.IsSuccessful)
        {
            dynamic responseData = JObject.Parse(response.Content);
            string accessToken = responseData.access_token;
            return accessToken;
        }
        else
        {
            // Handle error response
            Console.WriteLine("Salesforce token retrieval failed: " + response.ErrorMessage);
            return null;
        }
    }
    
    public async Task<string> CreateJob( string accessToken)
    {
        

        Client.AddDefaultHeader("Authorization", $"Bearer {accessToken}");
  
        var request = new RestRequest(Credential.JobRequestUrl,Method.Post);
        
        var response = await Client.PostAsync(request);
      
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error creating job: {response.ErrorMessage}");
            return null;
        }
        string responseJson = response.Content; 
        dynamic jobResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseJson);
        
        string jobId = jobResponse.id;
        Console.WriteLine($"Job created with ID: {jobId}");
        return jobId;
    }
}