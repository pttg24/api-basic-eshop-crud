using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEshopCrud.Api.AcceptanceTests.Drivers;

public class BasicEshopCrudApiDriver
{
    private readonly HttpClient _client;

    public BasicEshopCrudApiDriver(HttpClient client)
    {
        _client = client;
    }

    public static void ConfigureClient(BasicEshopCrudApiOptions options, HttpClient client)
    {
        client.BaseAddress = new Uri(options.Uri!);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new("application/json"));
    }

    public HttpRequestMessage CreatePostRequest(string requestBody)
    {
        return new HttpRequestMessage(HttpMethod.Post, "v1/payment-details")
        {
            Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
        };
    }

    public async Task<HttpResponseMessage> SendRequest(HttpRequestMessage message)
    {
        return await _client.SendAsync(message);
    }
}
