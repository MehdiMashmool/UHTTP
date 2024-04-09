using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

namespace UHTTP.Sample.OpenAIAssistant
{
    public static class OpenAIAssistantProvider
    {
        private const string baseURL = "https://api.openai.com/v1/";

        private const string ACCESS_TOKEN = "OPEN-AI-KEY";

        private static List<KeyValuePair<string, string>> Headers = new List<KeyValuePair<string, string>>()
        {
            HTTPHeaderHelper.ContentType,
            new KeyValuePair<string, string>("OpenAI-Beta", "assistants=v1")
        };

        public static void Initialize() =>
            JWTTokenResolver.SetAccessToken(ACCESS_TOKEN);


        public static void CreateAssistant(CreateAssistantDTO data, Action<UnityWebRequest> callback) =>
            new HTTPRequestData()
            {
                URL = baseURL + "assistants",
                Method = UnityWebRequest.kHttpVerbPOST,
                BodyJson = JsonUtility.ToJson(data),
                Headers = Headers,
                HaveAuth = true
            }.CreateRequest(callback).Send();

        public static void CreateThread(Action<UnityWebRequest> callback) =>
            new HTTPRequestData()
            {
                URL = baseURL + "threads",
                Method = UnityWebRequest.kHttpVerbPOST,
                Headers = Headers,
                HaveAuth = true
            }.CreateRequest(callback).Send();

        public static void AddMessageToThread(string threadId, AddMessageToThreadDTO data, Action<UnityWebRequest> callback) =>
            new HTTPRequestData()
            {
                URL = baseURL + "threads/" + threadId + "/messages",
                Method = UnityWebRequest.kHttpVerbPOST,
                BodyJson = JsonUtility.ToJson(data),      
                Headers = Headers,
                HaveAuth = true
            }.CreateRequest(callback).Send();


        public static void AddAssistantToThreadDTO(string threadId, AddAssistantToThreadDTO data, Action<UnityWebRequest> callback) =>
            new HTTPRequestData()
            {
                URL = baseURL + "threads/" + threadId + "/runs",
                Method = UnityWebRequest.kHttpVerbPOST,
                BodyJson = JsonUtility.ToJson(data),
                Headers = Headers,
                HaveAuth = true
            }.CreateRequest(callback).Send();

        
        public static void GetMessagesThread(string threadId, AddAssistantToThreadDTO data, Action<UnityWebRequest> callback) =>
            new HTTPRequestData()
            {
                URL = baseURL + "threads/" + threadId + "/messages",
                Method = UnityWebRequest.kHttpVerbGET,
                Headers = Headers,
                HaveAuth = true
            }.CreateRequest(callback).Send();
    }
}