using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonCrusadeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonCrusadeDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnGamePause(bool pause)
		{
			base.OnGamePause(pause);
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XDragonCrusadeDocument.QuitFromCrusade && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				XDragonCrusadeDocument.QuitFromCrusade = false;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonCrusadeDocument.AsyncLoader.AddTask("Table/DragonExpList", XDragonCrusadeDocument.mDragonExpList, false);
			XDragonCrusadeDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			for (int i = 0; i < XDragonCrusadeDocument.mDragonExpList.Table.Length; i++)
			{
				DragonCrusageGateData dragonCrusageGateData = new DragonCrusageGateData();
				dragonCrusageGateData.SceneID = XDragonCrusadeDocument.mDragonExpList.Table[i].SceneID;
				dragonCrusageGateData.expData = XDragonCrusadeDocument.mDragonExpList.Table[i];
				dragonCrusageGateData.sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(dragonCrusageGateData.SceneID);
				dragonCrusageGateData.Chapter = dragonCrusageGateData.expData.ChapterID[0];
				bool flag = !XDragonCrusadeDocument.SectonChapterMax.ContainsKey(dragonCrusageGateData.expData.ChapterID[0]);
				if (flag)
				{
					XDragonCrusadeDocument.SectonChapterMax[dragonCrusageGateData.expData.ChapterID[0]] = dragonCrusageGateData.expData.ChapterID[1];
				}
				else
				{
					bool flag2 = dragonCrusageGateData.expData.ChapterID[1] > XDragonCrusadeDocument.SectonChapterMax[dragonCrusageGateData.expData.ChapterID[0]];
					if (flag2)
					{
						XDragonCrusadeDocument.SectonChapterMax[dragonCrusageGateData.expData.ChapterID[0]] = dragonCrusageGateData.expData.ChapterID[1];
					}
				}
				XDragonCrusadeDocument._DragonCrusageGateDataInfo.Add(dragonCrusageGateData);
			}
		}

		public string GetChapter(uint sceneID)
		{
			for (int i = 0; i < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; i++)
			{
				DragonCrusageGateData dragonCrusageGateData = XDragonCrusadeDocument._DragonCrusageGateDataInfo[i];
				bool flag = dragonCrusageGateData.SceneID == sceneID;
				if (flag)
				{
					return string.Concat(new object[]
					{
						dragonCrusageGateData.expData.ChapterID[0].ToString(),
						"-",
						dragonCrusageGateData.expData.ChapterID[1],
						" ",
						dragonCrusageGateData.sceneData.Comment
					});
				}
			}
			return sceneID + " Not Found Chapter";
		}

		public void ReadyOpen()
		{
			this.DEProgressReq();
			this.DERankReq();
		}

		public void DEProgressReq()
		{
			RpcC2G_DEProgressReq rpc = new RpcC2G_DEProgressReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnDEProgressReq(DEProgressRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				this.leftChanllageCnt = oRes.leftcount;
				for (int i = 0; i < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; i++)
				{
					DragonCrusageGateData dragonCrusageGateData = XDragonCrusadeDocument._DragonCrusageGateDataInfo[i];
					for (int j = 0; j < oRes.allpro.Count; j++)
					{
						DEProgress deprogress = oRes.allpro[j];
						bool flag2 = deprogress.sceneID == dragonCrusageGateData.SceneID;
						if (flag2)
						{
							dragonCrusageGateData.deProgress = deprogress;
							dragonCrusageGateData.leftcount = oRes.leftcount;
							dragonCrusageGateData.allcount = oRes.allcount;
							dragonCrusageGateData.SealLevel = oRes.serverseallevel;
							break;
						}
					}
				}
				bool flag3 = DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.RefreshProgressFromNet();
				}
			}
		}

		public void DERankReq()
		{
			RpcC2M_DERankReq rpc = new RpcC2M_DERankReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnDERankReq(DERankRes oRes)
		{
			this.oResRank = oRes;
			DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.SetVisible(true, true);
			DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.RefreshProgressSync(new Action<bool>(this.RefreshProgressSyncDone));
		}

		private void RefreshProgressSyncDone(bool done)
		{
			DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.RefreshRank(this.oResRank);
		}

		public void OnNotifyResult(DERankChangePara data)
		{
			XDragonCrusadeDocument.mDERankChangePara = data;
			DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>.singleton.UpdateHint(data);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonCrusadeDocument");

		public static bool QuitFromCrusade = false;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static DragonExpList mDragonExpList = new DragonExpList();

		public static List<DragonCrusageGateData> _DragonCrusageGateDataInfo = new List<DragonCrusageGateData>();

		public static Dictionary<uint, uint> SectonChapterMax = new Dictionary<uint, uint>();

		public DERankRes oResRank;

		public int leftChanllageCnt;

		public static DERankChangePara mDERankChangePara;
	}
}
