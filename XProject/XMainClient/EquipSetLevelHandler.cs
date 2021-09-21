using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD9 RID: 3289
	internal class EquipSetLevelHandler : DlgHandlerBase
	{
		// Token: 0x0600B86D RID: 47213 RVA: 0x00251FDC File Offset: 0x002501DC
		protected override void Init()
		{
			base.Init();
			this.mDoc = XEquipCreateDocument.Doc;
			this.mLevelFmt = XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_LEVEL_FMT");
			Transform transform = base.PanelObject.transform.Find("Grid/LevelTpl");
			this.mLevelListPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			transform = base.PanelObject.transform.parent.Find("Level/V");
			this.mLbCurLevel = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.Find("Grid");
			this.mGrid = (transform.GetComponent("XUIList") as IXUIList);
			List<int> updateItemLevelList = this.mDoc.GetUpdateItemLevelList();
			bool flag = updateItemLevelList == null || updateItemLevelList.Count <= 0;
			if (!flag)
			{
				this.mLevelGoArr = new EquipSetLevelHandler._LevelGameObjectItem[updateItemLevelList.Count];
				bool flag2 = false;
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				for (int i = 0; i < updateItemLevelList.Count; i++)
				{
					this.mLevelGoArr[i] = new EquipSetLevelHandler._LevelGameObjectItem();
					this.mLevelGoArr[i].go = this._CreateLevelMenuItem(updateItemLevelList[i]);
					this.mLevelGoArr[i].level = updateItemLevelList[i];
					this.mLevelGoArr[i].select = this.mLevelGoArr[i].go.transform.Find("Selected").gameObject;
					bool flag3 = flag2;
					if (flag3)
					{
						this.mLevelGoArr[i].select.SetActive(false);
					}
					else
					{
						flag2 = (this.mLevelGoArr[i].level <= level && this.mLevelGoArr[i].level != 0);
						this.mLevelGoArr[i].select.SetActive(flag2);
						bool flag4 = flag2;
						if (flag4)
						{
							this.mLbCurLevel.SetText(this._GetLevelText(this.mLevelGoArr[i].level));
							this.mDoc.RefreshEquipSuitListUIByLevel(this.mLevelGoArr[i].level, false);
						}
					}
				}
				bool flag5 = !flag2;
				if (flag5)
				{
					this.mLevelGoArr[0].select.SetActive(true);
				}
			}
		}

		// Token: 0x0600B86E RID: 47214 RVA: 0x00252240 File Offset: 0x00250440
		public override void RegisterEvent()
		{
			base.Init();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("Block").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBlockCollider));
		}

		// Token: 0x0600B86F RID: 47215 RVA: 0x00252290 File Offset: 0x00250490
		private string _GetLevelText(int _level)
		{
			bool flag = _level > 0;
			string result;
			if (flag)
			{
				result = string.Format(this.mLevelFmt, _level);
			}
			else
			{
				result = XStringDefineProxy.GetString("ALL");
			}
			return result;
		}

		// Token: 0x0600B870 RID: 47216 RVA: 0x002522C8 File Offset: 0x002504C8
		private GameObject _CreateLevelMenuItem(int _level)
		{
			GameObject gameObject = this.mLevelListPool.FetchGameObject(false);
			gameObject.name = _level.ToString();
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)_level);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickLevelMenuItem));
			IXUILabel ixuilabel = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this._GetLevelText(_level));
			return gameObject;
		}

		// Token: 0x0600B871 RID: 47217 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClickBlockCollider(IXUISprite _spr)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600B872 RID: 47218 RVA: 0x00252354 File Offset: 0x00250554
		private void OnClickLevelMenuItem(IXUISprite _cb)
		{
			base.SetVisible(false);
			int num = (int)_cb.ID;
			for (int i = 0; i < this.mLevelGoArr.Length; i++)
			{
				this.mLevelGoArr[i].select.SetActive(num == this.mLevelGoArr[i].level);
			}
			this.mLbCurLevel.SetText(this._GetLevelText(num));
			this.mDoc.RefreshEquipSuitListUIByLevel(num, true);
		}

		// Token: 0x0600B873 RID: 47219 RVA: 0x002523D0 File Offset: 0x002505D0
		protected override void OnShow()
		{
			base.OnShow();
			int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			int nextShowLevel = this.mDoc.NextShowLevel;
			int num = 0;
			for (int i = 0; i < this.mLevelGoArr.Length; i++)
			{
				bool flag = this.mLevelGoArr[i].level == 0 || level >= this.mLevelGoArr[i].level || this.mLevelGoArr[i].level == nextShowLevel;
				if (flag)
				{
					this.mLevelGoArr[i].go.SetActive(true);
					this.mLevelGoArr[i].go.transform.localPosition = new Vector3(0f, (float)(-(float)num * this.mLevelListPool.TplHeight), 0f);
					num++;
				}
				else
				{
					this.mLevelGoArr[i].go.SetActive(false);
				}
			}
		}

		// Token: 0x0600B874 RID: 47220 RVA: 0x002524C2 File Offset: 0x002506C2
		public override void OnUnload()
		{
			this.mDoc = null;
			this.mLevelFmt = null;
			this.mLevelGoArr = null;
			base.OnUnload();
		}

		// Token: 0x040048FB RID: 18683
		private XUIPool mLevelListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040048FC RID: 18684
		private IXUILabel mLbCurLevel;

		// Token: 0x040048FD RID: 18685
		private IXUIList mGrid;

		// Token: 0x040048FE RID: 18686
		private string mLevelFmt;

		// Token: 0x040048FF RID: 18687
		private XEquipCreateDocument mDoc;

		// Token: 0x04004900 RID: 18688
		private EquipSetLevelHandler._LevelGameObjectItem[] mLevelGoArr;

		// Token: 0x020019B1 RID: 6577
		private class _LevelGameObjectItem
		{
			// Token: 0x04007F90 RID: 32656
			public GameObject go;

			// Token: 0x04007F91 RID: 32657
			public int level;

			// Token: 0x04007F92 RID: 32658
			public GameObject select;
		}
	}
}
