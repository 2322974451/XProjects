using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildSignInView : DlgBase<XGuildSignInView, XGuildSignInBehaviour>
	{

		public XGuildLogView LogView
		{
			get
			{
				return this._LogView;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildSignInDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

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

		protected override void OnUnload()
		{
			this._SignInDoc.GuildSignInView = null;
			this.m_Progress.Unload();
			DlgHandlerBase.EnsureUnload<XGuildLogView>(ref this._LogView);
			base.OnUnload();
		}

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

		protected override void OnShow()
		{
			this._LogView.SetVisible(false);
			this._SignInDoc.ReqAllInfo();
			this.RefreshProgress();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.m_Progress.Update(Time.deltaTime);
		}

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

		public void RefreshProgress()
		{
			this.m_Progress.TargetExp = this._SignInDoc.Progress;
			base.uiBehaviour.m_ExpTween.SetNumberWithTween((ulong)this._SignInDoc.Progress, "", false, true);
		}

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

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnSignInBtnClick(IXUIButton go)
		{
			this._SignInDoc.ReqSignIn((uint)go.ID);
			return true;
		}

		private bool _OnLogBtnClick(IXUIButton go)
		{
			this._SignInDoc.ReqLogList();
			this._LogView.SetVisible(true);
			return true;
		}

		public int BUTTON_COUNT = 3;

		public int CHEST_COUNT = 4;

		private XGuildSignInDocument _SignInDoc;

		private XGuildDocument _GuildDoc;

		private XGuildLogView _LogView;

		private XChestProgress m_Progress;

		private List<IXUIButton> m_Buttons = new List<IXUIButton>();

		private List<GameObject> m_ButtonGos = new List<GameObject>();
	}
}
