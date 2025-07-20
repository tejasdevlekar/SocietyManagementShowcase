using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Common
{
    public class MySession
    {   
        private readonly Dictionary<string, byte[]> _sessionData;

        public MySession()
        {
            _sessionData = new Dictionary<string, byte[]>();
        }

        public MySession(string key, dynamic value)
        {
            _sessionData = new Dictionary<string, byte[]>();

            Set(key, value);
        }
        public void Set(string key, dynamic value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty", nameof(key));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null");
            }

            byte[] serializedValue = JsonSerializer.SerializeToUtf8Bytes(value);

            _sessionData[key] = serializedValue;
        }

        public dynamic Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty", nameof(key));
            }

            if (_sessionData.TryGetValue(key, out byte[] value))
            {
                var deserializedValue = JsonSerializer.Deserialize<dynamic>(value);
                return deserializedValue;
            }
            else
            {
                throw new KeyNotFoundException($"No session data found for key: {key}");
            }
        }

        public byte[] GetSession()
        {
            var serializedSession = JsonSerializer.SerializeToUtf8Bytes(_sessionData);
            return serializedSession;
        }

        public void SetSession(byte[] sessionData)
        {
            if (sessionData == null || sessionData.Length == 0)
            {
                throw new ArgumentNullException(nameof(sessionData), "Session data cannot be null or empty");
            }
            _sessionData.Clear();
            var deserializedSession = JsonSerializer.Deserialize<Dictionary<string, byte[]>>(sessionData);
            foreach (var kvp in deserializedSession)
            {
                _sessionData[kvp.Key] = kvp.Value;
            }
        }

        public bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty", nameof(key));
            }
            return _sessionData.Remove(key);
        }




    }
}
