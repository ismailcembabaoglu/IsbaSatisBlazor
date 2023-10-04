﻿using IsbaSatisBlazor.Shared.CustomExceptions;
using IsbaSatisBlazor.Shared.ResponseModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace IsbaSatisBlazor.Client.Utils
{
    public static class HttpClientExtension
    {
        public async static Task<TResult> PostGetServiceResponseAsync<TResult, TValue>(this HttpClient Client, String Url, TValue Value, string token, bool ThrowSuccessException = false)
        {
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res.Value;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }

        public async static Task<BaseResponse> PostGetBaseResponseAsync<TValue>(this HttpClient Client, String Url, TValue Value, string token, bool ThrowSuccessException = false)
        {
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<BaseResponse>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }


        public async static Task<T> GetServiceResponseAsync<T>(this HttpClient Client, String Url, string token, bool ThrowSuccessException = false)
        {
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token.Replace("\"",""));
            var httpRes = await Client.GetFromJsonAsync<ServiceResponse<T>>(Url);

            return !httpRes.Success && ThrowSuccessException ? throw new ApiException(httpRes.Message) : httpRes.Value;
        }
    }
}
