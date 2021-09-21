using System;

namespace XUtliPoolLib
{
	// Token: 0x02000062 RID: 98
	public interface ILuaExtion : IXInterface
	{
		// Token: 0x0600031B RID: 795
		void SetPlayerProprerty(string key, object value);

		// Token: 0x0600031C RID: 796
		object GetPlayeProprerty(string key);

		// Token: 0x0600031D RID: 797
		object CallPlayerMethod(bool isPublic, string method, params object[] args);

		// Token: 0x0600031E RID: 798
		object GetDocument(string doc);

		// Token: 0x0600031F RID: 799
		object GetDocumentMember(string doc, string key, bool isPublic, bool isField);

		// Token: 0x06000320 RID: 800
		object GetDocumentStaticMember(string doc, string key, bool isPublic, bool isField);

		// Token: 0x06000321 RID: 801
		void SetDocumentMember(string doc, string key, object value, bool isPublic, bool isField);

		// Token: 0x06000322 RID: 802
		object CallDocumentMethod(string doc, bool isPublic, string method, params object[] args);

		// Token: 0x06000323 RID: 803
		object CallDocumentStaticMethod(string doc, bool isPublic, string method, params object[] args);

		// Token: 0x06000324 RID: 804
		object GetSingle(string className);

		// Token: 0x06000325 RID: 805
		object GetSingleMember(string className, string key, bool isPublic, bool isField, bool isStatic);

		// Token: 0x06000326 RID: 806
		void SetSingleMember(string className, string key, object value, bool isPublic, bool isField, bool isStatic);

		// Token: 0x06000327 RID: 807
		object CallSingleMethod(string className, bool isPublic, bool isStatic, string methodName, params object[] args);

		// Token: 0x06000328 RID: 808
		void RefreshPlayerName();

		// Token: 0x06000329 RID: 809
		Type GetType(string classname);

		// Token: 0x0600032A RID: 810
		object GetEnumType(string classname, string value);

		// Token: 0x0600032B RID: 811
		string GetStringTable(string key, params object[] args);

		// Token: 0x0600032C RID: 812
		string GetGlobalString(string key);

		// Token: 0x0600032D RID: 813
		XLuaLong Get(string str);
	}
}
