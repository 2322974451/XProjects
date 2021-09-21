using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A0E RID: 2574
	internal class XYorozuyaDocument : XDocComponent
	{
		// Token: 0x17002EAB RID: 11947
		// (get) Token: 0x06009DD0 RID: 40400 RVA: 0x0019CC38 File Offset: 0x0019AE38
		public override uint ID
		{
			get
			{
				return XYorozuyaDocument.uuID;
			}
		}

		// Token: 0x17002EAC RID: 11948
		// (get) Token: 0x06009DD1 RID: 40401 RVA: 0x0019CC4F File Offset: 0x0019AE4F
		// (set) Token: 0x06009DD2 RID: 40402 RVA: 0x0019CC57 File Offset: 0x0019AE57
		public byte SelectID { get; set; }

		// Token: 0x17002EAD RID: 11949
		// (get) Token: 0x06009DD3 RID: 40403 RVA: 0x0019CC60 File Offset: 0x0019AE60
		public static XYorozuyaDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XYorozuyaDocument.uuID) as XYorozuyaDocument;
			}
		}

		// Token: 0x17002EAE RID: 11950
		// (get) Token: 0x06009DD4 RID: 40404 RVA: 0x0019CC8C File Offset: 0x0019AE8C
		public YorozuyaTable YorozuyaTab
		{
			get
			{
				return XYorozuyaDocument.m_yorozuyaTab;
			}
		}

		// Token: 0x06009DD5 RID: 40405 RVA: 0x0019CCA3 File Offset: 0x0019AEA3
		public static void Execute(OnLoadedCallback callback = null)
		{
			XYorozuyaDocument.AsyncLoader.AddTask("Table/Yorozuya", XYorozuyaDocument.m_yorozuyaTab, false);
			XYorozuyaDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009DD6 RID: 40406 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTableLoaded()
		{
		}

		// Token: 0x06009DD7 RID: 40407 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009DD8 RID: 40408 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06009DD9 RID: 40409 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06009DDA RID: 40410 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009DDB RID: 40411 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06009DDC RID: 40412 RVA: 0x0019CCC8 File Offset: 0x0019AEC8
		public void ReqEnterScene(int id)
		{
			RpcC2G_EnterLeisureScene rpcC2G_EnterLeisureScene = new RpcC2G_EnterLeisureScene();
			rpcC2G_EnterLeisureScene.oArg.index = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnterLeisureScene);
		}

		// Token: 0x06009DDD RID: 40413 RVA: 0x0019CCF8 File Offset: 0x0019AEF8
		public YorozuyaTable.RowData GetRowData(byte id)
		{
			return XYorozuyaDocument.m_yorozuyaTab.GetByID(id);
		}

		// Token: 0x06009DDE RID: 40414 RVA: 0x0019CD18 File Offset: 0x0019AF18
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

		// Token: 0x040037B1 RID: 14257
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XYorozuyaDocument");

		// Token: 0x040037B3 RID: 14259
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040037B4 RID: 14260
		private static YorozuyaTable m_yorozuyaTab = new YorozuyaTable();
	}
}
