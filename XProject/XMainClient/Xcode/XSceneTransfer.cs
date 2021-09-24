using System;
using System.Collections;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public sealed class XSceneTransfer : MonoBehaviour
	{

		public void TransferScene(uint sceneid)
		{
			this._loading_scene_id = sceneid;
			base.StartCoroutine(this.TransferLevelInMainCity());
		}

		private IEnumerator TransferLevelInMainCity()
		{
			XSingleton<XScene>.singleton.OnSceneBeginLoad(this._loading_scene_id);
			XSingleton<XScene>.singleton.OnSceneLoaded(this._loading_scene_id);
			XSingleton<XGameUI>.singleton.m_uiTool.EnableUILoadingUpdate(true);
			XSingleton<XScene>.singleton.RefreshScenMustTransform();
			this.CreatePlayer(this._loading_scene_id);
			while (XSingleton<XEntityMgr>.singleton.Player.Equipment != null && XSingleton<XEntityMgr>.singleton.Player.Equipment.IsLoadingPart())
			{
				yield return null;
			}
			this.DocPreload(this._loading_scene_id);
			yield return null;
			this.PreLoadSceneMonster(this._loading_scene_id);
			yield return null;
			this.PlaceSceneNpc(this._loading_scene_id);
			yield return null;
			this.ResetLevelAirWall();
			yield return null;
			XSingleton<XGame>.singleton.OnEnterScene(this._loading_scene_id, true);
			SceneType sceneType = XSingleton<XSceneMgr>.singleton.GetSceneType(this._loading_scene_id);
			AsyncSceneAnimationRequest asar = XSingleton<XSceneMgr>.singleton.ShowSceneLoadAnim(sceneType);
			while (asar != null && !asar.IsDone)
			{
				XSingleton<XSceneMgr>.singleton.UpdateSceneLoadAnim(asar, sceneType);
				yield return null;
			}
			RpcC2G_DoEnterScene DoEnterSceneRpc = new RpcC2G_DoEnterScene();
			DoEnterSceneRpc.oArg.sceneid = XSingleton<XScene>.singleton.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(DoEnterSceneRpc);
			XSingleton<XScene>.singleton.bSceneLoadedRpcSend = true;
			while (!XSingleton<XScene>.singleton.bSceneServerReady)
			{
				bool flag = XSingleton<XScene>.singleton.Error > ErrorCode.ERR_SUCCESS;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.OnFatalErrorClosed(XSingleton<XScene>.singleton.Error);
					XSingleton<XScene>.singleton.Error = ErrorCode.ERR_SUCCESS;
					XSingleton<XClientNetwork>.singleton.CloseOnServerErrorNtf = false;
					break;
				}
				bool flag2 = XSingleton<XScene>.singleton.SceneEntranceConfig != null;
				if (flag2)
				{
					DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.HidePkLoading();
					DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.HidePkLoading();
					DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.HidePkLoading();
					XSingleton<XScene>.singleton.TriggerScene();
					break;
				}
				yield return null;
			}
			bool bSceneServerReady = XSingleton<XScene>.singleton.bSceneServerReady;
			if (bSceneServerReady)
			{
				this.PlayBGM(this._loading_scene_id);
				DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.HidePkLoading();
				DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.HidePkLoading();
				DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.HidePkLoading();
				XAutoFade.FadeIn(1f, true);
				XSingleton<XScene>.singleton.TriggerScene();
			}
			bool flag3 = XSingleton<XScene>.singleton.SceneEntranceConfig != null;
			if (flag3)
			{
				XSingleton<XScene>.singleton.SceneEnterTo(true);
			}
			XSingleton<XGame>.singleton.switchScene = false;
			yield break;
		}

		private void CreatePlayer(uint sceneID)
		{
			XSingleton<XDebug>.singleton.AddLog("Preload Player", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XEntityMgr>.singleton.Add(XSingleton<XEntityMgr>.singleton.CreatePlayer(Vector3.zero, Quaternion.identity, false, XSingleton<XScene>.singleton.IsMustTransform));
		}

		private void PreLoadSceneMonster(uint sceneID)
		{
			List<uint> list = new List<uint>();
			XLevelSpawnInfo spawnerBySceneID = XSingleton<XLevelSpawnMgr>.singleton.GetSpawnerBySceneID(sceneID);
			bool flag = spawnerBySceneID != null;
			if (flag)
			{
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				foreach (KeyValuePair<int, int> keyValuePair in spawnerBySceneID._preloadInfo)
				{
					bool flag2 = keyValuePair.Key == 0;
					if (!flag2)
					{
						dictionary.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
				for (int i = 0; i < XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs.Count; i++)
				{
					bool flag3 = XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs[i] == 0U;
					if (!flag3)
					{
						bool flag4 = !dictionary.ContainsKey((int)XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs[i]);
						if (flag4)
						{
							dictionary.Add((int)XSingleton<XLevelSpawnMgr>.singleton.MonsterIDs[i], 1);
						}
					}
				}
				foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
				{
					uint key = (uint)keyValuePair2.Key;
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(key);
					bool flag5 = byID == null;
					if (!flag5)
					{
						string prefab = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID).Prefab;
						bool flag6 = !list.Contains(byID.PresentID);
						if (flag6)
						{
							XSingleton<XEntityMgr>.singleton.PreloadTemp(byID.PresentID, key, (EntitySpecies)byID.Type);
							list.Add(byID.PresentID);
						}
					}
				}
			}
		}

		private void PlaceSceneNpc(uint sceneID)
		{
			List<uint> npcs = XSingleton<XEntityMgr>.singleton.GetNpcs(sceneID);
			bool flag = npcs != null;
			if (flag)
			{
				XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
				for (int i = 0; i < npcs.Count; i++)
				{
					bool flag2 = !specificDocument.ShouldNpcExist(npcs[i]);
					if (!flag2)
					{
						XSingleton<XEntityMgr>.singleton.CreateNpc(npcs[i], true);
					}
				}
			}
		}

		private void ResetLevelAirWall()
		{
			XSingleton<XLevelScriptMgr>.singleton.ResetAirWallState();
		}

		private void DocPreload(uint sceneid)
		{
			for (int i = 0; i < XSingleton<XGame>.singleton.Doc.Components.Count; i++)
			{
				XSingleton<XGame>.singleton.Doc.Components[i].OnEnterScene();
			}
		}

		private void PlayBGM(uint sceneid)
		{
			string sceneBGM = XSingleton<XSceneMgr>.singleton.GetSceneBGM(sceneid);
			XSingleton<XAudioMgr>.singleton.PlayBGM(sceneBGM);
		}

		private uint _loading_scene_id = 0U;
	}
}
