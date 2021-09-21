using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B1 RID: 6065
	internal class ArtifactFuseHandler : DlgHandlerBase
	{
		// Token: 0x17003877 RID: 14455
		// (get) Token: 0x0600FADE RID: 64222 RVA: 0x003A17C8 File Offset: 0x0039F9C8
		private string SucEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_sucEffectPath);
				if (flag)
				{
					this.m_sucEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("FuseSucEffectPath");
				}
				return this.m_sucEffectPath;
			}
		}

		// Token: 0x17003878 RID: 14456
		// (get) Token: 0x0600FADF RID: 64223 RVA: 0x003A1804 File Offset: 0x0039FA04
		private string FailEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_failEffectPath);
				if (flag)
				{
					this.m_failEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("FuseFailEffectPath");
				}
				return this.m_failEffectPath;
			}
		}

		// Token: 0x17003879 RID: 14457
		// (get) Token: 0x0600FAE0 RID: 64224 RVA: 0x003A1840 File Offset: 0x0039FA40
		private string EffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_effectPath);
				if (flag)
				{
					this.m_effectPath = XSingleton<XGlobalConfig>.singleton.GetValue("FuseEffectPath");
				}
				return this.m_effectPath;
			}
		}

		// Token: 0x1700387A RID: 14458
		// (get) Token: 0x0600FAE1 RID: 64225 RVA: 0x003A187C File Offset: 0x0039FA7C
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactFuseHandler";
			}
		}

		// Token: 0x0600FAE2 RID: 64226 RVA: 0x003A1894 File Offset: 0x0039FA94
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactFuseDocument.Doc;
			this.m_doc.Handler = this;
			Transform transform = base.PanelObject.transform.FindChild("Bg1");
			this.m_rateLab = (transform.FindChild("ossd").GetComponent("XUILabel") as IXUILabel);
			this.m_itemGo1 = transform.FindChild("item1").gameObject;
			this.m_itemGo2 = transform.FindChild("item2").gameObject;
			this.m_itemGo3 = transform.FindChild("item3").gameObject;
			this.m_boxSpr1 = (transform.FindChild("BgBox1").GetComponent("XUISprite") as IXUISprite);
			this.m_boxSpr2 = (transform.FindChild("BgBox2").GetComponent("XUISprite") as IXUISprite);
			this.m_checkBox = (transform.FindChild("BtnUse").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_fuseBtn = (transform.FindChild("Get").GetComponent("XUIButton") as IXUIButton);
			this.m_effectTra = transform.FindChild("Effect");
		}

		// Token: 0x0600FAE3 RID: 64227 RVA: 0x003A19CC File Offset: 0x0039FBCC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSpr1.ID = 1UL;
			this.m_boxSpr1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_boxSpr2.ID = 2UL;
			this.m_boxSpr2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_checkBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickToggle));
			this.m_fuseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickFuseBtn));
		}

		// Token: 0x0600FAE4 RID: 64228 RVA: 0x003A1A5D File Offset: 0x0039FC5D
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FAE5 RID: 64229 RVA: 0x003A1A6E File Offset: 0x0039FC6E
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			this.StopEffect();
		}

		// Token: 0x0600FAE6 RID: 64230 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FAE7 RID: 64231 RVA: 0x003A1A90 File Offset: 0x0039FC90
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.Handler = null;
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			bool flag2 = this.m_sucFx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_sucFx, true);
				this.m_sucFx = null;
			}
			bool flag3 = this.m_failFx != null;
			if (flag3)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_failFx, true);
				this.m_failFx = null;
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
		}

		// Token: 0x0600FAE8 RID: 64232 RVA: 0x003A1B3C File Offset: 0x0039FD3C
		public void RefreshUi(FuseEffectType type)
		{
			this.FillContent();
			bool flag = type > FuseEffectType.None;
			if (flag)
			{
				this.PlayEffect(type);
			}
		}

		// Token: 0x0600FAE9 RID: 64233 RVA: 0x003A1B64 File Offset: 0x0039FD64
		private void FillContent()
		{
			bool flag = this.m_doc.FuseUid == 0UL;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo1, null);
			}
			else
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.FuseUid);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo1, itemByUID);
				IXUISprite ixuisprite = this.m_itemGo1.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = this.m_doc.FuseUid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
			}
			bool flag2 = this.m_doc.FusedUid == 0UL;
			if (flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo2, null);
			}
			else
			{
				XItem itemByUID2 = XBagDocument.BagDoc.GetItemByUID(this.m_doc.FusedUid);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo2, itemByUID2);
				IXUISprite ixuisprite2 = this.m_itemGo2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = this.m_doc.FusedUid;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
			}
			bool flag3 = this.m_doc.FusedUid != 0UL && this.m_doc.FuseUid > 0UL;
			if (flag3)
			{
				bool flag4 = this.m_fx == null;
				if (flag4)
				{
					this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.EffectPath, null, true);
				}
				else
				{
					this.m_fx.SetActive(true);
				}
				this.m_fx.Play(this.m_effectTra, Vector3.zero, Vector3.one, 1f, true, false);
			}
			else
			{
				bool flag5 = this.m_fx != null;
				if (flag5)
				{
					this.m_fx.SetActive(false);
				}
			}
			this.m_checkBox.ForceSetFlag(this.m_doc.UseFuseStone);
			this.FillNeedItem();
		}

		// Token: 0x0600FAEA RID: 64234 RVA: 0x003A1D6C File Offset: 0x0039FF6C
		private void FillNeedItem()
		{
			IXUILabel ixuilabel = this.m_itemGo3.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
			bool flag = this.m_doc.FuseUid == 0UL;
			int num;
			if (flag)
			{
				num = this.m_doc.FuseStoneItemId;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGo3, num, 2, false);
				ulong itemCount = XBagDocument.BagDoc.GetItemCount(num);
				ixuilabel.SetText(string.Format("{0}/?", itemCount));
				this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FuseRateSucRate"), "?"));
				this.m_bMatIsEnough = false;
			}
			else
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.FuseUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("m_doc.FuseUid = {0} not find" + this.m_doc.FuseUid.ToString(), null, null, null, null, null);
					return;
				}
				ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemByUID.itemID);
				bool flag3 = artifactListRowData == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("artifactlist not find this itemId = {0}", itemByUID.itemID), null, null, null, null, null);
					return;
				}
				num = (int)artifactListRowData.FuseMaterials[0, 0];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGo3, num, 2, false);
				ulong itemCount2 = XBagDocument.BagDoc.GetItemCount(num);
				this.m_bMatIsEnough = (itemCount2 >= (ulong)artifactListRowData.FuseMaterials[0, 1]);
				bool bMatIsEnough = this.m_bMatIsEnough;
				if (bMatIsEnough)
				{
					ixuilabel.SetText(string.Format("[00ff00]{0}/{1}[-]", itemCount2, artifactListRowData.FuseMaterials[0, 1]));
				}
				else
				{
					ixuilabel.SetText(string.Format("[ff0000]{0}/{1}[-]", itemCount2, artifactListRowData.FuseMaterials[0, 1]));
				}
				bool useFuseStone = this.m_doc.UseFuseStone;
				if (useFuseStone)
				{
					this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FuseRateSucRate"), artifactListRowData.FuseSucRateUseStone));
				}
				else
				{
					this.m_bMatIsEnough = true;
					this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FuseRateSucRate"), artifactListRowData.FuseSucRate[0]));
				}
			}
			this.m_needItemId = num;
			IXUISprite ixuisprite = this.m_itemGo3.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)num);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
			ixuisprite = (this.m_itemGo3.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite);
			ixuisprite.SetGrey(this.m_doc.FuseUid > 0UL);
			ixuisprite = (this.m_itemGo3.transform.FindChild("Quality").GetComponent("XUISprite") as IXUISprite);
			ixuisprite.SetGrey(this.m_doc.FuseUid > 0UL);
		}

		// Token: 0x0600FAEB RID: 64235 RVA: 0x003A20BC File Offset: 0x003A02BC
		private void PlayEffect(FuseEffectType type)
		{
			bool flag = type == FuseEffectType.Sucess;
			if (flag)
			{
				bool flag2 = this.m_sucFx == null;
				if (flag2)
				{
					this.m_sucFx = XSingleton<XFxMgr>.singleton.CreateFx(this.SucEffectPath, null, true);
				}
				else
				{
					this.m_sucFx.SetActive(true);
				}
				this.m_sucFx.Play(base.PanelObject.transform, Vector3.zero, Vector3.one, 1f, true, false);
				this.m_bIsPlayingEffect = true;
			}
			else
			{
				bool flag3 = type == FuseEffectType.Fail;
				if (flag3)
				{
					bool flag4 = this.m_failFx == null;
					if (flag4)
					{
						this.m_failFx = XSingleton<XFxMgr>.singleton.CreateFx(this.FailEffectPath, null, true);
					}
					else
					{
						this.m_failFx.SetActive(true);
					}
					this.m_failFx.Play(base.PanelObject.transform, Vector3.zero, Vector3.one, 1f, true, false);
					this.m_bIsPlayingEffect = true;
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_lastTime, new XTimerMgr.ElapsedEventHandler(this.OnEffectEnd), null);
		}

		// Token: 0x0600FAEC RID: 64236 RVA: 0x003A21DC File Offset: 0x003A03DC
		private void OnEffectEnd(object o = null)
		{
			bool flag = this.m_sucFx != null;
			if (flag)
			{
				this.m_sucFx.SetActive(false);
			}
			bool flag2 = this.m_failFx != null;
			if (flag2)
			{
				this.m_failFx.SetActive(false);
			}
			this.m_bIsPlayingEffect = false;
		}

		// Token: 0x0600FAED RID: 64237 RVA: 0x003A2228 File Offset: 0x003A0428
		private void StopEffect()
		{
			bool flag = this.m_sucFx != null;
			if (flag)
			{
				this.m_sucFx.SetActive(false);
			}
			bool flag2 = this.m_failFx != null;
			if (flag2)
			{
				this.m_failFx.SetActive(false);
			}
			bool flag3 = this.m_fx != null;
			if (flag3)
			{
				this.m_fx.SetActive(false);
			}
		}

		// Token: 0x0600FAEE RID: 64238 RVA: 0x003A2284 File Offset: 0x003A0484
		private bool OnClickFuseBtn(IXUIButton btn)
		{
			bool bIsPlayingEffect = this.m_bIsPlayingEffect;
			bool result;
			if (bIsPlayingEffect)
			{
				result = false;
			}
			else
			{
				bool flag = this.m_doc.FuseUid == 0UL;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseTips1"), "fece00");
					result = false;
				}
				else
				{
					bool flag2 = this.m_doc.FusedUid == 0UL;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseTips2"), "fece00");
						result = false;
					}
					else
					{
						bool flag3 = !this.m_bMatIsEnough;
						if (flag3)
						{
							DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.SetVisible(false, true);
							XSingleton<UiUtility>.singleton.ShowItemAccess(this.m_needItemId, null);
							result = false;
						}
						else
						{
							XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
							bool flag4 = specificDocument.GetValue(XOptionsDefine.OD_NO_FUSE_CONFIRM) == 1;
							if (flag4)
							{
								this.m_doc.ReqFuse();
							}
							else
							{
								bool useFuseStone = this.m_doc.UseFuseStone;
								string @string;
								if (useFuseStone)
								{
									@string = XStringDefineProxy.GetString("FuseEnsureTips2");
								}
								else
								{
									@string = XStringDefineProxy.GetString("FuseEnsureTips1");
								}
								XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancel), false, XTempTipDefine.OD_FUSE_CONFIRM, 50);
							}
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600FAEF RID: 64239 RVA: 0x003A23E4 File Offset: 0x003A05E4
		private bool DoOK(IXUIButton btn)
		{
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_NO_FUSE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_FUSE_CONFIRM) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_doc.ReqFuse();
			return true;
		}

		// Token: 0x0600FAF0 RID: 64240 RVA: 0x003A2448 File Offset: 0x003A0648
		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_FUSE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_FUSE_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FAF1 RID: 64241 RVA: 0x003A2490 File Offset: 0x003A0690
		private void OnClickBox(IXUISprite spr)
		{
			bool flag = spr.ID == 1UL;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseTips1"), "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseTips2"), "fece00");
			}
		}

		// Token: 0x0600FAF2 RID: 64242 RVA: 0x003A24E4 File Offset: 0x003A06E4
		private void OnClickTips(IXUISprite spr)
		{
			bool flag = spr.ID == 0UL;
			if (!flag)
			{
				XItem xitem = XBagDocument.BagDoc.GetItemByUID(spr.ID);
				bool flag2 = xitem == null;
				if (flag2)
				{
					xitem = XBagDocument.MakeXItem((int)spr.ID, false);
				}
				bool flag3 = xitem == null;
				if (!flag3)
				{
					bool flag4 = xitem.Type == ItemType.ARTIFACT;
					if (flag4)
					{
						XSingleton<TooltipParam>.singleton.bShowTakeOutBtn = true;
					}
					XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, spr, true, 0U);
				}
			}
		}

		// Token: 0x0600FAF3 RID: 64243 RVA: 0x003A2560 File Offset: 0x003A0760
		private bool OnClickToggle(IXUICheckBox box)
		{
			bool flag = box.bChecked != this.m_doc.UseFuseStone;
			if (flag)
			{
				this.m_doc.UseFuseStone = box.bChecked;
				this.FillNeedItem();
			}
			return true;
		}

		// Token: 0x04006E08 RID: 28168
		private ArtifactFuseDocument m_doc;

		// Token: 0x04006E09 RID: 28169
		private bool m_bMatIsEnough = false;

		// Token: 0x04006E0A RID: 28170
		private int m_needItemId = 0;

		// Token: 0x04006E0B RID: 28171
		private GameObject m_itemGo1;

		// Token: 0x04006E0C RID: 28172
		private GameObject m_itemGo2;

		// Token: 0x04006E0D RID: 28173
		private GameObject m_itemGo3;

		// Token: 0x04006E0E RID: 28174
		private Transform m_effectTra;

		// Token: 0x04006E0F RID: 28175
		private IXUISprite m_boxSpr1;

		// Token: 0x04006E10 RID: 28176
		private IXUISprite m_boxSpr2;

		// Token: 0x04006E11 RID: 28177
		private IXUICheckBox m_checkBox;

		// Token: 0x04006E12 RID: 28178
		private IXUIButton m_fuseBtn;

		// Token: 0x04006E13 RID: 28179
		private IXUILabel m_rateLab;

		// Token: 0x04006E14 RID: 28180
		private XFx m_fx;

		// Token: 0x04006E15 RID: 28181
		private XFx m_sucFx;

		// Token: 0x04006E16 RID: 28182
		private XFx m_failFx;

		// Token: 0x04006E17 RID: 28183
		private uint m_token = 0U;

		// Token: 0x04006E18 RID: 28184
		private float m_lastTime = 1f;

		// Token: 0x04006E19 RID: 28185
		private bool m_bIsPlayingEffect = false;

		// Token: 0x04006E1A RID: 28186
		private string m_sucEffectPath = string.Empty;

		// Token: 0x04006E1B RID: 28187
		private string m_failEffectPath = string.Empty;

		// Token: 0x04006E1C RID: 28188
		private string m_effectPath = string.Empty;
	}
}
