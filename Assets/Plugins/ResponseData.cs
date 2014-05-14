using System;
using SimpleJSON;

namespace com.adjust.sdk
{
	public class ResponseData
	{
		public enum ActivityKind {
			UNKNOWN, SESSION, EVENT, REVENUE, REATTRIBUTION
		}

		public ActivityKind activityKind { get; private set; }
		public string activityKindString { get; private set; }
		public bool success { get; private set; }
		public bool willRetry { get; private set; }
		public string error { get; private set; }
		public string trackerToken { get; private set; }
		public string trackerName { get; private set; }

		public ResponseData(string jsonString) {
			var jsonNode = JSON.Parse (jsonString);

			activityKind = ParseActivityKind(jsonNode["activityKind"].Value);
			activityKindString = activityKind.ToString ().ToLower ();
			success = jsonNode ["success"].AsBool;
			willRetry = jsonNode ["willRetry"].AsBool;
			error = jsonNode ["error"].Value;
			trackerName = jsonNode ["trackerName"].Value;
			trackerToken = jsonNode ["trackerToken"].Value;
		}

		private ActivityKind ParseActivityKind(string sActivityKind) 
		{
			if ("session" == sActivityKind)
				return ActivityKind.SESSION;
			else if ("event" == sActivityKind)
				return ActivityKind.EVENT;
			else if ("revenue" == sActivityKind)
				return ActivityKind.REVENUE;
			else if ("reattribution" == sActivityKind)
				return ActivityKind.REATTRIBUTION;
			else 
				return ActivityKind.UNKNOWN;
		}
	}
}
