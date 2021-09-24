using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XArtifactAttrView<T> : XAttrCommonHandler<T> where T : XAttrCommonFile, new()
	{

		public void SetBaseData(XBodyBag equipments)
		{
			this.SetShowData(equipments);
			bool flag = base.IsVisible();
			if (flag)
			{
				this.RefreshData();
			}
		}

		public void SetBaseData(List<Item> lst)
		{
			this.SetShowData(lst);
			bool flag = base.IsVisible();
			if (flag)
			{
				this.RefreshData();
			}
		}

		public override void SetData()
		{
			base.SetData();
			bool flag = this.m_attrDataList != null || this.m_percentAttrDataList != null;
			if (flag)
			{
				XAttrData xattrData = base._FetchAttrData();
				xattrData.Type = AttriDataType.Attri;
				xattrData.Title = XStringDefineProxy.GetString("Tooltip_Artifact_attr");
				bool flag2 = (this.m_attrDataList == null || this.m_attrDataList.Count == 0) && (this.m_percentAttrDataList == null || this.m_percentAttrDataList.Count == 0);
				if (flag2)
				{
					xattrData.StrEmpty = XStringDefineProxy.GetString("No_Artifact_attr");
				}
				else
				{
					bool flag3 = this.m_attrDataList != null;
					if (flag3)
					{
						for (int i = 0; i < this.m_attrDataList.Count; i++)
						{
							xattrData.Left.Add(this.m_attrDataList[i].Name);
							xattrData.Right.Add(this.m_attrDataList[i].NumStr);
						}
					}
					bool flag4 = this.m_percentAttrDataList != null;
					if (flag4)
					{
						for (int j = 0; j < this.m_percentAttrDataList.Count; j++)
						{
							xattrData.Left.Add(this.m_percentAttrDataList[j].Name);
							xattrData.Right.Add(this.m_percentAttrDataList[j].NumStr);
						}
					}
				}
			}
			bool flag5 = this.m_effectDataList != null;
			if (flag5)
			{
				XAttrData xattrData = base._FetchAttrData();
				xattrData.Title = XStringDefineProxy.GetString("ArytifactSkillEffect");
				xattrData.Type = AttriDataType.SingleLine;
				bool flag6 = this.m_effectDataList.Count == 0;
				if (flag6)
				{
					xattrData.StrEmpty = XStringDefineProxy.GetString("NoArtifactSkillEffect");
				}
				else
				{
					for (int k = 0; k < this.m_effectDataList.Count; k++)
					{
						xattrData.Left.Add(this.m_effectDataList[k].LeftStr);
						xattrData.Right.Add(this.m_effectDataList[k].RightStr);
					}
				}
			}
			bool flag7 = this.m_suitDataList != null;
			if (flag7)
			{
				bool flag8 = this.m_suitDataList.Count == 0;
				if (flag8)
				{
					XAttrData xattrData = base._FetchAttrData();
					xattrData.Title = XStringDefineProxy.GetString("ArtifactSuitTittle");
					xattrData.Type = AttriDataType.Attri;
					xattrData.StrEmpty = XStringDefineProxy.GetString("NoArtifactSuit");
				}
				else
				{
					for (int l = 0; l < this.m_suitDataList.Count; l++)
					{
						List<ArtifactTotalAttrData> list = this.m_suitDataList[l];
						XAttrData xattrData = base._FetchAttrData();
						bool flag9 = list.Count > 0;
						if (flag9)
						{
							xattrData.Title = string.Format("{0}{1}", list[0].SuitName, XStringDefineProxy.GetString("ArtifactSuitTittle"));
						}
						else
						{
							xattrData.Title = XStringDefineProxy.GetString("ArtifactSuitTittle");
						}
						xattrData.Type = AttriDataType.Attri;
						for (int m = 0; m < list.Count; m++)
						{
							xattrData.Left.Add(list[m].LeftStr);
							xattrData.Right.Add(list[m].RightStr);
						}
					}
				}
			}
		}

		private void SetShowData(XBodyBag artifacts)
		{
			int num = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_START);
			int num2 = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_END);
			bool flag = this.m_attrDataList == null;
			if (flag)
			{
				this.m_attrDataList = new List<ArtifactTotalAttrData>();
			}
			else
			{
				this.m_attrDataList.Clear();
			}
			bool flag2 = this.m_percentAttrDataList == null;
			if (flag2)
			{
				this.m_percentAttrDataList = new List<ArtifactTotalAttrData>();
			}
			else
			{
				this.m_percentAttrDataList.Clear();
			}
			for (int i = num; i < num2; i++)
			{
				bool flag3 = artifacts[i] == null || artifacts[i].itemID == 0 || (ulong)artifacts[i].type != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT));
				if (!flag3)
				{
					XArtifactItem xartifactItem = artifacts[i] as XArtifactItem;
					for (int j = 0; j < xartifactItem.RandAttrInfo.RandAttr.Count; j++)
					{
						bool flag4 = xartifactItem.RandAttrInfo.RandAttr[j].AttrID == 0U;
						if (!flag4)
						{
							uint attrID = xartifactItem.RandAttrInfo.RandAttr[j].AttrID;
							bool flag5 = XAttributeCommon.IsPercentRange((int)attrID);
							ArtifactTotalAttrData artifactTotalAttrData = this.FindTheSameAttri(attrID, flag5);
							bool flag6 = artifactTotalAttrData == null;
							if (flag6)
							{
								artifactTotalAttrData = new ArtifactTotalAttrData(xartifactItem.RandAttrInfo.RandAttr[j]);
								bool flag7 = flag5;
								if (flag7)
								{
									this.m_percentAttrDataList.Add(artifactTotalAttrData);
								}
								else
								{
									this.m_attrDataList.Add(artifactTotalAttrData);
								}
							}
							else
							{
								artifactTotalAttrData.Add(xartifactItem.RandAttrInfo.RandAttr[j].AttrValue);
							}
						}
					}
				}
			}
			bool flag8 = this.m_effectDataList == null;
			if (flag8)
			{
				this.m_effectDataList = new List<ArtifactTotalAttrData>();
			}
			else
			{
				this.m_effectDataList.Clear();
			}
			for (int k = num; k < num2; k++)
			{
				bool flag9 = artifacts[k] == null || artifacts[k].itemID == 0 || artifacts[k].Type != ItemType.ARTIFACT;
				if (!flag9)
				{
					XArtifactItem xartifactItem = artifacts[k] as XArtifactItem;
					bool flag10 = xartifactItem != null;
					if (flag10)
					{
						for (int l = 0; l < xartifactItem.EffectInfoList.Count; l++)
						{
							bool flag11 = !xartifactItem.EffectInfoList[l].IsValid;
							if (!flag11)
							{
								string artifactEffectDes = ArtifactDocument.GetArtifactEffectDes(xartifactItem.EffectInfoList[l].EffectId, xartifactItem.EffectInfoList[l].GetValues());
								ArtifactTotalAttrData item = new ArtifactTotalAttrData(artifactEffectDes, "");
								this.m_effectDataList.Add(item);
							}
						}
					}
				}
			}
			bool flag12 = this.m_suitDataList == null;
			if (flag12)
			{
				this.m_suitDataList = new List<List<ArtifactTotalAttrData>>();
			}
			else
			{
				this.m_suitDataList.Clear();
			}
			List<XArtifactAttrView<T>.SuitStatistics> list = new List<XArtifactAttrView<T>.SuitStatistics>();
			for (int m = num; m < num2; m++)
			{
				bool flag13 = artifacts[m] == null || artifacts[m].itemID == 0 || (ulong)artifacts[m].type != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT));
				if (!flag13)
				{
					XArtifactItem xartifactItem = artifacts[m] as XArtifactItem;
					ArtifactSuit suitByArtifactId = ArtifactDocument.SuitMgr.GetSuitByArtifactId((uint)xartifactItem.itemID);
					bool flag14 = suitByArtifactId == null;
					if (!flag14)
					{
						this.SetHadSuitList(ref list, suitByArtifactId);
					}
				}
			}
			for (int n = 0; n < list.Count; n++)
			{
				List<ArtifactTotalAttrData> list2 = new List<ArtifactTotalAttrData>();
				int num3 = list[n].Suit.effects.Length;
				for (int num4 = 0; num4 < num3; num4++)
				{
					bool flag15 = num4 > list[n].Count;
					if (flag15)
					{
						break;
					}
					SeqListRef<uint> seqListRef = list[n].Suit.effects[num4];
					bool flag16 = seqListRef.Count == 0;
					if (!flag16)
					{
						for (int num5 = 0; num5 < seqListRef.Count; num5++)
						{
							bool flag17 = seqListRef[num5, 0] == 0U;
							if (!flag17)
							{
								string leftStr = string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactSuitEffect"), num4);
								string rightStr = string.Format("{0}{1}", XStringDefineProxy.GetString((XAttributeDefine)seqListRef[num5, 0]), XAttributeCommon.GetAttrValueStr((int)seqListRef[num5, 0], (float)seqListRef[num5, 1]));
								list2.Add(new ArtifactTotalAttrData(leftStr, rightStr)
								{
									SuitName = list[n].Suit.Name
								});
							}
						}
					}
				}
				bool flag18 = list2.Count != 0;
				if (flag18)
				{
					this.m_suitDataList.Add(list2);
				}
			}
		}

		private void SetShowData(List<Item> lst)
		{
			bool flag = this.m_attrDataList == null;
			if (flag)
			{
				this.m_attrDataList = new List<ArtifactTotalAttrData>();
			}
			else
			{
				this.m_attrDataList.Clear();
			}
			bool flag2 = this.m_percentAttrDataList == null;
			if (flag2)
			{
				this.m_percentAttrDataList = new List<ArtifactTotalAttrData>();
			}
			else
			{
				this.m_percentAttrDataList.Clear();
			}
			bool flag3 = this.m_effectDataList == null;
			if (flag3)
			{
				this.m_effectDataList = new List<ArtifactTotalAttrData>();
			}
			else
			{
				this.m_effectDataList.Clear();
			}
			bool flag4 = this.m_suitDataList == null;
			if (flag4)
			{
				this.m_suitDataList = new List<List<ArtifactTotalAttrData>>();
			}
			else
			{
				this.m_suitDataList.Clear();
			}
			bool flag5 = lst == null;
			if (flag5)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("lst is null", null, null, null, null, null);
			}
			else
			{
				int num = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_START);
				int num2 = XBagDocument.BodyPosition<ArtifactPosition>(ArtifactPosition.ARTIFACT_END);
				bool flag6 = lst.Count < num2;
				if (flag6)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("gived data count  < 4,count = {0}", lst.Count), null, null, null, null, null);
				}
				else
				{
					XItemChangeAttr attr = default(XItemChangeAttr);
					for (int i = num; i < num2; i++)
					{
						bool flag7 = lst[i] == null || lst[i].ItemID == 0U || (ulong)lst[i].ItemType != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT));
						if (!flag7)
						{
							for (int j = 0; j < lst[i].AttrID.Count; j++)
							{
								uint num3 = lst[i].AttrID[j];
								bool flag8 = num3 == 0U;
								if (!flag8)
								{
									bool flag9 = XAttributeCommon.IsPercentRange((int)num3);
									ArtifactTotalAttrData artifactTotalAttrData = this.FindTheSameAttri(num3, flag9);
									bool flag10 = artifactTotalAttrData == null;
									if (flag10)
									{
										attr.AttrID = num3;
										attr.AttrValue = lst[i].AttrValue[j];
										artifactTotalAttrData = new ArtifactTotalAttrData(attr);
										bool flag11 = flag9;
										if (flag11)
										{
											this.m_percentAttrDataList.Add(artifactTotalAttrData);
										}
										else
										{
											this.m_attrDataList.Add(artifactTotalAttrData);
										}
									}
									else
									{
										artifactTotalAttrData.Add(lst[i].AttrValue[j]);
									}
								}
							}
						}
					}
					for (int k = num; k < num2; k++)
					{
						bool flag12 = lst[k] == null || lst[k].ItemID == 0U || (ulong)lst[k].ItemType != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT));
						if (!flag12)
						{
							XArtifactItem xartifactItem = XBagDocument.MakeXItem(lst[k]) as XArtifactItem;
							bool flag13 = xartifactItem != null;
							if (flag13)
							{
								for (int l = 0; l < xartifactItem.EffectInfoList.Count; l++)
								{
									bool flag14 = !xartifactItem.EffectInfoList[l].IsValid;
									if (!flag14)
									{
										string artifactEffectDes = ArtifactDocument.GetArtifactEffectDes(xartifactItem.EffectInfoList[l].EffectId, xartifactItem.EffectInfoList[l].GetValues());
										ArtifactTotalAttrData item = new ArtifactTotalAttrData(artifactEffectDes, "");
										this.m_effectDataList.Add(item);
									}
								}
							}
						}
					}
					List<XArtifactAttrView<T>.SuitStatistics> list = new List<XArtifactAttrView<T>.SuitStatistics>();
					for (int m = num; m < num2; m++)
					{
						bool flag15 = lst[m] == null || lst[m].ItemID == 0U || (ulong)lst[m].ItemType != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT));
						if (!flag15)
						{
							ArtifactSuit suitByArtifactId = ArtifactDocument.SuitMgr.GetSuitByArtifactId(lst[m].ItemID);
							bool flag16 = suitByArtifactId == null;
							if (!flag16)
							{
								this.SetHadSuitList(ref list, suitByArtifactId);
							}
						}
					}
					for (int n = 0; n < list.Count; n++)
					{
						List<ArtifactTotalAttrData> list2 = new List<ArtifactTotalAttrData>();
						int num4 = list[n].Suit.effects.Length;
						for (int num5 = 0; num5 < num4; num5++)
						{
							bool flag17 = num5 > list[n].Count;
							if (flag17)
							{
								break;
							}
							SeqListRef<uint> seqListRef = list[n].Suit.effects[num5];
							bool flag18 = seqListRef.Count == 0;
							if (!flag18)
							{
								for (int num6 = 0; num6 < seqListRef.Count; num6++)
								{
									bool flag19 = seqListRef[num6, 0] == 0U;
									if (!flag19)
									{
										string leftStr = string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactSuitEffect"), num5);
										string rightStr = string.Format("{0}{1}", XStringDefineProxy.GetString((XAttributeDefine)seqListRef[num6, 0]), XAttributeCommon.GetAttrValueStr((int)seqListRef[num6, 0], (float)seqListRef[num6, 1]));
										list2.Add(new ArtifactTotalAttrData(leftStr, rightStr)
										{
											SuitName = list[n].Suit.Name
										});
									}
								}
							}
						}
						bool flag20 = list2.Count != 0;
						if (flag20)
						{
							this.m_suitDataList.Add(list2);
						}
					}
				}
			}
		}

		private ArtifactTotalAttrData FindTheSameAttri(uint nameId, bool isPrecent)
		{
			if (isPrecent)
			{
				for (int i = 0; i < this.m_percentAttrDataList.Count; i++)
				{
					bool flag = this.m_percentAttrDataList[i].NameId == nameId;
					if (flag)
					{
						return this.m_percentAttrDataList[i];
					}
				}
			}
			else
			{
				for (int j = 0; j < this.m_attrDataList.Count; j++)
				{
					bool flag2 = this.m_attrDataList[j].NameId == nameId;
					if (flag2)
					{
						return this.m_attrDataList[j];
					}
				}
			}
			return null;
		}

		private void SetHadSuitList(ref List<XArtifactAttrView<T>.SuitStatistics> suits, ArtifactSuit suit)
		{
			bool flag = false;
			for (int i = 0; i < suits.Count; i++)
			{
				bool flag2 = suit.Id == suits[i].Suit.Id;
				if (flag2)
				{
					flag = true;
					suits[i].Count++;
					break;
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				XArtifactAttrView<T>.SuitStatistics suitStatistics = new XArtifactAttrView<T>.SuitStatistics();
				suitStatistics.Suit = suit;
				suitStatistics.Count++;
				suits.Add(suitStatistics);
			}
		}

		private List<ArtifactTotalAttrData> m_attrDataList;

		private List<ArtifactTotalAttrData> m_percentAttrDataList;

		private List<ArtifactTotalAttrData> m_effectDataList;

		private List<List<ArtifactTotalAttrData>> m_suitDataList;

		private class SuitStatistics
		{

			public ArtifactSuit Suit;

			public int Count = 0;
		}
	}
}
