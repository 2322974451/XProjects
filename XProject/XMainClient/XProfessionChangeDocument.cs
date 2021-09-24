using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XProfessionChangeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XProfessionChangeDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XProfessionChangeDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnProfChangeTaskFinish));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._taskID = XSingleton<XGlobalConfig>.singleton.GetInt("ProfessionChangeTaskID");
			this.SceneID = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("ProfessionChangeSceneID"));
		}

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

		public void QueryChangeProfession()
		{
			RpcC2G_ChangeProfession rpcC2G_ChangeProfession = new RpcC2G_ChangeProfession();
			rpcC2G_ChangeProfession.oArg.pro = (uint)this.SelectProfession;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeProfession);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ProfessionChangeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private int _taskID;

		public uint SceneID;

		public int SelectProfession = 1;

		public int LastExperienceProfID = 1;
	}
}
