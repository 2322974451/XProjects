using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GVGCombatGuildDisplay
	{

		public void Setup(Transform t)
		{
			this.m_GuildNameLabel = (t.FindChild("txt_GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildHeadSprite = (t.FindChild("GuildIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_unKnowSprite = (t.FindChild("UnKnow").GetComponent("XUISprite") as IXUISprite);
			this._Support = t.FindChild("BtnSupport");
			this.SetEmptyMember();
		}

		public void Recycle()
		{
			this._Support = null;
			this.m_GuildHeadSprite = null;
			this.m_GuildNameLabel = null;
			this.m_unKnowSprite = null;
		}

		public void SetGuildMember(XGuildBasicData baseData, XGuildBasicData winData = null, bool isCup = false)
		{
			this._baseData = baseData;
			bool flag = baseData == null;
			if (flag)
			{
				this.SetEmptyMember();
				bool flag2 = this._Support != null;
				if (flag2)
				{
					this._Support.gameObject.SetActive(false);
				}
				if (isCup)
				{
					this.m_unKnowSprite.SetVisible(false);
				}
			}
			else
			{
				this.SetShowMember();
				XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
				XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				this.m_GuildHeadSprite.ID = baseData.uid;
				this.m_GuildNameLabel.SetText(baseData.ToGuildNameString());
				this.m_GuildHeadSprite.SetSprite(XGuildDocument.GetPortraitName(baseData.portraitIndex));
				this.m_GuildNameLabel.SetColor((specificDocument2.bInGuild && specificDocument2.BasicData.uid == baseData.uid) ? Color.green : Color.white);
				bool flag3 = winData == null;
				if (flag3)
				{
					this.m_GuildHeadSprite.SetGrey(true);
				}
				else
				{
					this.m_GuildHeadSprite.SetGrey(winData.uid == baseData.uid);
				}
				bool flag4 = this._Support != null;
				if (flag4)
				{
					XCrossGVGDocument specificDocument3 = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
					bool flag5 = specificDocument3.TimeStep == CrossGvgTimeState.CGVG_Guess;
					if (flag5)
					{
						this._Support.gameObject.SetActive(true);
						IXUIButton ixuibutton = this._Support.GetComponent("XUIButton") as IXUIButton;
						IXUILabel ixuilabel = this._Support.Find("Label").GetComponent("XUILabel") as IXUILabel;
						bool flag6 = specificDocument3.IsSupportExist(baseData.uid);
						bool flag7 = flag6;
						if (flag7)
						{
							ixuilabel.SetText(XStringDefineProxy.GetString("CROSSGVG_SUPPORT_TRUE"));
						}
						else
						{
							ixuilabel.SetText(XStringDefineProxy.GetString("CROSSGVG_SUPPORT_FALSE"));
						}
						ixuibutton.SetEnable(!flag6 && !specificDocument3.IsSupportFull(), false);
						ixuibutton.ID = baseData.uid;
						ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSupportClick));
					}
					else
					{
						this._Support.gameObject.SetActive(false);
					}
				}
			}
		}

		private bool _OnSupportClick(IXUIButton btn)
		{
			bool flag = this._baseData == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("CrossGVG_confirm_message", new object[]
				{
					this._baseData.ToGuildNameString()
				}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnSureSupport));
				result = true;
			}
			return result;
		}

		private bool _OnSureSupport(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = this._baseData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
				specificDocument.SendCrossGVGOper(CrossGvgOperType.CGOT_SupportGuild, this._baseData.uid);
				result = true;
			}
			return result;
		}

		private void SetShowMember()
		{
			this.m_GuildNameLabel.SetVisible(true);
			this.m_GuildHeadSprite.SetVisible(true);
			this.m_unKnowSprite.SetVisible(false);
		}

		private void SetEmptyMember()
		{
			this.m_GuildHeadSprite.ID = 0UL;
			this.m_GuildNameLabel.SetVisible(false);
			this.m_GuildHeadSprite.SetVisible(false);
			this.m_unKnowSprite.SetVisible(true);
		}

		private IXUILabel m_GuildNameLabel;

		private IXUISprite m_GuildHeadSprite;

		private IXUISprite m_unKnowSprite;

		private Transform _Support;

		private XGuildBasicData _baseData;
	}
}
