using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Variables received from SendGrid
/// </summary>
public class SendGridEvent
{
    // Shared > Processed / Spam Report / Unsubscribe
    public string sg_event_id { get; set; }
    public string sg_message_id { get; set; }
    public string email { get; set; }
    public int timestamp { get; set; }

    // For the -
    [JsonProperty("smtp-id")]
    public string smtp_id { get; set; }

    // For the reserved word
    [JsonProperty("event")]
    public string sendgrid_event { get; set; }

    // Deferred / Delivered
    public string response { get; set; }

    // Deferred
    public int attempt { get; set; }

    // Open / Click / Group Unsubscribe / Resubscribe
    public string ip { get; set; }
    public string useragent { get; set; }

    // Click
    public string url { get; set; }

    // Bounce / Drop
    public string reason { get; set; }

    // Bounce
    public string status { get; set; }
    public string type { get; set; }

    // Group Unsubscribe / Resubscribe
    public string asm_group_id { get; set; }

    // Categories
    public object category { get; set; }

    // Marketing Email Unsubscribes
    public SendGridNewsLetter newsletter { get; set; }

    // IP Pools
    public SendGridIpPool pool { get; set; }

    // Unique Arguments - Those are form the send grid example json
    // Put your own arguments here, if you use them
    public string id { get; set; }
    public string purchase { get; set; }
    public string uid { get; set; }

    // Those are for usable DateTime and the Categories
    public DateTime date { get; set; }
    public IList<string> categories { get; set; }
}

// SendGridNewsLetter
public class SendGridNewsLetter
{
    public string newsletter_user_list_id { get; set; }
    public string newsletter_id { get; set; }
    public string newsletter_send_id { get; set; }
}

// SendGridIpPool
public class SendGridIpPool
{
    public string name { get; set; }
    public string id { get; set; }
}   