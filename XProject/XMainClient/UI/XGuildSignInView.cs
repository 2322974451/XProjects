using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018AD RID: 6317
	internal class XGuildSignInView : DlgBase<XGuildSignInView, XGuildSignInBehaviour>
	{
		// Token: 0x17003A1F RID: 14879
		// (get) Token: 0x0601075F RID: 67423 RVA: 0x004072CC File Offset: 0x004054CC
		public XGuildLogView LogView
		{
			get
			{
				return this._LogView;
			}
		}

		// Token: 0x17003A20 RID: 14880
		// (get) Token: 0x06010760 RID: 67424 RVA: 0x004072E4 File Offset: 0x004054E4
		public override string fileName
		{
			get
			{
				return "Guild/GuildSignInDlg";
			}
		}

		// Token: 0x17003A21 RID: 14881
		// (get) Token: 0x06010761 RID: 67425 RVA: 0x004072FC File Offset: 0x004054FC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A22 RID: 14882
		// (get) Token: 0x06010762 RID: 67426 RVA: 0x00407310 File Offset: 0x00405510
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A23 RID: 14883
		// (get) Token: 0x06010763 RID: 67427 RVA: 0x00407324 File Offset: 0x00405524
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A24 RID: 14884
		// (get) Token: 0x06010764 RID: 67428 RVA: 0x00407338 File Offset: 0x00405538
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A25 RID: 14885
		// (get) Token: 0x06010765 RID: 67429 RVA: 0x0040734C File Offset: 0x0040554C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010766 RID: 67430 RVA: 0x00407360 File Offset: 0x00405560
		protected override void Init()
		{
			this._SignInDoc = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
			this._SignInDoc.GuildSignInView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			GuildCheckinBoxTable.RowData[] boxTableData = XGuildSignInDocument.GetBoxTableData();
			uint num = 0U;
			this.CHEST_COUNT = boxTableData.Length;
			this.m_Progress = new XChestProgress(base.uiBehaviour.m_ExpProgress);
			for (int i = 0; i < this.CHEST_COUNT; i++)
			{
				GuildCheckinBoxTable.RowData rowData = boxTableData[i];
				XChest xchest = new XChest(base.uiBehaviour.m_ChestPool.FetchGameObject(false), null);
				xchest.SetExp(rowData.process);
				num = Math.Max(num, rowData.process);
				this.m_Progress.AddChest(xchest);
			}
			this.m_Progress.SetExp(0U, num);
			base.uiBehaviour.m_BtnLog.SetVisible(false);
			this.m_Buttons.Clear();
			this.m_ButtonGos.Clear();
			GuildCheckinTable.RowData[] signInTableData = XGuildSignInDocument.GetSignInTableData();
			this.BUTTON_COUNT = signInTableData.Length;
			Vector3 tplPos = base.uiBehaviour.m_SignInButtonPool.TplPos;
			for (int j = 0; j < this.BUTTON_COUNT; j++)
			{
				GuildCheckinTable.RowData rowData2 = signInTableData[j];
				GameObject gameObject = base.uiBehaviour.m_SignInButtonPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(base.uiBehaviour.m_SignInButtonPool.TplWidth * j), tplPos.y);
				this.m_ButtonGos.Add(gameObject);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Progress").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Contribute").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = gameObject.transform.FindChild("BtnOK/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUIButton item = gameObject.transform.FindChild("BtnOK").GetComponent("XUIButton") as IXUIButton;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = gameObject.transform.FindChild("Title").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite("gh_qd_" + rowData2.type);
				ixuisprite2.SetSprite("gh_qd_word_" + rowData2.type);
				ixuilabel.SetText("+" + rowData2.process);
				ixuilabel2.SetText("+" + rowData2.reward[1]);
				ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatCostWithIcon((int)rowData2.consume[1], (ItemEnum)rowData2.consume[0]);
				this.m_Buttons.Add(item);
			}
			DlgHandlerBase.EnsureCreate<XGuildLogView>(ref this._LogView, base.uiBehaviour.m_LogPanel, null, true);
			this._LogView.LogSource = this._SignInDoc;
		}

		// Token: 0x06010767 RID: 67431 RVA: 0x004076A8 File Offset: 0x004058A8
		protected override void OnUnload()
		{
			this._SignInDoc.GuildSignInView = null;
			this.m_Progress.Unload();
			DlgHandlerBase.EnsureUnload<XGuildLogView>(ref this._LogView);
			base.OnUnload();
		}

		// Token: 0x06010768 RID: 67432 RVA: 0x004076D8 File Offset: 0x004058D8
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnLog.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnLogBtnClick));
			for (int i = 0; i < this.CHEST_COUNT; i++)
			{
				this.m_Progress.ChestList[i].m_Chest.ID = (ulong)((long)i);
				this.m_Progress.ChestList[i].m_Chest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			}
			for (int j = 0; j < this.BUTTON_COUNT; j++)
			{
				this.m_Buttons[j].ID = (ulong)((long)(j + 1));
				this.m_Buttons[j].RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSignInBtnClick));
			}
		}

		// Token: 0x06010769 RID: 67433 RVA: 0x004077C8 File Offset: 0x004059C8
		protected override void OnShow()
		{
			this._LogView.SetVisible(false);
			this._SignInDoc.ReqAllInfo();
			this.RefreshProgress();
		}

		// Token: 0x0601076A RID: 67434 RVA: 0x004077EB File Offset: 0x004059EB
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.m_Progress.Update(Time.deltaTime);
		}

		// Token: 0x0601076B RID: 67435 RVA: 0x00407808 File Offset: 0x00405A08
		public void Refresh()
		{
			base.uiBehaviour.m_MemberCount.SetText(string.Format("{0}/{1}", this._SignInDoc.CurrentCount, this._SignInDoc.TotalCount));
			for (int i = 0; i < this.BUTTON_COUNT; i++)
			{
				this.m_Buttons[i].SetEnable(this._SignInDoc.SignInSelection == 0U, false);
				GameObject gameObject = this.m_Buttons[i].gameObject.transform.FindChild("RedPoint").gameObject;
				gameObject.SetActive(false);
			}
			for (int j = 0; j < this.CHEST_COUNT; j++)
			{
				this.m_Progress.ChestList[j].Opened = this._SignInDoc.IsBoxOpen(j);
			}
		}

		// Token: 0x0601076C RID: 67436 RVA: 0x004078F3 File Offset: 0x00405AF3
		public void RefreshProgress()
		{
			this.m_Progress.TargetExp = this._SignInDoc.Progress;
			base.uiBehaviour.m_ExpTween.SetNumberWithTween((ulong)this._SignInDoc.Progress, "", false, true);
		}

		// Token: 0x0601076D RID: 67437 RVA: 0x00407934 File Offset: 0x00405B34
		public void OpenBox(int index)
		{
			for (int i = 0; i < this.CHEST_COUNT; i++)
			{
				bool flag = i != index;
				if (!flag)
				{
					XChest xchest = this.m_Progress.ChestList[i];
					xchest.Open();
					break;
				}
			}
		}

		// Token: 0x0601076E RID: 67438 RVA: 0x00407980 File Offset: 0x00405B80
		private void OnChestClicked(IXUISprite iSp)
		{
			uint num = (uint)iSp.ID;
			bool flag = !this.m_Progress.IsExpEnough((int)num);
			if (flag)
			{
				GuildCheckinBoxTable.RowData rowData = XGuildSignInDocument.GetBoxTableData()[(int)num];
				bool flag2 = rowData == null;
				if (!flag2)
				{
					List<uint> list = new List<uint>();
					List<uint> list2 = new List<uint>();
					for (int i = 0; i < rowData.viewabledrop.Count; i++)
					{
						list.Add(rowData.viewabledrop[i, 0]);
						list2.Add(rowData.viewabledrop[i, 1]);
					}
					DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.Show(list, list2, false);
					DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.SetGlobalPosition(iSp.gameObject.transform.position);
				}
			}
			else
			{
				this._SignInDoc.ReqFetchBox(num);
			}
		}

		// Token: 0x0601076F RID: 67439 RVA: 0x00407A58 File Offset: 0x00405C58
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010770 RID: 67440 RVA: 0x00407A74 File Offset: 0x00405C74
		private bool _OnSignInBtnClick(IXUIButton go)
		{
			this._SignInDoc.ReqSignIn((uint)go.ID);
			return true;
		}

		// Token: 0x06010771 RID: 67441 RVA: 0x00407A9C File Offset: 0x00405C9C
		private bool _OnLogBtnClick(IXUIButton go)
		{
			this._SignInDoc.ReqLogList();
			this._LogView.SetVisible(true);
			return true;
		}

		// Token: 0x040076F3 RID: 30451
		public int BUTTON_COUNT = 3;

		// Token: 0x040076F4 RID: 30452
		public int CHEST_COUNT = 4;

		// Token: 0x040076F5 RID: 30453
		private XGuildSignInDocument _SignInDoc;

		// Token: 0x040076F6 RID: 30454
		private XGuildDocument _GuildDoc;

		// Token: 0x040076F7 RID: 30455
		private XGuildLogView _LogView;

		// Token: 0x040076F8 RID: 30456
		private XChestProgress m_Progress;

		// Token: 0x040076F9 RID: 30457
		private List<IXUIButton> m_Buttons = new List<IXUIButton>();

		// Token: 0x040076FA RID: 30458
		private List<GameObject> m_ButtonGos = new List<GameObject>();
	}
}
