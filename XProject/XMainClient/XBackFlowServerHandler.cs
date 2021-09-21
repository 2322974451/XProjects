using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A1D RID: 2589
	internal class XBackFlowServerHandler : DlgHandlerBase
	{
		// Token: 0x17002EBC RID: 11964
		// (get) Token: 0x06009E4B RID: 40523 RVA: 0x0019F094 File Offset: 0x0019D294
		protected override string FileName
		{
			get
			{
				return "Hall/BfRecommendHandler";
			}
		}

		// Token: 0x06009E4C RID: 40524 RVA: 0x0019F0AC File Offset: 0x0019D2AC
		protected override void Init()
		{
			base.Init();
			this._chooseServer = (base.transform.Find("Server/Response/Select0/Bg").GetComponent("XUISprite") as IXUISprite);
			this._chooseRole = (base.transform.Find("Server/Response/Select1/Bg").GetComponent("XUISprite") as IXUISprite);
			this._serverList = base.transform.Find("Server/Response/ServerList");
			this._serverBlock = (this._serverList.Find("Block").GetComponent("XUISprite") as IXUISprite);
			this._serverScrollView = (this._serverList.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._serverWrapContent = (this._serverList.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._roleList = base.transform.Find("Server/Response/RoleList");
			this._roleBlock = (this._roleList.Find("Block").GetComponent("XUISprite") as IXUISprite);
			this._roleScrollView = (this._roleList.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._roleWrapContent = (this._roleList.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._btnGo = (base.transform.Find("BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._serverLabel = (base.transform.Find("Server/Response/Select0/ServerName").GetComponent("XUILabel") as IXUILabel);
			this._roleLabel = (base.transform.Find("Server/Response/Select1/RoleName").GetComponent("XUILabel") as IXUILabel);
			this._descibleLabel = (base.transform.Find("Server/Task").GetComponent("XUILabel") as IXUILabel);
			this._btnLabel = (base.transform.Find("BtnGo/Text").GetComponent("XUILabel") as IXUILabel);
			this._chooseRole.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowRoleList));
			this._chooseServer.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowServerList));
			this._serverBlock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseServerList));
			this._roleBlock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseRoleList));
			this._serverWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateServerItem));
			this._serverWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnInitServerItem));
			this._roleWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateRoleItem));
			this._roleWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnInitRoleItem));
			this._btnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnConfirmSelect));
			this.RefreshRewards();
		}

		// Token: 0x06009E4D RID: 40525 RVA: 0x0019F3B0 File Offset: 0x0019D5B0
		private void UpdateDesLabel()
		{
			string @string = XStringDefineProxy.GetString("backMassage");
			SeqList<int> sequence3List = XSingleton<XGlobalConfig>.singleton.GetSequence3List("NewZoneChargeBackTime", false);
			SeqList<int> sequence3List2 = XSingleton<XGlobalConfig>.singleton.GetSequence3List("NewZoneOpenTime", false);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("NewZoneChargeBackRange", false);
			SeqList<int> sequence3List3 = XSingleton<XGlobalConfig>.singleton.GetSequence3List("NewZoneChargeBackRewardEndTime", false);
			string string2 = XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD");
			string text = new DateTime(sequence3List[0, 0], sequence3List[0, 1], sequence3List[0, 2]).ToString(string2) + "--" + new DateTime(sequence3List[1, 0], sequence3List[1, 1], sequence3List[1, 2]).ToString(string2);
			string text2 = new DateTime(sequence3List2[0, 0], sequence3List2[0, 1], sequence3List2[0, 2]).ToString(string2);
			string text3 = sequenceList[(int)(sequenceList.Count - 1), 0].ToString();
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("NewZoneChargeBackRate");
			int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("NewZoneChargeBackMax");
			string text4 = @int.ToString();
			string text5 = Mathf.Min((float)int2, (float)@int / 100f * XBackFlowDocument.Doc.TotalPay).ToString();
			string text6 = new DateTime(sequence3List3[0, 0], sequence3List3[0, 1], sequence3List3[0, 2]).ToString(string2);
			this._descibleLabel.SetText(string.Format(@string, new object[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				text6,
				text3
			}));
		}

		// Token: 0x06009E4E RID: 40526 RVA: 0x0019F578 File Offset: 0x0019D778
		private bool OnConfirmSelect(IXUIButton button)
		{
			bool flag = this._selectedRoleRoleID > 0UL;
			if (flag)
			{
				string message = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BackFlowBindConfirmTip"));
				XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.ToConfirmBind));
			}
			return true;
		}

		// Token: 0x06009E4F RID: 40527 RVA: 0x0019F5C8 File Offset: 0x0019D7C8
		private bool ToConfirmBind(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XBackFlowDocument.Doc.SendToSelectRoleServer(this._selectedRoleRoleID);
			return true;
		}

		// Token: 0x06009E50 RID: 40528 RVA: 0x0019F5F7 File Offset: 0x0019D7F7
		private void OnCloseServerList(IXUISprite uiSprite)
		{
			this._serverList.gameObject.SetActive(false);
		}

		// Token: 0x06009E51 RID: 40529 RVA: 0x0019F60C File Offset: 0x0019D80C
		private void OnCloseRoleList(IXUISprite uiSprite)
		{
			this._roleList.gameObject.SetActive(false);
		}

		// Token: 0x06009E52 RID: 40530 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E53 RID: 40531 RVA: 0x0019F624 File Offset: 0x0019D824
		protected override void OnShow()
		{
			base.OnShow();
			this._selectedRoleRoleID = 0UL;
			this._selectedServerid = 0U;
			this._ServerListData.Clear();
			this._roleListData.Clear();
			this._serverList.gameObject.SetActive(false);
			this._roleList.gameObject.SetActive(false);
			this._btnGo.SetEnable(false, false);
			XBackFlowDocument.Doc.SendToGetNewZoneBenefit();
		}

		// Token: 0x06009E54 RID: 40532 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009E55 RID: 40533 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06009E56 RID: 40534 RVA: 0x0019F69D File Offset: 0x0019D89D
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		// Token: 0x06009E57 RID: 40535 RVA: 0x0019F6B0 File Offset: 0x0019D8B0
		private void RefreshUI()
		{
			this.UpdateDesLabel();
			this._btnGo.SetEnable(XBackFlowDocument.Doc.SelectedRoleID == 0UL && !XBackFlowDocument.Doc.CanSelectRole && XBackFlowDocument.Doc.IsPayReturnOpen, false);
			bool flag = XBackFlowDocument.Doc.SelectedRoleID > 0UL;
			if (flag)
			{
				this._btnLabel.SetText(XStringDefineProxy.GetString("BackFlowPayBackRoleSelected"));
			}
			else
			{
				bool flag2 = !XBackFlowDocument.Doc.IsPayReturnOpen;
				if (flag2)
				{
					this._btnLabel.SetText(XStringDefineProxy.GetString("BackFlowPayBackOverdue"));
				}
				else
				{
					this._btnLabel.SetText(XStringDefineProxy.GetString("BackFlowPayBackToBind"));
				}
			}
			bool flag3 = XBackFlowDocument.Doc.SelectedRoleID > 0UL;
			if (flag3)
			{
				List<ZoneRoleInfo> serverRoleList = XBackFlowDocument.Doc.ServerRoleList;
				for (int i = 0; i < serverRoleList.Count; i++)
				{
					bool flag4 = serverRoleList[i].roleid == XBackFlowDocument.Doc.SelectedRoleID;
					if (flag4)
					{
						this._serverLabel.SetText(serverRoleList[i].servername);
						this._roleLabel.SetText(serverRoleList[i].rolename);
						break;
					}
				}
			}
			else
			{
				this._ServerListData = XBackFlowDocument.Doc.GetServerList();
				this._serverLabel.SetText(XStringDefineProxy.GetString("BackFlowToSelServer"));
				this._roleLabel.SetText(XStringDefineProxy.GetString("BackFlowToSelRole"));
			}
		}

		// Token: 0x06009E58 RID: 40536 RVA: 0x0019F834 File Offset: 0x0019DA34
		private void OnInitRoleItem(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectRoleItem));
		}

		// Token: 0x06009E59 RID: 40537 RVA: 0x0019F868 File Offset: 0x0019DA68
		private void OnSelectRoleItem(IXUISprite uiSprite)
		{
			this._selectedRoleRoleID = uiSprite.ID;
			this._roleList.gameObject.SetActive(false);
			bool flag = this._selectedRoleRoleID > 0UL;
			if (flag)
			{
				List<ZoneRoleInfo> serverRoleList = XBackFlowDocument.Doc.ServerRoleList;
				for (int i = 0; i < serverRoleList.Count; i++)
				{
					bool flag2 = this._selectedRoleRoleID == serverRoleList[i].roleid;
					if (flag2)
					{
						this._roleLabel.SetText(serverRoleList[i].rolename);
						break;
					}
				}
			}
		}

		// Token: 0x06009E5A RID: 40538 RVA: 0x0019F8FC File Offset: 0x0019DAFC
		private void OnInitServerItem(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectServerItem));
		}

		// Token: 0x06009E5B RID: 40539 RVA: 0x0019F930 File Offset: 0x0019DB30
		private void OnSelectServerItem(IXUISprite uiSprite)
		{
			this._serverList.gameObject.SetActive(false);
			bool flag = (uint)uiSprite.ID != this._selectedServerid;
			if (flag)
			{
				this._selectedServerid = (uint)uiSprite.ID;
				List<ZoneRoleInfo> serverRoleList = XBackFlowDocument.Doc.ServerRoleList;
				for (int i = 0; i < serverRoleList.Count; i++)
				{
					bool flag2 = this._selectedServerid == serverRoleList[i].serverid;
					if (flag2)
					{
						this._serverLabel.SetText(serverRoleList[i].servername);
						break;
					}
				}
				this._selectedRoleRoleID = 0UL;
				this._roleLabel.SetText(XStringDefineProxy.GetString("BackFlowToSelRole"));
			}
		}

		// Token: 0x06009E5C RID: 40540 RVA: 0x0019F9F0 File Offset: 0x0019DBF0
		private void OnUpdateRoleItem(Transform itemTransform, int index)
		{
			bool flag = index < this._roleListData.Count;
			if (flag)
			{
				IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = this._roleListData[index];
				IXUILabel ixuilabel = itemTransform.Find("T").GetComponent("XUILabel") as IXUILabel;
				List<ZoneRoleInfo> serverRoleList = XBackFlowDocument.Doc.ServerRoleList;
				for (int i = 0; i < serverRoleList.Count; i++)
				{
					bool flag2 = this._roleListData[index] == serverRoleList[i].roleid;
					if (flag2)
					{
						ixuilabel.SetText(serverRoleList[i].rolename);
						break;
					}
				}
			}
		}

		// Token: 0x06009E5D RID: 40541 RVA: 0x0019FAB4 File Offset: 0x0019DCB4
		private void OnUpdateServerItem(Transform itemTransform, int index)
		{
			bool flag = index < this._ServerListData.Count;
			if (flag)
			{
				IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this._ServerListData[index];
				IXUILabel ixuilabel = itemTransform.Find("T").GetComponent("XUILabel") as IXUILabel;
				List<ZoneRoleInfo> serverRoleList = XBackFlowDocument.Doc.ServerRoleList;
				for (int i = 0; i < serverRoleList.Count; i++)
				{
					bool flag2 = this._ServerListData[index] == serverRoleList[i].serverid;
					if (flag2)
					{
						ixuilabel.SetText(serverRoleList[i].servername);
						break;
					}
				}
			}
		}

		// Token: 0x06009E5E RID: 40542 RVA: 0x0019FB7C File Offset: 0x0019DD7C
		private void OnShowServerList(IXUISprite uiSprite)
		{
			bool flag = XBackFlowDocument.Doc.SelectedRoleID == 0UL;
			if (flag)
			{
				this._serverList.gameObject.SetActive(true);
				this._serverWrapContent.SetContentCount(this._ServerListData.Count, false);
				this._serverScrollView.ResetPosition();
			}
		}

		// Token: 0x06009E5F RID: 40543 RVA: 0x0019FBD4 File Offset: 0x0019DDD4
		private void OnShowRoleList(IXUISprite uiSprite)
		{
			bool flag = XBackFlowDocument.Doc.SelectedRoleID == 0UL;
			if (flag)
			{
				bool flag2 = this._ServerListData.Contains(this._selectedServerid);
				if (flag2)
				{
					this._roleListData = XBackFlowDocument.Doc.GetRoleListByServerid(this._selectedServerid);
					this._roleList.gameObject.SetActive(true);
					this._roleWrapContent.SetContentCount(this._roleListData.Count, false);
					this._roleScrollView.ResetPosition();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PleaseSelectServerFirst"), "fece00");
				}
			}
		}

		// Token: 0x06009E60 RID: 40544 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void RefreshRewards()
		{
		}

		// Token: 0x04003819 RID: 14361
		private IXUISprite _chooseServer;

		// Token: 0x0400381A RID: 14362
		private IXUISprite _chooseRole;

		// Token: 0x0400381B RID: 14363
		private IXUISprite _serverBlock;

		// Token: 0x0400381C RID: 14364
		private IXUISprite _roleBlock;

		// Token: 0x0400381D RID: 14365
		private IXUIButton _btnGo;

		// Token: 0x0400381E RID: 14366
		private Transform _serverList;

		// Token: 0x0400381F RID: 14367
		private IXUIScrollView _serverScrollView;

		// Token: 0x04003820 RID: 14368
		private IXUIWrapContent _serverWrapContent;

		// Token: 0x04003821 RID: 14369
		private Transform _roleList;

		// Token: 0x04003822 RID: 14370
		private IXUIScrollView _roleScrollView;

		// Token: 0x04003823 RID: 14371
		private IXUIWrapContent _roleWrapContent;

		// Token: 0x04003824 RID: 14372
		private IXUILabel _serverLabel;

		// Token: 0x04003825 RID: 14373
		private IXUILabel _roleLabel;

		// Token: 0x04003826 RID: 14374
		private IXUILabel _descibleLabel;

		// Token: 0x04003827 RID: 14375
		private IXUILabel _btnLabel;

		// Token: 0x04003828 RID: 14376
		private uint _selectedServerid = 0U;

		// Token: 0x04003829 RID: 14377
		private List<uint> _ServerListData = new List<uint>();

		// Token: 0x0400382A RID: 14378
		private ulong _selectedRoleRoleID = 0UL;

		// Token: 0x0400382B RID: 14379
		private List<ulong> _roleListData = new List<ulong>();
	}
}
