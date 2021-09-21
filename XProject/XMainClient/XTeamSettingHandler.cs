using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D18 RID: 3352
	internal class XTeamSettingHandler : DlgHandlerBase
	{
		// Token: 0x170032EA RID: 13034
		// (get) Token: 0x0600BB00 RID: 47872 RVA: 0x002657F0 File Offset: 0x002639F0
		protected override string FileName
		{
			get
			{
				return "Team/TeamSetting";
			}
		}

		// Token: 0x0600BB01 RID: 47873 RVA: 0x00265808 File Offset: 0x00263A08
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

		// Token: 0x0600BB02 RID: 47874 RVA: 0x002659F4 File Offset: 0x00263BF4
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

		// Token: 0x0600BB03 RID: 47875 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600BB04 RID: 47876 RVA: 0x00265AD4 File Offset: 0x00263CD4
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

		// Token: 0x0600BB05 RID: 47877 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600BB06 RID: 47878 RVA: 0x00265E24 File Offset: 0x00264024
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

		// Token: 0x0600BB07 RID: 47879 RVA: 0x00265FE8 File Offset: 0x002641E8
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

		// Token: 0x0600BB08 RID: 47880 RVA: 0x002660FC File Offset: 0x002642FC
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

		// Token: 0x0600BB09 RID: 47881 RVA: 0x0026616C File Offset: 0x0026436C
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

		// Token: 0x0600BB0A RID: 47882 RVA: 0x002661B0 File Offset: 0x002643B0
		private bool _OnRewardChanged(IXUICheckBox ckb)
		{
			this.m_OpenReward.bChecked = ckb.bChecked;
			return true;
		}

		// Token: 0x0600BB0B RID: 47883 RVA: 0x002661D8 File Offset: 0x002643D8
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

		// Token: 0x0600BB0C RID: 47884 RVA: 0x00266230 File Offset: 0x00264430
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

		// Token: 0x0600BB0D RID: 47885 RVA: 0x00266283 File Offset: 0x00264483
		private void _RefreshPPT()
		{
			this.m_PPT.SetText(this.m_OpenPPT.bChecked ? this.m_CurPPT.ToString() : "0");
		}

		// Token: 0x04004B63 RID: 19299
		private IXUISprite m_Close;

		// Token: 0x04004B64 RID: 19300
		private IXUIButton m_BtnOK;

		// Token: 0x04004B65 RID: 19301
		private List<IXUICheckBox> m_RewardList = new List<IXUICheckBox>();

		// Token: 0x04004B66 RID: 19302
		private IXUICheckBox m_OpenReward;

		// Token: 0x04004B67 RID: 19303
		private IXUICheckBox m_OpenPPT;

		// Token: 0x04004B68 RID: 19304
		private IXUISprite m_AddPPT;

		// Token: 0x04004B69 RID: 19305
		private IXUISprite m_SubPPT;

		// Token: 0x04004B6A RID: 19306
		private IXUILabel m_PPT;

		// Token: 0x04004B6B RID: 19307
		private GameObject m_DisableReward;

		// Token: 0x04004B6C RID: 19308
		private XTeamDocument doc;

		// Token: 0x04004B6D RID: 19309
		private int m_RewardCount;

		// Token: 0x04004B6E RID: 19310
		private uint m_CurPPT;

		// Token: 0x04004B6F RID: 19311
		private uint m_MinPPT;

		// Token: 0x04004B70 RID: 19312
		private uint m_StepPPT;
	}
}
