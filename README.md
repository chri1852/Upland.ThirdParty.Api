# Upland.ThirdParty.Api
A Package that allows for Connecting to and communicating with the Upland Third Party API using C# .Net 6.0. Simply build the package and import it into your project. To utilize the configuration you will need to add the following entry to your appsettings.json:

```
{
  "UplandThirdPartyApi": {
    "Url": "https://api.sandbox.upland.me/developers-api/",
    "ApplicationId": *ApplicationId*,
    "SecurityKey": "*ApplicationSecretId*",
    "WebHookAccessCode": "*ApplicationAccessCode*"
  }
}
```
There is also an option to supply these options directly to the constructor.
