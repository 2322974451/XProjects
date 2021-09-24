using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct XGoldGroupData
	{

		public bool bActive
		{
			get
			{
				return this.index >= 0;
			}
			set
			{
				bool flag = !value;
				if (flag)
				{
					this.index = -1;
					this.type = GoldGroupType.GGT_NONE;
				}
			}
		}

		public static string GetName(ref SeqListRef<uint> data, int index)
		{
			bool flag = index < 0 || index >= data.Count;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				int num = (int)data[index, 0];
				int num2 = (int)data[index, 1];
				GoldGroupType goldGroupType = (GoldGroupType)num;
				if (goldGroupType != GoldGroupType.GGT_DIAMOND)
				{
					if (goldGroupType != GoldGroupType.GGT_TICKET)
					{
						result = string.Empty;
					}
					else
					{
						result = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("TeamGoldGroupName2_", num2.ToString()));
					}
				}
				else
				{
					result = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("TeamGoldGroupName1_", num2.ToString()), new object[]
					{
						data[index, 2].ToString()
					});
				}
			}
			return result;
		}

		public void SetData(TeamExtraInfo extraInfo, ExpeditionTable.RowData rowData)
		{
			bool flag = extraInfo == null || rowData == null || !extraInfo.costindexSpecified;
			if (flag)
			{
				this.bActive = false;
			}
			else
			{
				int costindex = (int)extraInfo.costindex;
				bool flag2 = costindex < 0 || costindex >= rowData.CostType.Count;
				if (flag2)
				{
					this.bActive = false;
				}
				else
				{
					this.index = costindex;
					this.type = (GoldGroupType)rowData.CostType[this.index, 0];
					this.itemid = (int)rowData.CostType[this.index, 1];
					this.itemcount = (int)rowData.CostType[this.index, 2];
				}
			}
		}

		public void SetUI(GameObject go, bool bShowFinalRewardIcon = true)
		{
			bool flag = !this.bActive;
			if (flag)
			{
				go.SetActive(false);
			}
			else
			{
				go.SetActive(true);
				IXUILabel ixuilabel = go.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = go.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = bShowFinalRewardIcon && this.type == GoldGroupType.GGT_TICKET;
				if (flag2)
				{
					ixuisprite.SetSprite(XBagDocument.GetItemSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN), 0U));
				}
				else
				{
					ixuisprite.SetSprite(XBagDocument.GetItemSmallIcon(this.itemid, 0U));
				}
				bool flag3 = this.type == GoldGroupType.GGT_TICKET;
				if (flag3)
				{
					ixuilabel.SetText(XStringDefineProxy.GetString("GGT_TICKET"));
				}
				else
				{
					ixuilabel.SetText(this.itemcount.ToString());
				}
				Transform transform = go.transform.Find("Description");
				bool flag4 = transform != null;
				if (flag4)
				{
					IXUILabel ixuilabel2 = transform.GetComponent("XUILabel") as IXUILabel;
					GoldGroupType goldGroupType = this.type;
					if (goldGroupType != GoldGroupType.GGT_DIAMOND)
					{
						if (goldGroupType != GoldGroupType.GGT_TICKET)
						{
							ixuilabel2.SetText(string.Empty);
						}
						else
						{
							ixuilabel2.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("TeamGoldGroupDescription2_", this.itemid.ToString())));
						}
					}
					else
					{
						ixuilabel2.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("TeamGoldGroupDescription1_", this.itemid.ToString()), new object[]
						{
							(this.teamBrief == null || this.teamBrief.totalMemberCount <= 1) ? this.itemcount : (this.itemcount / (this.teamBrief.totalMemberCount - 1))
						}));
					}
				}
			}
		}

		public GoldGroupType type;

		public int index;

		public int itemid;

		public int itemcount;

		public XTeamBriefData teamBrief;
	}
}
