using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSpriteAttributeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAttributeFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			Transform parent = base.PanelObject.transform.Find("SpriteAptitudeRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler, parent, true, this);
			Transform parent2 = base.PanelObject.transform.Find("SpriteAttributeRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributePHandler>(ref this.m_PropertyHandler, parent2, true, this);
			Transform parent3 = base.PanelObject.transform.Find("SpriteSkillRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributeSHandler>(ref this.m_SkillHandler, parent3, true, this);
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAttributePHandler>(ref this.m_PropertyHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeSHandler>(ref this.m_SkillHandler);
			base.OnUnload();
		}

		public void SetSpriteAttributeInfo(SpriteInfo spriteData, XAttributes attributes, SpriteInfo compareData = null)
		{
			this.m_PropertyHandler.SetSpriteAttributeInfo(spriteData, compareData);
			this.m_AptitudeHandler.SetSpriteAttributeInfo(spriteData, attributes, compareData);
			this.m_SkillHandler.SetSpriteAttributeInfo(spriteData, compareData);
		}

		public void SetSpriteAttributeInfo(uint spriteID)
		{
			this.m_PropertyHandler.SetSpriteAttributeInfo(spriteID);
			this.m_AptitudeHandler.SetSpriteAttributeInfo(spriteID);
			this.m_SkillHandler.SetSpriteAttributeInfo(spriteID);
		}

		public static void GetLevelOneSpriteAttr(SpriteTable.RowData spriteInfo, out List<uint> attrID, out List<double> attrValue, out List<double> attrMaxValue)
		{
			attrID = new List<uint>();
			attrID.Add(spriteInfo.AttrID1);
			attrID.Add(spriteInfo.AttrID2);
			attrID.Add(spriteInfo.AttrID3);
			attrID.Add(spriteInfo.AttrID4);
			attrID.Add(spriteInfo.AttrID5);
			List<double> list = new List<double>();
			list.Add(spriteInfo.BaseAttr1);
			list.Add(spriteInfo.BaseAttr2);
			list.Add(spriteInfo.BaseAttr3);
			list.Add(spriteInfo.BaseAttr4);
			list.Add(spriteInfo.BaseAttr5);
			attrMaxValue = new List<double>();
			attrMaxValue.Add(spriteInfo.Range1[1]);
			attrMaxValue.Add(spriteInfo.Range2[1]);
			attrMaxValue.Add(spriteInfo.Range3[1]);
			attrMaxValue.Add(spriteInfo.Range4[1]);
			attrMaxValue.Add(spriteInfo.Range5[1]);
			attrValue = new List<double>();
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			for (int i = 0; i < attrID.Count; i++)
			{
				double num = list[i] + attrMaxValue[i] * specificDocument.GetSpriteLevelRatio(spriteInfo.SpriteQuality, 1U);
				attrValue.Add(num / 100.0);
			}
		}

		private XSpriteAttributePHandler m_PropertyHandler;

		private XSpriteAttributeAHandler m_AptitudeHandler;

		private XSpriteAttributeSHandler m_SkillHandler;
	}
}
