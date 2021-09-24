using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildRelaxVoiceHandler : GuildRelaxChildHandler
	{

		public override void SetUnLockLevel()
		{
			base.SetUnLockLevel();
			this.SetVoiceInfo(base.transform.gameObject);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.GetGuildVoiceInfo();
		}

		protected override void Init()
		{
			base.Init();
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_VoiceQA);
			this._doc = XDocuments.GetSpecificDocument<XGuildRelaxGameDocument>(XGuildRelaxGameDocument.uuID);
		}

		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(false);
		}

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

		private bool OnEnterVoiceQAClick(IXUIButton btn)
		{
			this._doc.JoinGuildVoiceInfo();
			return true;
		}

		private bool OnOpenVoiceQAClick(IXUIButton btn)
		{
			this._doc.OpenGuildVoiceQuery();
			return true;
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
			this._doc.GetGuildVoiceInfo();
		}

		private IXUILabel timeLabel = null;

		private float targetTime = 0f;

		private XGuildRelaxGameDocument _doc = null;
	}
}
