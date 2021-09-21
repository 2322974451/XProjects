using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A97 RID: 2711
	internal class XEquipSuitManager
	{
		// Token: 0x0600A4EF RID: 42223 RVA: 0x001CA673 File Offset: 0x001C8873
		public XEquipSuitManager(EquipSuitTable.RowData[] datas)
		{
			this.equipSuitTable = datas;
		}

		// Token: 0x0600A4F0 RID: 42224 RVA: 0x001CA68C File Offset: 0x001C888C
		public EquipSuitTable.RowData GetSuit(int equipid, bool bConsiderOtherProf = false)
		{
			int basicTypeID = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID;
			for (int i = 0; i < this.equipSuitTable.Length; i++)
			{
				EquipSuitTable.RowData rowData = this.equipSuitTable[i];
				bool flag = rowData.ProfID != 0 && basicTypeID != rowData.ProfID;
				if (!flag)
				{
					bool flag2 = rowData.EquipID != null;
					if (flag2)
					{
						for (int j = 0; j < rowData.EquipID.Length; j++)
						{
							bool flag3 = rowData.EquipID[j] == equipid;
							if (flag3)
							{
								return rowData;
							}
						}
					}
				}
			}
			if (bConsiderOtherProf)
			{
				for (int k = 0; k < this.equipSuitTable.Length; k++)
				{
					EquipSuitTable.RowData rowData2 = this.equipSuitTable[k];
					bool flag4 = rowData2.EquipID != null;
					if (flag4)
					{
						for (int l = 0; l < rowData2.EquipID.Length; l++)
						{
							bool flag5 = rowData2.EquipID[l] == equipid;
							if (flag5)
							{
								return rowData2;
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600A4F1 RID: 42225 RVA: 0x001CA7C0 File Offset: 0x001C89C0
		public EquipSuitTable.RowData GetSuitBySuitId(int suitId)
		{
			for (int i = 0; i < this.equipSuitTable.Length; i++)
			{
				bool flag = this.equipSuitTable[i].SuitID == suitId;
				if (flag)
				{
					return this.equipSuitTable[i];
				}
			}
			return null;
		}

		// Token: 0x0600A4F2 RID: 42226 RVA: 0x001CA80C File Offset: 0x001C8A0C
		public bool WillChangeEquipedCount(int suitItemID, int newItemID)
		{
			EquipSuitTable.RowData suit = this.GetSuit(suitItemID, false);
			bool flag = suit != null;
			return flag && !XEquipSuitManager.ContainEquip(suit, newItemID);
		}

		// Token: 0x0600A4F3 RID: 42227 RVA: 0x001CA840 File Offset: 0x001C8A40
		public static bool ContainEquip(EquipSuitTable.RowData row, int itemID)
		{
			bool flag = row.EquipID != null;
			if (flag)
			{
				for (int i = 0; i < row.EquipID.Length; i++)
				{
					bool flag2 = row.EquipID[i] == itemID;
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600A4F4 RID: 42228 RVA: 0x001CA890 File Offset: 0x001C8A90
		public static int GetEffectDataCount()
		{
			return 11;
		}

		// Token: 0x0600A4F5 RID: 42229 RVA: 0x001CA8A4 File Offset: 0x001C8AA4
		public static int GetEffectData(EquipSuitTable.RowData row, int index, out int effect1)
		{
			int result;
			switch (index)
			{
			case 1:
				effect1 = (int)row.Effect1[1];
				result = (int)row.Effect1[0];
				break;
			case 2:
				effect1 = (int)row.Effect2[1];
				result = (int)row.Effect2[0];
				break;
			case 3:
				effect1 = (int)row.Effect3[1];
				result = (int)row.Effect3[0];
				break;
			case 4:
				effect1 = (int)row.Effect4[1];
				result = (int)row.Effect4[0];
				break;
			case 5:
				effect1 = (int)row.Effect5[1];
				result = (int)row.Effect5[0];
				break;
			case 6:
				effect1 = (int)row.Effect6[1];
				result = (int)row.Effect6[0];
				break;
			case 7:
				effect1 = (int)row.Effect7[1];
				result = (int)row.Effect7[0];
				break;
			case 8:
				effect1 = (int)row.Effect8[1];
				result = (int)row.Effect8[0];
				break;
			case 9:
				effect1 = (int)row.Effect9[1];
				result = (int)row.Effect9[0];
				break;
			case 10:
				effect1 = (int)row.Effect10[1];
				result = (int)row.Effect10[0];
				break;
			default:
				effect1 = 0;
				result = 0;
				break;
			}
			return result;
		}

		// Token: 0x0600A4F6 RID: 42230 RVA: 0x001CAA3C File Offset: 0x001C8C3C
		public static bool IsEffectJustActivated(EquipSuitTable.RowData row, int equipCount)
		{
			int num = 0;
			return XEquipSuitManager.GetEffectData(row, equipCount, out num) != 0;
		}

		// Token: 0x0600A4F7 RID: 42231 RVA: 0x001CAA5C File Offset: 0x001C8C5C
		public static int GetEquipedSuits(EquipSuitTable.RowData row, XBodyBag equipsOnBody, List<int> pos)
		{
			int num = 0;
			bool flag = equipsOnBody.Length != XBagDocument.EquipMax;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				for (int i = 0; i < XBagDocument.EquipMax; i++)
				{
					XItem xitem = equipsOnBody[i];
					bool flag2 = xitem == null;
					if (!flag2)
					{
						bool flag3 = XEquipSuitManager.ContainEquip(row, xitem.itemID);
						if (flag3)
						{
							bool flag4 = pos != null;
							if (flag4)
							{
								pos.Add(i);
							}
							num++;
						}
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x0600A4F8 RID: 42232 RVA: 0x001CAAE4 File Offset: 0x001C8CE4
		public static bool WillChangeEquipedCount(EquipSuitTable.RowData row, int itemid, XBodyBag equipsOnBody)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemid);
			bool flag = equipConf == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XItem xitem = equipsOnBody[(int)equipConf.EquipPos];
				bool flag2 = xitem == null;
				result = (flag2 || (XEquipSuitManager.ContainEquip(row, itemid) ^ XEquipSuitManager.ContainEquip(row, xitem.itemID)));
			}
			return result;
		}

		// Token: 0x04003C1D RID: 15389
		private EquipSuitTable.RowData[] equipSuitTable = null;
	}
}
