using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFlowerReplyDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFlowerReplyDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFlowerReplyDocument.AsyncLoader.AddTask("Table/FlowerRain", XFlowerReplyDocument._flowerRainTable, false);
			XFlowerReplyDocument.AsyncLoader.AddTask("Table/FlowerNotice", XFlowerReplyDocument._flowerNoticeTable, false);
			XFlowerReplyDocument.AsyncLoader.Execute(callback);
		}

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

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._sceneLoading = true;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			this._sceneLoading = false;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FlowerReplyDocument");

		public XFlowerReplyView View;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static FlowerRain _flowerRainTable = new FlowerRain();

		public static FlowerSendNoticeTable _flowerNoticeTable = new FlowerSendNoticeTable();

		private List<ReceiveFlowerData> _receiveFlowerMsgCache = new List<ReceiveFlowerData>();

		private bool _sceneLoading = true;
	}
}
