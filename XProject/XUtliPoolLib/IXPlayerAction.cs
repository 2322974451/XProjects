using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020000A4 RID: 164
	public interface IXPlayerAction : IXInterface
	{
		// Token: 0x060004FC RID: 1276
		void CameraWallEnter(AnimationCurve curve, Vector3 intersection, Vector3 cornerdir, float sector, float inDegree, float outDegree, bool positive);

		// Token: 0x060004FD RID: 1277
		void CameraWallExit(float angle);

		// Token: 0x060004FE RID: 1278
		void CameraWallVertical(float angle);

		// Token: 0x060004FF RID: 1279
		void SetExternalString(string exString, bool bOnce);

		// Token: 0x06000500 RID: 1280
		void TransferToSceneLocation(Vector3 pos, Vector3 forward);

		// Token: 0x06000501 RID: 1281
		void TransferToNewScene(uint sceneID);

		// Token: 0x06000502 RID: 1282
		void PlayCutScene(string cutscene);

		// Token: 0x06000503 RID: 1283
		void GotoBattle();

		// Token: 0x06000504 RID: 1284
		void GotoTerritoryBattle(int index);

		// Token: 0x06000505 RID: 1285
		void GotoNest();

		// Token: 0x06000506 RID: 1286
		void GotoFishing(int seatIndex, bool bFishing);

		// Token: 0x06000507 RID: 1287
		void GotoYororuya();

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000508 RID: 1288
		bool IsValid { get; }

		// Token: 0x06000509 RID: 1289
		Vector3 PlayerPosition(bool notplayertrigger);

		// Token: 0x0600050A RID: 1290
		Vector3 PlayerLastPosition(bool notplayertrigger);

		// Token: 0x0600050B RID: 1291
		void RefreshPosition();
	}
}
