using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001811 RID: 6161
	internal class XSpriteAttributePHandler : DlgHandlerBase
	{
		// Token: 0x170038FF RID: 14591
		// (get) Token: 0x0600FF9A RID: 65434 RVA: 0x003C7040 File Offset: 0x003C5240
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAttribute";
			}
		}

		// Token: 0x0600FF9B RID: 65435 RVA: 0x003C7058 File Offset: 0x003C5258
		protected override void Init()
		{
			base.Init();
			this.m_AttributeList = (base.PanelObject.transform.Find("Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.PanelObject.transform.Find("Grid/Tpl");
			this.m_AttributePool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
		}

		// Token: 0x0600FF9C RID: 65436 RVA: 0x003C70CC File Offset: 0x003C52CC
		private void PreProcessComparedData(SpriteInfo compareData)
		{
			this.attrCompareData.Clear();
			bool flag = compareData != null;
			if (flag)
			{
				for (int i = 0; i < compareData.AttrID.Count; i++)
				{
					bool flag2 = i < compareData.AttrValue.Count;
					if (flag2)
					{
						this.attrCompareData[compareData.AttrID[i]] = compareData.AttrValue[i];
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Cannot Find Aptitude ID", null, null, null, null, null);
					}
				}
			}
		}

		// Token: 0x0600FF9D RID: 65437 RVA: 0x003C7160 File Offset: 0x003C5360
		private void CreateSpriteAttr(List<uint> attrID, List<double> attrValue, List<uint> evoAttrID, List<double> evoAttrValue)
		{
			this.m_AttributePool.FakeReturnAll();
			for (int i = 0; i < attrID.Count; i++)
			{
				bool flag = attrID[i] == 0U;
				if (!flag)
				{
					GameObject obj = this.m_AttributePool.FetchGameObject(false);
					bool flag2 = i < attrValue.Count;
					if (flag2)
					{
						double evoValue = 0.0;
						bool flag3 = evoAttrID != null && evoAttrValue != null;
						if (flag3)
						{
							for (int j = 0; j < evoAttrID.Count; j++)
							{
								bool flag4 = attrID[i] == evoAttrID[j] && j < evoAttrValue.Count;
								if (flag4)
								{
									evoValue = evoAttrValue[j];
									break;
								}
							}
						}
						this.SetAttributeInfo(obj, attrID[i], (uint)attrValue[i], evoValue);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Cannot Find Attr Value", null, null, null, null, null);
					}
				}
			}
			this.m_AttributeList.Refresh();
			this.m_AttributePool.ActualReturnAll(false);
		}

		// Token: 0x0600FF9E RID: 65438 RVA: 0x003C7284 File Offset: 0x003C5484
		public void SetSpriteAttributeInfo(SpriteInfo spriteData, SpriteInfo compareData = null)
		{
			bool flag = spriteData == null;
			if (flag)
			{
				this.m_AttributePool.ReturnAll(false);
			}
			else
			{
				this.PreProcessComparedData(compareData);
				this.CreateSpriteAttr(spriteData.AttrID, spriteData.AttrValue, spriteData.EvoAttrID, spriteData.EvoAttrValue);
			}
		}

		// Token: 0x0600FF9F RID: 65439 RVA: 0x003C72D4 File Offset: 0x003C54D4
		public void SetSpriteAttributeInfo(uint spriteID)
		{
			this.attrCompareData.Clear();
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(spriteID);
			bool flag = bySpriteID == null;
			if (!flag)
			{
				List<uint> attrID = new List<uint>();
				List<double> attrValue = new List<double>();
				List<double> list = new List<double>();
				XSpriteAttributeHandler.GetLevelOneSpriteAttr(bySpriteID, out attrID, out attrValue, out list);
				this.CreateSpriteAttr(attrID, attrValue, null, null);
			}
		}

		// Token: 0x0600FFA0 RID: 65440 RVA: 0x003C7340 File Offset: 0x003C5540
		private void SetAttributeInfo(GameObject obj, uint attrID, uint attrValue, double evoValue)
		{
			IXUILabel ixuilabel = obj.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = obj.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = obj.transform.Find("Addon").GetComponent("XUILabel") as IXUILabel;
			string format = "Sprite_{0}";
			XAttributeDefine xattributeDefine = (XAttributeDefine)attrID;
			string key = string.Format(format, xattributeDefine.ToString());
			ixuilabel.SetText(XStringDefineProxy.GetString(key));
			ixuilabel2.SetText(attrValue.ToString());
			ixuilabel3.SetVisible(evoValue != 0.0);
			ixuilabel3.SetText(string.Format("+{0}", evoValue));
			bool flag = this.attrCompareData.Count > 0;
			if (flag)
			{
				double num = 0.0;
				bool flag2 = this.attrCompareData.TryGetValue(attrID, out num);
				if (flag2)
				{
					bool flag3 = attrValue > (uint)num;
					if (flag3)
					{
						ixuilabel2.SetText("[00ff00]+" + attrValue.ToString() + "[-]");
					}
					else
					{
						bool flag4 = attrValue < (uint)num;
						if (flag4)
						{
							ixuilabel2.SetText("[ff0000]+" + attrValue.ToString() + "[-]");
						}
						else
						{
							ixuilabel2.SetText("+" + attrValue.ToString());
						}
					}
				}
				else
				{
					ixuilabel2.SetText("[00ff00]+" + attrValue.ToString() + "[-]");
				}
			}
		}

		// Token: 0x04007129 RID: 28969
		private XUIPool m_AttributePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400712A RID: 28970
		private IXUIList m_AttributeList;

		// Token: 0x0400712B RID: 28971
		private Dictionary<uint, double> attrCompareData = new Dictionary<uint, double>();

		// Token: 0x0400712C RID: 28972
		private Dictionary<uint, double> aptitudeCompareData = new Dictionary<uint, double>();
	}
}
