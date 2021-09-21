using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000964 RID: 2404
	internal class XProfessionChangeDocument : XDocComponent
	{
		// Token: 0x17002C53 RID: 11347
		// (get) Token: 0x060090D9 RID: 37081 RVA: 0x0014AA1C File Offset: 0x00148C1C
		public override uint ID
		{
			get
			{
				return XProfessionChangeDocument.uuID;
			}
		}

		// Token: 0x060090DA RID: 37082 RVA: 0x0014AA33 File Offset: 0x00148C33
		public static void Execute(OnLoadedCallback callback = null)
		{
			XProfessionChangeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060090DB RID: 37083 RVA: 0x0014AA42 File Offset: 0x00148C42
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnProfChangeTaskFinish));
		}

		// Token: 0x060090DC RID: 37084 RVA: 0x0014AA64 File Offset: 0x00148C64
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._taskID = XSingleton<XGlobalConfig>.singleton.GetInt("ProfessionChangeTaskID");
			this.SceneID = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("ProfessionChangeSceneID"));
		}

		// Token: 0x060090DD RID: 37085 RVA: 0x0014AAA0 File Offset: 0x00148CA0
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XScene>.singleton.SceneID == this.SceneID;
			if (flag)
			{
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_ProfessionChange, EXStage.Hall);
				this.LastExperienceProfID = this.SelectProfession;
			}
		}

		// Token: 0x060090DE RID: 37086 RVA: 0x0014AAEC File Offset: 0x00148CEC
		public bool OnProfChangeTaskFinish(XEventArgs args)
		{
			XTaskStatusChangeArgs xtaskStatusChangeArgs = args as XTaskStatusChangeArgs;
			bool flag = xtaskStatusChangeArgs.status != TaskStatus.TaskStatus_Over;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = xtaskStatusChangeArgs.id == (uint)this._taskID;
				if (flag2)
				{
					DlgBase<ProfessionChangeDlg, ProfessionChangeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x060090DF RID: 37087 RVA: 0x0014AB3C File Offset: 0x00148D3C
		public void QueryChangeProfession()
		{
			RpcC2G_ChangeProfession rpcC2G_ChangeProfession = new RpcC2G_ChangeProfession();
			rpcC2G_ChangeProfession.oArg.pro = (uint)this.SelectProfession;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeProfession);
		}

		// Token: 0x060090E0 RID: 37088 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003000 RID: 12288
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ProfessionChangeDocument");

		// Token: 0x04003001 RID: 12289
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003002 RID: 12290
		private int _taskID;

		// Token: 0x04003003 RID: 12291
		public uint SceneID;

		// Token: 0x04003004 RID: 12292
		public int SelectProfession = 1;

		// Token: 0x04003005 RID: 12293
		public int LastExperienceProfID = 1;
	}
}
