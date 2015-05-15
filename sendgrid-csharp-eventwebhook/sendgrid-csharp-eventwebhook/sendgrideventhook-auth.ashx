<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Text;

// Creates Handler
public class Handler : IHttpHandler {

    // Process the Http Request
    public void ProcessRequest (HttpContext context) {

        // Adds 401 Challenge Response
        context.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"Authenticate\""));

        // Get the Authorization Header
        string authHeader = context.Request.Headers["Authorization"];

        // Create strings to receive user and pass
        string user = "";
        string pass = "";

        // Check the Header for Authorization
        if (authHeader != null && authHeader.StartsWith("Basic"))
        {
            // Get the encoded string only
            string encodedUserPass = authHeader.Substring(6).Trim();

            // Decode it
            string userPass = Encoding.ASCII.GetString(Convert.FromBase64String(encodedUserPass));

            // Split it
            string[] credentials = userPass.Split(':');

            // Put on the strings
            user = credentials[0];
            pass = credentials[1];
        }
        
        //
        // Here we are checking if user and pass are the same as provided on your webhook url at SendGrid
        //
        // In this case the url should be something like
        //
        // http://usuario:senha@domain.com/sendgrideventhook-auth.ashx
        //
        
        // If user and pass are correct
        if (user == "usuario" && pass == "senha")
        {
            // Try to get json and turn it into object
            try
            {
                // String to receive raw json from SendGrid
                string json;

                // Reads the input stream and put it on the json string    
                using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                {
                    json = reader.ReadToEnd();
                }

                // Creates new object to receive the events
                SendGridEvents sendGridEvents = new SendGridEvents();

                // Creates new instance of the webhook json processor
                SendGridWebHookProcess sendGridWebHookProcess = new SendGridWebHookProcess();

                // Process the json into the object
                sendGridEvents = sendGridWebHookProcess.json(json);

                //
                //
                // Now, do something with the received events
                //
                //
                
                // 

                // Return 200 OK Status Code
                context.Response.StatusCode = 200;
            }

            // Failing
            catch
            {
                // Returns 500 Internal Server Error
                context.Response.StatusCode = 500;
            }
        }

        // If user and pass are not correct
        else
        {
            // Returns 401 Unauthorized
            context.Response.StatusCode = 401;  
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}