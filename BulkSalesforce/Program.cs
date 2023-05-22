// See https://aka.ms/new-console-template for more information

using BulkSalesforce;

BSfClient bSfClient = new BSfClient();

string token = await bSfClient.GetSalesforceToken();
string test = await  bSfClient.CreateJob(token);