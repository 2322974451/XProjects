using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200180F RID: 6159
	internal class SpriteResolveFrame : DlgHandlerBase
	{
		// Token: 0x170038FD RID: 14589
		// (get) Token: 0x0600FF7F RID: 65407 RVA: 0x003C5FE8 File Offset: 0x003C41E8
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteResolveFrame";
			}
		}

		// Token: 0x0600FF80 RID: 65408 RVA: 0x003C6000 File Offset: 0x003C4200
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this._resolveMaxNum = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteResolveMaxNum"));
			Transform transform = base.PanelObject.transform.Find("ScrollView/Tpl");
			this.m_ScrollView = (base.PanelObject.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_SpritePool.SetupPool(transform.parent.gameObject, transform.gameObject, 12U, false);
			this.m_ResolveBtn = (base.PanelObject.transform.Find("ResolveBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_ResolveTips = base.PanelObject.transform.Find("ResolveTips").gameObject;
			this.m_JustTips = (base.PanelObject.transform.Find("info").GetComponent("XUILabel") as IXUILabel);
			this.m_JustTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpriteResolveTips")));
			DlgHandlerBase.EnsureCreate<SpriteSelectHandler>(ref this._SpriteSelectHandler, base.PanelObject.transform.Find("SelectHandlerParent"), false, this);
		}

		// Token: 0x0600FF81 RID: 65409 RVA: 0x003C6156 File Offset: 0x003C4356
		protected override void OnShow()
		{
			base.OnShow();
			this._SpriteSelectHandler.SetVisible(true);
			this.CheckSelectList();
		}

		// Token: 0x0600FF82 RID: 65410 RVA: 0x003C6174 File Offset: 0x003C4374
		protected override void OnHide()
		{
			base.OnHide();
			this._SpriteSelectHandler.SetVisible(false);
		}

		// Token: 0x0600FF83 RID: 65411 RVA: 0x003C618B File Offset: 0x003C438B
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ResolveBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnResolveBtnClick));
		}

		// Token: 0x0600FF84 RID: 65412 RVA: 0x003C61AD File Offset: 0x003C43AD
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<SpriteSelectHandler>(ref this._SpriteSelectHandler);
			base.OnUnload();
		}

		// Token: 0x0600FF85 RID: 65413 RVA: 0x003C61C4 File Offset: 0x003C43C4
		public void CheckSelectList()
		{
			this.SelectList.Clear();
			for (int i = 0; i < this._doc.ResolveList.Count; i++)
			{
				bool flag = this._resolveHash.Contains(this._doc.ResolveList[i].uid);
				if (flag)
				{
					bool flag2 = this._doc.isSpriteFight(this._doc.ResolveList[i].uid);
					if (flag2)
					{
						this._resolveHash.Remove(this._doc.ResolveList[i].uid);
					}
					else
					{
						this.SelectList.Add(this._doc.ResolveList[i]);
					}
				}
			}
			for (int j = 0; j < this._doc.FightingList.Count; j++)
			{
				bool flag3 = this._resolveHash.Contains(this._doc.FightingList[j]);
				if (flag3)
				{
					this._resolveHash.Remove(this._doc.FightingList[j]);
				}
			}
			this.SetSpriteList(true);
		}

		// Token: 0x0600FF86 RID: 65414 RVA: 0x003C6308 File Offset: 0x003C4508
		public void SetSpriteList(bool resetScrollPos = true)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_ResolveBtn.SetGrey(this.SelectList.Count != 0);
				this.m_ResolveTips.SetActive(this.SelectList.Count == 0);
				this.m_SpritePool.ReturnAll(false);
				Vector3 tplPos = this.m_SpritePool.TplPos;
				for (int i = 0; i < this.SelectList.Count; i++)
				{
					GameObject gameObject = this.m_SpritePool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(i % 3 * this.m_SpritePool.TplWidth), tplPos.y - (float)(i / 3 * this.m_SpritePool.TplHeight));
					SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this.SelectList[i].SpriteID);
					Transform ts = gameObject.transform.Find("Star");
					this.SetStar(ts, this.SelectList[i].EvolutionLevel);
					IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(string.Format("[{0}]{1}", this._doc.NAMECOLOR[(int)bySpriteID.SpriteQuality], bySpriteID.SpriteName));
					IXUILabel ixuilabel2 = gameObject.transform.Find("PPT").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("BOSSRUSH_POWER"), this.SelectList[i].PowerPoint));
					IXUILabel ixuilabel3 = gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(string.Format("Lv.{0}", this.SelectList[i].Level));
					IXUISprite ixuisprite = gameObject.transform.Find("Frame").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.spriteName = string.Format("kuang_dj_{0}", bySpriteID.SpriteQuality);
					IXUISprite ixuisprite2 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.spriteName = bySpriteID.SpriteIcon;
					IXUISprite ixuisprite3 = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.ID = (ulong)((long)i);
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSpriteScorllViewListClick));
				}
				if (resetScrollPos)
				{
					this.m_ScrollView.SetPosition(0f);
				}
			}
		}

		// Token: 0x0600FF87 RID: 65415 RVA: 0x003C65D4 File Offset: 0x003C47D4
		private void SetStar(Transform ts, uint num)
		{
			uint num2 = num / XSpriteSystemDocument.MOONWORTH;
			uint num3 = num % XSpriteSystemDocument.MOONWORTH;
			for (int i = 0; i < 7; i++)
			{
				IXUISprite ixuisprite = ts.Find(string.Format("star{0}", i)).GetComponent("XUISprite") as IXUISprite;
				bool flag = (long)i < (long)((ulong)(num2 + num3));
				if (flag)
				{
					ixuisprite.SetVisible(true);
					ixuisprite.spriteName = (((long)i < (long)((ulong)num2)) ? "l_stars_02" : "l_stars_01");
				}
				else
				{
					ixuisprite.SetVisible(false);
				}
			}
		}

		// Token: 0x0600FF88 RID: 65416 RVA: 0x003C6668 File Offset: 0x003C4868
		public bool ScrollViewHasSprite(ulong id)
		{
			return this._resolveHash.Contains(id);
		}

		// Token: 0x0600FF89 RID: 65417 RVA: 0x003C6688 File Offset: 0x003C4888
		public void OnSpriteListClick(IXUISprite iSp)
		{
			bool flag = (int)iSp.ID >= this._doc.ResolveList.Count;
			if (!flag)
			{
				SpriteInfo spriteInfo = this._doc.ResolveList[(int)iSp.ID];
				bool flag2 = this._resolveHash.Contains(spriteInfo.uid);
				if (flag2)
				{
					this.SelectList.Remove(spriteInfo);
					this._resolveHash.Remove(spriteInfo.uid);
					iSp.gameObject.transform.Find("Select").gameObject.SetActive(false);
					this.SetSpriteList(false);
				}
				else
				{
					bool flag3 = this.SelectList.Count >= this._doc.SpriteList.Count - 1;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteResolveAllTips"), "fece00");
					}
					else
					{
						bool flag4 = (long)this.SelectList.Count >= (long)((ulong)this._resolveMaxNum);
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteResolveMaxTips"), "fece00");
						}
						else
						{
							this.SelectList.Add(spriteInfo);
							this._resolveHash.Add(spriteInfo.uid);
							iSp.gameObject.transform.Find("Select").gameObject.SetActive(true);
							this.SetSpriteList(false);
						}
					}
				}
			}
		}

		// Token: 0x0600FF8A RID: 65418 RVA: 0x003C6804 File Offset: 0x003C4A04
		public void OnSpriteScorllViewListClick(IXUISprite iSp)
		{
			this._resolveHash.Remove(this.SelectList[(int)iSp.ID].uid);
			this.SelectList.RemoveAt((int)iSp.ID);
			this.SetSpriteList(false);
			this._SpriteSelectHandler.SetSpriteList(this._doc.ResolveList, false);
		}

		// Token: 0x0600FF8B RID: 65419 RVA: 0x003C6868 File Offset: 0x003C4A68
		public void OnResolveBtnClick(IXUISprite iSp)
		{
			bool flag = this.SelectList.Count == 0;
			if (!flag)
			{
				bool flag2 = this.SelectList.Count == this._doc.SpriteList.Count;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteResolveAllTips"), "fece00");
				}
				else
				{
					bool flag3 = this.CheckWhetherNeedToTips();
					if (flag3)
					{
						string label = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpriteResolveSureTips"));
						string @string = XStringDefineProxy.GetString("COMMON_OK");
						string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
						XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnResolveSure));
					}
					else
					{
						this.SendResolveList();
					}
				}
			}
		}

		// Token: 0x0600FF8C RID: 65420 RVA: 0x003C692C File Offset: 0x003C4B2C
		private bool CheckWhetherNeedToTips()
		{
			int i = 0;
			while (i < this.SelectList.Count)
			{
				bool flag = this.SelectList[i].Level > 1U;
				bool result;
				if (flag)
				{
					result = true;
				}
				else
				{
					SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this.SelectList[i].SpriteID);
					bool flag2 = bySpriteID.SpriteQuality > 2U;
					if (!flag2)
					{
						i++;
						continue;
					}
					result = true;
				}
				return result;
			}
			return false;
		}

		// Token: 0x0600FF8D RID: 65421 RVA: 0x003C69B0 File Offset: 0x003C4BB0
		private bool OnResolveSure(IXUIButton btn)
		{
			this.SendResolveList();
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FF8E RID: 65422 RVA: 0x003C69D7 File Offset: 0x003C4BD7
		private void SendResolveList()
		{
			XSingleton<XDebug>.singleton.AddLog("Resolve", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.QueryResolveSprite(this.SelectList);
		}

		// Token: 0x0600FF8F RID: 65423 RVA: 0x003C6A02 File Offset: 0x003C4C02
		public void Clean()
		{
			this.SelectList.Clear();
			this._resolveHash.Clear();
			this.SetSpriteList(true);
			this._SpriteSelectHandler.SetSpriteList(this._doc.ResolveList, true);
		}

		// Token: 0x0400711C RID: 28956
		private XSpriteSystemDocument _doc;

		// Token: 0x0400711D RID: 28957
		public SpriteSelectHandler _SpriteSelectHandler;

		// Token: 0x0400711E RID: 28958
		public XUIPool m_SpritePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400711F RID: 28959
		public IXUIScrollView m_ScrollView;

		// Token: 0x04007120 RID: 28960
		public IXUISprite m_ResolveBtn;

		// Token: 0x04007121 RID: 28961
		public GameObject m_ResolveTips;

		// Token: 0x04007122 RID: 28962
		public IXUILabel m_JustTips;

		// Token: 0x04007123 RID: 28963
		private HashSet<ulong> _resolveHash = new HashSet<ulong>();

		// Token: 0x04007124 RID: 28964
		public List<SpriteInfo> SelectList = new List<SpriteInfo>();

		// Token: 0x04007125 RID: 28965
		private uint _resolveMaxNum;
	}
}
