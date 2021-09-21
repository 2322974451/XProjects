using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000988 RID: 2440
	public class XEquipCreateStaticData : XStaticDataBase<XEquipCreateStaticData>
	{
		// Token: 0x060092A8 RID: 37544 RVA: 0x00153908 File Offset: 0x00151B08
		protected override void OnInit()
		{
			this.TimerPerSecondCount = XSingleton<XGlobalConfig>.singleton.GetInt("EquipCreateTimerPerSecondCount");
			this.TimerTotalSecond = (float)XSingleton<XGlobalConfig>.singleton.GetInt("EquipCreateTimerTotalSecond") / 1000f;
			this.EquipPosOrderArray = new int[XFastEnumIntEqualityComparer<EquipPosition>.ToInt(EquipPosition.EQUIP_END)];
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("EquipCreatePosOrder").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				int.TryParse(array[i], out this.EquipPosOrderArray[i]);
			}
			string[] array2 = XSingleton<XGlobalConfig>.singleton.GetValue("EquipCreateRedPointPosGroupList").Split(XGlobalConfig.ListSeparator);
			this.RedPointPosGroupList = new int[array2.Length][];
			this.ItemPosGroupList = new EquipSuitItemData[array2.Length][];
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(XGlobalConfig.SequenceSeparator);
				this.RedPointPosGroupList[i] = new int[array3.Length];
				this.ItemPosGroupList[i] = new EquipSuitItemData[array3.Length];
				for (int j = 0; j < array3.Length; j++)
				{
					int.TryParse(array3[j], out this.RedPointPosGroupList[i][j]);
				}
			}
		}

		// Token: 0x060092A9 RID: 37545 RVA: 0x00153A4A File Offset: 0x00151C4A
		public override void Uninit()
		{
			this.EquipPosOrderArray = null;
			base.Uninit();
		}

		// Token: 0x04003129 RID: 12585
		public int[] EquipPosOrderArray;

		// Token: 0x0400312A RID: 12586
		public int TimerPerSecondCount = 0;

		// Token: 0x0400312B RID: 12587
		public float TimerTotalSecond = 0f;

		// Token: 0x0400312C RID: 12588
		public EquipSuitItemData[][] ItemPosGroupList;

		// Token: 0x0400312D RID: 12589
		public int[][] RedPointPosGroupList;

		// Token: 0x0400312E RID: 12590
		public int[] RedPointCheckLevelList;
	}
}
