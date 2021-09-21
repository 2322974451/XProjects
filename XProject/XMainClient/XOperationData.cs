using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EA6 RID: 3750
	internal class XOperationData : XSingleton<XOperationData>
	{
		// Token: 0x0600C7D4 RID: 51156 RVA: 0x002CB220 File Offset: 0x002C9420
		public static bool Is3DMode()
		{
			return XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X3D || XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X3D_Free;
		}

		// Token: 0x0400580D RID: 22541
		public XOperationMode OperationMode = XOperationMode.X3D;

		// Token: 0x0400580E RID: 22542
		public int TailCameraSpeed = 60;

		// Token: 0x0400580F RID: 22543
		public float ManualCameraSpeedXInBattle = 0.6f;

		// Token: 0x04005810 RID: 22544
		public float ManualCameraSpeedYInBattle = 0.15f;

		// Token: 0x04005811 RID: 22545
		public float ManualCameraDampXInBattle = 10f;

		// Token: 0x04005812 RID: 22546
		public float ManualCameraDampYInBattle = 10f;

		// Token: 0x04005813 RID: 22547
		public float ManualCameraSpeedXInHall = 0.3f;

		// Token: 0x04005814 RID: 22548
		public float ManualCameraSpeedYInHall = 0.3f;

		// Token: 0x04005815 RID: 22549
		public float ManualCameraDampXInHall = 2f;

		// Token: 0x04005816 RID: 22550
		public float ManualCameraDampYInHall = 2f;

		// Token: 0x04005817 RID: 22551
		public float CameraAngle = 2f;

		// Token: 0x04005818 RID: 22552
		public float CameraDistance = 6f;

		// Token: 0x04005819 RID: 22553
		public bool AllowVertical = false;

		// Token: 0x0400581A RID: 22554
		public bool AllowHorizontal = false;

		// Token: 0x0400581B RID: 22555
		public float MaxVertical = 30f;

		// Token: 0x0400581C RID: 22556
		public float MinVertical = -10f;

		// Token: 0x0400581D RID: 22557
		public int RangeWeight = 10;

		// Token: 0x0400581E RID: 22558
		public int BossWeight = 10;

		// Token: 0x0400581F RID: 22559
		public int EliteWeight = 2;

		// Token: 0x04005820 RID: 22560
		public int EnemyWeight = 1;

		// Token: 0x04005821 RID: 22561
		public int PupetWeight = 0;

		// Token: 0x04005822 RID: 22562
		public int ImmortalWeight = -10;

		// Token: 0x04005823 RID: 22563
		public int RoleWeight = 10;

		// Token: 0x04005824 RID: 22564
		public float AssistAngle = 60f;

		// Token: 0x04005825 RID: 22565
		public float WithinScope = 90f;

		// Token: 0x04005826 RID: 22566
		public float WithinRange = 1f;

		// Token: 0x04005827 RID: 22567
		public float ProfRange = 1.5f;

		// Token: 0x04005828 RID: 22568
		public float ProfRangeLong = 8f;

		// Token: 0x04005829 RID: 22569
		public float ProfRangeAll = 5f;

		// Token: 0x0400582A RID: 22570
		public int ProfScope = 60;

		// Token: 0x0400582B RID: 22571
		public int CameraAdjustScope = 0;

		// Token: 0x0400582C RID: 22572
		public bool OffSolo = false;
	}
}
