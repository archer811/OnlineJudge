using OnlineJudge.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJudge.Controllers
{
    public class ProblemController : Controller
    {
        //
        // GET: /Problem/
        public ActionResult Domains()
        {
            return View();
        }

        public ActionResult Algorithms(string kind)
        {
            ViewBag.kind = kind;

            int Kind = 0;
            switch(kind)
            {
                case "String": 
                    Kind=0;
                    break;
                case "Number_Theory":
                    Kind = 1;
                    break;
            }

            string query = "Select * from onlinejudge.problem where kind = '" +
                Kind + "';";
            DataTable dt = new DataTable();
            dt = ConnnectDatabase.QueryDataTable(query);
            int len = dt.Rows.Count;
            List<ProblemModel> problems = new List<ProblemModel>();
            for (int i = 0; i < len;i++ )
            {
                ProblemModel problem = new ProblemModel();

                problem.ProblemId = Convert.ToInt32(dt.Rows[i]["ProblemId"]);
                problem.kind = Convert.ToInt32(dt.Rows[i]["Kind"]);
                problem.Title = Convert.ToString(dt.Rows[i]["Title"]);
                problem.ProblemdescriptionFilePath = Convert.ToString(dt.Rows[i]["ProblemdescriptionFilePath"]);
                problem.score = Convert.ToInt32(dt.Rows[i]["Score"]);
                problem.TotalSubmissions = Convert.ToInt32(dt.Rows[i]["TotalSubmissions"]);
                problem.TotalAcs = Convert.ToInt32(dt.Rows[i]["TotalAcs"]);
                problems.Add(problem);
            }
            return View(problems);
        }


        public ActionResult Problem(int problemId)
        {
            string query = "Select * from onlinejudge.problem where ProblemID = '" +
                problemId + "';";
            DataTable dt = new DataTable();
            dt = ConnnectDatabase.QueryDataTable(query);
            ProblemModel problem = new ProblemModel();

             problem.ProblemId = Convert.ToInt32(dt.Rows[0]["ProblemId"]);
            problem.kind = Convert.ToInt32(dt.Rows[0]["Kind"]);
            problem.Title = Convert.ToString(dt.Rows[0]["Title"]);
            problem.ProblemdescriptionFilePath = Convert.ToString(dt.Rows[0]["ProblemdescriptionFilePath"]);
            problem.ProblemdescriptionFilePath = System.AppDomain.CurrentDomain.BaseDirectory + problem.ProblemdescriptionFilePath;
            problem.score = Convert.ToInt32(dt.Rows[0]["Score"]);
            problem.TotalSubmissions = Convert.ToInt32(dt.Rows[0]["TotalSubmissions"]);
            problem.TotalAcs = Convert.ToInt32(dt.Rows[0]["TotalAcs"]);
            problem.ProblemFile = System.IO.File.ReadAllLines(problem.ProblemdescriptionFilePath);
            return View(problem);
        }


        /// <summary>
        /// 上传文件
        /// </summary>

        public void Upload(HttpPostedFileBase[] fileToUpload)
        {
            foreach (HttpPostedFileBase file in fileToUpload)
            {


                string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions", "RWWTDWESDES");
                //System.IO.Path.GetFileName(file.FileName)
                file.SaveAs(path);

                
            }
            
        }


        /// <summary>
        /// 编译运行文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult ProgressSubmission(int problemId)
        {
            if(string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home", new {returnurl=Request.QueryString["ReturnUrl"] });
            }
            string query = "Select ifnull(max(SubmissionID),0) from onlinejudge.submission;";
            DataTable dt = new DataTable();
            dt = ConnnectDatabase.QueryDataTable(query);


            int SubmissionID = Convert.ToInt32(dt.Rows[0][0]);

            SubmissionID++;

            //获得submissionID之后,把上传的文件复制给以submissionID命名的cpp
            String sourcePath = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions/RWWTDWESDES";
            String targetPath = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions/" + SubmissionID.ToString() + ".cpp";
            bool isrewrite = true; // true=覆盖已存在的同名文件,false则反之
            System.IO.File.Copy(sourcePath, targetPath, isrewrite);

            //获取authorid
            query = "select authorid from onlinejudge.author where Email = '" + Session["Email"] + "' and Password = '" + Session["Password"] + "';";
            dt = ConnnectDatabase.QueryDataTable(query);
            int authroId = Convert.ToInt32(dt.Rows[0][0]);
            //获取此题的分数
            query = "select score from onlinejudge.problem where ProblemID = '" + problemId + "';";
            dt = ConnnectDatabase.QueryDataTable(query);
            int score = Convert.ToInt32(dt.Rows[0][0]);

            //Process类，编译代码，运行代码，输入输入数据，结果记录在一个字符串里面
            RunCode.CompileCode(SubmissionID.ToString());
            string Result = RunCode.RunCodeGetResult(SubmissionID.ToString(), problemId, SubmissionID);
            string finalResult = RunCode.CompareResult(Result, problemId, SubmissionID);
 
            int TotalAcs_add = 0;
            //对比结果字符串和输出数据,对比结果写入文件，判定程序结果
            if (finalResult.CompareTo("WrongAnswer") == 0) 
            {
                score = 0;
                
            }
            else
            {
                TotalAcs_add = 1;
            }
                

            //将提交插入数据库
            string SourceCodeFilePath = "../Submissions/" + SubmissionID.ToString() + ".cpp";
            string ResultFilePath = "../Submissions/" + SubmissionID.ToString() + "_result.txt";
            query = @"insert into  `OnlineJudge`.`submission`()
values(" + SubmissionID + "," + authroId + ",'" + Session["Email"] + "'," + problemId + ",'" + SourceCodeFilePath + "',now()," + 0 + ",'" + finalResult + "'," + score + ",'" + ResultFilePath + "',now(),now());";
            ConnnectDatabase.ExecSql(query);
            //Problem表里面更新数据


            query = @"update onlinejudge.problem set TotalSubmissions = TotalSubmissions+1 , 
TotalAcs = TotalAcs + " + TotalAcs_add + " where problemid = "+problemId;
            ConnnectDatabase.ExecSql(query);





            Result result = new Result();
            result.outputfile = "../Submissions/" + SubmissionID.ToString() + ".txt";
            result.answerfile = "../Problems/" + problemId.ToString() + "/" + problemId.ToString() + "_output.txt";
            result.resultfile = "../Submissions/" + SubmissionID.ToString() + "_result.txt";
            result.Verdict = finalResult;
            return PartialView("ProgressSubmission", result);
        }
	
    
       
    }
}