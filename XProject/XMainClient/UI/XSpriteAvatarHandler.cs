using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSpriteAvatarHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAvatarHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			Transform transform = base.PanelObject.transform.Find("Message/StarGrid/StarTpl");
			this.m_StarPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("Message/StarGrid/MoonTpl");
			this.m_MoonPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_StarGrid = base.PanelObject.transform.Find("Message/StarGrid").gameObject;
			this.m_Name = (base.PanelObject.transform.Find("Message/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_LevelFrame = (base.PanelObject.transform.Find("Message/Level").GetComponent("XUISprite") as IXUISprite);
			this.m_Level = (base.PanelObject.transform.Find("Message/Level/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_Power = (base.PanelObject.transform.Find("Message/Power").GetComponent("XUILabel") as IXUILabel);
			this.m_Quality = (base.PanelObject.transform.Find("Message/Quality").GetComponent("XUISprite") as IXUISprite);
			this.m_Avatar = (base.PanelObject.transform.Find("AvatarBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_Snapshot = (base.PanelObject.transform.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("XSpriteAvatarHandler", 1);
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
				this.m_Dummy = null;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		public void HideAvatar()
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
				this.m_Dummy = null;
			}
			this.m_Name.SetText("");
			this.m_Level.gameObject.transform.parent.gameObject.SetActive(false);
			this.m_Quality.SetVisible(false);
			this.m_Power.SetText("");
			this.m_StarPool.ReturnAll(false);
			this.m_MoonPool.ReturnAll(false);
		}

		public void SetSpriteInfoByIndex(int index, int avatarIndex = 0, bool needClickEvent = false, bool showLevel = true)
		{
			bool flag = index >= this._doc.SpriteList.Count;
			if (!flag)
			{
				this.SetSpriteInfo(this._doc.SpriteList[index], XSingleton<XAttributeMgr>.singleton.XPlayerData, avatarIndex, needClickEvent, showLevel);
			}
		}

		public void SetSpriteInfo(SpriteInfo spriteData, XAttributes attributes, int avatarIndex = 6, bool needClickEvent = false, bool showLevel = true)
		{
			if (needClickEvent)
			{
				this.m_Avatar.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickAvatar));
			}
			else
			{
				this.m_Avatar.RegisterSpriteClickEventHandler(null);
			}
			bool flag = spriteData == null;
			if (!flag)
			{
				this.m_SpriteInfo = this._doc._SpriteTable.GetBySpriteID(spriteData.SpriteID);
				this.m_SpriteData = spriteData;
				this.m_Attributes = attributes;
				SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(spriteData.SpriteID);
				this.m_StarGrid.SetActive(true);
				this.m_StarPool.ReturnAll(false);
				this.m_MoonPool.ReturnAll(false);
				uint num = spriteData.EvolutionLevel / XSpriteSystemDocument.MOONWORTH;
				uint num2 = spriteData.EvolutionLevel % XSpriteSystemDocument.MOONWORTH;
				float num3 = (num + num2 - 1f) / 2f;
				int num4 = 0;
				while ((long)num4 < (long)((ulong)(num + num2)))
				{
					bool flag2 = (long)num4 < (long)((ulong)num);
					if (flag2)
					{
						GameObject gameObject = this.m_MoonPool.FetchGameObject(false);
						Vector3 tplPos = this.m_MoonPool.TplPos;
						gameObject.transform.localPosition = new Vector3(tplPos.x + ((float)num4 - num3) * (float)this.m_MoonPool.TplWidth, tplPos.y);
					}
					else
					{
						GameObject gameObject2 = this.m_StarPool.FetchGameObject(false);
						Vector3 tplPos2 = this.m_StarPool.TplPos;
						gameObject2.transform.localPosition = new Vector3(tplPos2.x + ((float)num4 - num3) * (float)this.m_StarPool.TplWidth, tplPos2.y);
					}
					num4++;
				}
				this.m_Name.SetText(string.Format("[{0}]{1}", this._doc.NAMECOLOR[(int)bySpriteID.SpriteQuality], bySpriteID.SpriteName));
				this.m_Quality.SetVisible(true);
				this.m_Quality.spriteName = string.Format("icondjdj_{0}", bySpriteID.SpriteQuality);
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				if (showLevel)
				{
					this.m_Level.gameObject.transform.parent.gameObject.SetActive(true);
					this.m_Level.SetText(string.Format("Lv. {0}", spriteData.Level));
				}
				else
				{
					this.m_Level.gameObject.transform.parent.gameObject.SetActive(false);
				}
				this.m_Power.SetText(string.Format(XStringDefineProxy.GetString("BOSSRUSH_POWER"), spriteData.PowerPoint));
				this.m_LevelFrame.UpdateAnchors();
				this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, bySpriteID.SpriteModelID, this.m_Snapshot, this.m_Dummy, 1f);
				this.ResetSpriteAnim();
				bool flag3 = this.m_SpriteInfo != null;
				if (flag3)
				{
					this.ChangeMatColor(this.m_Dummy.EngineObject, this.m_SpriteInfo.PresentID);
				}
			}
		}

		public void SetSpriteInfo(uint spriteID, bool showLevel = true, uint power = 0U)
		{
			this.m_SpriteData = null;
			this.m_Attributes = null;
			this.m_SpriteInfo = this._doc._SpriteTable.GetBySpriteID(spriteID);
			this.m_Name.SetText(string.Format("[{0}]{1}", this._doc.NAMECOLOR[(int)this.m_SpriteInfo.SpriteQuality], this.m_SpriteInfo.SpriteName));
			this.m_Quality.SetVisible(true);
			this.m_Quality.spriteName = string.Format("icondjdj_{0}", this.m_SpriteInfo.SpriteQuality);
			this.m_Level.gameObject.transform.parent.gameObject.SetActive(showLevel);
			if (showLevel)
			{
				this.m_Level.SetText("Lv.1");
			}
			this.m_Power.SetText(string.Format(XStringDefineProxy.GetString("BOSSRUSH_POWER"), (power == 0U) ? this.GetSpriteOneLevelPower(this.m_SpriteInfo) : power));
			this.m_StarGrid.SetActive(false);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.m_SpriteInfo.SpriteModelID, this.m_Snapshot, this.m_Dummy, 1f);
			this.ResetSpriteAnim();
			bool flag = this.m_SpriteInfo != null;
			if (flag)
			{
				this.ChangeMatColor(this.m_Dummy.EngineObject, this.m_SpriteInfo.PresentID);
			}
		}

		private void ChangeMatColor(XGameObject xobject, uint presentID)
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteTable.RowData byPresentID = specificDocument._SpriteTable.GetByPresentID(presentID);
			bool flag = byPresentID != null;
			if (flag)
			{
				xobject.CallCommand(XAffiliate._changeSpriteMatColorCb, byPresentID, -1, false);
			}
		}

		public XEntityPresentation.RowData GetSpritePresent()
		{
			bool flag = this.m_Dummy == null;
			XEntityPresentation.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = this.m_Dummy.Present == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					result = this.m_Dummy.Present.PresentLib;
				}
			}
			return result;
		}

		public void ResetSpriteAnim()
		{
			bool flag = this.m_Dummy == null;
			if (!flag)
			{
				this.m_Dummy.ResetAnimation();
			}
		}

		public float SetSpriteAnim(string clipname)
		{
			bool flag = this.m_Dummy == null;
			float result;
			if (flag)
			{
				result = -1f;
			}
			else
			{
				result = this.m_Dummy.SetAnimationGetLength(clipname);
			}
			return result;
		}

		private uint GetSpriteOneLevelPower(SpriteTable.RowData spriteInfo)
		{
			List<uint> list = new List<uint>();
			List<double> list2 = new List<double>();
			List<double> list3 = new List<double>();
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			XSpriteAttributeHandler.GetLevelOneSpriteAttr(spriteInfo, out list, out list2, out list3);
			double num = 0.0;
			for (int i = 0; i < list3.Count; i++)
			{
				num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(list[i], list3[i] / 100.0, null, 0);
			}
			for (int j = 0; j < list2.Count; j++)
			{
				num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(list[j], (uint)list2[j], null, 0);
			}
			return (uint)num;
		}

		private void OnClickAvatar(IXUISprite btn)
		{
			bool flag = this.m_SpriteData != null;
			if (flag)
			{
				DlgBase<XSpriteDetailView, XSpriteDetailBehaviour>.singleton.ShowDetail(this.m_SpriteData, this.m_Attributes);
			}
			else
			{
				bool flag2 = this.m_SpriteInfo != null;
				if (flag2)
				{
					DlgBase<XSpriteDetailView, XSpriteDetailBehaviour>.singleton.ShowDetail(this.m_SpriteInfo.SpriteID);
				}
			}
		}

		private XSpriteSystemDocument _doc;

		private XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_MoonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel m_Name;

		private IXUILabel m_Power;

		private IXUILabel m_Level;

		private IXUISprite m_LevelFrame;

		private IUIDummy m_Snapshot;

		private IXUISprite m_Avatar;

		private IXUISprite m_Quality;

		private GameObject m_StarGrid;

		private XDummy m_Dummy;

		private SpriteInfo m_SpriteData = null;

		private XAttributes m_Attributes = null;

		private SpriteTable.RowData m_SpriteInfo = null;
	}
}
