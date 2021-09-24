using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildRedPakageLogView : DlgHandlerBase
	{

		public ILogSource LogSource
		{
			set
			{
				this.m_LogSource = value;
			}
		}

		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this.m_ScrollView = (base.PanelObject.transform.FindChild("LogMenu/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("LogMenu/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public void Refresh()
		{
			List<ILogData> logList = this.m_LogSource.GetLogList();
			int count = logList.Count;
			this.m_WrapContent.SetContentCount(count, false);
			this.m_ScrollView.ResetPosition();
		}

		private void _WrapContentItemUpdated(Transform t, int index)
		{
			List<ILogData> logList = this.m_LogSource.GetLogList();
			bool flag = index < 0 || index >= logList.Count;
			if (!flag)
			{
				XGuildRedPacketLog xguildRedPacketLog = logList[index] as XGuildRedPacketLog;
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Content").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol2 = t.FindChild("Gold").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUISprite ixuisprite = t.FindChild("mvp").GetComponent("XUISprite") as IXUISprite;
				ixuilabelSymbol.RegisterNameEventHandler(new HyperLinkClickEventHandler(this._NameClick));
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == xguildRedPacketLog.uid;
				if (flag2)
				{
					ixuilabelSymbol.InputText = XStringDefineProxy.GetString("YOU");
				}
				else
				{
					ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatName(xguildRedPacketLog.name, xguildRedPacketLog.uid, "00ffff");
				}
				Vector3 localPosition = this.startPos;
				bool flag3 = this._Doc.CheckLuckest(xguildRedPacketLog.uid);
				if (flag3)
				{
					ixuisprite.SetVisible(true);
					ixuisprite.gameObject.transform.localPosition = localPosition;
					localPosition.x += (float)(ixuisprite.spriteWidth + 10);
				}
				else
				{
					ixuisprite.SetVisible(false);
				}
				ixuilabelSymbol2.InputText = XLabelSymbolHelper.FormatCostWithIcon(xguildRedPacketLog.itemcount, (ItemEnum)xguildRedPacketLog.itemid);
				ixuilabel.SetText(string.Empty);
			}
		}

		public override void RegisterEvent()
		{
			Transform transform = base.PanelObject.transform.FindChild("Close");
			bool flag = transform != null;
			if (flag)
			{
				IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			}
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		private void _NameClick(string param)
		{
			string text = "";
			ulong num = 0UL;
			bool flag = XLabelSymbolHelper.ParseNameParam(param, ref text, ref num);
			if (flag)
			{
				bool flag2 = num == XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				if (!flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(num, false);
				}
			}
		}

		private ILogSource m_LogSource;

		private XGuildRedPacketDocument _Doc;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ScrollView;

		private Vector3 startPos = new Vector3(-96f, 0f, 0f);
	}
}
