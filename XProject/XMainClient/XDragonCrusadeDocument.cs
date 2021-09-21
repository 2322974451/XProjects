using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000971 RID: 2417
	internal class XDragonCrusadeDocument : XDocComponent
	{
		// Token: 0x17002C70 RID: 11376
		// (get) Token: 0x060091A6 RID: 37286 RVA: 0x0014E314 File Offset: 0x0014C514
		public override uint ID
		{
			get
			{
				return XDragonCrusadeDocument.uuID;
			}
		}

		// Token: 0x060091A7 RID: 37287 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060091A8 RID: 37288 RVA: 0x0012BF81 File Offset: 0x0012A181
		public override void OnGamePause(bool pause)
		{
			base.OnGamePause(pause);
		}

		// Token: 0x060091A9 RID: 37289 RVA: 0x0014E32B File Offset: 0x0014C52B
		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		// Token: 0x060091AA RID: 37290 RVA: 0x0014E338 File Offset: 0x0014C538
		public override void OnEnterSceneFinally()
		{
			bool flag = XDragonCrusadeDocument.QuitFromCrusade && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				XDragonCrusadeDocument.QuitFromCrusade = false;
			}
		}

		// Token: 0x060091AB RID: 37291 RVA: 0x0014E36E File Offset: 0x0014C56E
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonCrusadeDocument.AsyncLoader.AddTask("Table/DragonExpList", XDragonCrusadeDocument.mDragonExpList, false);
			XDragonCrusadeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060091AC RID: 37292 RVA: 0x0014E394 File Offset: 0x0014C594
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

		// Token: 0x060091AD RID: 37293 RVA: 0x0014E4E8 File Offset: 0x0014C6E8
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

		// Token: 0x060091AE RID: 37294 RVA: 0x0014E5AB File Offset: 0x0014C7AB
		public void ReadyOpen()
		{
			this.DEProgressReq();
			this.DERankReq();
		}

		// Token: 0x060091AF RID: 37295 RVA: 0x0014E5BC File Offset: 0x0014C7BC
		public void DEProgressReq()
		{
			RpcC2G_DEProgressReq rpc = new RpcC2G_DEProgressReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060091B0 RID: 37296 RVA: 0x0014E5DC File Offset: 0x0014C7DC
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

		// Token: 0x060091B1 RID: 37297 RVA: 0x0014E6C0 File Offset: 0x0014C8C0
		public void DERankReq()
		{
			RpcC2M_DERankReq rpc = new RpcC2M_DERankReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060091B2 RID: 37298 RVA: 0x0014E6E0 File Offset: 0x0014C8E0
		public void OnDERankReq(DERankRes oRes)
		{
			this.oResRank = oRes;
			DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.SetVisible(true, true);
			DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.RefreshProgressSync(new Action<bool>(this.RefreshProgressSyncDone));
		}

		// Token: 0x060091B3 RID: 37299 RVA: 0x0014E70E File Offset: 0x0014C90E
		private void RefreshProgressSyncDone(bool done)
		{
			DlgBase<DragonCrusadeDlg, DragonCrusadeBehavior>.singleton.RefreshRank(this.oResRank);
		}

		// Token: 0x060091B4 RID: 37300 RVA: 0x0014E722 File Offset: 0x0014C922
		public void OnNotifyResult(DERankChangePara data)
		{
			XDragonCrusadeDocument.mDERankChangePara = data;
			DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>.singleton.UpdateHint(data);
		}

		// Token: 0x04003071 RID: 12401
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonCrusadeDocument");

		// Token: 0x04003072 RID: 12402
		public static bool QuitFromCrusade = false;

		// Token: 0x04003073 RID: 12403
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003074 RID: 12404
		private static DragonExpList mDragonExpList = new DragonExpList();

		// Token: 0x04003075 RID: 12405
		public static List<DragonCrusageGateData> _DragonCrusageGateDataInfo = new List<DragonCrusageGateData>();

		// Token: 0x04003076 RID: 12406
		public static Dictionary<uint, uint> SectonChapterMax = new Dictionary<uint, uint>();

		// Token: 0x04003077 RID: 12407
		public DERankRes oResRank;

		// Token: 0x04003078 RID: 12408
		public int leftChanllageCnt;

		// Token: 0x04003079 RID: 12409
		public static DERankChangePara mDERankChangePara;
	}
}
