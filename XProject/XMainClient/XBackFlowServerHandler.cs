using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowServerHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfRecommendHandler";
			}
		}

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

		private bool ToConfirmBind(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XBackFlowDocument.Doc.SendToSelectRoleServer(this._selectedRoleRoleID);
			return true;
		}

		private void OnCloseServerList(IXUISprite uiSprite)
		{
			this._serverList.gameObject.SetActive(false);
		}

		private void OnCloseRoleList(IXUISprite uiSprite)
		{
			this._roleList.gameObject.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

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

		private void OnInitRoleItem(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectRoleItem));
		}

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

		private void OnInitServerItem(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectServerItem));
		}

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

		private void RefreshRewards()
		{
		}

		private IXUISprite _chooseServer;

		private IXUISprite _chooseRole;

		private IXUISprite _serverBlock;

		private IXUISprite _roleBlock;

		private IXUIButton _btnGo;

		private Transform _serverList;

		private IXUIScrollView _serverScrollView;

		private IXUIWrapContent _serverWrapContent;

		private Transform _roleList;

		private IXUIScrollView _roleScrollView;

		private IXUIWrapContent _roleWrapContent;

		private IXUILabel _serverLabel;

		private IXUILabel _roleLabel;

		private IXUILabel _descibleLabel;

		private IXUILabel _btnLabel;

		private uint _selectedServerid = 0U;

		private List<uint> _ServerListData = new List<uint>();

		private ulong _selectedRoleRoleID = 0UL;

		private List<ulong> _roleListData = new List<ulong>();
	}
}
