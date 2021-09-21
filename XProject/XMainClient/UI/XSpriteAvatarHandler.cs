using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200185F RID: 6239
	internal class XSpriteAvatarHandler : DlgHandlerBase
	{
		// Token: 0x1700398F RID: 14735
		// (get) Token: 0x060103EA RID: 66538 RVA: 0x003ECEB4 File Offset: 0x003EB0B4
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAvatarHandler";
			}
		}

		// Token: 0x060103EB RID: 66539 RVA: 0x003ECECC File Offset: 0x003EB0CC
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

		// Token: 0x060103EC RID: 66540 RVA: 0x003ED0A1 File Offset: 0x003EB2A1
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("XSpriteAvatarHandler", 1);
		}

		// Token: 0x060103ED RID: 66541 RVA: 0x003ED0B8 File Offset: 0x003EB2B8
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

		// Token: 0x060103EE RID: 66542 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x060103EF RID: 66543 RVA: 0x003ED0FA File Offset: 0x003EB2FA
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		// Token: 0x060103F0 RID: 66544 RVA: 0x003ED114 File Offset: 0x003EB314
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

		// Token: 0x060103F1 RID: 66545 RVA: 0x003ED1BC File Offset: 0x003EB3BC
		public void SetSpriteInfoByIndex(int index, int avatarIndex = 0, bool needClickEvent = false, bool showLevel = true)
		{
			bool flag = index >= this._doc.SpriteList.Count;
			if (!flag)
			{
				this.SetSpriteInfo(this._doc.SpriteList[index], XSingleton<XAttributeMgr>.singleton.XPlayerData, avatarIndex, needClickEvent, showLevel);
			}
		}

		// Token: 0x060103F2 RID: 66546 RVA: 0x003ED210 File Offset: 0x003EB410
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

		// Token: 0x060103F3 RID: 66547 RVA: 0x003ED530 File Offset: 0x003EB730
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

		// Token: 0x060103F4 RID: 66548 RVA: 0x003ED6A8 File Offset: 0x003EB8A8
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

		// Token: 0x060103F5 RID: 66549 RVA: 0x003ED6E8 File Offset: 0x003EB8E8
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

		// Token: 0x060103F6 RID: 66550 RVA: 0x003ED734 File Offset: 0x003EB934
		public void ResetSpriteAnim()
		{
			bool flag = this.m_Dummy == null;
			if (!flag)
			{
				this.m_Dummy.ResetAnimation();
			}
		}

		// Token: 0x060103F7 RID: 66551 RVA: 0x003ED760 File Offset: 0x003EB960
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

		// Token: 0x060103F8 RID: 66552 RVA: 0x003ED794 File Offset: 0x003EB994
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

		// Token: 0x060103F9 RID: 66553 RVA: 0x003ED868 File Offset: 0x003EBA68
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

		// Token: 0x040074B5 RID: 29877
		private XSpriteSystemDocument _doc;

		// Token: 0x040074B6 RID: 29878
		private XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040074B7 RID: 29879
		private XUIPool m_MoonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040074B8 RID: 29880
		private IXUILabel m_Name;

		// Token: 0x040074B9 RID: 29881
		private IXUILabel m_Power;

		// Token: 0x040074BA RID: 29882
		private IXUILabel m_Level;

		// Token: 0x040074BB RID: 29883
		private IXUISprite m_LevelFrame;

		// Token: 0x040074BC RID: 29884
		private IUIDummy m_Snapshot;

		// Token: 0x040074BD RID: 29885
		private IXUISprite m_Avatar;

		// Token: 0x040074BE RID: 29886
		private IXUISprite m_Quality;

		// Token: 0x040074BF RID: 29887
		private GameObject m_StarGrid;

		// Token: 0x040074C0 RID: 29888
		private XDummy m_Dummy;

		// Token: 0x040074C1 RID: 29889
		private SpriteInfo m_SpriteData = null;

		// Token: 0x040074C2 RID: 29890
		private XAttributes m_Attributes = null;

		// Token: 0x040074C3 RID: 29891
		private SpriteTable.RowData m_SpriteInfo = null;
	}
}
