﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.CreateICM
{
    public class CreateBTCRequest : IRequest<int>
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
        public int high_fee_per_kb { get; set; }
        public int medium_fee_per_kb { get; set; }
        public int low_fee_per_kb { get; set; }
        public int last_fork_height { get; set; }
        public string last_fork_hash { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now.ToLocalTime();
    }
}
