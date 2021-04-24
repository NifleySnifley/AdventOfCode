using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

public class Utils {
	public const string AOCPath = "../../../data.txt";
	public static string GetWebData(string URL) {
		WebRequest request = WebRequest.Create(URL);
		Console.WriteLine();
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		// Display the status.
		Console.WriteLine(string.Format("Request status {0}", response.StatusDescription));
		// Get the stream containing content returned by the server.
		Stream dataStream = response.GetResponseStream();
		// Open the stream using a StreamReader for easy access.
		StreamReader reader = new StreamReader(dataStream);
		// Read the content.
		string responseFromServer = reader.ReadToEnd();
		// Display the content.
		return responseFromServer;
	}
}

