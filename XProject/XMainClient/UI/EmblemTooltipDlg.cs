using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EmblemTooltipDlg : TooltipDlg<EmblemTooltipDlg, EmblemTooltipDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/EmblemToolTipDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new TooltipButtonOperateEmblemPutOn();
			this.m_OperateList[0, 1] = new TooltipButtonOperateIdentify();
			this.m_OperateList[0, 2] = new TooltipButtonOperateRecycle(XSysDefine.XSys_Char_Emblem);
			this.m_OperateList[0, 3] = new TooltipButtonOperateSell();
			this.m_OperateList[0, 4] = new TooltipButtonOperateSmeltReturn();
			this.m_OperateList[1, 0] = new TooltipButtonOperateTakeOff();
			this.m_OperateList[1, 1] = new TooltipButtonOperateEmblemSmelt();
		}

		public void ShowToolTip(ulong MainUID, ulong CompareUID, bool bShowButtons = true)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(MainUID);
			XItem xitem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(CompareUID);
			bool flag = xitem.uid == 0UL;
			if (flag)
			{
				xitem = null;
			}
			this.ShowToolTip(itemByUID, xitem, bShowButtons, 0U);
		}

		protected override void SetupOtherFrame(GameObject goToolTip, XItem mainItem, XItem compareItem, bool bMain)
		{
			Transform transform = goToolTip.transform.Find("ScrollPanel");
			IXUISprite ixuisprite = transform.Find("Description").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = ixuisprite.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
			XEmblemItem xemblemItem = mainItem as XEmblemItem;
			EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(xemblemItem.itemID);
			bool flag = emblemConf != null;
			if (flag)
			{
				bool flag2 = emblemConf.EmblemType <= 1000;
				if (flag2)
				{
					base._SetTopFrameLabel(goToolTip, 0, XStringDefineProxy.GetString("ToolTipText_Type"), XStringDefineProxy.GetString("EMBLEM_ATTR"));
					ixuisprite.gameObject.SetActive(false);
				}
				else
				{
					base._SetTopFrameLabel(goToolTip, 0, XStringDefineProxy.GetString("ToolTipText_Type"), XStringDefineProxy.GetString("EMBLEM_SKILL"));
					ixuisprite.gameObject.SetActive(true);
					ixuilabel.SetText(XEmblemDocument.GetEmblemSkillAttrString(emblemConf.EmblemID));
					base.AppendFrame(ixuisprite.gameObject, (float)ixuisprite.spriteHeight, null);
				}
			}
			else
			{
				base._SetTopFrameLabel(goToolTip, 0, XStringDefineProxy.GetString("ToolTipText_Type"), string.Empty);
			}
			IXUISprite ixuisprite2 = transform.Find("IdentifyHint").GetComponent("XUISprite") as IXUISprite;
			bool flag3 = xemblemItem.emblemInfo.thirdslot == 1U;
			if (flag3)
			{
				ixuisprite2.gameObject.SetActive(true);
				base.AppendFrame(ixuisprite2.gameObject, (float)ixuisprite2.spriteHeight, null);
			}
			else
			{
				ixuisprite2.gameObject.SetActive(false);
			}
			base.SetupOtherFrame(goToolTip, mainItem, compareItem, bMain);
		}

		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupType(goToolTip, data, 0);
			base._SetupLevel(goToolTip, data, 1);
			base._SetupProf(goToolTip, data, bMain, instanceData, 2);
		}

		protected override int SetupAttrFrame(GameObject attrFrame, AttrFrameParam param, bool bMain)
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
			int num3 = 0;
			while (num3 < param.AttrList.Count && num3 < 2)
			{
				GameObject gameObject = base.uiBehaviour.m_AttrPool.FetchGameObject(false);
				gameObject.transform.parent = attrFrame.transform;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AttrPool.TplPos.x, (float)(num2 + num), base.uiBehaviour.m_AttrPool.TplPos.z);
				gameObject.transform.localScale = Vector3.one;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(param.AttrList[num3].strText);
				ixuilabel3.SetText(param.AttrList[num3].strValue);
				num -= base.uiBehaviour.m_AttrPool.TplHeight;
				num3++;
			}
			IXUISprite ixuisprite = attrFrame.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteHeight = -num - num2;
			return ixuisprite.spriteHeight;
		}

		protected override void SetAllAttrFrames(GameObject goToolTip, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			bool flag = item == null || item.changeAttr.Count == 0;
			if (!flag)
			{
				GameObject gameObject = goToolTip.transform.FindChild("ScrollPanel").gameObject;
				this.SetEmlemAttrFrame(gameObject, item, compareItem, bMain);
			}
		}

		protected void SetEmlemAttrFrame(GameObject scrollPanel, XAttrItem item, XAttrItem compareItem, bool bMain)
		{
			GameObject gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
			gameObject.transform.parent = scrollPanel.transform;
			this.tmpAttrFrameParam.Clear();
			this.tmpAttrFrameParam.Title = XStringDefineProxy.GetString("TOOLTIP_BASIC_ATTR");
			int num;
			int endIndex;
			XEquipCreateDocument.GetEmblemAttrDataByID((uint)item.itemID, out num, out endIndex);
			bool flag = num >= 0;
			if (flag)
			{
				for (int i = 0; i < item.changeAttr.Count; i++)
				{
					AttrParam item2 = default(AttrParam);
					AttrParam.ResetSb();
					XItemChangeAttr xitemChangeAttr = item.changeAttr[i];
					bool flag2 = !XAttributeCommon.IsPercentRange((int)xitemChangeAttr.AttrID);
					if (flag2)
					{
						AttributeEmblem.RowData rowData = XEquipCreateDocument.FindAttr(num, endIndex, i, xitemChangeAttr.AttrID);
						bool flag3 = rowData != null;
						if (flag3)
						{
							string prefixColor = XEquipCreateDocument.GetPrefixColor(rowData, xitemChangeAttr.AttrValue);
							AttrParam.Append(xitemChangeAttr, prefixColor, prefixColor);
							AttrParam.ValueSb.Append(" [");
							AttrParam.ValueSb.Append(rowData.Range[0]);
							AttrParam.ValueSb.Append(" - ");
							AttrParam.ValueSb.Append(rowData.Range[1]);
							AttrParam.ValueSb.Append("] ");
						}
						else
						{
							AttrParam.Append(xitemChangeAttr, "", "");
						}
					}
					else
					{
						AttrParam.Append(xitemChangeAttr, "", "");
					}
					item2.SetTextFromSb();
					item2.SetValueFromSb();
					this.tmpAttrFrameParam.AttrList.Add(item2);
				}
			}
			base.AppendFrame(gameObject, (float)this.SetupAttrFrame(gameObject, this.tmpAttrFrameParam, bMain), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
			this.SetAttrOther(scrollPanel.transform, this.tmpAttrFrameParam);
			XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
		}

		protected override void SetAttrOther(Transform ParentTra, AttrFrameParam param)
		{
			bool flag = param.AttrList.Count <= 2;
			if (!flag)
			{
				GameObject gameObject = base.uiBehaviour.m_AttrFramePool.FetchGameObject(false);
				gameObject.transform.parent = ParentTra;
				base.AppendFrame(gameObject, (float)this.SetAttrThird(gameObject, param), new Vector3?(base.uiBehaviour.m_AttrFramePool.TplPos));
			}
		}

		private int SetAttrThird(GameObject attrFrame, AttrFrameParam param)
		{
			int num = 0;
			IXUILabel ixuilabel = attrFrame.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("IdentifyThird"));
			ixuilabel.SetVisible(true);
			int num2 = (int)ixuilabel.gameObject.transform.localPosition.y - ixuilabel.spriteHeight;
			for (int i = 2; i < param.AttrList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_AttrPool.FetchGameObject(false);
				gameObject.transform.parent = attrFrame.transform;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AttrPool.TplPos.x, (float)(num2 + num), base.uiBehaviour.m_AttrPool.TplPos.z);
				gameObject.transform.localScale = Vector3.one;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = gameObject.transform.FindChild("Value").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				bool flag = ixuilabelSymbol.gameObject.transform.localPosition.x > 230f;
				if (flag)
				{
					ixuilabelSymbol.gameObject.transform.localPosition = new Vector3(120f, -13f, 0f);
				}
				ixuilabel2.SetText(param.AttrList[i].strText);
				ixuilabelSymbol.InputText = param.AttrList[i].strValue;
				num -= base.uiBehaviour.m_AttrPool.TplHeight;
			}
			IXUISprite ixuisprite = attrFrame.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteHeight = -num - num2;
			return ixuisprite.spriteHeight;
		}

		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			XEmblemItem xemblemItem = item as XEmblemItem;
			bool flag = xemblemItem == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool bIsSkillEmblem = xemblemItem.bIsSkillEmblem;
				if (bIsSkillEmblem)
				{
					SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)xemblemItem.itemID);
					bool flag2 = emblemSkillConf == null;
					if (flag2)
					{
						valueText = "SKILL EMBLEM.";
						result = -1;
					}
					else
					{
						valueText = emblemSkillConf.SkillPPT.ToString();
						result = (int)emblemSkillConf.SkillPPT;
					}
				}
				else
				{
					XAttributes attributes = bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes;
					bool flag3 = xemblemItem.emblemInfo.thirdslot == 1U || xemblemItem.emblemInfo.thirdslot == 10U;
					if (flag3)
					{
						int num;
						int endIndex;
						XEquipCreateDocument.GetEmblemAttrDataByID((uint)item.itemID, out num, out endIndex);
						bool flag4 = num >= 0;
						if (flag4)
						{
							bool flag5 = xemblemItem.emblemInfo.thirdslot == 1U;
							uint num2;
							uint num3;
							if (flag5)
							{
								uint ppt = xemblemItem.GetPPT(attributes);
								XEquipCreateDocument.GetRandomPPT(num, endIndex, out num2, out num3);
							}
							else
							{
								XEquipCreateDocument.GetPPT(num, endIndex, false, true, out num2, out num3);
							}
							valueText = string.Format("{0} - {1}", num2, num3);
						}
						result = -1;
					}
					else
					{
						uint ppt = xemblemItem.GetPPT(attributes);
						valueText = xemblemItem.GetPPT(attributes).ToString();
						result = (int)ppt;
					}
				}
			}
			return result;
		}

		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			bool flag = !this.bShowButtons;
			if (!flag)
			{
				XEmblemItem xemblemItem = item as XEmblemItem;
				if (bMain)
				{
					bool flag2 = XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag.HasItem(item.uid);
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

		private AttrFrameParam tmpAttrFrameParam = new AttrFrameParam();
	}
}
