using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamSettingHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Team/TeamSetting";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnOK = (base.PanelObject.transform.Find("BtnOK").GetComponent("XUIButton") as IXUIButton);
			int num = 1;
			for (;;)
			{
				Transform transform = base.PanelObject.transform.Find(XSingleton<XCommon>.singleton.StringCombine("TeamReward/BtnLevel", num.ToString()));
				bool flag = transform == null;
				if (flag)
				{
					break;
				}
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)(num - 1));
				this.m_RewardList.Add(ixuicheckBox);
				num++;
			}
			this.m_OpenReward = (base.PanelObject.transform.Find("TeamReward/BtnOpen").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_OpenPPT = (base.PanelObject.transform.Find("PPTSetting/BtnOpen").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_DisableReward = base.PanelObject.transform.Find("TeamRewardDisable").gameObject;
			this.m_AddPPT = (base.PanelObject.transform.Find("PPTSetting/Count/Add").GetComponent("XUISprite") as IXUISprite);
			this.m_SubPPT = (base.PanelObject.transform.Find("PPTSetting/Count/Sub").GetComponent("XUISprite") as IXUISprite);
			this.m_PPT = (base.PanelObject.transform.Find("PPTSetting/Count/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_StepPPT = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("TeamSettingPPTStep");
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			this.m_BtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKClicked));
			this.m_OpenPPT.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnOpenPPTChanged));
			this.m_OpenReward.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnOpenRewardChanged));
			for (int i = 0; i < this.m_RewardList.Count; i++)
			{
				this.m_RewardList[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnRewardChanged));
			}
			this.m_AddPPT.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnAddPPTClicked));
			this.m_SubPPT.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSubPPTClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = !this.doc.bInTeam || this.doc.currentExpInfo == null;
			if (flag)
			{
				base.SetVisible(false);
			}
			else
			{
				for (int i = 0; i < this.m_RewardList.Count; i++)
				{
					this.m_RewardList[i].ForceSetFlag(false);
				}
				bool flag2 = this.doc.currentExpInfo.CostType.Count == 0;
				if (flag2)
				{
					this.m_OpenReward.ForceSetFlag(false);
					this.m_DisableReward.SetActive(true);
					this.m_RewardCount = 0;
				}
				else
				{
					this.m_DisableReward.SetActive(false);
					this.m_OpenReward.ForceSetFlag(this.doc.MyTeam.teamBrief.goldGroup.bActive);
					this.m_RewardCount = Math.Min(this.doc.currentExpInfo.CostType.Count, this.m_RewardList.Count);
					int i;
					for (i = 0; i < this.m_RewardCount; i++)
					{
						this.m_RewardList[i].gameObject.SetActive(true);
						IXUILabel ixuilabel = this.m_RewardList[i].gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
						IXUISprite ixuisprite = this.m_RewardList[i].gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.doc.currentExpInfo.CostType[i, 1]);
						bool flag3 = this.doc.currentExpInfo.CostType[i, 0] == 2U;
						string text;
						if (flag3)
						{
							text = ((itemConf == null) ? string.Empty : XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U));
						}
						else
						{
							text = this.doc.currentExpInfo.CostType[i, 2].ToString();
						}
						ixuilabel.SetText(text);
						ixuisprite.SetSprite((itemConf == null) ? string.Empty : XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon1, 0U));
						ixuisprite.MakePixelPerfect();
						bool flag4 = this.doc.MyTeam.teamBrief.goldGroup.bActive && i == this.doc.MyTeam.teamBrief.goldGroup.index;
						if (flag4)
						{
							this.m_RewardList[i].bChecked = true;
						}
					}
					while (i < this.m_RewardList.Count)
					{
						this.m_RewardList[i].gameObject.SetActive(false);
						i++;
					}
				}
				this.m_MinPPT = this.doc.currentExpInfo.DisplayPPT;
				this.m_CurPPT = this.doc.MyTeam.teamBrief.teamPPT;
				this.m_OpenPPT.bChecked = (this.doc.MyTeam.teamBrief.teamPPT > 0U);
			}
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		private bool _OnOKClicked(IXUIButton btn)
		{
			bool flag = !this.doc.bInTeam;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				int num = -1;
				bool bChecked = this.m_OpenReward.bChecked;
				if (bChecked)
				{
					for (int i = 0; i < this.m_RewardCount; i++)
					{
						bool bChecked2 = this.m_RewardList[i].bChecked;
						if (bChecked2)
						{
							num = i;
							break;
						}
					}
				}
				bool flag2 = num >= 0 && num < this.doc.currentExpInfo.CostType.Count;
				if (flag2)
				{
					bool flag3 = this.doc.MyTeam.teamBrief.goldGroup.index != num;
					if (flag3)
					{
						string key = XSingleton<XCommon>.singleton.StringCombine("TeamGoldGroup", this.doc.currentExpInfo.CostType[num, 0].ToString(), "SettingConfirm");
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.doc.currentExpInfo.CostType[num, 1]);
						bool flag4 = itemConf == null;
						if (flag4)
						{
							return true;
						}
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString(key, new object[]
						{
							XGoldGroupData.GetName(ref this.doc.currentExpInfo.CostType, num),
							XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U),
							this.doc.currentExpInfo.CostType[num, 2].ToString()
						}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._DoOK));
						return true;
					}
				}
				this._DoOK(btn);
				result = true;
			}
			return result;
		}

		private bool _DoOK(IXUIButton btn)
		{
			TeamExtraInfo teamExtraInfo = new TeamExtraInfo();
			bool bChecked = this.m_OpenReward.bChecked;
			if (bChecked)
			{
				for (int i = 0; i < this.m_RewardCount; i++)
				{
					bool bChecked2 = this.m_RewardList[i].bChecked;
					if (bChecked2)
					{
						teamExtraInfo.costindex = (uint)i;
						break;
					}
				}
			}
			else
			{
				teamExtraInfo.costindex = uint.MaxValue;
			}
			bool bChecked3 = this.m_OpenPPT.bChecked;
			if (bChecked3)
			{
				teamExtraInfo.pptlimit = this.m_CurPPT;
			}
			else
			{
				teamExtraInfo.pptlimit = 0U;
			}
			this.doc.ReqTeamOp(TeamOperate.TEAM_PPTLIMIT, 0UL, teamExtraInfo, TeamMemberType.TMT_NORMAL, null);
			bool flag = this.doc.bInTeam && this.doc.MyTeam.teamBrief.goldGroup.index != (int)teamExtraInfo.costindex;
			if (flag)
			{
				this.doc.ReqTeamOp(TeamOperate.TEAM_COSTTYPE, 0UL, teamExtraInfo, TeamMemberType.TMT_NORMAL, null);
			}
			base.SetVisible(false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool _OnOpenRewardChanged(IXUICheckBox ckb)
		{
			bool bChecked = ckb.bChecked;
			if (bChecked)
			{
				bool flag = this.m_RewardCount > 0;
				if (flag)
				{
					this.m_RewardList[0].bChecked = true;
				}
			}
			else
			{
				for (int i = 0; i < this.m_RewardCount; i++)
				{
					this.m_RewardList[i].bChecked = false;
				}
			}
			return true;
		}

		private bool _OnOpenPPTChanged(IXUICheckBox ckb)
		{
			bool flag = ckb.bChecked && this.m_CurPPT < this.m_MinPPT;
			if (flag)
			{
				this.m_CurPPT = this.m_MinPPT;
			}
			this._RefreshPPT();
			return true;
		}

		private bool _OnRewardChanged(IXUICheckBox ckb)
		{
			this.m_OpenReward.bChecked = ckb.bChecked;
			return true;
		}

		private void _OnAddPPTClicked(IXUISprite iSp)
		{
			bool flag = !this.m_OpenPPT.bChecked;
			if (!flag)
			{
				bool flag2 = this.m_CurPPT >= uint.MaxValue - this.m_StepPPT;
				if (!flag2)
				{
					this.m_CurPPT += this.m_StepPPT;
					this._RefreshPPT();
				}
			}
		}

		private void _OnSubPPTClicked(IXUISprite iSp)
		{
			bool flag = !this.m_OpenPPT.bChecked;
			if (!flag)
			{
				bool flag2 = this.m_CurPPT <= this.m_MinPPT;
				if (!flag2)
				{
					this.m_CurPPT -= this.m_StepPPT;
					this._RefreshPPT();
				}
			}
		}

		private void _RefreshPPT()
		{
			this.m_PPT.SetText(this.m_OpenPPT.bChecked ? this.m_CurPPT.ToString() : "0");
		}

		private IXUISprite m_Close;

		private IXUIButton m_BtnOK;

		private List<IXUICheckBox> m_RewardList = new List<IXUICheckBox>();

		private IXUICheckBox m_OpenReward;

		private IXUICheckBox m_OpenPPT;

		private IXUISprite m_AddPPT;

		private IXUISprite m_SubPPT;

		private IXUILabel m_PPT;

		private GameObject m_DisableReward;

		private XTeamDocument doc;

		private int m_RewardCount;

		private uint m_CurPPT;

		private uint m_MinPPT;

		private uint m_StepPPT;
	}
}
