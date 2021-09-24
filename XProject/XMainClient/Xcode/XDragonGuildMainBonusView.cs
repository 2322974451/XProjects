using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildMainBonusView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_btnClose = (base.PanelObject.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_CurrentBuff = base.PanelObject.transform.Find("Active/CurrentBuff").gameObject;
			this.m_NextBuff = base.PanelObject.transform.FindChild("Active/NextBuff").gameObject;
			this.m_doc = XDragonGuildDocument.Doc;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseBtnClick));
		}

		private void _OnCloseBtnClick(IXUISprite go)
		{
			base.SetVisible(false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		public void Refresh()
		{
			uint level = this.m_doc.BaseData.level;
			bool flag = this.m_doc.IsMaxLevel();
			if (flag)
			{
				this._RefreshBuff(this.m_CurrentBuff, level);
				this._SetFinalBuff(this.m_NextBuff);
			}
			else
			{
				this._RefreshBuff(this.m_CurrentBuff, level);
				this._RefreshBuff(this.m_NextBuff, level + 1U);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		private void _SetFinalBuff(GameObject go)
		{
			IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Buff1").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText("--");
			ixuilabel2.SetText(XStringDefineProxy.GetString("DRAGON_GUILD_MAX_LEVEL"));
		}

		private void _RefreshBuff(GameObject go, uint level)
		{
			DragonGuildTable.RowData bylevel = XDragonGuildDocument.DragonGuildBuffTable.GetBylevel(level);
			bool flag = bylevel == null;
			if (!flag)
			{
				IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = go.transform.Find("Buff1").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(bylevel.level.ToString());
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(bylevel.buf[0], bylevel.buf[1]);
				bool flag2 = buffData == null;
				if (flag2)
				{
					ixuilabel2.SetText(string.Empty);
				}
				else
				{
					ixuilabel2.SetText(buffData.BuffName);
				}
			}
		}

		private IXUISprite m_btnClose;

		private GameObject m_CurrentBuff;

		private GameObject m_NextBuff;

		private XDragonGuildDocument m_doc;
	}
}
