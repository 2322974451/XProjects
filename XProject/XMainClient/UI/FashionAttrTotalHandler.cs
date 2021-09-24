using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionAttrTotalHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
			this._closebg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
		}

		protected void OnClose(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		public void SetDataSource(List<uint> s)
		{
			this.UDataSource = s;
		}

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

		private XUIPool AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool SuitAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool CharmAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XFashionDocument _doc;

		private XFashionStorageDocument _fsDoc;

		private IXUIScrollView m_scrollView;

		private IXUISprite _close;

		private IXUISprite _closebg;

		private GameObject SuitFrame = null;

		private GameObject BaseFrame = null;

		private GameObject NoAttrGo = null;

		private GameObject NoSuitAttrGo = null;

		private GameObject SuitFrameAnchor = null;

		private GameObject CharmFrame = null;

		private GameObject NotCharmAttrGo = null;

		private List<uint> UDataSource = null;

		public bool ShowCharm = false;
	}
}
