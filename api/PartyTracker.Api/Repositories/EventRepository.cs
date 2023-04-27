using System;
using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Options;
using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Settings;

namespace PartyTracker.Api.Repositories
{
	public class EventRepository : IEventRepository
	{
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly IOptions<DatabaseSettings> _databaseSettings;

        public EventRepository(IAmazonDynamoDB dynamoDb,
            IOptions<DatabaseSettings> databaseSettings)
		{
            _dynamoDb = dynamoDb;
            _databaseSettings = databaseSettings;
        }

        public async Task<EventDto> CreateAsync(EventDto customer)
        {
            var customerAsJson = JsonSerializer.Serialize(customer);
            var itemAsDocument = Document.FromJson(customerAsJson);
            var itemAsAttributes = itemAsDocument.ToAttributeMap();

            var createItemRequest = new PutItemRequest
            {
                TableName = _databaseSettings.Value.TableName,
                Item = itemAsAttributes
            };

            await _dynamoDb.PutItemAsync(createItemRequest);
            return customer;
        }
    }
}

