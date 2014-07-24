using System.Collections.Generic;

namespace NewRelicCleanup.Model
{
    public class Summary
    {
        public double cpu { get; set; }
        public int cpu_stolen { get; set; }
        public double disk_io { get; set; }
        public double memory { get; set; }
        public object memory_used { get; set; }
        public object memory_total { get; set; }
        public double fullest_disk { get; set; }
        public object fullest_disk_free { get; set; }
    }

    public class Server
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public string name { get; set; }
        public string host { get; set; }
        public bool reporting { get; set; }
        public string last_reported_at { get; set; }
        public Summary summary { get; set; }
    }

    public class RootObject
    {
        public List<Server> servers { get; set; }
    }
}