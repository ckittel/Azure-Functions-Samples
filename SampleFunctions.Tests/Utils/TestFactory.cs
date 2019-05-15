using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace SampleFunctions.Tests
{
    public static class TestFactory
    {
        public static DefaultHttpRequest CreateHttpRequest(string queryStringKey, string queryStringValue)
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Query = new QueryCollection(CreateDictionary(queryStringKey, queryStringValue))
            };
            return request;
        }

        public static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };
            return qs;
        }

        public static TimerSchedule CreateTimerSchedule(int minutes)
        {
            return new UnitTestTimerSchedule(minutes);
        }



        public static ListLogger CreateLogger()
        {
            return new ListLogger();
        }
    }

    public class UnitTestTimerSchedule : TimerSchedule
    {
        private readonly int _minutes;

        public UnitTestTimerSchedule(int minutes)
        {
            _minutes = minutes;
        }


        public override DateTime GetNextOccurrence(DateTime now)
        {
            return now.AddMinutes(_minutes);
        }
    }
}
