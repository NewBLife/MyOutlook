// ***********************************************************************
// FileName:EmailUtility
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/12 13:27:58
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MyOutlook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyOutlook
{
    public class EmailUtility
    {
        private static JsonSerializer serializer = new JsonSerializer()
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        };
        /// <summary>
        /// 执行API
        /// </summary>
        /// <param name="url">API地址</param>
        /// <param name="method">请求方式</param>
        /// <returns>请求结果</returns>
        private static async Task<byte[]> ExcuteApi(string url, HttpMethod method)
        {
            var httpclient = new HttpClient();

            using (var request = new HttpRequestMessage(method, url))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(App.Authentication.TokenType, App.Authentication.Token);

                using (var response = await httpclient.SendAsync(request).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 邮件一览取得
        /// </summary>
        /// <returns>邮件一览</returns>
        public static async Task<List<Message>> GetListAsync()
        {
            var listData = await ExcuteApi(Constants.MESSAGES_LIST, HttpMethod.Get);
            if (listData?.Length > 0)
            {
                var listObject = JObject.Parse(System.Text.Encoding.UTF8.GetString(listData, 0, listData.Length));
                var list = new List<Message>();

                foreach (var item in listObject["value"])
                {
                    list.Add(item.ToObject<Message>(serializer));
                }
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
