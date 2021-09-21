using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200098F RID: 2447
	internal class XFlowerReplyDocument : XDocComponent
	{
		// Token: 0x17002CB8 RID: 11448
		// (get) Token: 0x0600932A RID: 37674 RVA: 0x00157A18 File Offset: 0x00155C18
		public override uint ID
		{
			get
			{
				return XFlowerReplyDocument.uuID;
			}
		}

		// Token: 0x0600932B RID: 37675 RVA: 0x00157A2F File Offset: 0x00155C2F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFlowerReplyDocument.AsyncLoader.AddTask("Table/FlowerRain", XFlowerReplyDocument._flowerRainTable, false);
			XFlowerReplyDocument.AsyncLoader.AddTask("Table/FlowerNotice", XFlowerReplyDocument._flowerNoticeTable, false);
			XFlowerReplyDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600932C RID: 37676 RVA: 0x00157A6C File Offset: 0x00155C6C
		public void OnReceiveFlower(ReceiveFlowerData data)
		{
			bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
			if (!inTutorial)
			{
				bool sceneLoading = this._sceneLoading;
				if (!sceneLoading)
				{
					bool flag = this._receiveFlowerMsgCache.Count == 0;
					if (flag)
					{
						this._receiveFlowerMsgCache.Add(data);
					}
					else
					{
						bool flag2 = data.sendRoleID != this._receiveFlowerMsgCache[this._receiveFlowerMsgCache.Count - 1].sendRoleID;
						if (flag2)
						{
							this._receiveFlowerMsgCache.Add(data);
						}
					}
				}
			}
		}

		// Token: 0x0600932D RID: 37677 RVA: 0x00157AF8 File Offset: 0x00155CF8
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
			if (!inTutorial)
			{
				bool sceneLoading = this._sceneLoading;
				if (!sceneLoading)
				{
					bool flag = this._receiveFlowerMsgCache.Count > 0;
					if (flag)
					{
						bool flag2 = !DlgBase<XFlowerReplyView, XFlowerReplyBehavior>.singleton.IsVisible();
						if (flag2)
						{
							this.DisposeMsg(this._receiveFlowerMsgCache[0]);
						}
					}
				}
			}
		}

		// Token: 0x0600932E RID: 37678 RVA: 0x00157B64 File Offset: 0x00155D64
		private void DisposeMsg(ReceiveFlowerData data)
		{
			bool flag = !DlgBase<XFlowerReplyView, XFlowerReplyBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XFlowerReplyView, XFlowerReplyBehavior>.singleton.ShowView(data.itemID, data.sendRoleID, data.sendName, data.power, data.profession, data.vip, data.itemCount);
				XFlowerReplyView singleton = DlgBase<XFlowerReplyView, XFlowerReplyBehavior>.singleton;
				singleton.OnClosed = (Action)Delegate.Combine(singleton.OnClosed, new Action(this.OnReplyViewClosed));
			}
		}

		// Token: 0x0600932F RID: 37679 RVA: 0x00157BE0 File Offset: 0x00155DE0
		public void OnReplyViewClosed()
		{
			XFlowerReplyView singleton = DlgBase<XFlowerReplyView, XFlowerReplyBehavior>.singleton;
			singleton.OnClosed = (Action)Delegate.Remove(singleton.OnClosed, new Action(this.OnReplyViewClosed));
			bool flag = this._receiveFlowerMsgCache.Count > 0;
			if (flag)
			{
				this._receiveFlowerMsgCache.RemoveAt(0);
			}
		}

		// Token: 0x06009330 RID: 37680 RVA: 0x00157C38 File Offset: 0x00155E38
		public void OnShowFlowerRain(ReceiveFlowerData data)
		{
			bool flag = !XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID).Flowerrain;
			if (!flag)
			{
				bool sceneLoading = this._sceneLoading;
				if (!sceneLoading)
				{
					FlowerRain.RowData flowerRain = this.GetFlowerRain(data.itemID, data.itemCount);
					bool flag2 = flowerRain != null;
					if (flag2)
					{
						Transform transform = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
						bool flag3 = transform != null;
						if (flag3)
						{
							XFx xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(flowerRain.EffectPath, transform, false);
							xfx.DelayDestroy = (float)flowerRain.PlayTime;
							XSingleton<XFxMgr>.singleton.DestroyFx(xfx, false);
						}
					}
				}
			}
		}

		// Token: 0x06009331 RID: 37681 RVA: 0x00157CE8 File Offset: 0x00155EE8
		private FlowerRain.RowData GetFlowerRain(int flowerID, int sendCount)
		{
			foreach (FlowerRain.RowData rowData in XFlowerReplyDocument._flowerRainTable.Table)
			{
				bool flag = rowData.FlowerID == flowerID && sendCount == rowData.Count;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x06009332 RID: 37682 RVA: 0x00157D44 File Offset: 0x00155F44
		public string GetThxContent(int flowerID, int sendCount)
		{
			for (int i = 0; i < XFlowerReplyDocument._flowerNoticeTable.Table.Length; i++)
			{
				FlowerSendNoticeTable.RowData rowData = XFlowerReplyDocument._flowerNoticeTable.Table[i];
				bool flag = rowData.ItemID == flowerID && rowData.Num == sendCount;
				if (flag)
				{
					return rowData.ThanksWords;
				}
			}
			return "";
		}

		// Token: 0x06009333 RID: 37683 RVA: 0x00157DAA File Offset: 0x00155FAA
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._sceneLoading = true;
		}

		// Token: 0x06009334 RID: 37684 RVA: 0x00157DBB File Offset: 0x00155FBB
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			this._sceneLoading = false;
		}

		// Token: 0x06009335 RID: 37685 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003175 RID: 12661
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FlowerReplyDocument");

		// Token: 0x04003176 RID: 12662
		public XFlowerReplyView View;

		// Token: 0x04003177 RID: 12663
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003178 RID: 12664
		private static FlowerRain _flowerRainTable = new FlowerRain();

		// Token: 0x04003179 RID: 12665
		public static FlowerSendNoticeTable _flowerNoticeTable = new FlowerSendNoticeTable();

		// Token: 0x0400317A RID: 12666
		private List<ReceiveFlowerData> _receiveFlowerMsgCache = new List<ReceiveFlowerData>();

		// Token: 0x0400317B RID: 12667
		private bool _sceneLoading = true;
	}
}
