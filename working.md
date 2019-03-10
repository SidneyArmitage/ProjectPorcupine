# Gear plan

create inventory like the following for furniture
```cs
Inventory asInventory = Inventory.CreatePrototype(Type, 1, 0f, "crated_furniture", LocalizationName, LocalizationDescription);
            PrototypeManager.Inventory.Add(asInventory);
```
which triggers
```cs
private Inventory(string type, int maxStackSize, float basePrice, string category, string localizationName, string localizationDesc)
{
    Type = type;
    MaxStackSize = maxStackSize;
    BasePrice = basePrice;
    Category = category;
    LocalizationName = localizationName;
    LocalizationDescription = localizationDesc;
}
```

## Specification

### Gear prototype

```js
{
  "Gear": {
    "default_character": {
      "MaxStackSize": 1,
      "BasePrice": 0.0,
      "Category": "inv_cat_raw",
      "LocalizationName": "inv_raw_default_character",
      "LocalizationDescription": "inv_raw_default_character_desc",
      "Stats": {
          //Stats go here
      },
      "Slots": [
          // attachable slots go here
        "suit",
        "tool"
      ],
      "Slot": "body" // slot to attach this to
    }
  }
}
```

## Tasks

### &#9744; Importing 

&#9745; Read file  
&#9744; Create inventory  
&#9744; Base constructor  
&#9745; Create stats  
&#9744; catch stat not existing  
&#9745; Slots  

### &#9744; Loading  

&#9744; Copy constructor  
&#9744; load as inventory item  
&#9744; modify character for equipping  
&#9744; load as equipped  
&#9744; load as equipped onto self  

### &#9744; Saving  
### &#9744; Equipping  
### &#9744; Unequipping  
### &#9744; Effects  
### &#9744; UI  
### &#9744; AI  