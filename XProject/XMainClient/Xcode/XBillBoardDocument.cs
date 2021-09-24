using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBillBoardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBillBoardDocument.uuID;
			}
		}

		public static GameObject GetBillboard(Vector3 position, Quaternion quaternion)
		{
			return XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XBillboardComponent.HPBAR_TEMPLATE, position, quaternion, true, false);
		}

		public static void ReturnBillboard(GameObject go)
		{
			bool flag = go != null;
			if (flag)
			{
				XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroy(go, true, false);
			}
		}

		public static void PreLoad(int count)
		{
			XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(XBillboardComponent.HPBAR_TEMPLATE, count, ECreateHideType.NotHide);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_FightGroupChanged, new XComponent.XEventHandler(this.FightGroupChangeMyself));
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BillboardDocument");
	}
}
