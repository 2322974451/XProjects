using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200185E RID: 6238
	internal class XSpriteAttributeHandler : DlgHandlerBase
	{
		// Token: 0x1700398E RID: 14734
		// (get) Token: 0x060103E3 RID: 66531 RVA: 0x003ECC10 File Offset: 0x003EAE10
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAttributeFrame";
			}
		}

		// Token: 0x060103E4 RID: 66532 RVA: 0x003ECC28 File Offset: 0x003EAE28
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

		// Token: 0x060103E5 RID: 66533 RVA: 0x003ECCAC File Offset: 0x003EAEAC
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAttributePHandler>(ref this.m_PropertyHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeSHandler>(ref this.m_SkillHandler);
			base.OnUnload();
		}

		// Token: 0x060103E6 RID: 66534 RVA: 0x003ECCDA File Offset: 0x003EAEDA
		public void SetSpriteAttributeInfo(SpriteInfo spriteData, XAttributes attributes, SpriteInfo compareData = null)
		{
			this.m_PropertyHandler.SetSpriteAttributeInfo(spriteData, compareData);
			this.m_AptitudeHandler.SetSpriteAttributeInfo(spriteData, attributes, compareData);
			this.m_SkillHandler.SetSpriteAttributeInfo(spriteData, compareData);
		}

		// Token: 0x060103E7 RID: 66535 RVA: 0x003ECD08 File Offset: 0x003EAF08
		public void SetSpriteAttributeInfo(uint spriteID)
		{
			this.m_PropertyHandler.SetSpriteAttributeInfo(spriteID);
			this.m_AptitudeHandler.SetSpriteAttributeInfo(spriteID);
			this.m_SkillHandler.SetSpriteAttributeInfo(spriteID);
		}

		// Token: 0x060103E8 RID: 66536 RVA: 0x003ECD34 File Offset: 0x003EAF34
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

		// Token: 0x040074B2 RID: 29874
		private XSpriteAttributePHandler m_PropertyHandler;

		// Token: 0x040074B3 RID: 29875
		private XSpriteAttributeAHandler m_AptitudeHandler;

		// Token: 0x040074B4 RID: 29876
		private XSpriteAttributeSHandler m_SkillHandler;
	}
}
