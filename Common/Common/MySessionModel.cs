using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common
{
    public class MySessionModel
    {
        public string Id { get; set; }
        public byte[] Value { get; set; }
        public DateTime ExpiresAtTime { get; set; }
        public double SlidingExpirationInSeconds { get; set; }
        public DateTime AbsoluteExpiration { get; set; }
    }
}
