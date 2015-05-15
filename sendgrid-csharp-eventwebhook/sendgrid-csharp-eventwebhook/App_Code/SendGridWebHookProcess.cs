using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Process the json from SendGrid - Event WebHook into object
/// </summary>
public class SendGridWebHookProcess
{
    //
    // Process the json from SendGrid - Event WebHook into object SendGridEvents (list of SendGridEvent)
    //
    public SendGridEvents json(string json)
    {
        // Deserialize the json using Newtonsoft.Json
        SendGridEvents sendGridEvents = JsonConvert.DeserializeObject<SendGridEvents>(json);

        // For each event found
        foreach (SendGridEvent sendGridEvent in sendGridEvents)
        {
            // Convert the unix timespar into usable DateTime
            sendGridEvent.date = TimeStampToDateTime(sendGridEvent.timestamp);

            // If there is an array of categories
            if (sendGridEvent.category.GetType() == typeof(JArray))
            {
                // Deserialize them into the sendGridEvent categories object
                sendGridEvent.categories = JsonConvert.DeserializeObject<IList<string>>(sendGridEvent.category.ToString());
            }
        }

        // Retorna the events
        return sendGridEvents;
    }

    // Unix timestamp default
    private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    // Convert the unix timestamp to DateTime
    public static DateTime TimeStampToDateTime(int timestamp)
    {
        double seconds = double.Parse(timestamp.ToString(), CultureInfo.InvariantCulture);
        return Epoch.AddSeconds(seconds);
    }

}
