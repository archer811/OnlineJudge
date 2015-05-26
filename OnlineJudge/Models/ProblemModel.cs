using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJudge.Models
{
    public class ProblemModel
    {
        public int ProblemId { get; set; }
        public int kind { get; set; }
        public string Title { get; set; }
        public string ProblemdescriptionFilePath { get; set; }
        public int score { get;set;}
        public int TotalSubmissions { get; set; }
        public int TotalAcs { get; set; }
        public string[] ProblemFile { get; set; }
    }
}