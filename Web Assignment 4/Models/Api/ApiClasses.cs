﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment_4.Models.Api
{

    public class ApiRootobject
    {
        public Meta meta { get; set; }
        public List<FoodApiObject> results { get; set; }
    }

    public class Meta
    {
        public string disclaimer { get; set; }
        public string terms { get; set; }
        public string license { get; set; }
        public string last_updated { get; set; }
        public Results results { get; set; }
    }

    public class Results
    {
        public int skip { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class FoodApiObject
    {
        public string country { get; set; }
        public string city { get; set; }
        public string address_1 { get; set; }
        public string reason_for_recall { get; set; }
        public string address_2 { get; set; }
        public string product_quantity { get; set; }
        public string code_info { get; set; }
        public string center_classification_date { get; set; }
        public string distribution_pattern { get; set; }
        public string state { get; set; }
        public string product_description { get; set; }
        public string report_date { get; set; }
        public string report_date1 => report_date.Insert(4,"-").Insert(7,"-"); 
        public string classification { get; set; }
        public string recalling_firm { get; set; }
        public string recall_number { get; set; }
        public string initial_firm_notification { get; set; }
        public string product_type { get; set; }
        public string event_id { get; set; }
        public string termination_date { get; set; }
        public string more_code_info { get; set; }
        public string recall_initiation_date { get; set; }
        public string postal_code { get; set; }
        public string voluntary_mandated { get; set; }
        public string status { get; set; }
    }

   
}
