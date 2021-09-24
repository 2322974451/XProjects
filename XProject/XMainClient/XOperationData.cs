using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOperationData : XSingleton<XOperationData>
	{

		public static bool Is3DMode()
		{
			return XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X3D || XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X3D_Free;
		}

		public XOperationMode OperationMode = XOperationMode.X3D;

		public int TailCameraSpeed = 60;

		public float ManualCameraSpeedXInBattle = 0.6f;

		public float ManualCameraSpeedYInBattle = 0.15f;

		public float ManualCameraDampXInBattle = 10f;

		public float ManualCameraDampYInBattle = 10f;

		public float ManualCameraSpeedXInHall = 0.3f;

		public float ManualCameraSpeedYInHall = 0.3f;

		public float ManualCameraDampXInHall = 2f;

		public float ManualCameraDampYInHall = 2f;

		public float CameraAngle = 2f;

		public float CameraDistance = 6f;

		public bool AllowVertical = false;

		public bool AllowHorizontal = false;

		public float MaxVertical = 30f;

		public float MinVertical = -10f;

		public int RangeWeight = 10;

		public int BossWeight = 10;

		public int EliteWeight = 2;

		public int EnemyWeight = 1;

		public int PupetWeight = 0;

		public int ImmortalWeight = -10;

		public int RoleWeight = 10;

		public float AssistAngle = 60f;

		public float WithinScope = 90f;

		public float WithinRange = 1f;

		public float ProfRange = 1.5f;

		public float ProfRangeLong = 8f;

		public float ProfRangeAll = 5f;

		public int ProfScope = 60;

		public int CameraAdjustScope = 0;

		public bool OffSolo = false;
	}
}
