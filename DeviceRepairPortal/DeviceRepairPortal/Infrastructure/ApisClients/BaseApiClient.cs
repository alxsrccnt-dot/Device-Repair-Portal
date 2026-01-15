using FluentResults;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace DeviceRepairPortal.Infrastructure.ApisClients;

public class BaseApiClient
{
    private readonly string _baseAddress;
    private readonly HttpClient _httpClient;

    public BaseApiClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient = client;
        _baseAddress = client.BaseAddress.AbsoluteUri;
    }

    public async Task<TRs> GetAsync<TRs>(string path)
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}{path}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TRs>(content);
        }

        throw new Exception($"Failed to call get. Request: {path} StatusCode:{response.StatusCode} Error:{await response.Content.ReadAsStringAsync()}");
    }

    public async Task<TRs> PostAsync<TRq, TRs>(string path, TRq request)
    {
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var requestString = JsonConvert.SerializeObject(request, jsonSerializerSettings);
        var response = await _httpClient.PostAsync($"{_baseAddress}{path}", new StringContent(requestString, Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TRs>(content, jsonSerializerSettings);
        }

        throw new Exception($"Failed to call post. Path: {path} RequestBody: {requestString} StatusCode:{response.StatusCode} Error: {await response.Content.ReadAsStringAsync()}");
    }

    public async Task<Result<TRs>> PostAsync<TRs>(string path)
    {
        var jsonSerializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        var response = await _httpClient.PostAsync($"{_baseAddress}{path}", new StringContent("application/json"));

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TRs>(content, jsonSerializerSettings);
            return Result.Ok(result);
        }

        if (IsClientError(response.StatusCode))
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<string>(content, jsonSerializerSettings);
            return Result.Fail(result);
        }

        throw new Exception($"Failed to call post. Path: {path} StatusCode:{response.StatusCode} Error: {await response.Content.ReadAsStringAsync()}");
    }

    public async Task<Result> DeleteAsync(string path)
    {
        var response = await _httpClient.DeleteAsync($"{_baseAddress}{path}");

        if (response.IsSuccessStatusCode)
        {
            return Result.Ok();
        }

        var errorContent = await response.Content.ReadAsStringAsync();
        if (IsClientError(response.StatusCode))
        {
            return Result.Fail(errorContent);
        }

        throw new Exception($"Failed to call DELETE. Path: {path} StatusCode:{response.StatusCode} Error: {errorContent}");
    }

    private static bool IsClientError(HttpStatusCode statusCode)
    {
        return statusCode is >= HttpStatusCode.BadRequest and <= HttpStatusCode.TooManyRequests;
    }
}