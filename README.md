## 流程情境

**此專案包含以下物件 :**

 * FlowManager.cs
 * IFlow.cs
 * IStep.cs
 * ILog.cs
 
 

**關係圖如下 :** 

![](../../images/relations.png)

**Schema如下 :**
> `紀錄資訊` ILog.cs 


> 欄位 | 型態 | 說明
> ------------ | ------------- | ----------
> Sn | string | 紀錄編號
> NextSts | int | 下一個過程
> PrevSts | int | 前一個過程
> CurrentSts | int | 目前所在過程
> Bookmark | string | 流程註記

## Building the Extension Bundles

>`過程` IStep.cs 


> 欄位 | 型態 | 說明
> ------------ | ------------- | ----------
> Key | string | 過程註記


> 方法:
>> 解釋 | 方法 | 型態 | 說明
>> ------------ | ------------- | ------------ | -----------
>> 執行過程 |  Excute(ILog) | Boolean | 執行該過程




>`流程` IFlow.cs 


> 欄位 | 型態 | 說明
> ------------ | ------------- | ----------
> _steps | IDictionary<int, IStep> | 過程清單


> 方法:
>> 解釋 | 方法 | 型態 | 說明
>> ------------ | ------------- | ------------ | -----------
>> 新增過程 |  AddMember(int, IStep) | void| (過程註記,過程)
>> 刪除過程 |  RemoveMember(int) | void | (過程註記)
>> 替換過程 |  UpdateMember(int, IStep)| void | (過程註記,過程)

>`控制器` FlowManager.cs 


>欄位 | 型態 | 說明
>------------ | ------------- | ----------
>_flow | IDictionary<String, IFlow> | 流程清單

>方法:
>> 解釋 | 方法 | 型態 | 說明
>> ------------ | ------------- | ------------ | ------------ 
>> 新增流程 |  AddFlow(String , IFlow) | void | (流程註記,流程)
>> 刪除流程 |  RemoveFlow(String) | void|  (流程註記)
>> 替換流程 |  UpdateFlow(String, IFlow)| void| (流程註記,流程)
>> 清除所有流程 |  ClearAllFlow() | void 
>> 執行下個階段 |  Next(this ILog) | Boolean | (紀錄資訊)
>> 執行上個階段 |  Prev(this ILog) | Boolean | (紀錄資訊)

**使用範例 :**

> 1.於 `global.asax` 建立關腳本
>```C#
>			 //初始化相關腳本
>				
>            IStep ConcreteA  = new ConcreteStepA();
>			 IStep ConcreteB  = new ConcreteStepB();
>			 IStep ConcreteC  = new ConcreteStepC();
>
>            CallerFlow AFlow = new CallerFlow();
>            AFlow.Add(1,ConcreteA);
>            AFlow.Add(2,ConcreteB);
>            AFlow.Add(3,ConcreteC);
>
>
>			 FlowManager.Add("AFlow", callerFlow);           
>
>
>```
> 2.於 `ILog.cs` 叫用方法
> ```C#
>			 //初始化相關腳本
>
>			 Ilog log = new ConcreteLog();
>			 log.nextSts = 2
>			 log.Bookmark = "AFlow"
>
>            //執行下個階段
>            log.Next();
>
>			 //執行上個階段
>			 log.Prev();
>           
>```
