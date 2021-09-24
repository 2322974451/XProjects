using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RefinedReplaceHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactRefinedDocument.Doc;
			this.m_cancleBtn = (base.PanelObject.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_sureBtn = (base.PanelObject.transform.FindChild("Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_parentTra = base.PanelObject.transform.FindChild("Bg/AttrGos");
			this.m_itemPool.SetupPool(this.m_parentTra.gameObject, this.m_parentTra.FindChild("AttrItem").gameObject, 2U, true);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_cancleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancleClicked));
			this.m_sureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSureClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void FillContent()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				XArtifactItem xartifactItem = itemByUID as XArtifactItem;
				bool flag2 = xartifactItem.RandAttrInfo.RandAttr.Count == 0;
				if (!flag2)
				{
					List<XItemChangeAttr> list = new List<XItemChangeAttr>();
					List<XItemChangeAttr> list2 = new List<XItemChangeAttr>();
					for (int i = 0; i < xartifactItem.RandAttrInfo.RandAttr.Count; i++)
					{
						bool flag3 = xartifactItem.RandAttrInfo.RandAttr[i].AttrID > 0U;
						if (flag3)
						{
							list.Add(xartifactItem.RandAttrInfo.RandAttr[i]);
						}
					}
					for (int j = 0; j < xartifactItem.UnSavedAttr.Count; j++)
					{
						bool flag4 = xartifactItem.UnSavedAttr[j].AttrID > 0U;
						if (flag4)
						{
							list2.Add(xartifactItem.UnSavedAttr[j]);
						}
					}
					string text = string.Empty;
					bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
					if (flag5)
					{
						ProfessionTable.RowData byProfID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID);
						bool flag6 = byProfID != null;
						if (flag6)
						{
							text = XStringDefineProxy.GetString("ZizhiType" + byProfID.AttackType);
						}
					}
					this.m_itemPool.ReturnAll(false);
					int num = (list.Count < list2.Count) ? list.Count : list2.Count;
					float num2 = (float)(num * this.m_gap / 2);
					for (int k = 0; k <= num; k++)
					{
						GameObject gameObject = this.m_itemPool.FetchGameObject(false);
						gameObject.transform.parent = this.m_parentTra;
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = new Vector3(0f, num2 - (float)(this.m_gap * k), 0f);
						bool flag7 = k == 0;
						if (flag7)
						{
							int ppt = this.GetPPT(itemByUID, false);
							int ppt2 = this.GetPPT(itemByUID, true);
							IXUILabel ixuilabel = gameObject.transform.FindChild("BeforeName").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(text);
							ixuilabel = (gameObject.transform.FindChild("BeforeValue").GetComponent("XUILabel") as IXUILabel);
							ixuilabel.SetText(this.GetPPT(itemByUID, false).ToString());
							ixuilabel = (gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
							ixuilabel.SetText(text);
							ixuilabel = (gameObject.transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
							bool flag8 = ppt >= ppt2;
							if (flag8)
							{
								ixuilabel.SetText(string.Format("[ff0000]{0}[-]", this.GetPPT(itemByUID, true)));
							}
							else
							{
								ixuilabel.SetText(string.Format("[00ff00]{0}[-]", this.GetPPT(itemByUID, true)));
							}
						}
						else
						{
							int num3 = k - 1;
							XItemChangeAttr xitemChangeAttr = list[num3];
							ArtifactAttrRange artifactAttrRange = ArtifactDocument.GetArtifactAttrRange((uint)xartifactItem.itemID, num3, xitemChangeAttr.AttrID, xitemChangeAttr.AttrValue);
							string color = this.GetColor(xitemChangeAttr.AttrValue, artifactAttrRange.Min, artifactAttrRange.Max);
							IXUILabel ixuilabel = gameObject.transform.FindChild("BeforeName").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)xitemChangeAttr.AttrID)));
							ixuilabel = (gameObject.transform.FindChild("BeforeValue").GetComponent("XUILabel") as IXUILabel);
							ixuilabel.SetText(string.Format("[{0}]{1}[-]", color, xitemChangeAttr.AttrValue));
							xitemChangeAttr = list2[num3];
							artifactAttrRange = ArtifactDocument.GetArtifactAttrRange((uint)xartifactItem.itemID, num3, xitemChangeAttr.AttrID, xitemChangeAttr.AttrValue);
							color = this.GetColor(xitemChangeAttr.AttrValue, artifactAttrRange.Min, artifactAttrRange.Max);
							ixuilabel = (gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
							ixuilabel.SetText(string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)xitemChangeAttr.AttrID)));
							ixuilabel = (gameObject.transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
							ixuilabel.SetText(string.Format("[{0}]{1}[-]", color, xitemChangeAttr.AttrValue));
						}
					}
				}
			}
		}

		private string GetColor(uint attrValue, uint min, uint max)
		{
			bool flag = min >= max;
			float num;
			if (flag)
			{
				num = 100f;
			}
			else
			{
				bool flag2 = attrValue < max;
				if (flag2)
				{
					num = (attrValue - min) * 100U / (max - min);
				}
				else
				{
					num = 100f;
				}
			}
			int quality = EquipAttrDataMgr.MarkList.Count - 1;
			for (int i = 0; i < EquipAttrDataMgr.MarkList.Count; i++)
			{
				bool flag3 = num < (float)EquipAttrDataMgr.MarkList[i];
				if (flag3)
				{
					quality = i;
					break;
				}
			}
			return XSingleton<UiUtility>.singleton.GetItemQualityRGB(quality);
		}

		private int GetPPT(XItem item, bool isTemp)
		{
			XArtifactItem xartifactItem = item as XArtifactItem;
			bool flag = xartifactItem == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				XAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				bool flag2 = xplayerData == null;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					double num = xartifactItem.GetPPT(xplayerData);
					bool flag3 = !isTemp;
					if (flag3)
					{
						for (int i = 0; i < xartifactItem.RandAttrInfo.RandAttr.Count; i++)
						{
							bool flag4 = xartifactItem.RandAttrInfo.RandAttr[i].AttrID == 0U;
							if (!flag4)
							{
								num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xartifactItem.RandAttrInfo.RandAttr[i], xplayerData, -1);
							}
						}
					}
					else
					{
						for (int j = 0; j < xartifactItem.UnSavedAttr.Count; j++)
						{
							bool flag5 = xartifactItem.UnSavedAttr[j].AttrID == 0U;
							if (!flag5)
							{
								num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xartifactItem.UnSavedAttr[j], xplayerData, -1);
							}
						}
					}
					result = (int)num;
				}
			}
			return result;
		}

		private bool OnCancleClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			this.m_doc.ReqRefined(ArtifactDeityStoveOpType.ArtifactDeityStove_RefineRetain);
			return true;
		}

		private bool OnSureClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			this.m_doc.ReqRefined(ArtifactDeityStoveOpType.ArtifactDeityStove_RefineReplace);
			return true;
		}

		private ArtifactRefinedDocument m_doc;

		private IXUIButton m_cancleBtn;

		private IXUIButton m_sureBtn;

		private Transform m_parentTra;

		private readonly int m_gap = 42;

		private XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
