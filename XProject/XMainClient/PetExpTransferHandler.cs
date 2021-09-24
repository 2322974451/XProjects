using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class PetExpTransferHandler : DlgHandlerBase
	{

		public int ExpTransferPetCount
		{
			get
			{
				return this.doc.Pets.Count - 1;
			}
		}

		private bool CanPlayExpUp
		{
			get
			{
				return this.ChangeExp && !this.HasGetSkillUI && !this.InPlayExpUp[0] && !this.InPlayExpUp[1];
			}
		}

		public bool HasGetSkillUI
		{
			get
			{
				bool flag = this.SkillHandler[0] != null && this.SkillHandler[0].HasGetSkillUI;
				bool result;
				if (flag)
				{
					result = true;
				}
				else
				{
					bool flag2 = this.SkillHandler[1] != null && this.SkillHandler[1].HasGetSkillUI;
					result = flag2;
				}
				return result;
			}
			set
			{
				bool flag = this.SkillHandler[0] != null;
				if (flag)
				{
					this.SkillHandler[0].HasGetSkillUI = value;
				}
				bool flag2 = this.SkillHandler[1] != null;
				if (flag2)
				{
					this.SkillHandler[1].HasGetSkillUI = value;
				}
			}
		}

		public int DefaultPet
		{
			get
			{
				bool flag = this.doc.CurSelectedIndex == 0;
				int result;
				if (flag)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_PetListScrollView = (base.transform.Find("Bg/PetListPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("Bg/PetListPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Pet[0] = base.transform.Find("Bg/ExpTransferPanel/PetLeft");
			this.m_Pet[1] = base.transform.Find("Bg/ExpTransferPanel/PetRight");
			for (int i = 0; i < 2; i++)
			{
				this.m_ExpBar[i] = (this.m_Pet[i].Find("ExpBar").GetComponent("XUIProgress") as IXUIProgress);
				this.m_ExpBarLevel[i] = (this.m_ExpBar[i].gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
				this.m_Skill[i] = this.m_Pet[i].Find("Skill");
				this.m_HistoryLevelMAX[i] = (this.m_Pet[i].Find("T").GetComponent("XUILabel") as IXUILabel);
				this.m_PetSnapshot[i] = (this.m_Pet[i].Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
			}
			this.m_Ready = base.transform.Find("Bg/ExpTransferPanel/TransferStatus/Ready");
			this.m_Start = base.transform.Find("Bg/ExpTransferPanel/TransferStatus/Start");
			this.m_End = (base.transform.Find("Bg/ExpTransferPanel/TransferStatus/End").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Arrow = (this.m_Ready.Find("Arrow").GetComponent("XUISprite") as IXUISprite);
			this.m_CostItem = this.m_Ready.Find("Cost/Item");
			this.m_CostNum = (this.m_Ready.Find("Cost/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnTransfer = (this.m_Ready.Find("BtnTransfer").GetComponent("XUIButton") as IXUIButton);
			DlgHandlerBase.EnsureCreate<XPetSkillHandler>(ref this.SkillHandler[0], this.m_Skill[0].gameObject, null, true);
			DlgHandlerBase.EnsureCreate<XPetSkillHandler>(ref this.SkillHandler[1], this.m_Skill[1].gameObject, null, true);
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/PetExptransfer";
			}
		}

		public int CurExpTransferSelectedIndex
		{
			get
			{
				return this.m_CurExpTransferSelected;
			}
		}

		public XPet CurExpTransferSelectedPet
		{
			get
			{
				bool flag = this.m_CurExpTransferSelected >= this.doc.Pets.Count || this.m_CurExpTransferSelected < 0;
				XPet result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = this.doc.Pets[this.m_CurExpTransferSelected];
				}
				return result;
			}
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_BtnTransfer.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExpTransferClicked));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnPetListItemUpdated));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		public bool OnExpTransferClicked(IXUIButton btn)
		{
			bool canTransfer = this.m_CanTransfer;
			if (canTransfer)
			{
				RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
				rpcC2G_PetOperation.oArg.type = PetOP.PetExpTransfer;
				rpcC2G_PetOperation.oArg.uid = this.doc.CurSelectedPet.UID;
				rpcC2G_PetOperation.oArg.destpet_id = this.CurExpTransferSelectedPet.UID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
				this.m_CanTransfer = false;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Click To Fast", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("PetExpTransferHandler", 1);
			this.Select(this.DefaultPet, true);
			this.ClearPetAnimation();
			this.RefreshPetModel(1);
		}

		protected override void OnHide()
		{
			DlgBase<XPetMainView, XPetMainBehaviour>.singleton.UnloadFx(DlgBase<XPetMainView, XPetMainBehaviour>.singleton._LevelUpFx);
			base.Return3DAvatarPool();
			for (int i = 0; i < 2; i++)
			{
				bool flag = this.m_PetSnapshot[i] != null;
				if (flag)
				{
					this.m_PetSnapshot[i].RefreshRenderQueue = null;
				}
			}
			this.Select(-1, false);
			bool flag2 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				this.doc.View.RefreshPage(false);
			}
			base.OnHide();
		}

		public override void OnUnload()
		{
			for (int i = 0; i < 2; i++)
			{
				bool flag = this.m_PetSnapshot[i] != null;
				if (flag)
				{
					this.m_PetSnapshot[i].RefreshRenderQueue = null;
					this.m_PetSnapshot[i] = null;
				}
			}
			base.Return3DAvatarPool();
			this.Select(-1, false);
			this.doc = null;
			DlgHandlerBase.EnsureUnload<XPetSkillHandler>(ref this.SkillHandler[0]);
			DlgHandlerBase.EnsureUnload<XPetSkillHandler>(ref this.SkillHandler[1]);
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("PetExpTransferHandler", 1);
		}

		public void RefreshList(bool bResetPosition = true)
		{
			int num = Math.Min(this.doc.PetCountMax, this.ExpTransferPetCount);
			this.m_WrapContent.SetContentCount(num, false);
			if (bResetPosition)
			{
				this.m_PetListScrollView.ResetPosition();
			}
			else
			{
				this.m_WrapContent.RefreshAllVisibleContents();
			}
		}

		private void OnPetListItemUpdated(Transform t, int index)
		{
			bool flag = index < 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index:" + index, null, null, null, null, null);
			}
			else
			{
				IXUILabel ixuilabel = t.Find("Level").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("Item/uiIcon").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = t.Find("Item/Quality").GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject = t.Find("Mount").gameObject;
				GameObject gameObject2 = t.Find("Fight").gameObject;
				IXUISprite ixuisprite3 = t.GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject3 = t.Find("Selected").gameObject;
				GameObject gameObject4 = t.Find("Item").gameObject;
				bool flag2 = index >= this.doc.CurSelectedIndex;
				if (flag2)
				{
					index++;
				}
				bool flag3 = index >= this.doc.Pets.Count;
				if (flag3)
				{
					ixuilabel.SetText("");
					gameObject4.SetActive(false);
					gameObject.SetActive(false);
					gameObject2.SetActive(false);
					gameObject3.SetActive(false);
				}
				else
				{
					XPet xpet = this.doc.Pets[index];
					gameObject4.SetActive(true);
					ixuilabel.SetText("Lv." + xpet.showLevel);
					gameObject3.SetActive(index == this.m_CurExpTransferSelected);
					gameObject.SetActive(xpet.UID == this.doc.CurMount);
					gameObject2.SetActive(xpet.UID == this.doc.CurFightUID);
					PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(xpet.ID);
					bool flag4 = petInfo != null;
					if (flag4)
					{
						ixuisprite.SetSprite(petInfo.icon);
					}
					ixuisprite2.SetSprite(XSingleton<UiUtility>.singleton.GetItemQualityFrame((int)petInfo.quality, 0));
					ixuisprite3.ID = (ulong)((long)index);
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnPetClicked));
				}
			}
		}

		private void _OnPetClicked(IXUISprite iSp)
		{
			int index = (int)iSp.ID;
			this.Select(index, false);
		}

		public void Select(int index, bool bResetPosition = false)
		{
			this.ClearPetAnimation();
			bool flag = index <= this.ExpTransferPetCount;
			if (flag)
			{
				this.m_CurExpTransferSelected = index;
				bool flag2 = index != -1;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("uid:" + this.CurExpTransferSelectedPet.UID, null, null, null, null, null);
				}
			}
			this.TransferPet[0] = this.CurExpTransferSelectedPet;
			this.TransferPet[1] = this.doc.CurSelectedPet;
			this.m_CanTransfer = true;
			this.ShowCurPet(0);
			bool flag3 = base.IsVisible();
			if (flag3)
			{
				this.RefreshPage(bResetPosition);
				this.RefreshPetModel(0);
			}
		}

		public void ShowCurPet(int index)
		{
			bool flag = this.TransferPet[index] != null;
			if (flag)
			{
				this.TransferPet[index].Refresh();
				this.RefreshStatus(PetExpTransferStatus.Ready);
			}
			this.doc.petGetSkill.Clear();
		}

		public void Transfer(ulong uid1, ulong uid2)
		{
			bool flag = (uid1 == this.doc.CurSelectedPet.UID && uid2 == this.CurExpTransferSelectedPet.UID) || (uid2 == this.doc.CurSelectedPet.UID && uid1 == this.CurExpTransferSelectedPet.UID);
			if (flag)
			{
				this.ChangeExp = true;
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.doc.CurSelectedPet == null || this.CurExpTransferSelectedPet == null;
				if (!flag2)
				{
					bool canPlayExpUp = this.CanPlayExpUp;
					if (canPlayExpUp)
					{
						this.InPlayExpUp[0] = true;
						this.InPlayExpUp[1] = true;
						int requiredExp = this.doc.GetRequiredExp(this.CurExpTransferSelectedPet.ID, this.CurExpTransferSelectedPet.showLevel);
						this.AddExp[0] = this.doc.GetAddExp(requiredExp);
						int requiredExp2 = this.doc.GetRequiredExp(this.doc.CurSelectedPet.ID, this.doc.CurSelectedPet.showLevel);
						this.AddExp[1] = this.doc.GetAddExp(requiredExp2);
						this.RefreshStatus(PetExpTransferStatus.Start);
					}
					bool flag3 = !this.HasGetSkillUI;
					if (flag3)
					{
						this.PlayExpUpAnim(0);
						this.PlayExpUpAnim(1);
					}
				}
			}
		}

		private void PlayExpUpAnim(int index)
		{
			bool flag = !this.InPlayExpUp[index];
			if (!flag)
			{
				XPet xpet = this.TransferPet[index];
				int requiredExp = this.doc.GetRequiredExp(xpet.ID, xpet.showLevel);
				bool flag2 = xpet.showLevel < xpet.Level || (xpet.showLevel == xpet.Level && xpet.showExp < xpet.Exp);
				if (flag2)
				{
					xpet.showExp += this.AddExp[index];
					bool flag3 = xpet.showExp >= requiredExp && xpet.showLevel < xpet.Level;
					if (flag3)
					{
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.PlayPetLevelUpFx(this.m_PetSnapshot[index].transform, false);
						xpet.showExp = 0;
						xpet.showLevel++;
						requiredExp = this.doc.GetRequiredExp(xpet.ID, xpet.showLevel);
						this.AddExp[index] = this.doc.GetAddExp(requiredExp);
						this.RefreshPage(false);
						bool flag4 = xpet.showLevel > xpet.Level;
						if (flag4)
						{
							this.PlayEnd(index);
						}
						this.SkillHandler[index].PlayNewSkillTip(this.GetNewSkill(xpet), 0U);
					}
					bool flag5 = xpet.showExp >= xpet.Exp && xpet.showLevel >= xpet.Level;
					if (flag5)
					{
						this.PlayEnd(index);
					}
				}
				else
				{
					xpet.showExp -= this.AddExp[index];
					bool flag6 = xpet.showExp < 0 && xpet.showLevel > xpet.Level;
					if (flag6)
					{
						xpet.showLevel--;
						requiredExp = this.doc.GetRequiredExp(xpet.ID, xpet.showLevel);
						xpet.showExp = requiredExp;
						this.AddExp[index] = this.doc.GetAddExp(requiredExp);
						this.RefreshPage(false);
						bool flag7 = xpet.showLevel < xpet.Level;
						if (flag7)
						{
							this.PlayEnd(index);
						}
					}
					bool flag8 = xpet.showExp <= xpet.Exp && xpet.showLevel <= xpet.Level;
					if (flag8)
					{
						this.PlayEnd(index);
					}
				}
				this.RefreshExp(index);
			}
		}

		private void PlayEnd(int index)
		{
			this.TransferPet[index].showExp = this.TransferPet[index].Exp;
			this.TransferPet[index].showLevel = this.TransferPet[index].Level;
			this.InPlayExpUp[index] = false;
			bool flag = !this.InPlayExpUp[index ^ 1];
			if (flag)
			{
				this.ChangeExp = false;
				this.RefreshStatus(PetExpTransferStatus.End);
			}
			this.RefreshPage(false);
		}

		public void ClearPetAnimation()
		{
			this.ChangeExp = false;
			this.HasGetSkillUI = false;
			this.InPlayExpUp[0] = false;
			this.InPlayExpUp[1] = false;
			bool flag = this.TransferPet[0] != null;
			if (flag)
			{
				this.TransferPet[0].showExp = this.TransferPet[0].Exp;
				this.TransferPet[0].showLevel = this.TransferPet[0].Level;
			}
			bool flag2 = this.TransferPet[1] != null;
			if (flag2)
			{
				this.TransferPet[1].showExp = this.TransferPet[1].Exp;
				this.TransferPet[1].showLevel = this.TransferPet[1].Level;
			}
		}

		public void RefreshPage(bool bResetPosition = false)
		{
			this.RefreshList(bResetPosition);
			this.RefreshContent(0);
			this.RefreshContent(1);
			this.RefreshCost();
		}

		public void RefreshContent(int index)
		{
			bool flag = this.TransferPet[index] == null;
			if (flag)
			{
				this.m_Pet[index].gameObject.SetActive(false);
			}
			else
			{
				this.m_Pet[index].gameObject.SetActive(true);
				this.RefreshExp(index);
				this.SkillHandler[index].Refresh(this.TransferPet[index]);
			}
		}

		public void RefreshStatus(PetExpTransferStatus status)
		{
			this.m_Ready.gameObject.SetActive(status == PetExpTransferStatus.Ready);
			this.m_Start.gameObject.SetActive(status == PetExpTransferStatus.Start);
			this.m_End.gameObject.SetActive(status == PetExpTransferStatus.End);
			bool flag = status == PetExpTransferStatus.Ready;
			if (flag)
			{
				bool flag2 = this.TransferPet[0].Level == this.TransferPet[1].Level;
				if (flag2)
				{
					this.m_Arrow.gameObject.SetActive(false);
				}
				else
				{
					this.m_Arrow.gameObject.SetActive(true);
					this.m_Arrow.SetFlipHorizontal(this.TransferPet[0].Level > this.TransferPet[1].Level);
				}
				this.RefreshHistoryLevelMAX(0);
				this.RefreshHistoryLevelMAX(1);
			}
			bool flag3 = status == PetExpTransferStatus.End;
			if (flag3)
			{
				this.m_End.PlayTween(true, -1f);
			}
		}

		public void RefreshHistoryLevelMAX(int index)
		{
			this.m_HistoryLevelMAX[index].SetText("");
		}

		public void RefreshExp(int index)
		{
			XPet xpet = this.TransferPet[index];
			bool flag = xpet == null;
			if (!flag)
			{
				bool flag2 = this.doc.IsMaxLevel(xpet.ID, xpet.showLevel);
				if (flag2)
				{
					this.m_ExpBar[index].value = 0f;
					this.m_ExpBarLevel[index].SetText(string.Format("Lv.{0}", xpet.showLevel.ToString()));
					this.doc.InPlayExpUp = false;
				}
				else
				{
					int num;
					int num2;
					this.doc.GetExpInfo(xpet, out num, out num2);
					this.m_ExpBar[index].value = Math.Min((float)num / (float)num2, 1f);
					this.m_ExpBarLevel[index].SetText(string.Format("Lv.{0}", xpet.showLevel.ToString()));
				}
			}
		}

		public void RefreshCost()
		{
			int num = int.Parse(this.PetExpTransferCost[0]);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_CostItem.gameObject, num, 0, false);
			ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(num);
			string text = this.PetExpTransferCost[1];
			string arg = (itemCount < ulong.Parse(text)) ? "[ff0000]" : "[ffffff]";
			this.m_CostNum.SetText(string.Format("{0}{1}[-]/{2}", arg, itemCount.ToString(), text));
			IXUISprite ixuisprite = this.m_CostItem.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)num);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			bool flag = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount((int)iSp.ID) < ulong.Parse(this.PetExpTransferCost[1]);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowItemAccess((int)iSp.ID, null);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
			}
		}

		public int GetNewSkill(XPet pet)
		{
			for (int i = 0; i < this.doc.petGetSkill.Count; i++)
			{
				bool flag = (ulong)this.doc.petGetSkill[i].petLvl == (ulong)((long)pet.showLevel);
				if (flag)
				{
					int j = 0;
					while (j < pet.SkillList.Count)
					{
						bool flag2 = pet.SkillList[j].id == this.doc.petGetSkill[i].skillid;
						if (flag2)
						{
							XSingleton<XDebug>.singleton.AddLog("Get Skill:" + this.doc.petGetSkill[i].skillid, null, null, null, null, null, XDebugColor.XDebug_None);
							bool flag3 = (long)j < (long)((ulong)XPet.FIX_SKILL_COUNT_MAX);
							if (flag3)
							{
								pet.ShowSkillList[j].open = true;
								this.doc.petGetSkill.Remove(this.doc.petGetSkill[i]);
								return j;
							}
							pet.ShowSkillList.Add(pet.SkillList[j]);
							this.doc.petGetSkill.Remove(this.doc.petGetSkill[i]);
							return pet.ShowSkillList.Count - 1;
						}
						else
						{
							j++;
						}
					}
				}
			}
			return -1;
		}

		public void RefreshPetModel(int index)
		{
			bool flag = this.TransferPet[index] == null;
			if (!flag)
			{
				this.m_Dummy[index] = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, XPetDocument.GetPresentID(this.TransferPet[index].ID), this.m_PetSnapshot[index], this.m_Dummy[index], 1f);
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.PetActionChange(XPetActionFile.IDLE, this.TransferPet[index].ID, this.m_Dummy[index], false);
			}
		}

		private XPetDocument doc;

		public List<XPet> petList = new List<XPet>();

		public bool ChangeExp;

		public bool[] InPlayExpUp = new bool[2];

		private int[] AddExp = new int[2];

		private XPet[] TransferPet = new XPet[2];

		private XDummy[] m_Dummy = new XDummy[2];

		public XPetSkillHandler[] SkillHandler = new XPetSkillHandler[2];

		private string[] PetExpTransferCost = XSingleton<XGlobalConfig>.singleton.GetValue("PetExpTransferCost").Split(new char[]
		{
			'|',
			'='
		});

		public bool m_CanTransfer = true;

		private IXUIButton m_Close;

		private IXUIButton m_BtnTransfer;

		private Transform[] m_Pet = new Transform[2];

		private IXUIProgress[] m_ExpBar = new IXUIProgress[2];

		private IXUILabel[] m_ExpBarLevel = new IXUILabel[2];

		private Transform[] m_Skill = new Transform[2];

		private IXUILabel[] m_HistoryLevelMAX = new IXUILabel[2];

		private IUIDummy[] m_PetSnapshot = new IUIDummy[2];

		private IXUIScrollView m_PetListScrollView;

		private IXUIWrapContent m_WrapContent;

		private Transform m_Ready;

		private Transform m_Start;

		private IXUITweenTool m_End;

		private IXUISprite m_Arrow;

		private Transform m_CostItem;

		private IXUILabel m_CostNum;

		private int m_CurExpTransferSelected = -1;
	}
}
