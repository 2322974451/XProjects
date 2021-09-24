using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelAIMgr : XSingleton<XLevelAIMgr>
	{

		public bool AiReady
		{
			get
			{
				return this._ai_ready;
			}
		}

		public bool AiDebug
		{
			get
			{
				return this._ai_debug;
			}
		}

		public Vector3 ArenaCenter
		{
			get
			{
				return this._arena_center;
			}
		}

		public List<GameObject> PathList
		{
			get
			{
				return this._path_list;
			}
		}

		public void InitAIData()
		{
			string sceneDynamicPrefix = XSingleton<XSceneMgr>.singleton.GetSceneDynamicPrefix(XSingleton<XScene>.singleton.SceneID);
			GameObject gameObject = GameObject.Find("Arena_center");
			bool flag = gameObject != null;
			if (flag)
			{
				this._arena_center = gameObject.transform.position;
			}
			GameObject gameObject2 = GameObject.Find(sceneDynamicPrefix + "navigation");
			this._path_list.Clear();
			bool flag2 = gameObject2 != null;
			if (flag2)
			{
				for (int i = 0; i < XLevelAIMgr.MAX_PATH_POINT; i++)
				{
					Transform transform = gameObject2.transform.FindChild("path" + i.ToString());
					bool flag3 = transform == null;
					if (flag3)
					{
						break;
					}
					GameObject gameObject3 = transform.gameObject;
					bool flag4 = gameObject3 == null;
					if (flag4)
					{
						break;
					}
					this._path_list.Add(gameObject3);
				}
			}
			bool flag5 = this._path_list.Count == 0;
			if (flag5)
			{
				this._ai_ready = false;
			}
			else
			{
				this._ai_ready = true;
			}
		}

		public void ClearAIData()
		{
			this._start_pos = null;
			this._path_list.Clear();
		}

		public GameObject GetAiStartPos()
		{
			return this._start_pos;
		}

		public List<GameObject> GetPathPos()
		{
			return this._path_list;
		}

		public void EnableAllAI(bool enable)
		{
			List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
			List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
			for (int i = 0; i < opponent.Count; i++)
			{
				XAIEnableAI @event = XEventPool<XAIEnableAI>.GetEvent();
				@event.Firer = opponent[i];
				@event.Enable = enable;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			for (int j = 0; j < ally.Count; j++)
			{
				XAIEnableAI event2 = XEventPool<XAIEnableAI>.GetEvent();
				event2.Firer = ally[j];
				event2.Enable = enable;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		private GameObject _start_pos = null;

		private List<GameObject> _path_list = new List<GameObject>();

		private bool _ai_ready = false;

		private bool _ai_debug = false;

		private Vector3 _arena_center = Vector3.zero;

		private static readonly int MAX_PATH_POINT = 100;
	}
}
