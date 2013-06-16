﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AppReadyGo.API.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using AppReadyGo.API.Models.Analytics;
using AppReadyGo.API.Controllers;
using AppReadyGo.Common;
using AppReadyGo.API.Models.Market;

namespace AppReadyGo.API.Tests.Controllers
{
    [TestClass]
    public class MarketClientTest
    {
#if QA
        static readonly Uri _baseAddress = new Uri("http://api.qa.appreadygo.com/market/");
#elif DEBUG
        static readonly Uri _baseAddress = new Uri("http://localhost:63321/market/");
#else
        static readonly Uri _baseAddress = new Uri("http://api.appreadygo.com/market/");
#endif


        [TestMethod]
        public void MarketGetSettingsByNetwork()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = client.GetAsync("getsettings").Result;
            if (!response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync();
                Assert.Fail(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
            else
            {
                var res = response.Content.ReadAsStringAsync();
                //Assert.IsTrue(res.Result);
            }
        }

        [TestMethod]
        public void MarketLoginByNetwork()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var data = new LoginModel { Email = "test@test.com", Password = "1234" };

            var response = client.PostAsJsonAsync("login", data).Result;
            if (!response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync();
                Assert.Fail(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
            else
            {
                var res = response.Content.ReadAsAsync<UserResultModel>().Result;
                Assert.AreEqual(res.Code, UserResultModel.Result.WrongUserNamePassword);
            }
        }

        [TestMethod]
        public void MarketRegisterByNetwork()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var data = new UserModel { ContryId = 1, Email = "ypanshin@gmail.com", FirstName = "xxx", Password = "121" };

            var task = client.PostAsJsonAsync("register", data);
            var response = task.Result;
            if (!response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync();
                Assert.Fail(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
            else
            {
                var res = response.Content.ReadAsAsync<bool>();
                Assert.IsTrue(res.Result);
            }
        }

        [TestMethod]
        public void MarketThirdPartyRegisterByNetwork()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var data = new ThirdPartyUserModel { ContryId = 1, Email = "ypanshin@gmail.com", FirstName = "xxx" };

            var task = client.PostAsJsonAsync("thirdpartyregister", data);
            var response = task.Result;
            if (!response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                Assert.Fail(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
            else
            {
                var res = response.Content.ReadAsAsync<bool>();
                Assert.IsTrue(res.Result);
            }
        }

        [TestMethod]
        public void MarketGetAppsByNetwork()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var response = client.GetAsync("GetApps/?email=some&curPage=1&pageSize=10").Result;
            if (!response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync();
                Assert.Fail(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
            }
            else
            {
                var res = response.Content.ReadAsStringAsync();
                //Assert.IsTrue(res.Result);
            }
        }
    }
}
