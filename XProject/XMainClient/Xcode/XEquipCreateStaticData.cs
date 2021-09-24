using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XEquipCreateStaticData : XStaticDataBase<XEquipCreateStaticData>
	{

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

		public override void Uninit()
		{
			this.EquipPosOrderArray = null;
			base.Uninit();
		}

		public int[] EquipPosOrderArray;

		public int TimerPerSecondCount = 0;

		public float TimerTotalSecond = 0f;

		public EquipSuitItemData[][] ItemPosGroupList;

		public int[][] RedPointPosGroupList;

		public int[] RedPointCheckLevelList;
	}
}
