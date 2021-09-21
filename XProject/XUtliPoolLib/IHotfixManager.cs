using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200005C RID: 92
	public interface IHotfixManager
	{
		// Token: 0x060002F1 RID: 753
		void Dispose();

		// Token: 0x060002F2 RID: 754
		bool DoLuaFile(string name);

		// Token: 0x060002F3 RID: 755
		void TryFixMsglist();

		// Token: 0x060002F4 RID: 756
		bool TryFixClick(HotfixMode _mode, string _path);

		// Token: 0x060002F5 RID: 757
		bool TryFixRefresh(HotfixMode _mode, string _pageName, GameObject go);

		// Token: 0x060002F6 RID: 758
		bool TryFixHandler(HotfixMode _mode, string _handlerName, GameObject go);

		// Token: 0x060002F7 RID: 759
		void RegistedPtc(uint _type, byte[] body, int length);

		// Token: 0x060002F8 RID: 760
		void ProcessOveride(uint _type, byte[] body, int length);

		// Token: 0x060002F9 RID: 761
		void OnLeaveScene();

		// Token: 0x060002FA RID: 762
		void OnEnterScene();

		// Token: 0x060002FB RID: 763
		void OnEnterSceneFinally();

		// Token: 0x060002FC RID: 764
		void OnAttachToHost();

		// Token: 0x060002FD RID: 765
		void OnReconnect();

		// Token: 0x060002FE RID: 766
		void OnDetachFromHost();

		// Token: 0x060002FF RID: 767
		void CallLuaFunc(string className, string funcName);

		// Token: 0x06000300 RID: 768
		void OnPayCallback(string result, string paramID);
	}
}
