using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSpriteAttributePHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAttribute";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_AttributeList = (base.PanelObject.transform.Find("Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.PanelObject.transform.Find("Grid/Tpl");
			this.m_AttributePool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
		}

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

		private XUIPool m_AttributePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIList m_AttributeList;

		private Dictionary<uint, double> attrCompareData = new Dictionary<uint, double>();

		private Dictionary<uint, double> aptitudeCompareData = new Dictionary<uint, double>();
	}
}
