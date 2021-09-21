using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001824 RID: 6180
	internal class FashionAttrTotalHandler : DlgHandlerBase
	{
		// Token: 0x060100BB RID: 65723 RVA: 0x003D25D8 File Offset: 0x003D07D8
		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XFashionDocument.uuID) as XFashionDocument);
			this._fsDoc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this._close = (base.PanelObject.transform.FindChild("ToolTip/Close").GetComponent("XUISprite") as IXUISprite);
			this._closebg = (base.PanelObject.transform.FindChild("ToolTip/CloseBg").GetComponent("XUISprite") as IXUISprite);
			this.m_scrollView = (base.PanelObject.transform.Find("ToolTip/Frame").GetComponent("XUIScrollView") as IXUIScrollView);
			this.SuitFrameAnchor = base.PanelObject.transform.FindChild("ToolTip/Frame/SuitFrameAnchor").gameObject;
			this.CharmFrame = base.PanelObject.transform.Find("ToolTip/Frame/CharmFrame").gameObject;
			Transform transform = this.CharmFrame.transform.Find("Attr1");
			this.CharmAttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.NotCharmAttrGo = this.CharmFrame.transform.Find("NoSuitAttr").gameObject;
			this.BaseFrame = base.PanelObject.transform.FindChild("ToolTip/Frame/BaseFrame").gameObject;
			transform = this.BaseFrame.transform.Find("Attr1");
			this.AttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.NoAttrGo = base.PanelObject.transform.FindChild("ToolTip/Frame/BaseFrame/NoSuitAttr").gameObject;
			this.SuitFrame = base.PanelObject.transform.FindChild("ToolTip/Frame/SuitFrame").gameObject;
			this.NoSuitAttrGo = this.SuitFrame.transform.Find("NoSuitAttr").gameObject;
			transform = this.SuitFrame.transform.FindChild("Attr1");
			this.SuitAttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
		}

		// Token: 0x060100BC RID: 65724 RVA: 0x003D2812 File Offset: 0x003D0A12
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
			this._closebg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
		}

		// Token: 0x060100BD RID: 65725 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		protected void OnClose(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x060100BE RID: 65726 RVA: 0x003D284C File Offset: 0x003D0A4C
		public void SetDataSource(List<uint> s)
		{
			this.UDataSource = s;
		}

		// Token: 0x060100BF RID: 65727 RVA: 0x003D2858 File Offset: 0x003D0A58
		protected override void OnShow()
		{
			Vector3 localPosition = this.SuitFrameAnchor.transform.localPosition;
			bool showCharm = this.ShowCharm;
			Dictionary<uint, uint> dictionary;
			if (showCharm)
			{
				this.CharmFrame.SetActive(true);
				int num = 0;
				int num2 = 0;
				this.CharmFrame.transform.localPosition = localPosition;
				bool flag = this._fsDoc.TryGetCharmAttr(out dictionary, out num, out num2);
				this.CharmAttrPool.ReturnAll(false);
				int num3 = 0;
				bool flag2 = flag;
				if (flag2)
				{
					foreach (KeyValuePair<uint, uint> keyValuePair in dictionary)
					{
						bool flag3 = keyValuePair.Value == 0U;
						if (!flag3)
						{
							GameObject gameObject = this.CharmAttrPool.FetchGameObject(false);
							gameObject.transform.localPosition = this.CharmAttrPool.TplPos + new Vector3(0f, (float)(-(float)num3 * this.CharmAttrPool.TplHeight));
							IXUILabel ixuilabel = gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
							IXUILabel ixuilabel2 = gameObject.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(XStringDefineProxy.GetString((XAttributeDefine)keyValuePair.Key));
							ixuilabel2.SetText(string.Format(" +{0}", keyValuePair.Value));
							num3++;
						}
					}
				}
				this.NotCharmAttrGo.SetActive(num3 == 0);
				bool flag4 = num3 == 0;
				if (flag4)
				{
					num3 += 2;
				}
				else
				{
					num3++;
				}
				localPosition.y -= (float)(this.CharmAttrPool.TplHeight * num3);
			}
			else
			{
				this.CharmFrame.SetActive(false);
				this.NotCharmAttrGo.SetActive(false);
			}
			this.BaseFrame.transform.localPosition = localPosition;
			int num4 = 0;
			dictionary = ((this.UDataSource == null) ? this._doc.GetOnBodyAttr() : this._doc.GetFashonListAttr(this.UDataSource));
			this.AttrPool.ReturnAll(false);
			foreach (KeyValuePair<uint, uint> keyValuePair2 in dictionary)
			{
				GameObject gameObject2 = this.AttrPool.FetchGameObject(false);
				gameObject2.transform.localPosition = this.AttrPool.TplPos + new Vector3(0f, (float)(-(float)num4 * this.AttrPool.TplHeight));
				IXUILabel ixuilabel3 = gameObject2.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject2.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(XStringDefineProxy.GetString((XAttributeDefine)keyValuePair2.Key));
				ixuilabel4.SetText(string.Format(" +{0}", keyValuePair2.Value));
				num4++;
			}
			this.NoAttrGo.SetActive(num4 == 0);
			bool flag5 = num4 == 0;
			if (flag5)
			{
				num4 += 2;
			}
			else
			{
				num4++;
			}
			localPosition.y -= (float)(this.AttrPool.TplHeight * num4);
			this.SuitFrame.transform.localPosition = localPosition;
			int num5 = 0;
			Dictionary<int, uint> dictionary2 = (this.UDataSource == null) ? this._doc.GetTotalQualityCountOnBody(false) : this._doc.GetTotalQualityCount(this.UDataSource, false);
			this.SuitAttrPool.ReturnAll(false);
			foreach (KeyValuePair<int, uint> keyValuePair3 in dictionary2)
			{
				for (int i = 2; i <= 7; i++)
				{
					bool flag6 = (long)i > (long)((ulong)keyValuePair3.Value);
					if (flag6)
					{
						break;
					}
					SeqListRef<uint> qualityEffect = this._doc.GetQualityEffect(keyValuePair3.Key, i, false);
					bool flag7 = qualityEffect.Count == 0;
					if (!flag7)
					{
						for (int j = 0; j < qualityEffect.Count; j++)
						{
							bool flag8 = qualityEffect[j, 0] == 0U;
							if (!flag8)
							{
								GameObject gameObject3 = this.SuitAttrPool.FetchGameObject(false);
								gameObject3.transform.localPosition = this.SuitAttrPool.TplPos + new Vector3(0f, (float)(-(float)num5 * this.SuitAttrPool.TplHeight));
								IXUILabel ixuilabel5 = gameObject3.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
								IXUILabel ixuilabel6 = gameObject3.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
								ixuilabel5.SetText(XStringDefineProxy.GetString("SUIT_PART_COUNT_EFFECT", new object[]
								{
									this._doc.GetQualityName(keyValuePair3.Key) + XStringDefineProxy.GetString("SUIT_QUALITY") + i
								}));
								ixuilabel6.SetText(XStringDefineProxy.GetString((XAttributeDefine)qualityEffect[j, 0]) + XAttributeCommon.GetAttrValueStr((int)qualityEffect[j, 0], (float)qualityEffect[j, 1]));
								num5++;
							}
						}
					}
				}
			}
			Dictionary<int, uint> dictionary3 = (this.UDataSource == null) ? this._doc.GetTotalQualityCountOnBody(true) : this._doc.GetTotalQualityCount(this.UDataSource, true);
			foreach (KeyValuePair<int, uint> keyValuePair4 in dictionary3)
			{
				for (int k = 2; k <= 7; k++)
				{
					bool flag9 = (long)k > (long)((ulong)keyValuePair4.Value);
					if (flag9)
					{
						break;
					}
					SeqListRef<uint> qualityEffect2 = this._doc.GetQualityEffect(keyValuePair4.Key, k, true);
					bool flag10 = qualityEffect2.Count == 0;
					if (!flag10)
					{
						for (int l = 0; l < qualityEffect2.Count; l++)
						{
							bool flag11 = qualityEffect2[l, 0] == 0U;
							if (!flag11)
							{
								GameObject gameObject4 = this.SuitAttrPool.FetchGameObject(false);
								gameObject4.transform.localPosition = this.SuitAttrPool.TplPos + new Vector3(0f, (float)(-(float)num5 * this.SuitAttrPool.TplHeight));
								IXUILabel ixuilabel7 = gameObject4.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
								IXUILabel ixuilabel8 = gameObject4.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
								ixuilabel7.SetText(XStringDefineProxy.GetString("SUIT_PART_COUNT_EFFECT", new object[]
								{
									this._doc.GetQualityName(keyValuePair4.Key) + XStringDefineProxy.GetString("SUIT_QUALITY_THREE") + k
								}));
								ixuilabel8.SetText(XStringDefineProxy.GetString((XAttributeDefine)qualityEffect2[l, 0]) + XAttributeCommon.GetAttrValueStr((int)qualityEffect2[l, 0], (float)qualityEffect2[l, 1]));
								num5++;
							}
						}
					}
				}
			}
			this.NoSuitAttrGo.SetActive(num5 == 0);
			this.m_scrollView.ResetPosition();
		}

		// Token: 0x04007240 RID: 29248
		private XUIPool AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007241 RID: 29249
		private XUIPool SuitAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007242 RID: 29250
		private XUIPool CharmAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007243 RID: 29251
		private XFashionDocument _doc;

		// Token: 0x04007244 RID: 29252
		private XFashionStorageDocument _fsDoc;

		// Token: 0x04007245 RID: 29253
		private IXUIScrollView m_scrollView;

		// Token: 0x04007246 RID: 29254
		private IXUISprite _close;

		// Token: 0x04007247 RID: 29255
		private IXUISprite _closebg;

		// Token: 0x04007248 RID: 29256
		private GameObject SuitFrame = null;

		// Token: 0x04007249 RID: 29257
		private GameObject BaseFrame = null;

		// Token: 0x0400724A RID: 29258
		private GameObject NoAttrGo = null;

		// Token: 0x0400724B RID: 29259
		private GameObject NoSuitAttrGo = null;

		// Token: 0x0400724C RID: 29260
		private GameObject SuitFrameAnchor = null;

		// Token: 0x0400724D RID: 29261
		private GameObject CharmFrame = null;

		// Token: 0x0400724E RID: 29262
		private GameObject NotCharmAttrGo = null;

		// Token: 0x0400724F RID: 29263
		private List<uint> UDataSource = null;

		// Token: 0x04007250 RID: 29264
		public bool ShowCharm = false;
	}
}
