using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200091D RID: 2333
	internal class XBillBoardDocument : XDocComponent
	{
		// Token: 0x17002B9E RID: 11166
		// (get) Token: 0x06008CE9 RID: 36073 RVA: 0x00132AC0 File Offset: 0x00130CC0
		public override uint ID
		{
			get
			{
				return XBillBoardDocument.uuID;
			}
		}

		// Token: 0x06008CEA RID: 36074 RVA: 0x00132AD8 File Offset: 0x00130CD8
		public static GameObject GetBillboard(Vector3 position, Quaternion quaternion)
		{
			return XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XBillboardComponent.HPBAR_TEMPLATE, position, quaternion, true, false);
		}

		// Token: 0x06008CEB RID: 36075 RVA: 0x00132B00 File Offset: 0x00130D00
		public static void ReturnBillboard(GameObject go)
		{
			bool flag = go != null;
			if (flag)
			{
				XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy(go, true, false);
			}
		}

		// Token: 0x06008CEC RID: 36076 RVA: 0x00132B29 File Offset: 0x00130D29
		public static void PreLoad(int count)
		{
			XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(XBillboardComponent.HPBAR_TEMPLATE, count, ECreateHideType.NotHide);
		}

		// Token: 0x06008CED RID: 36077 RVA: 0x00132B3E File Offset: 0x00130D3E
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_FightGroupChanged, new XComponent.XEventHandler(this.FightGroupChangeMyself));
		}

		// Token: 0x06008CEE RID: 36078 RVA: 0x00132B60 File Offset: 0x00130D60
		private bool FightGroupChangeMyself(XEventArgs e)
		{
			XFightGroupChangedArgs xfightGroupChangedArgs = e as XFightGroupChangedArgs;
			bool flag = xfightGroupChangedArgs == null || xfightGroupChangedArgs.targetEntity == null || !xfightGroupChangedArgs.targetEntity.IsPlayer;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
				for (int i = 0; i < all.Count; i++)
				{
					bool flag2 = all[i].Attributes == null;
					if (!flag2)
					{
						bool flag3 = all[i].BillBoard != null;
						if (flag3)
						{
							all[i].BillBoard.Refresh();
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06008CEF RID: 36079 RVA: 0x00132C0C File Offset: 0x00130E0C
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGameUI>.singleton.HpbarRoot != null;
			if (flag)
			{
				XSingleton<XGameUI>.singleton.HpbarRoot.gameObject.SetActive(true);
			}
			bool flag2 = XSingleton<XGameUI>.singleton.NpcHpbarRoot != null;
			if (flag2)
			{
				XSingleton<XGameUI>.singleton.NpcHpbarRoot.gameObject.SetActive(true);
			}
		}

		// Token: 0x06008CF0 RID: 36080 RVA: 0x00132C70 File Offset: 0x00130E70
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (flag)
			{
				bool flag2 = !XSingleton<XSceneMgr>.singleton.IsPVPScene() && !XSingleton<XSceneMgr>.singleton.IsPVEScene();
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Please set the scene PVE or PVP", null, null, null, null, null);
				}
			}
		}

		// Token: 0x06008CF1 RID: 36081 RVA: 0x00132CD0 File Offset: 0x00130ED0
		public static void SetAllBillBoardState(BillBoardHideType type, bool state)
		{
			List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
			for (int i = 0; i < all.Count; i++)
			{
				bool flag = all[i].BillBoard == null;
				if (!flag)
				{
					XBillboardShowCtrlEventArgs @event = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
					@event.show = state;
					@event.type = type;
					@event.Firer = all[i];
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}

		// Token: 0x06008CF2 RID: 36082 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002DA1 RID: 11681
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BillboardDocument");
	}
}
