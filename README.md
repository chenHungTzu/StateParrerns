## �y�{����

**���M�ץ]�t�H�U���� :**

 * FlowManager.cs
 * IFlow.cs
 * IStep.cs
 * [ILog.cs][1]
  

**���Y�Ϧp�U :** 

![](/images/relations.png)

**Schema�p�U :**

> [1]:`������T` ILog.cs 


> ��� | ���A | ����
> ------------ | ------------- | ----------
> Sn | string | �����s��
> NextSts | int | �U�@�ӹL�{
> PrevSts | int | �e�@�ӹL�{
> CurrentSts | int | �ثe�Ҧb�L�{
> Bookmark | string | �y�{���O



>`�L�{` IStep.cs 


> ��� | ���A | ����
> ------------ | ------------- | ----------
> Key | string | �L�{���O


> ��k:
>> ���� | ��k | ���A | ����
>> ------------ | ------------- | ------------ | -----------
>> ����L�{ |  Excute(ILog) | Boolean | ����ӹL�{




>`�y�{` IFlow.cs 


> ��� | ���A | ����
> ------------ | ------------- | ----------
> _steps | IDictionary<int, IStep> | �L�{�M��


> ��k:
>> ���� | ��k | ���A | ����
>> ------------ | ------------- | ------------ | -----------
>> �s�W�L�{ |  AddMember(int, IStep) | void| (�L�{���O,�L�{)
>> �R���L�{ |  RemoveMember(int) | void | (�L�{���O)
>> �����L�{ |  UpdateMember(int, IStep)| void | (�L�{���O,�L�{)

>`���` FlowManager.cs 


>��� | ���A | ����
>------------ | ------------- | ----------
>_flow | IDictionary<String, IFlow> | �y�{�M��

>��k:
>> ���� | ��k | ���A | ����
>> ------------ | ------------- | ------------ | ------------ 
>> �s�W�y�{ |  AddFlow(String , IFlow) | void | (�y�{���O,�y�{)
>> �R���y�{ |  RemoveFlow(String) | void|  (�y�{���O)
>> �����y�{ |  UpdateFlow(String, IFlow)| void| (�y�{���O,�y�{)
>> �M���Ҧ��y�{ |  ClearAllFlow() | void 
>> ����U�Ӷ��q |  Next(this ILog) | Boolean | (������T)
>> ����W�Ӷ��q |  Prev(this ILog) | Boolean | (������T)

**�ϥνd�� :**

> 1.�� `global.asax` �إ����}��
>```C#
>			 //��l�Ƭ����}��
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
> 2.�� `ILog.cs` �s�Τ�k
> ```C#
>			 //��l�Ƭ����}��
>
>			 Ilog log = new ConcreteLog();
>			 log.nextSts = 2
>			 log.Bookmark = "AFlow"
>
>            //����U�Ӷ��q
>            log.Next();
>
>			 //����W�Ӷ��q
>			 log.Prev();
>           
>```