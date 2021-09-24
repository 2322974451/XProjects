using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public interface IHotfixManager
	{

		void Dispose();

		bool DoLuaFile(string name);

		void TryFixMsglist();

		bool TryFixClick(HotfixMode _mode, string _path);

		bool TryFixRefresh(HotfixMode _mode, string _pageName, GameObject go);

		bool TryFixHandler(HotfixMode _mode, string _handlerName, GameObject go);

		void RegistedPtc(uint _type, byte[] body, int length);

		void ProcessOveride(uint _type, byte[] body, int length);

		void OnLeaveScene();

		void OnEnterScene();

		void OnEnterSceneFinally();

		void OnAttachToHost();

		void OnReconnect();

		void OnDetachFromHost();

		void CallLuaFunc(string className, string funcName);

		void OnPayCallback(string result, string paramID);
	}
}
