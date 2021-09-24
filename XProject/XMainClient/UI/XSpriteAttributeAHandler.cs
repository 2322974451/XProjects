using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSpriteAttributeAHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAptitude";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_AptitudeList = (base.PanelObject.transform.Find("Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.PanelObject.transform.Find("Grid/Tpl");
			this.m_AptitudePool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
		}

		public void SetSpriteAttributeInfo(SpriteInfo spriteData, XAttributes attributes, SpriteInfo compareData = null)
		{
			bool flag = spriteData == null;
			if (flag)
			{
				this.m_AptitudePool.ReturnAll(false);
			}
			else
			{
				this.PreProcessComparedData(compareData, attributes);
				this.CreateSpriteAptitude(spriteData.AddValue, spriteData.AttrID, spriteData.SpriteID, attributes, false);
			}
		}

		public void SetSpriteAttributeInfo(uint spriteID)
		{
			this.aptitudeCompareData.Clear();
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(spriteID);
			bool flag = bySpriteID == null;
			if (!flag)
			{
				List<uint> attrID = new List<uint>();
				List<double> list = new List<double>();
				List<double> addValue = new List<double>();
				XSpriteAttributeHandler.GetLevelOneSpriteAttr(bySpriteID, out attrID, out list, out addValue);
				this.CreateSpriteAptitude(addValue, attrID, spriteID, null, true);
			}
		}

		private void PreProcessComparedData(SpriteInfo compareData, XAttributes attributes = null)
		{
			this.aptitudeCompareData.Clear();
			bool flag = compareData != null;
			if (flag)
			{
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				for (int i = 0; i < compareData.AddValue.Count; i++)
				{
					bool flag2 = i < compareData.AttrID.Count;
					if (flag2)
					{
						this.aptitudeCompareData[compareData.AttrID[i]] = specificDocument.CalAptitude(compareData.AttrID[i], compareData.AddValue[i], attributes);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Cannot Find Aptitude ID", null, null, null, null, null);
					}
				}
			}
		}

		private void CreateSpriteAptitude(List<double> addValue, List<uint> attrID, uint spriteID, XAttributes attributes, bool readTable = false)
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this.m_AptitudePool.FakeReturnAll();
			int i = 0;
			while (i < addValue.Count)
			{
				bool flag = i < attrID.Count;
				if (flag)
				{
					bool flag2 = attrID[i] == 0U;
					if (!flag2)
					{
						GameObject obj = this.m_AptitudePool.FetchGameObject(false);
						double num = specificDocument.CalAptitude(attrID[i], addValue[i], attributes);
						this.SetAptitudeInfo(obj, attrID[i], this.GetMinAttr(spriteID, i), readTable ? ((uint)num / 100U) : ((uint)num), (uint)specificDocument.GetMaxAptitude(spriteID, i) / 100U);
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cannot Find Aptitude ID", null, null, null, null, null);
				}
				IL_B2:
				i++;
				continue;
				goto IL_B2;
			}
			this.m_AptitudeList.Refresh();
			this.m_AptitudePool.ActualReturnAll(false);
		}

		private uint GetMinAttr(uint spriteID, int index)
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(spriteID);
			uint result;
			switch (index)
			{
			case 0:
				result = bySpriteID.Range1[0];
				break;
			case 1:
				result = bySpriteID.Range2[0];
				break;
			case 2:
				result = bySpriteID.Range3[0];
				break;
			case 3:
				result = bySpriteID.Range4[0];
				break;
			case 4:
				result = bySpriteID.Range5[0];
				break;
			default:
				XSingleton<XDebug>.singleton.AddErrorLog("GetMaxAptitude error. index is out of the range. index = ", index.ToString(), null, null, null, null);
				result = 0U;
				break;
			}
			return result;
		}

		private void SetAptitudeInfo(GameObject obj, uint attrID, uint minAttr, uint attrValue, uint attrMax)
		{
			IXUILabel ixuilabel = obj.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUIProgress ixuiprogress = obj.transform.Find("Progress Bar").GetComponent("XUIProgress") as IXUIProgress;
			IXUILabel ixuilabel2 = obj.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = obj.transform.Find("ValueMax").GetComponent("XUILabel") as IXUILabel;
			string format = "Sprite_{0}";
			XAttributeDefine xattributeDefine = (XAttributeDefine)attrID;
			string key = string.Format(format, xattributeDefine.ToString());
			ixuilabel.SetText(XStringDefineProxy.GetString(key));
			ixuilabel3.SetText(XSingleton<XCommon>.singleton.StringCombine("/", attrMax.ToString()));
			float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SpriteAptitudePBarBeginValueRatio"));
			float num2 = minAttr * num / 100f;
			ixuiprogress.value = ((attrMax - num2 == 0f) ? 1f : ((attrValue - num2) / (attrMax - num2)));
			ixuilabel2.SetText(attrValue.ToString());
			bool flag = this.aptitudeCompareData.Count > 0;
			if (flag)
			{
				double num3 = 0.0;
				bool flag2 = this.aptitudeCompareData.TryGetValue(attrID, out num3);
				if (flag2)
				{
					bool flag3 = attrValue > (uint)num3;
					if (flag3)
					{
						ixuilabel2.SetText(XStringDefineProxy.GetString("SpriteAttributeUpColor", new object[]
						{
							attrValue
						}));
					}
					else
					{
						bool flag4 = attrValue < (uint)num3;
						if (flag4)
						{
							ixuilabel2.SetText(XStringDefineProxy.GetString("SpriteAttributeDownColor", new object[]
							{
								attrValue
							}));
						}
						else
						{
							ixuilabel2.SetText(attrValue.ToString());
						}
					}
				}
				else
				{
					ixuilabel2.SetText(XStringDefineProxy.GetString("SpriteAttributeUpColor", new object[]
					{
						attrValue
					}));
				}
			}
		}

		private XUIPool m_AptitudePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIList m_AptitudeList;

		private Dictionary<uint, double> aptitudeCompareData = new Dictionary<uint, double>();
	}
}
