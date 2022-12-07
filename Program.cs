using TestServer.Client;
try
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri("http://localhost:10000/graphql");

    var client = new TestServerGraphQLClient(httpClient);

    var response = await client.Query(static o => o.Me(o => new { o.Id, o.FirstName, o.LastName }));

    Console.WriteLine($"GraphQL: {response.Query}"); // GraphQL: query { me { id firstName lastName } }
    Console.WriteLine($"{response.Data.Id}: {response.Data.FirstName} {response.Data.LastName}"); // 1: Jon Smith
}catch(Exception e)
{
    Console.WriteLine(e);
}