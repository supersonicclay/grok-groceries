# API Endpoints

## Shopping List

### `GET /v1/shopping-list`

Get all shopping items on list.

Response:

```json
[
    {
        "uuid": "entry1",
        "item": {
            "uuid": "item1",
            "name": "milk",
            "occurrences": 120
        },
        "quantity": 1
    },
    {
        "uuid": "entry2",
        "item": {
            "uuid": "item2",
            "name": "eggs",
            "occurrences": 80
        },
        "quantity": 1
    }
]
```

### `POST /v1/shopping-list`

Adds a new item to the shopping list.

Request:

```json
{
    "itemUuid": "item3",
    "quantity": 1
}
```

Response:

```json
{
    "uuid": "entry3",
    "item": {
        "uuid": "item3",
        "name": "cheese",
        "occurrences": 80
    },
    "quantity": 1
}
```

### `POST /v1/shopping-list/complete?uuid=entry2`

Mark `entry2` as completed

### `POST /v1/shopping-list/clear-completed`

Clear all completed entries.

## Items

### `GET /v1/item`

Get all items

```json
[
    {
        "uuid": "item1",
        "name": "milk",
        "occurrences": 120
    },
    {
        "uuid": "item2",
        "name": "eggs",
        "occurrences": 80
    },
    {
        "uuid": "item3",
        "name": "cheese",
        "occurrences": 50
    }
]
```

### `GET /v1/item?name=e`

Get items matching name.

```json
[
    {
        "uuid": "item2",
        "name": "eggs",
        "occurrences": 80
    },
    {
        "uuid": "item3",
        "name": "cheese",
        "occurrences": 50
    }
]
```
