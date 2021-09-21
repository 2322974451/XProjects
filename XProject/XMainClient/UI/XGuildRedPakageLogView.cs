using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001837 RID: 6199
	internal class XGuildRedPakageLogView : DlgHandlerBase
	{
		// Token: 0x1700393F RID: 14655
		// (set) Token: 0x060101A9 RID: 65961 RVA: 0x003D92C7 File Offset: 0x003D74C7
		public ILogSource LogSource
		{
			set
			{
				this.m_LogSource = value;
			}
		}

		// Token: 0x060101AA RID: 65962 RVA: 0x003D92D4 File Offset: 0x003D74D4
		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this.m_ScrollView = (base.PanelObject.transform.FindChild("LogMenu/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("LogMenu/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
		}

		// Token: 0x060101AB RID: 65963 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x060101AC RID: 65964 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x060101AD RID: 65965 RVA: 0x003D9360 File Offset: 0x003D7560
		public void Refresh()
		{
			List<ILogData> logList = this.m_LogSource.GetLogList();
			int count = logList.Count;
			this.m_WrapContent.SetContentCount(count, false);
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x060101AE RID: 65966 RVA: 0x003D939C File Offset: 0x003D759C
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

		// Token: 0x060101AF RID: 65967 RVA: 0x003D9538 File Offset: 0x003D7738
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

		// Token: 0x060101B0 RID: 65968 RVA: 0x003D9590 File Offset: 0x003D7790
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x060101B1 RID: 65969 RVA: 0x003D95AC File Offset: 0x003D77AC
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

		// Token: 0x040072D0 RID: 29392
		private ILogSource m_LogSource;

		// Token: 0x040072D1 RID: 29393
		private XGuildRedPacketDocument _Doc;

		// Token: 0x040072D2 RID: 29394
		private IXUIWrapContent m_WrapContent;

		// Token: 0x040072D3 RID: 29395
		private IXUIScrollView m_ScrollView;

		// Token: 0x040072D4 RID: 29396
		private Vector3 startPos = new Vector3(-96f, 0f, 0f);
	}
}
