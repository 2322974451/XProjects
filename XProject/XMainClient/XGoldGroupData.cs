using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D33 RID: 3379
	internal struct XGoldGroupData
	{
		// Token: 0x170032F3 RID: 13043
		// (get) Token: 0x0600BB61 RID: 47969 RVA: 0x002679E0 File Offset: 0x00265BE0
		// (set) Token: 0x0600BB62 RID: 47970 RVA: 0x00267A00 File Offset: 0x00265C00
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

		// Token: 0x0600BB63 RID: 47971 RVA: 0x00267A28 File Offset: 0x00265C28
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

		// Token: 0x0600BB64 RID: 47972 RVA: 0x00267ADC File Offset: 0x00265CDC
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

		// Token: 0x0600BB65 RID: 47973 RVA: 0x00267B90 File Offset: 0x00265D90
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

		// Token: 0x04004BD9 RID: 19417
		public GoldGroupType type;

		// Token: 0x04004BDA RID: 19418
		public int index;

		// Token: 0x04004BDB RID: 19419
		public int itemid;

		// Token: 0x04004BDC RID: 19420
		public int itemcount;

		// Token: 0x04004BDD RID: 19421
		public XTeamBriefData teamBrief;
	}
}
