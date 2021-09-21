using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000075 RID: 117
	public interface IXAIGeneralMgr : IXInterface
	{
		// Token: 0x060003C6 RID: 966
		bool IsHPValue(ulong id, int min, int max);

		// Token: 0x060003C7 RID: 967
		bool IsHPValue(Transform transform, int min, int max);

		// Token: 0x060003C8 RID: 968
		bool IsMPValue(ulong id, int min, int max);

		// Token: 0x060003C9 RID: 969
		bool IsMPValue(Transform transform, int min, int max);

		// Token: 0x060003CA RID: 970
		bool IsValid(ulong id);

		// Token: 0x060003CB RID: 971
		bool IsValid(Transform transform);

		// Token: 0x060003CC RID: 972
		bool HasQTE(ulong id, int QTEState);

		// Token: 0x060003CD RID: 973
		bool HasQTE(GameObject go, int QTEState);

		// Token: 0x060003CE RID: 974
		bool IsAtState(GameObject go, int state);

		// Token: 0x060003CF RID: 975
		bool IsAtState(ulong id, int state);

		// Token: 0x060003D0 RID: 976
		bool IsRotate(GameObject go);

		// Token: 0x060003D1 RID: 977
		bool IsCastSkill(GameObject go);

		// Token: 0x060003D2 RID: 978
		bool IsFighting(ulong id);

		// Token: 0x060003D3 RID: 979
		bool IsFighting(Transform transform);

		// Token: 0x060003D4 RID: 980
		bool IsWoozy(GameObject go);

		// Token: 0x060003D5 RID: 981
		bool IsOppoCastingSkill(ulong id);

		// Token: 0x060003D6 RID: 982
		bool IsOppoCastingSkill(Transform transform);

		// Token: 0x060003D7 RID: 983
		bool IsHurtOppo(ulong id);

		// Token: 0x060003D8 RID: 984
		bool IsHurtOppo(Transform transform);

		// Token: 0x060003D9 RID: 985
		bool IsFixedInCd(ulong id);

		// Token: 0x060003DA RID: 986
		bool IsFixedInCd(Transform transform);

		// Token: 0x060003DB RID: 987
		bool IsWander(ulong id);

		// Token: 0x060003DC RID: 988
		bool IsWander(Transform transform);

		// Token: 0x060003DD RID: 989
		bool IsSkillChoosed(ulong id);

		// Token: 0x060003DE RID: 990
		bool IsSkillChoosed(Transform transform);

		// Token: 0x060003DF RID: 991
		bool DetectEnimyInSight(GameObject go);

		// Token: 0x060003E0 RID: 992
		bool CastQTESkill(GameObject go);

		// Token: 0x060003E1 RID: 993
		bool CastDashSkill(GameObject go);

		// Token: 0x060003E2 RID: 994
		bool ResetTargets(GameObject go);

		// Token: 0x060003E3 RID: 995
		bool FindTargetByDistance(GameObject go, float distance, bool filterImmortal, float angle, float delta, int targettype);

		// Token: 0x060003E4 RID: 996
		bool FindTargetByHitLevel(GameObject go, bool filterImmortal);

		// Token: 0x060003E5 RID: 997
		bool FindTargetByHartedList(GameObject go, bool filterImmortal);

		// Token: 0x060003E6 RID: 998
		bool FindTargetByNonImmortal(GameObject go);

		// Token: 0x060003E7 RID: 999
		bool DoSelectNearest(GameObject go);

		// Token: 0x060003E8 RID: 1000
		bool DoSelectFarthest(GameObject go);

		// Token: 0x060003E9 RID: 1001
		bool DoSelectRandomTarget(GameObject go);

		// Token: 0x060003EA RID: 1002
		void ClearTarget(ulong id);

		// Token: 0x060003EB RID: 1003
		void ClearTarget(Transform transform);

		// Token: 0x060003EC RID: 1004
		bool TryCastInstallSkill(GameObject go, GameObject targetgo);

		// Token: 0x060003ED RID: 1005
		bool TryCastLearnedSkill(GameObject go, GameObject targetgo);

		// Token: 0x060003EE RID: 1006
		bool TryCastPhysicalSkill(GameObject go, GameObject targetgo);

		// Token: 0x060003EF RID: 1007
		bool NavToTarget(ulong id, GameObject target);

		// Token: 0x060003F0 RID: 1008
		bool NavToTarget(GameObject go, GameObject target);

		// Token: 0x060003F1 RID: 1009
		bool FindNavPath(GameObject go);

		// Token: 0x060003F2 RID: 1010
		bool ActionMove(GameObject go, Vector3 dir, Vector3 dest, float speed);

		// Token: 0x060003F3 RID: 1011
		bool ActionNav(ulong id, Vector3 dest);

		// Token: 0x060003F4 RID: 1012
		bool ActionNav(GameObject go, Vector3 dest);

		// Token: 0x060003F5 RID: 1013
		bool ActionRotate(GameObject go, float degree, float speed, int type);

		// Token: 0x060003F6 RID: 1014
		bool RotateToTarget(GameObject go);

		// Token: 0x060003F7 RID: 1015
		bool SelectSkill(GameObject go, FilterSkillArg skillarg);

		// Token: 0x060003F8 RID: 1016
		bool DoSelectInOrder(GameObject go);

		// Token: 0x060003F9 RID: 1017
		bool DoSelectRandom(GameObject go);

		// Token: 0x060003FA RID: 1018
		bool DoCastSkill(GameObject go, GameObject targetgo);

		// Token: 0x060003FB RID: 1019
		bool SendAIEvent(GameObject go, int msgto, int msgtype, int entitytypeid, string msgarg, float delaytime, Vector3 pos);

		// Token: 0x060003FC RID: 1020
		string ReceiveAIEvent(GameObject go, int msgType, bool Deprecate);

		// Token: 0x060003FD RID: 1021
		bool IsTargetImmortal(ulong id);

		// Token: 0x060003FE RID: 1022
		Transform SelectMoveTargetById(GameObject go, int objectid);

		// Token: 0x060003FF RID: 1023
		Transform SelectBuffTarget(GameObject go);

		// Token: 0x06000400 RID: 1024
		Transform SelectItemTarget(GameObject go);

		// Token: 0x06000401 RID: 1025
		bool SelectTargetBySkillCircle(GameObject go);

		// Token: 0x06000402 RID: 1026
		bool ResetHartedList(GameObject go);

		// Token: 0x06000403 RID: 1027
		bool CallMonster(GameObject go, CallMonsterData data);

		// Token: 0x06000404 RID: 1028
		bool CallScript(GameObject go, string script, float delaytime);

		// Token: 0x06000405 RID: 1029
		bool AddBuff(int monsterid, int buffid, int buffid2);

		// Token: 0x06000406 RID: 1030
		void RunSubTree(GameObject go, string treename);

		// Token: 0x06000407 RID: 1031
		bool PlayFx(GameObject go, string fxname, Vector3 fxpos, float delaytime);

		// Token: 0x06000408 RID: 1032
		bool StopCastingSkill(GameObject go);

		// Token: 0x06000409 RID: 1033
		bool DetectEnemyInRange(GameObject go, ref DetectEnemyInRangeArg arg);

		// Token: 0x0600040A RID: 1034
		bool UpdateNavigation(GameObject go, int dir, int oldDir);

		// Token: 0x0600040B RID: 1035
		int GetPlayerProf();

		// Token: 0x0600040C RID: 1036
		bool IsPointInMap(Vector3 pos);

		// Token: 0x0600040D RID: 1037
		bool AIDoodad(GameObject go, int doodadid, int waveid, Vector3 pos, float randompos, float delaytime);
	}
}
