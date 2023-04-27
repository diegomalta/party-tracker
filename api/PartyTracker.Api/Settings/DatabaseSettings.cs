using System;
namespace PartyTracker.Api.Settings
{
	public class DatabaseSettings
	{
        public const string KeyName = "Database";

        public string TableName { get; set; } = default!;
    }
}

