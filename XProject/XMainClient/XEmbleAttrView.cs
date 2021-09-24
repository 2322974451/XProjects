using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEmbleAttrView<T> : XAttrCommonHandler<T> where T : XAttrCommonFile, new()
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
			bool flag = this.m_ShowAttriDataLst == null;
			if (!flag)
			{
				List<ShowAttriData> list = new List<ShowAttriData>();
				List<ShowAttriData> list2 = new List<ShowAttriData>();
				List<ShowAttriData> list3 = new List<ShowAttriData>();
				this.GetData(ref list, ref list2, ref list3);
				XAttrData xattrData = base._FetchAttrData();
				xattrData.Type = AttriDataType.Attri;
				xattrData.Title = XStringDefineProxy.GetString("EmblemAttriTittle");
				bool flag2 = list.Count == 0 && list2.Count == 0;
				if (flag2)
				{
					xattrData.StrEmpty = XStringDefineProxy.GetString("EmblemAttriDes");
				}
				else
				{
					for (int i = 0; i < list.Count; i++)
					{
						xattrData.Left.Add(list[i].Name);
						xattrData.Right.Add(list[i].NumStr);
					}
					for (int j = 0; j < list2.Count; j++)
					{
						xattrData.Left.Add(list2[j].Name);
						xattrData.Right.Add(list2[j].NumStr);
					}
				}
				xattrData = base._FetchAttrData();
				xattrData.Title = XStringDefineProxy.GetString("EmblemSkillTittle");
				xattrData.Type = AttriDataType.Skill;
				bool flag3 = list3.Count == 0;
				if (flag3)
				{
					xattrData.StrEmpty = XStringDefineProxy.GetString("EmblemSkillDes");
				}
				else
				{
					for (int k = 0; k < list3.Count; k++)
					{
						xattrData.Left.Add(list3[k].NeedLevelStr);
						xattrData.Right.Add(list3[k].SkillDes);
					}
				}
			}
		}

		private void GetData(ref List<ShowAttriData> lst1, ref List<ShowAttriData> lst2, ref List<ShowAttriData> lst3)
		{
			for (int i = 0; i < this.m_ShowAttriDataLst.Count; i++)
			{
				bool flag = this.m_ShowAttriDataLst[i].TypeID == 1U;
				if (flag)
				{
					lst1.Add(this.m_ShowAttriDataLst[i]);
				}
				else
				{
					bool flag2 = this.m_ShowAttriDataLst[i].TypeID == 2U;
					if (flag2)
					{
						lst2.Add(this.m_ShowAttriDataLst[i]);
					}
					else
					{
						bool flag3 = this.m_ShowAttriDataLst[i].TypeID == 3U;
						if (flag3)
						{
							lst3.Add(this.m_ShowAttriDataLst[i]);
						}
					}
				}
			}
		}

		private void SetShowData(XBodyBag equipments)
		{
			this.m_ShowAttriDataLst = new List<ShowAttriData>();
			int num = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_START);
			int num2 = XBagDocument.BodyPosition<EmblemPosition>(EmblemPosition.EMBLEM_END);
			for (int i = num; i < num2; i++)
			{
				bool flag = equipments[i] == null || equipments[i].itemID == 0 || (ulong)equipments[i].type != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM));
				if (!flag)
				{
					XEmblemItem xemblemItem = equipments[i] as XEmblemItem;
					EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(xemblemItem.itemID);
					bool flag2 = emblemConf != null;
					if (flag2)
					{
						bool flag3 = emblemConf.EmblemType > 1000;
						if (flag3)
						{
							ShowAttriData showAttriData = new ShowAttriData(emblemConf);
							this.m_ShowAttriDataLst.Add(showAttriData);
						}
						else
						{
							XAttrItem xattrItem = equipments[i] as XAttrItem;
							for (int j = 0; j < xattrItem.changeAttr.Count; j++)
							{
								ShowAttriData showAttriData = this.FindTheSameAttri(xattrItem.changeAttr[j].AttrID);
								bool flag4 = showAttriData == null;
								if (flag4)
								{
									showAttriData = new ShowAttriData((uint)equipments[i].itemID, xattrItem.changeAttr[j]);
									this.m_ShowAttriDataLst.Add(showAttriData);
								}
								else
								{
									showAttriData.Add(xattrItem.changeAttr[j].AttrValue);
								}
							}
						}
					}
				}
			}
		}

		private void SetShowData(List<Item> lst)
		{
			bool flag = lst == null;
			if (!flag)
			{
				this.m_ShowAttriDataLst = new List<ShowAttriData>();
				XItemChangeAttr xitemChangeAttr = default(XItemChangeAttr);
				for (int i = 0; i < lst.Count; i++)
				{
					bool flag2 = lst[i] == null || lst[i].ItemID == 0U || (ulong)lst[i].ItemType != (ulong)((long)XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM));
					if (!flag2)
					{
						EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf((int)lst[i].ItemID);
						bool flag3 = emblemConf != null;
						if (flag3)
						{
							bool flag4 = emblemConf.EmblemType > 1000;
							if (flag4)
							{
								ShowAttriData showAttriData = new ShowAttriData(emblemConf);
								this.m_ShowAttriDataLst.Add(showAttriData);
							}
							else
							{
								for (int j = 0; j < lst[i].AttrID.Count; j++)
								{
									xitemChangeAttr.AttrID = lst[i].AttrID[j];
									xitemChangeAttr.AttrValue = lst[i].AttrValue[j];
									ShowAttriData showAttriData = this.FindTheSameAttri(lst[i].AttrID[j]);
									bool flag5 = showAttriData == null;
									if (flag5)
									{
										showAttriData = new ShowAttriData(lst[i].ItemID, xitemChangeAttr);
										this.m_ShowAttriDataLst.Add(showAttriData);
									}
									else
									{
										showAttriData.Add(xitemChangeAttr.AttrValue);
									}
								}
							}
						}
					}
				}
			}
		}

		private ShowAttriData FindTheSameAttri(uint nameId)
		{
			for (int i = 0; i < this.m_ShowAttriDataLst.Count; i++)
			{
				bool flag = this.m_ShowAttriDataLst[i].NameId == nameId;
				if (flag)
				{
					return this.m_ShowAttriDataLst[i];
				}
			}
			return null;
		}

		private List<ShowAttriData> m_ShowAttriDataLst;
	}
}
