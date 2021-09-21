using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D98 RID: 3480
	internal class XLevelAIMgr : XSingleton<XLevelAIMgr>
	{
		// Token: 0x17003337 RID: 13111
		// (get) Token: 0x0600BD50 RID: 48464 RVA: 0x00273B60 File Offset: 0x00271D60
		public bool AiReady
		{
			get
			{
				return this._ai_ready;
			}
		}

		// Token: 0x17003338 RID: 13112
		// (get) Token: 0x0600BD51 RID: 48465 RVA: 0x00273B78 File Offset: 0x00271D78
		public bool AiDebug
		{
			get
			{
				return this._ai_debug;
			}
		}

		// Token: 0x17003339 RID: 13113
		// (get) Token: 0x0600BD52 RID: 48466 RVA: 0x00273B90 File Offset: 0x00271D90
		public Vector3 ArenaCenter
		{
			get
			{
				return this._arena_center;
			}
		}

		// Token: 0x1700333A RID: 13114
		// (get) Token: 0x0600BD53 RID: 48467 RVA: 0x00273BA8 File Offset: 0x00271DA8
		public List<GameObject> PathList
		{
			get
			{
				return this._path_list;
			}
		}

		// Token: 0x0600BD54 RID: 48468 RVA: 0x00273BC0 File Offset: 0x00271DC0
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

		// Token: 0x0600BD55 RID: 48469 RVA: 0x00273CCB File Offset: 0x00271ECB
		public void ClearAIData()
		{
			this._start_pos = null;
			this._path_list.Clear();
		}

		// Token: 0x0600BD56 RID: 48470 RVA: 0x00273CE4 File Offset: 0x00271EE4
		public GameObject GetAiStartPos()
		{
			return this._start_pos;
		}

		// Token: 0x0600BD57 RID: 48471 RVA: 0x00273CFC File Offset: 0x00271EFC
		public List<GameObject> GetPathPos()
		{
			return this._path_list;
		}

		// Token: 0x0600BD58 RID: 48472 RVA: 0x00273D14 File Offset: 0x00271F14
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

		// Token: 0x04004D0D RID: 19725
		private GameObject _start_pos = null;

		// Token: 0x04004D0E RID: 19726
		private List<GameObject> _path_list = new List<GameObject>();

		// Token: 0x04004D0F RID: 19727
		private bool _ai_ready = false;

		// Token: 0x04004D10 RID: 19728
		private bool _ai_debug = false;

		// Token: 0x04004D11 RID: 19729
		private Vector3 _arena_center = Vector3.zero;

		// Token: 0x04004D12 RID: 19730
		private static readonly int MAX_PATH_POINT = 100;
	}
}
