# ErrorExecption 錯誤處理整合包
版本: 1.0.0
修改: 陳冠豪
最後修改時間: 2025/07/31

## 組件介紹
1. CatchErrorAttribute.cs
    - 自定義屬性
    - 攔截 API Action 拋出錯誤
    - 自動包裝錯誤訊息統一拋出
2. ResponseModel.cs
    - 包裝統一回應前端格式物件
3. AppExceptionMiddleware.cs
    - 中介軟體
    - 攔截全域錯誤拋出
    - 統一包裝錯誤回應與 Http Code
4. AppException.cs
    - 錯誤拋出格式物件

## 使用方式
1. CatchErrorAttribute.cs
``` csharp
// ! 請記得引用程式存放位置
// ! controller 或 action 則一增加即可
[CatchError] // NOTE: 錯誤處理屬性增加在此代表此 class 所有函示皆套用
public class testController : ControllerBase
{
    [CatchError] // NOTE: 也可為個別增加
    public async Task<ActionResult> TestGet()
    {
        // ...控制器內部邏輯...
    }
}
```
2. AppExceptionMiddleware.cs
``` csharp
// Program.cs
var app = builder.Build();

// ...其他設定...

// 註冊錯誤處理中介軟體
app.UseMiddleware<AppExceptionMiddleware>();

app.MapControllers();
app.Run();
```
3. AppException.cs
``` csharp
// 拋出錯誤建立一個新的 AppException 實例
throw new AppException({HttpCode}, {MessageTitle}, {Message});
```

