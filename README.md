# sendgrid-csharp-eventwebhook

Process the json from SendGrid - Event WebHook into object

+Categories working

So you can have one category only (string) or multiple categories (array) as an object (categories)


+Timestamp to DateTime

So it´s easy to search dates and integrate


+Auth optional

Have more security using provided basic auth to your requests


Usage:

    
    // json from SendGrid
    string json = @"[ json ]";
    
    // New object to receive the events
    SendGridEvents sendGridEvents = new SendGridEvents();
    
    // New instance of the Webhook json processor
    SendGridWebHookProcess sendGridWebHookProcess = new SendGridWebHookProcess();
    
    // Process the json into the object
    sendGridEvents = sendGridWebHookProcess.json(json);
    
    // Now do what you need with the object
    

If there is only one category, it will be in sendGridEvent.category
If there are two or more categories, they will be in sendGridEvent.categories

Converted timestamp to DateTime will be in sendGridEvent.date

Please see the example 1 and 2 for working example with local json.

Auth:

There are two handlers sendgrideventhook.ashx and sendgrideventhook-auth.ashx

Use sendgrideventhook-auth.ashx and configure your user and pass (line 49).
Add basic auth to your SendGrid url at the Dashboard.


