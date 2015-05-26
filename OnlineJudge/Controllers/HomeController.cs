using OnlineJudge.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using OnlineJudge;
using System.Web.Security;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Management;

namespace OnlineJudge.Controllers
{
    public class HomeController : Controller
    {
        
        //
        // GET: /Home/
        public ActionResult Index()
        {

            //Judge.RunCmd();
            //string[] lines = System.IO.File.ReadAllLines(System.AppDomain.CurrentDomain.BaseDirectory+"/../Problems/1001.txt");
            return View();
        }

        //
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginAuthorModel author,string returnurl)
         {
            
            if (ModelState.IsValid)
            {
                string query = "Select * from onlinejudge.author where Email = '"+
                    author.Email+"';";
                //MySqlDataReader datareader =ConnnectDatabase.ExecQuery(query);
                //if(datareader.Read()==false)
                var dt = ConnnectDatabase.QueryDataTable(query);
                if(dt == null || dt.Rows.Count == 0)
                {
                    ModelState.AddModelError("Email", "The user name hasn't be registered.");
                    return View(author);
                }
                query = "Select * from onlinejudge.author where Email = '" +
                    author.Email + "' and Password = '"+author.Password+"';";
                //datareader = ConnnectDatabase.ExecQuery(query);
                //if (datareader.Read() == false)
                if (dt == null || dt.Rows.Count == 0)
              
                {
                    ModelState.AddModelError("Password", "The user name or password provided is incorrect.");
                    return View(author);
                }
                //FormsAuthentication.SetAuthCookie(author.Email, true);
                Session["Email"] = author.Email;
                Session["Password"] = author.Password;
                Session["UserName"] = dt.Rows[0]["Name"];
                //Session["UserName"]= datareader["Name"];
                //datareader.Close();
                if(String.IsNullOrEmpty(returnurl))
                {
                    return RedirectToAction("Domains","Problem");
                }
                return RedirectToAction(returnurl);
            }

            return View(author);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(AuthorModel author)
        {
            
            if (ModelState.IsValid)
            {
                //电子邮箱没有注册过
                string query = "Select * from onlinejudge.author where Email = '" +
                    author.Email + "';";
                MySqlDataReader datareader = ConnnectDatabase.ExecQuery(query);
                if (datareader.Read() == true)
                {
                    ModelState.AddModelError("Email", "The user name has been registered.");
                    return View(author);
                }
                //插入数据库
                query = @"insert into onlinejudge.author
values('','"+author.Email+"','"+author.Password+"','"+author.UserName+"',0,now(),now());";
                ConnnectDatabase.ExecSql(query);
                //FormsAuthentication.SetAuthCookie(author.UserName, false /* createPersistentCookie */);
                
                
                Response.Cookies["userName"].Value = author.UserName;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);


                Session["Email"] = author.Email;
                Session["Password"] = author.Password;
                Session["UserName"] = author.UserName;
                return RedirectToAction("Index");
            }

            return View(author);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            HttpCookie cookie = Response.Cookies["userName"];
            //HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];
            //cookie.Domain = cookie.Domain;
            cookie.Value = null;
            cookie.Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Home");
        }

        
	}
}