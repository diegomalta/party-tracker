using System;
using System.Net;
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
	public class EventRepository : IEventRepository
	{
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly IOptions<DatabaseSettings> _databaseSettings;
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public EventRepository(IAmazonDynamoDB dynamoDb,
            IOptions<DatabaseSettings> databaseSettings)
		{
            _dynamoDb = dynamoDb;
            _databaseSettings = databaseSettings;
        }

        public async Task<EventDto> CreateAsync(EventDto evtDto)
        {
            var eventAsJson = JsonSerializer.Serialize(evtDto, options);
            var itemAsDocument = Document.FromJson(eventAsJson);
            var itemAsAttributes = itemAsDocument.ToAttributeMap();

            var createItemRequest = new PutItemRequest
            {
                TableName = _databaseSettings.Value.TableName,
                Item = itemAsAttributes
            };

            await _dynamoDb.PutItemAsync(createItemRequest);
            return evtDto;
        }

        private string GeneratePk(Guid id) => $"EVENT#{id}";

        public async Task<EventDto?> GetByIdAsync(Guid id)
        {
            var request = new GetItemRequest
            {
                TableName = _databaseSettings.Value.TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "PK", new AttributeValue { S = GeneratePk(id) } },
                    { "SK", new AttributeValue { S = GeneratePk(id) } }
                }
            };

            var response = await _dynamoDb.GetItemAsync(request);
            if (response.Item.Count == 0)
            {
                return null;
            }

            var itemAsDocument = Document.FromAttributeMap(response.Item);
            return JsonSerializer.Deserialize<EventDto>(itemAsDocument.ToJson());
        }
    }
}

