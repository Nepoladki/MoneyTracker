# Domain Models

## Order

```csharp
class Order
{
    Order Create();
    void AddDish(Guid dishId, int quantity, string note);
    
}
```

```json
{
    "Id": "00000000-0000-0000-0000-000000000000",
    "DishIds": [
        "00000000-0000-0000-0000-000000000000",
        "00000000-0000-0000-0000-000000000000"
        ],
    "OrderNumber" : 0,
    "Note": "Salt-free please",
    "OrderStatus" : 0,
    "TotalSum": 0.0,
    "CreatedDateTime": 2000-01-01 00:00:00,
    "PayedDateTime": 2000-01-01 00:00:00,
    "CompletedDateTime": 2000-01-01 00:00:00
}

```