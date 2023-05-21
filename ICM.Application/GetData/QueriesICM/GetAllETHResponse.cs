﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.QueriesICM
{
    public class GetAllETHResponse
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public string hash { get; set; }
        public string time { get; set; }
        public string latest_url { get; set; }
        public string previous_hash { get; set; }
        public string previous_url { get; set; }
        public int peer_count { get; set; }
        public int unconfirmed_count { get; set; }
        public long high_gas_price { get; set; }
        public long medium_gas_price { get; set; }
        public long low_gas_price { get; set; }
        public long high_priority_fee { get; set; }
        public int medium_priority_fee { get; set; }
        public int low_priority_fee { get; set; }
        public long base_fee { get; set; }
        public int last_fork_height { get; set; }
        public string last_fork_hash { get; set; }
        public DateTime created_at { get; set; }
    }
}
