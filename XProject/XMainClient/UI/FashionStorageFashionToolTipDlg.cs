using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001807 RID: 6151
	internal class FashionStorageFashionToolTipDlg : FashionStorageTooltipBase<FashionStorageFashionToolTipDlg, FashionTooltipDlgBehaviour>
	{
		// Token: 0x170038F0 RID: 14576
		// (get) Token: 0x0600FF02 RID: 65282 RVA: 0x003C0FA0 File Offset: 0x003BF1A0
		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageFashionToolTip";
			}
		}

		// Token: 0x0600FF03 RID: 65283 RVA: 0x003C0FB8 File Offset: 0x003BF1B8
		protected override void SetupTopFrame(GameObject goToolTip, ItemList.RowData data, bool bMain, XItem instanceData = null, XItem compareData = null)
		{
			base.SetupTopFrame(goToolTip, data, bMain, instanceData, compareData);
			base._SetupLevel(goToolTip, data, 0);
			base._SetupProf(goToolTip, data, bMain, instanceData, 1);
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(data.ItemID);
			base._SetTopFrameLabel(goToolTip, 2, XStringDefineProxy.GetString("ToolTipText_Part"), (fashionConf != null) ? XSingleton<UiUtility>.singleton.GetFashionPartName((FashionPosition)fashionConf.EquipPos, true) : string.Empty);
			Transform transform = goToolTip.transform;
			GameObject gameObject = transform.FindChild("TopFrame/State").gameObject;
			gameObject.SetActive(false);
			this.time = (transform.FindChild("TopFrame/Time/Left").GetComponent("XUILabel") as IXUILabel);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(data.ItemID);
			bool flag = itemConf == null || itemConf.TimeLimit == 0U;
			if (flag)
			{
				this.time.SetText(XStringDefineProxy.GetString("FASHION_LIMIT_ALWAYS"));
			}
			else
			{
				this.time.SetText(XStringDefineProxy.GetString("Designation_Tab_Name5"));
			}
		}

		// Token: 0x0600FF04 RID: 65284 RVA: 0x003C10B4 File Offset: 0x003BF2B4
		protected override void SetupOtherFrame(GameObject goToolTip, XItem item, XItem compareItem, bool bMain)
		{
			this._SetupSuitFrame(goToolTip, item, compareItem, bMain);
			base.SetupOtherFrame(goToolTip, item, compareItem, bMain);
		}

		// Token: 0x0600FF05 RID: 65285 RVA: 0x003C10D0 File Offset: 0x003BF2D0
		protected override int _GetPPT(XItem item, bool bMain, ref string valueText)
		{
			bool flag = item == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				uint ppt = item.GetPPT(bMain ? XSingleton<TooltipParam>.singleton.mainAttributes : XSingleton<TooltipParam>.singleton.compareAttributes);
				valueText = ppt.ToString();
				result = (int)ppt;
			}
			return result;
		}

		// Token: 0x0600FF06 RID: 65286 RVA: 0x003C1118 File Offset: 0x003BF318
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
				ixuisprite.SetVisible(true);
				ItemList.RowData itemConf = XBagDocument.GetItemConf(mainItem.itemID);
				int itemQuality = (int)itemConf.ItemQuality;
				bool flag2 = this.m_fashionDoc.IsFashionThreeSpecial(mainItem.itemID);
				int fashionSuit = this.m_fashionDoc.GetFashionSuit(mainItem.itemID);
				bool flag3 = flag2 && fashionSuit == 0;
				if (flag3)
				{
					ixuisprite.SetVisible(false);
				}
				else
				{
					int num = 0;
					int num2 = (XSingleton<TooltipParam>.singleton.FashionOnBody == null) ? this.m_fashionDoc.GetQualityCountOnBody(itemQuality, flag2) : this.GetFashionCount(itemQuality, flag2);
					AttrFrameParam attrFrameParam = new AttrFrameParam();
					for (int i = 2; i <= 7; i++)
					{
						SeqListRef<uint> qualityEffect = this.m_fashionDoc.GetQualityEffect(itemQuality, i, flag2);
						bool flag4 = qualityEffect.Count == 0;
						if (!flag4)
						{
							for (int j = 0; j < qualityEffect.Count; j++)
							{
								bool flag5 = qualityEffect[j, 0] == 0U;
								if (!flag5)
								{
									bool flag6 = i <= num2;
									string text;
									string color;
									if (flag6)
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
									string s = string.Format("{0}{1}", XStringDefineProxy.GetString((XAttributeDefine)qualityEffect[j, 0]), XAttributeCommon.GetAttrValueStr((int)qualityEffect[j, 0], (float)qualityEffect[j, 1]));
									AttrParam.Append(AttrParam.ValueSb, s, text);
									item.SetTextFromSb();
									item.SetValueFromSb();
									attrFrameParam.AttrList.Add(item);
									num++;
								}
							}
						}
					}
					bool flag7 = num > 0;
					if (flag7)
					{
						bool flag8 = !flag2;
						if (flag8)
						{
							string @string = XStringDefineProxy.GetString("EQUIP_SUIT_TITLE", new object[]
							{
								this.m_fashionDoc.GetQualityName(itemQuality)
							});
							string str = string.Format("({0}/{1})", num2, 7);
							attrFrameParam.Title = @string + str;
						}
						else
						{
							string string2 = XStringDefineProxy.GetString("EQUIP_SUIT_THREE_TITLE", new object[]
							{
								this.m_fashionDoc.GetQualityName(itemQuality)
							});
							string str2 = string.Format("({0}/{1})", num2, 3);
							attrFrameParam.Title = string2 + str2;
						}
						base.AppendFrame(ixuisprite.gameObject, (float)this.SetupAttrFrame(ixuisprite.gameObject, attrFrameParam, bMain), null);
					}
					else
					{
						ixuisprite.SetVisible(false);
					}
				}
			}
		}

		// Token: 0x0600FF07 RID: 65287 RVA: 0x003C145C File Offset: 0x003BF65C
		private int GetFashionCount(int quality, bool IsThreeSuit)
		{
			bool flag = XSingleton<TooltipParam>.singleton.FashionOnBody == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int i = 0;
				int count = XSingleton<TooltipParam>.singleton.FashionOnBody.Count;
				while (i < count)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)XSingleton<TooltipParam>.singleton.FashionOnBody[i]);
					bool flag2 = itemConf == null;
					if (!flag2)
					{
						bool flag3 = IsThreeSuit ^ this.m_fashionDoc.IsFashionThreeSpecial((int)XSingleton<TooltipParam>.singleton.FashionOnBody[i]);
						if (!flag3)
						{
							bool flag4 = IsThreeSuit && this.m_fashionDoc.GetFashionSuit((int)XSingleton<TooltipParam>.singleton.FashionOnBody[i]) == 0;
							if (!flag4)
							{
								bool flag5 = (int)itemConf.ItemQuality == quality;
								if (flag5)
								{
									num++;
								}
							}
						}
					}
					i++;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x040070B8 RID: 28856
		private IXUILabel time = null;
	}
}
