<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

// Creates Handler
public class Handler : IHttpHandler {

    // Process the Http Request
    public void ProcessRequest (HttpContext context) {

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
        
        catch
        {
            // Return 500 Internal Server Error Status Code
            context.Response.StatusCode = 500;
        }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}