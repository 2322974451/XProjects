using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200180E RID: 6158
	internal class SpriteFightFrame : DlgHandlerBase
	{
		// Token: 0x170038FC RID: 14588
		// (get) Token: 0x0600FF71 RID: 65393 RVA: 0x003C5934 File Offset: 0x003C3B34
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteFightFrame";
			}
		}

		// Token: 0x0600FF72 RID: 65394 RVA: 0x003C594C File Offset: 0x003C3B4C
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this.RefreshPosition();
			this.m_Tips = (base.PanelObject.transform.Find("Tips").GetComponent("XUILabel") as IXUILabel);
			for (int i = 0; i < 3; i++)
			{
				IXUISprite ixuisprite = base.PanelObject.transform.Find(string.Format("Avatar{0}/Open/CBtn", i + 1)).GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)(i + 1));
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSwapTeamLeaderClick));
				this.m_SetLeaderBtnList.Add(ixuisprite);
			}
			DlgHandlerBase.EnsureCreate<SpriteSelectHandler>(ref this._SpriteSelectHandler, base.PanelObject.transform.Find("SelectHandlerParent"), false, this);
		}

		// Token: 0x0600FF73 RID: 65395 RVA: 0x003C5A34 File Offset: 0x003C3C34
		public void RefreshPosition()
		{
			for (int i = 0; i < 4; i++)
			{
				bool flag = (long)i < (long)((ulong)this._doc.MaxFightNum);
				GameObject gameObject = base.PanelObject.transform.Find(string.Format("Avatar{0}/Open", i)).gameObject;
				GameObject gameObject2 = base.PanelObject.transform.Find(string.Format("Avatar{0}/UnOpen", i)).gameObject;
				gameObject.SetActive(flag);
				gameObject2.SetActive(!flag);
				bool flag2 = flag;
				if (flag2)
				{
					DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler[i], gameObject.transform.Find("AvatarHandlerParent"), true, this);
					this._IXUISpriteList[i] = (gameObject.GetComponent("XUISprite") as IXUISprite);
				}
				else
				{
					IXUILabel ixuilabel = gameObject2.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL"), this._doc.PositionLevelCondition[i]));
				}
			}
		}

		// Token: 0x0600FF74 RID: 65396 RVA: 0x003C5B63 File Offset: 0x003C3D63
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<SpriteSelectHandler>(ref this._SpriteSelectHandler);
			base.OnUnload();
		}

		// Token: 0x0600FF75 RID: 65397 RVA: 0x003C5B79 File Offset: 0x003C3D79
		protected override void OnShow()
		{
			base.OnShow();
			this._SpriteSelectHandler.SetVisible(true);
			this.SetSpriteAvatarHandlerVisible(true);
			this.RefreshFightList();
		}

		// Token: 0x0600FF76 RID: 65398 RVA: 0x003C5B9F File Offset: 0x003C3D9F
		protected override void OnHide()
		{
			this._SpriteSelectHandler.SetVisible(false);
			this.SetSpriteAvatarHandlerVisible(false);
			base.OnHide();
		}

		// Token: 0x0600FF77 RID: 65399 RVA: 0x003C5BC0 File Offset: 0x003C3DC0
		private void SetSpriteAvatarHandlerVisible(bool visible)
		{
			for (int i = 0; i < this._SpriteAvatarHandler.Length; i++)
			{
				bool flag = this._SpriteAvatarHandler[i] != null;
				if (flag)
				{
					this._SpriteAvatarHandler[i].SetVisible(visible);
				}
			}
		}

		// Token: 0x0600FF78 RID: 65400 RVA: 0x003C5C08 File Offset: 0x003C3E08
		public void RefreshFightList()
		{
			bool flag = this._doc.FightingList[0] == 0UL;
			if (flag)
			{
				this.m_Tips.SetText(XStringDefineProxy.GetString("SpriteSkill_NoneCaptainTips"));
			}
			else
			{
				int indexByUid = this._doc.GetIndexByUid(this._doc.FightingList[0]);
				bool flag2 = indexByUid == -1;
				if (flag2)
				{
					this._doc.FightingList[0] = 0UL;
					this.m_Tips.SetText(XStringDefineProxy.GetString("SpriteSkill_NoneCaptainTips"));
				}
				else
				{
					SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this._doc.SpriteList[indexByUid].SpriteID);
					SpriteSkill.RowData spriteSkillData = this._doc.GetSpriteSkillData((short)bySpriteID.SpriteSkillID, true, this._doc.SpriteList[indexByUid].EvolutionLevel);
					this.m_Tips.SetText(spriteSkillData.Tips);
				}
			}
			int num = 0;
			while ((long)num < (long)((ulong)this._doc.MaxFightNum))
			{
				bool flag3 = num != 0;
				if (flag3)
				{
					this.m_SetLeaderBtnList[num - 1].SetVisible(this._doc.FightingList[num] > 0UL);
				}
				bool flag4 = this._doc.FightingList[num] == 0UL;
				if (flag4)
				{
					this._IXUISpriteList[num].RegisterSpriteClickEventHandler(null);
					this._SpriteAvatarHandler[num].HideAvatar();
				}
				else
				{
					this._IXUISpriteList[num].ID = (ulong)((long)num);
					this._IXUISpriteList[num].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRightListClick));
					int indexByUid2 = this._doc.GetIndexByUid(this._doc.FightingList[num]);
					bool flag5 = indexByUid2 == -1;
					if (flag5)
					{
						this._doc.FightingList[num] = 0UL;
						this._IXUISpriteList[num].RegisterSpriteClickEventHandler(null);
						this._SpriteAvatarHandler[num].HideAvatar();
					}
					else
					{
						this._SpriteAvatarHandler[num].SetSpriteInfoByIndex(indexByUid2, num, false, true);
					}
				}
				num++;
			}
		}

		// Token: 0x0600FF79 RID: 65401 RVA: 0x003C5E54 File Offset: 0x003C4054
		public void SetAvatar()
		{
			bool flag = this._doc.MaxFightNum == 0U;
			if (!flag)
			{
				bool flag2 = this._doc.FightingList[0] == 0UL;
				if (!flag2)
				{
					int indexByUid = this._doc.GetIndexByUid(this._doc.FightingList[0]);
					bool flag3 = indexByUid == -1;
					if (!flag3)
					{
						this._SpriteAvatarHandler[0].SetSpriteInfoByIndex(indexByUid, 0, false, true);
					}
				}
			}
		}

		// Token: 0x0600FF7A RID: 65402 RVA: 0x003C5ECC File Offset: 0x003C40CC
		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = base.IsVisible();
			if (flag)
			{
				this.SetAvatar();
			}
		}

		// Token: 0x0600FF7B RID: 65403 RVA: 0x003C5EF2 File Offset: 0x003C40F2
		public void OnRightListClick(IXUISprite iSp)
		{
			this._doc.QueryFightOut(this._doc.FightingList[(int)iSp.ID]);
		}

		// Token: 0x0600FF7C RID: 65404 RVA: 0x003C5F18 File Offset: 0x003C4118
		public void OnLeftListClick(IXUISprite iSp)
		{
			ulong uid = this._doc.SpriteList[(int)iSp.ID].uid;
			bool flag = this._doc.isSpriteFight(uid);
			if (flag)
			{
				this._doc.QueryFightOut(uid);
			}
			else
			{
				this._doc.QueryFightIn(uid);
			}
		}

		// Token: 0x0600FF7D RID: 65405 RVA: 0x003C5F70 File Offset: 0x003C4170
		private void OnSwapTeamLeaderClick(IXUISprite iSp)
		{
			int index = (int)iSp.ID;
			bool flag = this._doc.FightingList[index] > 0UL;
			if (flag)
			{
				this._doc.QuerySwapTeamLeader(this._doc.FightingList[index]);
			}
		}

		// Token: 0x04007116 RID: 28950
		private XSpriteSystemDocument _doc;

		// Token: 0x04007117 RID: 28951
		public SpriteSelectHandler _SpriteSelectHandler;

		// Token: 0x04007118 RID: 28952
		public XSpriteAvatarHandler[] _SpriteAvatarHandler = new XSpriteAvatarHandler[4];

		// Token: 0x04007119 RID: 28953
		private IXUISprite[] _IXUISpriteList = new IXUISprite[4];

		// Token: 0x0400711A RID: 28954
		private IXUILabel m_Tips;

		// Token: 0x0400711B RID: 28955
		private List<IXUISprite> m_SetLeaderBtnList = new List<IXUISprite>();
	}
}
