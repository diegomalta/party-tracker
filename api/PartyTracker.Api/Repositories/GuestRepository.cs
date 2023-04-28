using System;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Options;
using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Settings;
using System.Text.Json.Serialization;

namespace PartyTracker.Api.Repositories
{
	public class GuestRepository : IGuestRepository
	{
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public GuestRepository(IAmazonDynamoDB dynamoDb,
            IOptions<DatabaseSettings> databaseSettings)
		{
            _dynamoDb = dynamoDb;
            _databaseSettings = databaseSettings;
        }

        public async Task<GuestDto> CreateAsync(GuestDto guest)
        {
            var guestAsJson = JsonSerializer.Serialize(guest, options);
            var itemAsDocument = Document.FromJson(guestAsJson);
            var itemAsAttributes = itemAsDocument.ToAttributeMap();

            var createItemRequest = new PutItemRequest
            {
                TableName = _databaseSettings.Value.TableName,
                Item = itemAsAttributes
            };

            await _dynamoDb.PutItemAsync(createItemRequest);
            return guest;
        }


    }
}

