using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactToolTipDlg : TooltipDlg<ArtifactToolTipDlg, ArtifactTooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ArtifactToolTipDlg";
			}
		}

		protected override int compareWindowDistance
		{
			get
			{
				return 20;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new ArtifactTooltipButtonOperate();
			this.m_OperateList[0, 1] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Artifact);
			this.m_OperateList[0, 2] = new TooltipButtonOperatePutIn();
			this.m_OperateList[0, 3] = new TooltipButtonOperateTakeOut();
			this.m_OperateList[1, 0] = new TooltipButtonOperateTakeOff();
			this.m_OperateList[1, 1] = new TooltipButtonOperatePutIn();
			this.m_OperateList[1, 2] = new TooltipButtonOperateTakeOut();
		}

		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			XArtifactItem xartifactItem = item as XArtifactItem;
			bool flag = xartifactItem == null;
			if (!flag)
			{
				GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
				this._SetupRandFrame(gameObject, item, bMain);
			}
		}

		private void _SetupRandFrame(GameObject scrollPanel, XItem mainItem, bool bMain)
		{
			XArtifactItem xartifactItem = mainItem as XArtifactItem;
			bool flag = xartifactItem == null;
			if (!flag)
			{
				bool flag2 = !xartifactItem.RandAttrInfo.bPreview && xartifactItem.RandAttrInfo.RandAttr.Count == 0;
				if (!flag2)
				{
					GameObject gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
					gameObject.transform.parent = scrollPanel.transform;
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					attrFrameParam.Title = XStringDefineProxy.GetString("HIDDEN_ATTR");
					bool bPreview = xartifactItem.RandAttrInfo.bPreview;
					if (bPreview)
					{
						AttrParam item = default(AttrParam);
						AttrParam.ResetSb();
						AttrParam.Append(AttrParam.TextSb, XStringDefineProxy.GetString("HIDDEN_ATTR"), "");
						AttrParam.Append(AttrParam.ValueSb, "???", "");
						item.SetTextFromSb();
						item.SetValueFromSb();
						attrFrameParam.AttrList.Add(item);
					}
					for (int i = 0; i < xartifactItem.RandAttrInfo.RandAttr.Count; i++)
					{
						XItemChangeAttr xitemChangeAttr = xartifactItem.RandAttrInfo.RandAttr[i];
						bool flag3 = xitemChangeAttr.AttrID == 0U;
						if (!flag3)
						{
							ArtifactAttrRange artifactAttrRange = ArtifactDocument.GetArtifactAttrRange((uint)xartifactItem.itemID, i, xitemChangeAttr.AttrID, xitemChangeAttr.AttrValue);
							string color = this.GetColor(xitemChangeAttr.AttrValue, artifactAttrRange.Min, artifactAttrRange.Max);
							AttrParam item2 = default(AttrParam);
							AttrParam.ResetSb();
							AttrParam.Append(xitemChangeAttr, color, color);
							AttrParam.ValueSb.Append(" [");
							AttrParam.ValueSb.Append(artifactAttrRange.Min);
							AttrParam.ValueSb.Append(" - ");
							AttrParam.ValueSb.Append(artifactAttrRange.Max);
							AttrParam.ValueSb.Append("] ");
							item2.SetTextFromSb();
							item2.SetValueFromSb();
							attrFrameParam.AttrList.Add(item2);
						}
					}
					base.AppendFrame(gameObject, (float)this.SetupAttrFrame(gameObject, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
					XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				}
			}
		}

		public string GetColor(uint attrValue, uint min, uint max)
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

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			Transform transform = goToolTip.transform;
			GameObject gameObject = transform.FindChild("TopFrame/State").gameObject;
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)data.ItemID);
			base._SetTopFrameLabel(goToolTip, 2, XStringDefineProxy.GetString("ToolTipText_Part"), (artifactListRowData != null) ? XSingleton<UiUtility>.singleton.GetArtifactPartName((ArtifactPosition)artifactListRowData.ArtifactPos, true) : string.Empty);
			gameObject.SetActive(!bMain || XSingleton<TooltipParam>.singleton.bEquiped);
		}

		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
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
				XAttributes attributes = bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes;
				double num = xartifactItem.GetPPT(attributes);
				bool bPreview = xartifactItem.RandAttrInfo.bPreview;
				if (bPreview)
				{
					uint num2 = (uint)num + ArtifactDocument.GetArtifactMinPPt((uint)xartifactItem.itemID, attributes);
					uint num3 = (uint)num + ArtifactDocument.GetArtifactMaxPPt((uint)xartifactItem.itemID, attributes);
					valueText = string.Format("{0} - {1}", num2, num3);
					result = -1;
				}
				else
				{
					for (int i = 0; i < xartifactItem.RandAttrInfo.RandAttr.Count; i++)
					{
						bool flag2 = xartifactItem.RandAttrInfo.RandAttr[i].AttrID == 0U;
						if (!flag2)
						{
							num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(xartifactItem.RandAttrInfo.RandAttr[i], attributes, -1);
						}
					}
					valueText = ((uint)num).ToString();
					result = (int)num;
				}
			}
			return result;
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			this._SetupArtifactEffect(goToolTip, mainItem, compareItem, bMain);
			this._SetupSuitFrame(goToolTip, mainItem, compareItem, bMain);
			base.SetupOtherFrame(goToolTip, mainItem, compareItem, bMain);
		}

		private void _SetupArtifactEffect(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			XArtifactItem xartifactItem = mainItem as XArtifactItem;
			bool flag = xartifactItem == null;
			if (!flag)
			{
				bool flag2 = xartifactItem.EffectInfoList.Count <= 0;
				if (!flag2)
				{
					GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
					GameObject gameObject2 = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
					gameObject2.transform.parent = gameObject.transform;
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					attrFrameParam.Title = XStringDefineProxy.GetString("ArytifactSkillEffect");
					int num = int.MaxValue;
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)xartifactItem.itemID);
					bool flag3 = artifactListRowData != null;
					if (flag3)
					{
						num = (int)artifactListRowData.EffectNum;
					}
					for (int i = 0; i < xartifactItem.EffectInfoList.Count; i++)
					{
						XArtifactEffectInfo xartifactEffectInfo = xartifactItem.EffectInfoList[i];
						AttrParam item = default(AttrParam);
						AttrParam.ResetSb();
						string text = ArtifactDocument.GetArtifactEffectDes(xartifactEffectInfo.EffectId, xartifactEffectInfo.GetValues());
						bool flag4 = !xartifactEffectInfo.IsValid;
						if (flag4)
						{
							text = string.Format("{0}{1}", text, XSingleton<XStringTable>.singleton.GetString("NotValid"));
						}
						bool flag5 = i >= num;
						if (flag5)
						{
							text = XSingleton<XCommon>.singleton.StringCombine(XLabelSymbolHelper.FormatAnimation("common/Universal", "Emblem_0", 10), text);
						}
						AttrParam.Append(AttrParam.ValueSb, text, "");
						item.SetTextFromSb();
						item.SetValueFromSb();
						attrFrameParam.AttrList.Add(item);
					}
					base.AppendFrame(gameObject2, (float)this.SetupDesFrame(gameObject2, attrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
					XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject2);
				}
			}
		}

		protected int SetupDesFrame(GameObject attrFrame, AttrFrameParam param, bool bMain)
		{
			int num = 0;
			IXUILabel ixuilabel = attrFrame.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
			bool flag = !string.IsNullOrEmpty(param.Title);
			int num2;
			if (flag)
			{
				ixuilabel.SetText(param.Title);
				ixuilabel.SetVisible(true);
				num2 = (int)ixuilabel.gameObject.transform.localPosition.y - ixuilabel.spriteHeight;
			}
			else
			{
				ixuilabel.SetVisible(false);
				num2 = (int)ixuilabel.gameObject.transform.localPosition.y;
			}
			int num3 = 8;
			IXUILabel ixuilabel2 = base.uiBehaviour.m_AttrPool._tpl.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			int num4 = base.uiBehaviour.m_AttrPool.TplHeight - ixuilabel2.fontSize;
			for (int i = 0; i < param.AttrList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_DesFramePool.FetchGameObject(false);
				gameObject.transform.parent = attrFrame.transform;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AttrPool.TplPos.x, (float)(num2 + num), base.uiBehaviour.m_AttrPool.TplPos.z);
				gameObject.transform.localScale = Vector3.one;
				IXUILabelSymbol ixuilabelSymbol = gameObject.transform.FindChild("Text").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				ixuilabelSymbol.InputText = param.AttrList[i].strValue;
				num -= ixuilabel3.spriteHeight + num3;
			}
			IXUISprite ixuisprite = attrFrame.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteHeight = -num - num2 - num4;
			return ixuisprite.spriteHeight;
		}

		private void _SetupSuitFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			IXUISprite ixuisprite = goToolTip.transform.FindChild("ScrollPanel/SuitFrame").GetComponent("XUISprite") as IXUISprite;
			bool flag = mainItem == null;
			if (flag)
			{
				ixuisprite.SetVisible(false);
			}
			else
			{
				ArtifactSuit suitByArtifactId = ArtifactDocument.SuitMgr.GetSuitByArtifactId((uint)mainItem.itemID);
				bool flag2 = suitByArtifactId == null;
				if (flag2)
				{
					ixuisprite.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(true);
					bool flag3 = XSingleton<TooltipParam>.singleton.BodyBag == null;
					if (flag3)
					{
						XSingleton<TooltipParam>.singleton.BodyBag = XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag;
					}
					int num = suitByArtifactId.GetEquipedSuitCount(XSingleton<TooltipParam>.singleton.BodyBag);
					bool flag4 = bMain && suitByArtifactId.WillChangeEquipedCount(mainItem.itemID, XSingleton<TooltipParam>.singleton.BodyBag);
					if (flag4)
					{
						num++;
					}
					int num2 = 0;
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					for (int i = 0; i < suitByArtifactId.effects.Length; i++)
					{
						SeqListRef<uint> seqListRef = suitByArtifactId.effects[i];
						bool flag5 = seqListRef.Count == 0;
						if (!flag5)
						{
							for (int j = 0; j < seqListRef.Count; j++)
							{
								bool flag6 = seqListRef[j, 0] == 0U;
								if (!flag6)
								{
									bool flag7 = i <= num;
									string text;
									string color;
									if (flag7)
									{
										text = "ffffff";
										color = XSingleton<UiUtility>.singleton.GetColorStr(new Color(0.99607843f, 0.80784315f, 0f));
									}
									else
									{
										text = XSingleton<UiUtility>.singleton.GetColorStr(new Color(0.5019608f, 0.5019608f, 0.5019608f));
										color = text;
									}
									AttrParam item = default(AttrParam);
									AttrParam.ResetSb();
									AttrParam.Append(AttrParam.TextSb, XStringDefineProxy.GetString("EQUIP_SUIT_EFFECT", new object[]
									{
										i
									}), color);
									string s = string.Format("{0}{1}", XStringDefineProxy.GetString((XAttributeDefine)seqListRef[j, 0]), XAttributeCommon.GetAttrValueStr((int)seqListRef[j, 0], (float)seqListRef[j, 1]));
									AttrParam.Append(AttrParam.ValueSb, s, text);
									item.SetTextFromSb();
									item.SetValueFromSb();
									attrFrameParam.AttrList.Add(item);
									num2++;
								}
							}
						}
					}
					bool flag8 = num2 > 0;
					if (flag8)
					{
						string arg = string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactSuitEffectTittle"), suitByArtifactId.Name);
						attrFrameParam.Title = string.Format("{0}({1}/{2})", arg, num.ToString(), suitByArtifactId.Artifacts.Count.ToString());
						base.AppendFrame(ixuisprite.gameObject, (float)this.SetupAttrFrame(ixuisprite.gameObject, attrFrameParam, bMain), null);
					}
					else
					{
						ixuisprite.SetVisible(false);
					}
				}
			}
		}

		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = !this.bShowButtons;
			if (!flag)
			{
				if (bMain)
				{
					XArtifactItem xartifactItem = item as XArtifactItem;
					bool flag2 = XSingleton<XGame>.singleton.Doc.XBagDoc.ArtifactBag.HasItem(item.uid);
					if (flag2)
					{
						base._SetupButtonVisiability(goToolTip, 1, item);
					}
					else
					{
						base._SetupButtonVisiability(goToolTip, 0, item);
					}
				}
			}
		}

		public override bool HideToolTip(bool forceHide = false)
		{
			bool flag = base.HideToolTip(forceHide);
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				result = flag;
			}
			else
			{
				bool flag3 = base.uiBehaviour.m_DesFramePool != null;
				if (flag3)
				{
					base.uiBehaviour.m_DesFramePool.ReturnAll(false);
				}
				result = true;
			}
			return result;
		}
	}
}
