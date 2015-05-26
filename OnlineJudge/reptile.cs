using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace OnlineJudge
{
    public class reptile
    {
        public void reptitle()
        {
            var httpRequest = (HttpWebRequest)System.Net.WebRequest.Create("http://acm.hust.edu.cn/vjudge/problem/submit.action");
            httpRequest.Method = "POST";
            httpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36";
            httpRequest.Headers.Add("Cookie", "_ga=GA1.3.538718919.1423037518; _ga=GA1.4.538718919.1423037518; hoj=42sevoftmpla4dfb2lb8sfd4q2; JSESSIONID=3ABC539B54334D6F37C316C050B7B37A; twgdh=cloris; btzhy=MVWPDYXGM2NYU5NQWWY5J8PCUM7G4D");

            string input = @"";


            byte[] data = Encoding.UTF8.GetBytes("language=3&isOpen=0&source=I2luY2x1ZGU8aW9zdHJlYW0%2BCiNpbmNsdWRlPGNzdGRpbz4KI2luY2x1ZGU8Y3N0cmluZz4KI2luY2x1ZGU8Y21hdGg%2BCiNpbmNsdWRlPHF1ZXVlPgojaW5jbHVkZTxzdGFjaz4KI2luY2x1ZGU8YWxnb3JpdGhtPgojaW5jbHVkZTxzZXQ%2BCnVzaW5nIG5hbWVzcGFjZSBzdGQ7CiNkZWZpbmUgbGwgbG9uZyBsb25nCmxsIGdjZChsbCBhLGxsIGIpCnsKICAgIGlmKGI9PTApcmV0dXJuIGE7CiAgICByZXR1cm4gZ2NkKGIsYSViKTsKfQppbnQgbWFpbigpCnsKICAgIGludCBpLGo7CiAgICBsbCBhLGI7CiAgICBpbnQgY2FzPTA7CiAgICBpbnQgdDsKICAgIGNpbj4%2BdDsKICAgIHdoaWxlKHQtLSkKICAgIHsKICAgICAgICBzY2FuZigiJWxsZCVsbGQiLCZhLCZiKTsKICAgICAgICBsbCBjID0gZ2NkKGEsYik7CiAgICAgICAvLyBjb3V0PDxhK2I8PCIgIjw8Yzw8ZW5kbDsKICAgICAgICBwcmludGYoIkNhc2UgJWQ6ICVsbGRcbiIsKytjYXMsKGErYikvZ2NkKGEsYikpOwogICAgfQp9&id=27918");
            //byte[] data = Encoding.UTF8.GetBytes("language=3&isOpen=0&source=intmain()");

            httpRequest.GetRequestStream().Write(data, 0, data.Length);
            var httpResponse = httpRequest.GetResponse();
            var url = httpResponse.Headers["Location"];
            



           //var httpRequest = (HttpWebRequest)System.Net.WebRequest.Create("http://acm.hust.edu.cn/vjudge/problem/fetchStatus.action");
           //httpRequest.Method = "POST";
           //httpRequest.Accept = "application/json, text/javascript, */*; q=0.01";
           //httpRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
           //httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36";

           // httpRequest.Headers.Add("Origin", "http://acm.hust.edu.cn");
           // httpRequest.Headers.Add("Cookie", "_ga=GA1.3.538718919.1423037518; twgdh=cloris; btzhy=MVWPDYXGM2NYU5NQWWY5J8PCUM7G4D; lang_UVA=3; JSESSIONID=2B36B8666A17269EDFBA3F96BDD1A87E; _gat=1; _ga=GA1.4.538718919.1423037518");



            //byte[] data = Encoding.UTF8.GetBytes("draw=1&columns%5B0%5D%5Bdata%5D=0&columns%5B0%5D%5Bname%5D=&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D%5Borderable%5D=false&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=1&columns%5B1%5D%5Bname%5D=&columns%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=false&columns%5B1%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B2%5D%5Bdata%5D=2&columns%5B2%5D%5Bname%5D=&columns%5B2%5D%5Bsearchable%5D=true&columns%5B2%5D%5Borderable%5D=false&columns%5B2%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B2%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B3%5D%5Bdata%5D=3&columns%5B3%5D%5Bname%5D=&columns%5B3%5D%5Bsearchable%5D=true&columns%5B3%5D%5Borderable%5D=false&columns%5B3%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B3%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B4%5D%5Bdata%5D=4&columns%5B4%5D%5Bname%5D=&columns%5B4%5D%5Bsearchable%5D=true&columns%5B4%5D%5Borderable%5D=false&columns%5B4%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B4%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B5%5D%5Bdata%5D=5&columns%5B5%5D%5Bname%5D=&columns%5B5%5D%5Bsearchable%5D=true&columns%5B5%5D%5Borderable%5D=false&columns%5B5%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B5%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B6%5D%5Bdata%5D=6&columns%5B6%5D%5Bname%5D=&columns%5B6%5D%5Bsearchable%5D=true&columns%5B6%5D%5Borderable%5D=false&columns%5B6%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B6%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B7%5D%5Bdata%5D=7&columns%5B7%5D%5Bname%5D=&columns%5B7%5D%5Bsearchable%5D=true&columns%5B7%5D%5Borderable%5D=false&columns%5B7%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B7%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B8%5D%5Bdata%5D=8&columns%5B8%5D%5Bname%5D=&columns%5B8%5D%5Bsearchable%5D=true&columns%5B8%5D%5Borderable%5D=false&columns%5B8%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B8%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B9%5D%5Bdata%5D=9&columns%5B9%5D%5Bname%5D=&columns%5B9%5D%5Bsearchable%5D=true&columns%5B9%5D%5Borderable%5D=false&columns%5B9%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B9%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B10%5D%5Bdata%5D=10&columns%5B10%5D%5Bname%5D=&columns%5B10%5D%5Bsearchable%5D=true&columns%5B10%5D%5Borderable%5D=false&columns%5B10%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B10%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B11%5D%5Bdata%5D=11&columns%5B11%5D%5Bname%5D=&columns%5B11%5D%5Bsearchable%5D=true&columns%5B11%5D%5Borderable%5D=false&columns%5B11%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B11%5D%5Bsearch%5D%5Bregex%5D=false&order%5B0%5D%5Bcolumn%5D=0&order%5B0%5D%5Bdir%5D=desc&start=0&length=20&search%5Bvalue%5D=&search%5Bregex%5D=false&un=cloris&OJId=UVA&probNum=&res=0&language=&orderBy=run_id");
          // httpRequest.GetRequestStream().Write(data,0,data.Length);
         //  var httpResponse = httpRequest.GetResponse();
           //string response = string.Empty;
           //using (var memoryStream = new System.IO.MemoryStream())
           //{
           //    httpResponse.GetResponseStream().CopyTo(memoryStream);
           //    response = Encoding.UTF8.GetString(memoryStream.ToArray());
           //}
           //var json = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(response);
           //var row = json["data"][0];

        }
    }
}