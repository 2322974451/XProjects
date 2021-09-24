using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSetProfHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.Init();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("Block").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBlockCollider));
		}

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

		private void OnClickBlockCollider(IXUISprite _spr)
		{
			base.SetVisible(false);
		}

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

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		public override void OnUnload()
		{
			this.mDoc = null;
			this.mProfGoArr = null;
			base.OnUnload();
		}

		private XUIPool mProfListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel mLbCurProf;

		private IXUIList mGrid;

		private XEquipCreateDocument mDoc;

		private EquipSetProfHandler._ProfGameObjectItem[] mProfGoArr;

		private class _ProfGameObjectItem
		{

			public int prof;

			public GameObject select;
		}
	}
}
