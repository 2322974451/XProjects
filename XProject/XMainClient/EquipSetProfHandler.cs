using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD7 RID: 3287
	internal class EquipSetProfHandler : DlgHandlerBase
	{
		// Token: 0x0600B85D RID: 47197 RVA: 0x002519F4 File Offset: 0x0024FBF4
		protected override void Init()
		{
			base.Init();
			this.mDoc = XEquipCreateDocument.Doc;
			Transform transform = base.PanelObject.transform.Find("Grid/ProfTpl");
			this.mProfListPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			transform = base.PanelObject.transform.parent.Find("Prof/V");
			this.mLbCurProf = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.Find("Grid");
			this.mGrid = (transform.GetComponent("XUIList") as IXUIList);
			List<ProfSkillTable.RowData> mainProfList = this.mDoc.GetMainProfList();
			bool flag = mainProfList == null || mainProfList.Count <= 0 || mainProfList.Count < XGame.RoleCount;
			if (!flag)
			{
				this.mProfGoArr = new EquipSetProfHandler._ProfGameObjectItem[XGame.RoleCount];
				int curRoleProf = this.mDoc.CurRoleProf;
				bool flag2 = false;
				for (int i = 0; i < XGame.RoleCount; i++)
				{
					GameObject gameObject = this._CreateProfMenuItem(mainProfList[i].ProfID, mainProfList[i].ProfName);
					this.mProfGoArr[i] = new EquipSetProfHandler._ProfGameObjectItem();
					this.mProfGoArr[i].prof = mainProfList[i].ProfID;
					this.mProfGoArr[i].select = gameObject.transform.Find("Selected").gameObject;
					bool flag3 = flag2;
					if (flag3)
					{
						this.mProfGoArr[i].select.SetActive(false);
					}
					else
					{
						flag2 = (curRoleProf == this.mProfGoArr[i].prof);
						this.mProfGoArr[i].select.SetActive(flag2);
						bool flag4 = flag2;
						if (flag4)
						{
							this.mLbCurProf.SetText(this.mDoc.GetMainProfByID(curRoleProf).ProfName);
							this.mDoc.RefreshEquipSuitListUIByProf(curRoleProf, false);
						}
					}
				}
				this.mGrid.Refresh();
			}
		}

		// Token: 0x0600B85E RID: 47198 RVA: 0x00251C10 File Offset: 0x0024FE10
		public override void RegisterEvent()
		{
			base.Init();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("Block").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBlockCollider));
		}

		// Token: 0x0600B85F RID: 47199 RVA: 0x00251C60 File Offset: 0x0024FE60
		private GameObject _CreateProfMenuItem(int _profID, string _profName)
		{
			GameObject gameObject = this.mProfListPool.FetchGameObject(false);
			gameObject.name = _profID.ToString();
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)_profID);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickProfMenuItem));
			IXUILabel ixuilabel = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(_profName);
			return gameObject;
		}

		// Token: 0x0600B860 RID: 47200 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClickBlockCollider(IXUISprite _spr)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600B861 RID: 47201 RVA: 0x00251CE4 File Offset: 0x0024FEE4
		private void OnClickProfMenuItem(IXUISprite _cb)
		{
			base.SetVisible(false);
			int num = (int)_cb.ID;
			for (int i = 0; i < this.mProfGoArr.Length; i++)
			{
				this.mProfGoArr[i].select.SetActive(num == this.mProfGoArr[i].prof);
			}
			this.mLbCurProf.SetText(this.mDoc.GetMainProfByID(num).ProfName);
			this.mDoc.RefreshEquipSuitListUIByProf(num, true);
		}

		// Token: 0x0600B862 RID: 47202 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B863 RID: 47203 RVA: 0x0025083F File Offset: 0x0024EA3F
		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		// Token: 0x0600B864 RID: 47204 RVA: 0x00251D69 File Offset: 0x0024FF69
		public override void OnUnload()
		{
			this.mDoc = null;
			this.mProfGoArr = null;
			base.OnUnload();
		}

		// Token: 0x040048F1 RID: 18673
		private XUIPool mProfListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040048F2 RID: 18674
		private IXUILabel mLbCurProf;

		// Token: 0x040048F3 RID: 18675
		private IXUIList mGrid;

		// Token: 0x040048F4 RID: 18676
		private XEquipCreateDocument mDoc;

		// Token: 0x040048F5 RID: 18677
		private EquipSetProfHandler._ProfGameObjectItem[] mProfGoArr;

		// Token: 0x020019B0 RID: 6576
		private class _ProfGameObjectItem
		{
			// Token: 0x04007F8E RID: 32654
			public int prof;

			// Token: 0x04007F8F RID: 32655
			public GameObject select;
		}
	}
}
