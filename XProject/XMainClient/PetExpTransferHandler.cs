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
	// Token: 0x02000C81 RID: 3201
	internal class PetExpTransferHandler : DlgHandlerBase
	{
		// Token: 0x17003204 RID: 12804
		// (get) Token: 0x0600B4D2 RID: 46290 RVA: 0x00237A10 File Offset: 0x00235C10
		public int ExpTransferPetCount
		{
			get
			{
				return this.doc.Pets.Count - 1;
			}
		}

		// Token: 0x17003205 RID: 12805
		// (get) Token: 0x0600B4D3 RID: 46291 RVA: 0x00237A34 File Offset: 0x00235C34
		private bool CanPlayExpUp
		{
			get
			{
				return this.ChangeExp && !this.HasGetSkillUI && !this.InPlayExpUp[0] && !this.InPlayExpUp[1];
			}
		}

		// Token: 0x17003206 RID: 12806
		// (get) Token: 0x0600B4D4 RID: 46292 RVA: 0x00237A70 File Offset: 0x00235C70
		// (set) Token: 0x0600B4D5 RID: 46293 RVA: 0x00237AC8 File Offset: 0x00235CC8
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

		// Token: 0x17003207 RID: 12807
		// (get) Token: 0x0600B4D6 RID: 46294 RVA: 0x00237B10 File Offset: 0x00235D10
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

		// Token: 0x0600B4D7 RID: 46295 RVA: 0x00237B3C File Offset: 0x00235D3C
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

		// Token: 0x17003208 RID: 12808
		// (get) Token: 0x0600B4D8 RID: 46296 RVA: 0x00237DF8 File Offset: 0x00235FF8
		protected override string FileName
		{
			get
			{
				return "GameSystem/PetExptransfer";
			}
		}

		// Token: 0x17003209 RID: 12809
		// (get) Token: 0x0600B4D9 RID: 46297 RVA: 0x00237E10 File Offset: 0x00236010
		public int CurExpTransferSelectedIndex
		{
			get
			{
				return this.m_CurExpTransferSelected;
			}
		}

		// Token: 0x1700320A RID: 12810
		// (get) Token: 0x0600B4DA RID: 46298 RVA: 0x00237E28 File Offset: 0x00236028
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

		// Token: 0x0600B4DB RID: 46299 RVA: 0x00237E7C File Offset: 0x0023607C
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_BtnTransfer.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExpTransferClicked));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnPetListItemUpdated));
		}

		// Token: 0x0600B4DC RID: 46300 RVA: 0x00237ED4 File Offset: 0x002360D4
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600B4DD RID: 46301 RVA: 0x00237EF0 File Offset: 0x002360F0
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

		// Token: 0x0600B4DE RID: 46302 RVA: 0x00237F83 File Offset: 0x00236183
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("PetExpTransferHandler", 1);
			this.Select(this.DefaultPet, true);
			this.ClearPetAnimation();
			this.RefreshPetModel(1);
		}

		// Token: 0x0600B4DF RID: 46303 RVA: 0x00237FB8 File Offset: 0x002361B8
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

		// Token: 0x0600B4E0 RID: 46304 RVA: 0x00238044 File Offset: 0x00236244
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

		// Token: 0x0600B4E1 RID: 46305 RVA: 0x002380CF File Offset: 0x002362CF
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("PetExpTransferHandler", 1);
		}

		// Token: 0x0600B4E2 RID: 46306 RVA: 0x002380E8 File Offset: 0x002362E8
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

		// Token: 0x0600B4E3 RID: 46307 RVA: 0x0023813C File Offset: 0x0023633C
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

		// Token: 0x0600B4E4 RID: 46308 RVA: 0x00238370 File Offset: 0x00236570
		private void _OnPetClicked(IXUISprite iSp)
		{
			int index = (int)iSp.ID;
			this.Select(index, false);
		}

		// Token: 0x0600B4E5 RID: 46309 RVA: 0x00238390 File Offset: 0x00236590
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

		// Token: 0x0600B4E6 RID: 46310 RVA: 0x00238440 File Offset: 0x00236640
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

		// Token: 0x0600B4E7 RID: 46311 RVA: 0x00238488 File Offset: 0x00236688
		public void Transfer(ulong uid1, ulong uid2)
		{
			bool flag = (uid1 == this.doc.CurSelectedPet.UID && uid2 == this.CurExpTransferSelectedPet.UID) || (uid2 == this.doc.CurSelectedPet.UID && uid1 == this.CurExpTransferSelectedPet.UID);
			if (flag)
			{
				this.ChangeExp = true;
			}
		}

		// Token: 0x0600B4E8 RID: 46312 RVA: 0x002384EC File Offset: 0x002366EC
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

		// Token: 0x0600B4E9 RID: 46313 RVA: 0x002385F8 File Offset: 0x002367F8
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

		// Token: 0x0600B4EA RID: 46314 RVA: 0x00238858 File Offset: 0x00236A58
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

		// Token: 0x0600B4EB RID: 46315 RVA: 0x002388D0 File Offset: 0x00236AD0
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

		// Token: 0x0600B4EC RID: 46316 RVA: 0x00238989 File Offset: 0x00236B89
		public void RefreshPage(bool bResetPosition = false)
		{
			this.RefreshList(bResetPosition);
			this.RefreshContent(0);
			this.RefreshContent(1);
			this.RefreshCost();
		}

		// Token: 0x0600B4ED RID: 46317 RVA: 0x002389AC File Offset: 0x00236BAC
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

		// Token: 0x0600B4EE RID: 46318 RVA: 0x00238A18 File Offset: 0x00236C18
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

		// Token: 0x0600B4EF RID: 46319 RVA: 0x00238B10 File Offset: 0x00236D10
		public void RefreshHistoryLevelMAX(int index)
		{
			this.m_HistoryLevelMAX[index].SetText("");
		}

		// Token: 0x0600B4F0 RID: 46320 RVA: 0x00238B28 File Offset: 0x00236D28
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

		// Token: 0x0600B4F1 RID: 46321 RVA: 0x00238C04 File Offset: 0x00236E04
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

		// Token: 0x0600B4F2 RID: 46322 RVA: 0x00238CDC File Offset: 0x00236EDC
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

		// Token: 0x0600B4F3 RID: 46323 RVA: 0x00238D44 File Offset: 0x00236F44
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

		// Token: 0x0600B4F4 RID: 46324 RVA: 0x00238ED0 File Offset: 0x002370D0
		public void RefreshPetModel(int index)
		{
			bool flag = this.TransferPet[index] == null;
			if (!flag)
			{
				this.m_Dummy[index] = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, XPetDocument.GetPresentID(this.TransferPet[index].ID), this.m_PetSnapshot[index], this.m_Dummy[index], 1f);
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.PetActionChange(XPetActionFile.IDLE, this.TransferPet[index].ID, this.m_Dummy[index], false);
			}
		}

		// Token: 0x04004670 RID: 18032
		private XPetDocument doc;

		// Token: 0x04004671 RID: 18033
		public List<XPet> petList = new List<XPet>();

		// Token: 0x04004672 RID: 18034
		public bool ChangeExp;

		// Token: 0x04004673 RID: 18035
		public bool[] InPlayExpUp = new bool[2];

		// Token: 0x04004674 RID: 18036
		private int[] AddExp = new int[2];

		// Token: 0x04004675 RID: 18037
		private XPet[] TransferPet = new XPet[2];

		// Token: 0x04004676 RID: 18038
		private XDummy[] m_Dummy = new XDummy[2];

		// Token: 0x04004677 RID: 18039
		public XPetSkillHandler[] SkillHandler = new XPetSkillHandler[2];

		// Token: 0x04004678 RID: 18040
		private string[] PetExpTransferCost = XSingleton<XGlobalConfig>.singleton.GetValue("PetExpTransferCost").Split(new char[]
		{
			'|',
			'='
		});

		// Token: 0x04004679 RID: 18041
		public bool m_CanTransfer = true;

		// Token: 0x0400467A RID: 18042
		private IXUIButton m_Close;

		// Token: 0x0400467B RID: 18043
		private IXUIButton m_BtnTransfer;

		// Token: 0x0400467C RID: 18044
		private Transform[] m_Pet = new Transform[2];

		// Token: 0x0400467D RID: 18045
		private IXUIProgress[] m_ExpBar = new IXUIProgress[2];

		// Token: 0x0400467E RID: 18046
		private IXUILabel[] m_ExpBarLevel = new IXUILabel[2];

		// Token: 0x0400467F RID: 18047
		private Transform[] m_Skill = new Transform[2];

		// Token: 0x04004680 RID: 18048
		private IXUILabel[] m_HistoryLevelMAX = new IXUILabel[2];

		// Token: 0x04004681 RID: 18049
		private IUIDummy[] m_PetSnapshot = new IUIDummy[2];

		// Token: 0x04004682 RID: 18050
		private IXUIScrollView m_PetListScrollView;

		// Token: 0x04004683 RID: 18051
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04004684 RID: 18052
		private Transform m_Ready;

		// Token: 0x04004685 RID: 18053
		private Transform m_Start;

		// Token: 0x04004686 RID: 18054
		private IXUITweenTool m_End;

		// Token: 0x04004687 RID: 18055
		private IXUISprite m_Arrow;

		// Token: 0x04004688 RID: 18056
		private Transform m_CostItem;

		// Token: 0x04004689 RID: 18057
		private IXUILabel m_CostNum;

		// Token: 0x0400468A RID: 18058
		private int m_CurExpTransferSelected = -1;
	}
}
