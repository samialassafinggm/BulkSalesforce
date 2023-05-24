namespace BulkSalesforce; 

public class ApiCredentials {
    
    public string ClientId { get; set; }

    public string ClientSecret { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string SandboxEndPoint { get; set; }
    public string BaseUrl { get; set; }
    public string CreateJobRequestUrl { get; set; }

    public ApiCredentials()
    {
        ClientId = "3MVG9r_yMkYxwhkinmWiRQeC9UfZ1BvacYHjjLmjCJoFnLsOamEiXUu9XCO.cqX9_A5MYxgOz7yzLOuzIzoMD";
        ClientSecret = "460AF19E91F4044834B7AD7590F8EECEDDC9F237771C65E7E0B750A48D9BDA06";
        Username = "devtest@ggmgastro.com.saptest";
        Password = "#AcNYQ$dv2*sV5Swh8";
        SandboxEndPoint = "https://test.salesforce.com/services/oauth2/token";
        BaseUrl = "https://login.salesforce.com/services/oauth2/token";
        CreateJobRequestUrl = "https://ggmgastro--saptest.sandbox.my.salesforce.com/services/data/v57.0/jobs/ingest";
    }
}