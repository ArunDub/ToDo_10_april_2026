using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class MessageBuilder
    {
        //public static string BuildExceptionMessage(HttpContext context,Exception ex)
        //{
        //    var msgBuilder = new StringBuilder();
        //    msgBuilder.AppendLine($"<h1>Message:{ex.Message}</h1>");
        //    msgBuilder.AppendLine(context.User.Identity.IsAuthenticated
        //   ?$"Source:{ex.Source} User:{ context.User.Identity.Name}<h1/>"
        //   :$"source{ ex.Source}<h1/>");
        //    msgBuilder.AppendLine($"Request Path:{context.Request.Path}<h1/>");
        //    msgBuilder.AppendLine($"QueryString:{context.Request.QueryString}<h1/>");
        //    if(ex.StackTrace!=null)
        //    {
        //        msgBuilder.AppendLine($"StackTrace:{ex.StackTrace.Replace(Environment.NewLine, "<br/>")}<hr/>");
        //    }
        //    if(ex.InnerException!=null)
        //    {
        //        msgBuilder.AppendLine($"Inner Exception<hr/>:{ex.InnerException?.Message.Replace(Environment.NewLine,) });
        //    }
        //    if(context.Request.HasFormContentType && context.Request.Form !=null && context.Request.Form.Count>0)
        //    {
        //        msgBuilder.Append("<table border=\"1\"><tr><td></td></tr>)
        //    }
        //}
    }
}
