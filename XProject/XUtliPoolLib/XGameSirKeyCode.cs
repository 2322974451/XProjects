using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020001F4 RID: 500
	public class XGameSirKeyCode
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0003D93C File Offset: 0x0003BB3C
		public static List<string>[] SkillMap
		{
			get
			{
				bool flag = XGameSirKeyCode._skillMap == null;
				if (flag)
				{
					XGameSirKeyCode._skillMap = new List<string>[XGameSirKeyCode.SKILL_SIZE];
					XGameSirKeyCode._skillMap[0] = new List<string>
					{
						XGameSirKeyCode.BTN_L2
					};
					XGameSirKeyCode._skillMap[1] = new List<string>
					{
						XGameSirKeyCode.BTN_L1
					};
					XGameSirKeyCode._skillMap[2] = new List<string>
					{
						XGameSirKeyCode.BTN_A
					};
					XGameSirKeyCode._skillMap[3] = new List<string>
					{
						XGameSirKeyCode.BTN_B
					};
					XGameSirKeyCode._skillMap[4] = new List<string>
					{
						XGameSirKeyCode.BTN_X
					};
					XGameSirKeyCode._skillMap[5] = new List<string>
					{
						XGameSirKeyCode.BTN_Y
					};
					XGameSirKeyCode._skillMap[6] = new List<string>
					{
						XGameSirKeyCode.BTN_L2,
						XGameSirKeyCode.BTN_A
					};
					XGameSirKeyCode._skillMap[7] = new List<string>
					{
						XGameSirKeyCode.BTN_L2,
						XGameSirKeyCode.BTN_B
					};
					XGameSirKeyCode._skillMap[8] = new List<string>
					{
						XGameSirKeyCode.DPAD_LEFT
					};
					XGameSirKeyCode._skillMap[9] = new List<string>
					{
						XGameSirKeyCode.DPAD_RIGHT
					};
				}
				return XGameSirKeyCode._skillMap;
			}
		}

		// Token: 0x040005CB RID: 1483
		public static string BTN_A = "A";

		// Token: 0x040005CC RID: 1484
		public static string BTN_B = "B";

		// Token: 0x040005CD RID: 1485
		public static string BTN_X = "X";

		// Token: 0x040005CE RID: 1486
		public static string BTN_Y = "Y";

		// Token: 0x040005CF RID: 1487
		public static string BTN_L1 = "L1";

		// Token: 0x040005D0 RID: 1488
		public static string BTN_L2 = "L2";

		// Token: 0x040005D1 RID: 1489
		public static string BTN_R1 = "R1";

		// Token: 0x040005D2 RID: 1490
		public static string BTN_R2 = "R2";

		// Token: 0x040005D3 RID: 1491
		public static string AXIS_RTRIGGER = "TRIGGERL";

		// Token: 0x040005D4 RID: 1492
		public static string AXIS_LTRIGGER = "TRIGGERR";

		// Token: 0x040005D5 RID: 1493
		public static string DPAD_UP = "DPAD_UP";

		// Token: 0x040005D6 RID: 1494
		public static string DPAD_DOWN = "DPAD_DOWN";

		// Token: 0x040005D7 RID: 1495
		public static string DPAD_LEFT = "DPAD_LEFT";

		// Token: 0x040005D8 RID: 1496
		public static string DPAD_RIGHT = "DPAD_RIGHT";

		// Token: 0x040005D9 RID: 1497
		public static string AXIS_HAT_X = "HAT_X";

		// Token: 0x040005DA RID: 1498
		public static string AXIS_HAT_Y = "HAT_Y";

		// Token: 0x040005DB RID: 1499
		public static string AXIS_X = "L3D_X";

		// Token: 0x040005DC RID: 1500
		public static string AXIS_Y = "L3D_Y";

		// Token: 0x040005DD RID: 1501
		public static string BTN_THUMBL = "THUMB_L";

		// Token: 0x040005DE RID: 1502
		public static string AXIS_Z = "R3D_Z";

		// Token: 0x040005DF RID: 1503
		public static string AXIS_RZ = "R3D_RZ";

		// Token: 0x040005E0 RID: 1504
		public static string BTN_THUMBR = "THUMB_R";

		// Token: 0x040005E1 RID: 1505
		public static string BTN_SELECT = "SELECT";

		// Token: 0x040005E2 RID: 1506
		public static string BTN_START = "START";

		// Token: 0x040005E3 RID: 1507
		public static int SKILL_SIZE = 10;

		// Token: 0x040005E4 RID: 1508
		private static List<string>[] _skillMap;
	}
}
