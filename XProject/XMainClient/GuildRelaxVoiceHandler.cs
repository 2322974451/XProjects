using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C40 RID: 3136
	internal class GuildRelaxVoiceHandler : GuildRelaxChildHandler
	{
		// Token: 0x0600B19E RID: 45470 RVA: 0x0022187C File Offset: 0x0021FA7C
		public override void SetUnLockLevel()
		{
			base.SetUnLockLevel();
			this.SetVoiceInfo(base.transform.gameObject);
		}

		// Token: 0x0600B19F RID: 45471 RVA: 0x00221898 File Offset: 0x0021FA98
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.GetGuildVoiceInfo();
		}

		// Token: 0x0600B1A0 RID: 45472 RVA: 0x002218AE File Offset: 0x0021FAAE
		protected override void Init()
		{
			base.Init();
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_VoiceQA);
			this._doc = XDocuments.GetSpecificDocument<XGuildRelaxGameDocument>(XGuildRelaxGameDocument.uuID);
		}

		// Token: 0x0600B1A1 RID: 45473 RVA: 0x0021466C File Offset: 0x0021286C
		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(false);
		}

		// Token: 0x0600B1A2 RID: 45474 RVA: 0x002218D8 File Offset: 0x0021FAD8
		private void SetVoiceInfo(GameObject go)
		{
			this.m_qa.SetActive(true);
			IXUIButton ixuibutton = go.transform.Find("QA/Enter").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = go.transform.Find("QA/Open").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel = go.transform.Find("QA/Time").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("QA/Time/Tips").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("QA/top").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.Find("QA/center").GetComponent("XUILabel") as IXUILabel;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterVoiceQAClick));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenVoiceQAClick));
			this.SetVoiceTipFalse(go);
			bool flag = this._doc.GuildVoiceQAState == 0U;
			if (!flag)
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool flag2 = specificDocument.Position == GuildPosition.GPOS_LEADER || specificDocument.Position == GuildPosition.GPOS_VICELEADER;
				if (flag2)
				{
					switch (this._doc.GuildVoiceQAState)
					{
					case 1U:
						ixuibutton2.gameObject.SetActive(true);
						ixuibutton2.SetEnable(false, false);
						ixuilabel.gameObject.SetActive(true);
						this.timeLabel = ixuilabel;
						this.targetTime = Time.time + this._doc.GuildVoiceQAWaitTime;
						ixuilabel2.SetText(XStringDefineProxy.GetString("VoiceQA_Guild_Tips1"));
						break;
					case 2U:
						ixuibutton2.gameObject.SetActive(true);
						ixuibutton2.SetEnable(true, false);
						ixuilabel.gameObject.SetActive(true);
						this.timeLabel = ixuilabel;
						this.targetTime = Time.time + this._doc.GuildVoiceQAWaitTime;
						ixuilabel2.SetText(XStringDefineProxy.GetString("VoiceQA_Guild_Tips2"));
						break;
					case 3U:
						ixuibutton.gameObject.SetActive(true);
						break;
					case 4U:
						ixuilabel4.gameObject.SetActive(true);
						ixuilabel4.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("VoiceQA_Guild_Tips3")));
						break;
					case 5U:
					{
						ixuilabel4.gameObject.SetActive(true);
						XActivityDocument doc = XActivityDocument.Doc;
						MultiActivityList.RowData byID = doc.MulActivityTable.GetByID(4);
						ixuilabel4.SetText(byID.OpenDayTips);
						break;
					}
					}
				}
				else
				{
					switch (this._doc.GuildVoiceQAState)
					{
					case 1U:
					case 2U:
						ixuilabel4.gameObject.SetActive(true);
						ixuilabel4.SetText(XStringDefineProxy.GetString("VoiceQA_Guild_Tips5"));
						break;
					case 3U:
						ixuibutton.gameObject.SetActive(true);
						break;
					case 4U:
						ixuilabel4.gameObject.SetActive(true);
						ixuilabel4.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("VoiceQA_Guild_Tips3")));
						break;
					case 5U:
					{
						ixuilabel4.gameObject.SetActive(true);
						XActivityDocument doc2 = XActivityDocument.Doc;
						MultiActivityList.RowData byID2 = doc2.MulActivityTable.GetByID(4);
						ixuilabel4.SetText(byID2.OpenDayTips);
						break;
					}
					}
				}
			}
		}

		// Token: 0x0600B1A3 RID: 45475 RVA: 0x00221C40 File Offset: 0x0021FE40
		private void SetVoiceTipFalse(GameObject go)
		{
			GameObject gameObject = go.transform.Find("QA/Enter").gameObject;
			GameObject gameObject2 = go.transform.Find("QA/Open").gameObject;
			GameObject gameObject3 = go.transform.Find("QA/Time").gameObject;
			GameObject gameObject4 = go.transform.Find("QA/top").gameObject;
			GameObject gameObject5 = go.transform.Find("QA/center").gameObject;
			gameObject.SetActive(false);
			gameObject2.SetActive(false);
			gameObject3.SetActive(false);
			gameObject4.SetActive(false);
			gameObject5.SetActive(false);
			this.timeLabel = null;
		}

		// Token: 0x0600B1A4 RID: 45476 RVA: 0x00221CF0 File Offset: 0x0021FEF0
		private bool OnEnterVoiceQAClick(IXUIButton btn)
		{
			this._doc.JoinGuildVoiceInfo();
			return true;
		}

		// Token: 0x0600B1A5 RID: 45477 RVA: 0x00221D10 File Offset: 0x0021FF10
		private bool OnOpenVoiceQAClick(IXUIButton btn)
		{
			this._doc.OpenGuildVoiceQuery();
			return true;
		}

		// Token: 0x0600B1A6 RID: 45478 RVA: 0x00221D30 File Offset: 0x0021FF30
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.timeLabel == null;
			if (!flag)
			{
				int num = (int)(this.targetTime - Time.time);
				bool flag2 = num < 0;
				if (flag2)
				{
					this._doc.GetGuildVoiceInfo();
				}
				bool flag3 = num < 0;
				if (flag3)
				{
					this.timeLabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(0, 3, 3, 4, false, true));
				}
				else
				{
					this.timeLabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(num, 3, 3, 4, false, true));
				}
			}
		}

		// Token: 0x0600B1A7 RID: 45479 RVA: 0x00221DB8 File Offset: 0x0021FFB8
		public override void StackRefresh()
		{
			base.StackRefresh();
			this._doc.GetGuildVoiceInfo();
		}

		// Token: 0x04004474 RID: 17524
		private IXUILabel timeLabel = null;

		// Token: 0x04004475 RID: 17525
		private float targetTime = 0f;

		// Token: 0x04004476 RID: 17526
		private XGuildRelaxGameDocument _doc = null;
	}
}
