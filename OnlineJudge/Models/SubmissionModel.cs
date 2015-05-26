using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJudge.Models
{
    public class SubmissionModel
    {
        public int SubmissionID { get; set; }
        public string Email{get;set;}
        public string UserName{ get; set; }
        public int ProblemId{get;set;}
        public int score { get; set; }

        public string SourceCodeFilePath{get;set;}

        public string Verdict{get;set;}
        public string TestCaseResultFilePath{get;set;}
    }
}