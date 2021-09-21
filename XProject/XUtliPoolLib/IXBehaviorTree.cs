using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000077 RID: 119
	public interface IXBehaviorTree : IXInterface
	{
		// Token: 0x0600040F RID: 1039
		void OnStartSkill(uint skillid);

		// Token: 0x06000410 RID: 1040
		void OnEndSkill(uint skillid);

		// Token: 0x06000411 RID: 1041
		void OnSkillHurt();

		// Token: 0x06000412 RID: 1042
		void EnableBehaviorTree(bool enable);

		// Token: 0x06000413 RID: 1043
		void SetManual(bool enable);

		// Token: 0x06000414 RID: 1044
		float OnGetHeartRate();

		// Token: 0x06000415 RID: 1045
		void TickBehaviorTree();

		// Token: 0x06000416 RID: 1046
		bool SetBehaviorTree(string location);

		// Token: 0x06000417 RID: 1047
		void SetNavPoint(Transform navpoint);

		// Token: 0x06000418 RID: 1048
		void SetVariable(string name, object value);

		// Token: 0x06000419 RID: 1049
		void SetIntByName(string name, int value);

		// Token: 0x0600041A RID: 1050
		void SetFloatByName(string name, float value);

		// Token: 0x0600041B RID: 1051
		void SetBoolByName(string name, bool value);

		// Token: 0x0600041C RID: 1052
		void SetVector3ByName(string name, Vector3 value);

		// Token: 0x0600041D RID: 1053
		void SetTransformByName(string name, Transform value);

		// Token: 0x0600041E RID: 1054
		void SetXGameObjectByName(string name, XGameObject value);
	}
}
