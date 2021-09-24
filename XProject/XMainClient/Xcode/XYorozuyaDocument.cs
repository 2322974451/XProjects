using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XYorozuyaDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XYorozuyaDocument.uuID;
			}
		}

		public byte SelectID { get; set; }

		public static XYorozuyaDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XYorozuyaDocument.uuID) as XYorozuyaDocument;
			}
		}

		public YorozuyaTable YorozuyaTab
		{
			get
			{
				return XYorozuyaDocument.m_yorozuyaTab;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XYorozuyaDocument.AsyncLoader.AddTask("Table/Yorozuya", XYorozuyaDocument.m_yorozuyaTab, false);
			XYorozuyaDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void ReqEnterScene(int id)
		{
			RpcC2G_EnterLeisureScene rpcC2G_EnterLeisureScene = new RpcC2G_EnterLeisureScene();
			rpcC2G_EnterLeisureScene.oArg.index = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnterLeisureScene);
		}

		public YorozuyaTable.RowData GetRowData(byte id)
		{
			return XYorozuyaDocument.m_yorozuyaTab.GetByID(id);
		}

		public void OnReqBack(EnterLeisureSceneRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XYorozuyaDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static YorozuyaTable m_yorozuyaTab = new YorozuyaTable();
	}
}
