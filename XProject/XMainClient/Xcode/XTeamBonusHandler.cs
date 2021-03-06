using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamBonusHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_Root = (base.PanelObject.GetComponent("XUIButton") as IXUIButton);
			this.m_TitleActive = base.PanelObject.transform.Find("TitleActive").gameObject;
			this.m_TitleDisactive = base.PanelObject.transform.Find("TitleDisactive").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("AttrActive");
			Transform transform2 = base.PanelObject.transform.FindChild("AttrDisactive");
			this.m_AttrActive = transform.gameObject;
			this.m_AttrDisactive = transform2.gameObject;
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("TeamGuildBuff").Split(XGlobalConfig.SequenceSeparator);
			int num = int.Parse(array[0]);
			int num2 = int.Parse(array[1]);
			BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(num, num2);
			bool flag = buffData == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("TeamGuildBuff: Buff data not found: [{0} {1}]", num, num2), null, null, null, null, null);
			}
			else
			{
				IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = transform2.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = transform2.Find("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(buffData.BuffName);
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(buffData.BuffName);
				ixuilabel4.SetText(string.Empty);
			}
		}

		public void Refresh()
		{
			bool flag = !this._TeamDoc.bInTeam;
			if (flag)
			{
				this._Enable(false);
			}
			else
			{
				XTeamMember myData = this._TeamDoc.MyTeam.myData;
				bool flag2 = myData == null || myData.guildID == 0UL;
				if (flag2)
				{
					this._Enable(false);
				}
				else
				{
					bool flag3 = false;
					for (int i = 0; i < this._TeamDoc.MyTeam.members.Count; i++)
					{
						XTeamMember xteamMember = this._TeamDoc.MyTeam.members[i];
						bool flag4 = xteamMember != myData && xteamMember.guildID == myData.guildID;
						if (flag4)
						{
							flag3 = true;
							break;
						}
					}
					bool flag5 = !flag3;
					if (flag5)
					{
						this._Enable(false);
					}
					else
					{
						this._Enable(true);
					}
				}
			}
		}

		private void _Enable(bool bEnable)
		{
			this.m_TitleActive.SetActive(bEnable);
			this.m_TitleDisactive.SetActive(!bEnable);
			this.m_AttrActive.SetActive(bEnable);
			this.m_AttrDisactive.SetActive(!bEnable);
		}

		private XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XTeamDocument _TeamDoc;

		private IXUIButton m_Root;

		private GameObject m_TitleActive;

		private GameObject m_TitleDisactive;

		private GameObject m_AttrActive;

		private GameObject m_AttrDisactive;
	}
}
