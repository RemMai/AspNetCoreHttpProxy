# AspNetCoreHttpProxy

- AspNetCore实现代理请求

- 适用于DotNet6

### 食用方式教程

1. 在 `appSetting.json` 中设置如下项 
   
   ```json
   {
    "proxy": {
      "prefix": "/arcgis",
      "newHost": "http://xxxUrl:Port/arcgis"
    }
   }
   ```
2. 在`Program.cs`中设置  
   
   ```csharp
   builder.Services.AddHttpProxy();  
   ...
   app.UseHttpProxy();  
   ```
