using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipSetLevelHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.Init();
			IXUISprite ixuisprite = base.PanelObject.transform.Find("Block").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBlockCollider));
		}

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

		private void OnClickBlockCollider(IXUISprite _spr)
		{
			base.SetVisible(false);
		}

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

		public override void OnUnload()
		{
			this.mDoc = null;
			this.mLevelFmt = null;
			this.mLevelGoArr = null;
			base.OnUnload();
		}

		private XUIPool mLevelListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel mLbCurLevel;

		private IXUIList mGrid;

		private string mLevelFmt;

		private XEquipCreateDocument mDoc;

		private EquipSetLevelHandler._LevelGameObjectItem[] mLevelGoArr;

		private class _LevelGameObjectItem
		{

			public GameObject go;

			public int level;

			public GameObject select;
		}
	}
}
