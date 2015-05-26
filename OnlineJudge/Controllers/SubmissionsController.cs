using OnlineJudge.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJudge.Controllers
{
    public class SubmissionsController : Controller
    {
        //
        // GET: /Submissions/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult mysubmissions(int problemId)
        {
            ViewBag.ProblemId = problemId;
            if(string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home", new  { returnurl = Request.QueryString["ReturnUrl"] });
            }
            string query = "Select * from onlinejudge.submission where ProblemID = '" +
                problemId + "' and Email = '"+Session["Email"]+"' group by Email;";
            DataTable dt = new DataTable();
            dt = ConnnectDatabase.QueryDataTable(query);
            int len = dt.Rows.Count;
            List<SubmissionModel> submissions = new List<SubmissionModel>();
            for (int i = 0; i < len; i++)
            {
                SubmissionModel submission = new SubmissionModel();

                submission.SubmissionID = Convert.ToInt32(dt.Rows[i]["SubmissionID"]);
                submission.ProblemId = Convert.ToInt32(dt.Rows[i]["ProblemId"]);
                submission.Email = Convert.ToString(dt.Rows[i]["Email"]);
                submission.UserName = Session["UserName"].ToString();
                submission.Verdict = Convert.ToString(dt.Rows[i]["Verdict"]);
                submission.SourceCodeFilePath = Convert.ToString(dt.Rows[i]["SourceCodeFilePath"]);
                submission.score = Convert.ToInt32(dt.Rows[i]["Score"]);
                submission.TestCaseResultFilePath = Convert.ToString(dt.Rows[i]["TestCaseResultFilePath"]);
                submissions.Add(submission);
            }
            return View(submissions);
        }

        public ActionResult otherssubmissions(int problemId)
        {
            ViewBag.ProblemId = problemId;
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home", new { returnurl = Request.QueryString["ReturnUrl"] });
            }
            string query = "Select * from onlinejudge.submission where ProblemID = '" +
                problemId + "' and Email != '" + Session["Email"] + "' group by Email;";
            DataTable dt = new DataTable();
            dt = ConnnectDatabase.QueryDataTable(query);

            int len = dt.Rows.Count;
            List<SubmissionModel> submissions = new List<SubmissionModel>();
            for (int i = 0; i < len; i++)
            {
                SubmissionModel submission = new SubmissionModel();

                submission.SubmissionID = Convert.ToInt32(dt.Rows[i]["SubmissionID"]);
                submission.ProblemId = Convert.ToInt32(dt.Rows[i]["ProblemId"]);
                submission.Email = Convert.ToString(dt.Rows[i]["Email"]);
                submission.UserName = Session["UserName"].ToString();
                submission.Verdict = Convert.ToString(dt.Rows[i]["Verdict"]);
                submission.SourceCodeFilePath = Convert.ToString(dt.Rows[i]["SourceCodeFilePath"]);
                submission.score = Convert.ToInt32(dt.Rows[i]["Score"]);
                submission.TestCaseResultFilePath = Convert.ToString(dt.Rows[i]["TestCaseResultFilePath"]);
                submissions.Add(submission);
            }
            return View(submissions);
        }



        public FileStreamResult DownFile(int SubmissionID)
        {
            string absoluFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions/" + SubmissionID.ToString() + ".cpp"; ;
            return File(new FileStream(absoluFilePath, FileMode.Open), "application/octet-stream", Server.UrlEncode(SubmissionID.ToString()+".cpp"));
        }

    
	}
}