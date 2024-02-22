# Mini project Week 7
The `Asset` class serves as the base class for all assets and contains properties like `ModelName`, `PurchaseDate`, and `Price`. It also has methods to calculate the remaining months until the end of life and determine the status of the asset.
- The `Laptop` and `MobilePhone` classes inherit from the `Asset` class, adding no additional properties but inheriting the base properties and methods.
- The `Office` class defines properties for the name and currency of the office.
- In the `Main` method, sample assets and offices are created and stored in a dictionary `officeAssets` where the key is the office and the value is a list of assets.
- The assets are then printed out sorted by office and purchase date, along with their end-of-life status and currency.
