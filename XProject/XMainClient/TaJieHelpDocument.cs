using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008EC RID: 2284
	internal class TaJieHelpDocument : XDocComponent
	{
		// Token: 0x17002B04 RID: 11012
		// (get) Token: 0x06008A34 RID: 35380 RVA: 0x001247AC File Offset: 0x001229AC
		public override uint ID
		{
			get
			{
				return TaJieHelpDocument.uuID;
			}
		}

		// Token: 0x17002B05 RID: 11013
		// (get) Token: 0x06008A35 RID: 35381 RVA: 0x001247C4 File Offset: 0x001229C4
		public static TaJieHelpDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(TaJieHelpDocument.uuID) as TaJieHelpDocument;
			}
		}

		// Token: 0x17002B06 RID: 11014
		// (get) Token: 0x06008A36 RID: 35382 RVA: 0x001247F0 File Offset: 0x001229F0
		// (set) Token: 0x06008A37 RID: 35383 RVA: 0x00124824 File Offset: 0x00122A24
		public bool ShowHallBtn
		{
			get
			{
				bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_TaJieHelp);
				bool flag2 = !flag;
				return !flag2 && this.m_showHallBtn;
			}
			set
			{
				bool flag = this.m_showHallBtn != value;
				if (flag)
				{
					this.m_showHallBtn = value;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.Xsys_TaJieHelp, true);
				}
			}
		}

		// Token: 0x17002B07 RID: 11015
		// (get) Token: 0x06008A38 RID: 35384 RVA: 0x0012485C File Offset: 0x00122A5C
		// (set) Token: 0x06008A39 RID: 35385 RVA: 0x00124874 File Offset: 0x00122A74
		public int CurType
		{
			get
			{
				return this.m_curType;
			}
			set
			{
				this.m_curType = value;
			}
		}

		// Token: 0x06008A3A RID: 35386 RVA: 0x0012487E File Offset: 0x00122A7E
		public static void Execute(OnLoadedCallback callback = null)
		{
			TaJieHelpDocument.AsyncLoader.AddTask("Table/TaJieHelpTab", TaJieHelpDocument.m_tajieHelpTable, false);
			TaJieHelpDocument.AsyncLoader.AddTask("Table/TaJieHelpUrl", TaJieHelpDocument.m_tajieHelpUrl, false);
			TaJieHelpDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008A3B RID: 35387 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008A3C RID: 35388 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008A3D RID: 35389 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008A3E RID: 35390 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008A3F RID: 35391 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008A40 RID: 35392 RVA: 0x001248BC File Offset: 0x00122ABC
		public List<TaJieHelpTab.RowData> GetTaJieHelpData()
		{
			List<TaJieHelpTab.RowData> list = new List<TaJieHelpTab.RowData>();
			bool inGuild = XGuildDocument.InGuild;
			for (int i = 0; i < TaJieHelpDocument.m_tajieHelpTable.Table.Length; i++)
			{
				TaJieHelpTab.RowData rowData = TaJieHelpDocument.m_tajieHelpTable.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					bool flag2 = (ulong)rowData.SysID != (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildHall)) || !inGuild;
					if (flag2)
					{
						for (int j = 0; j < rowData.Type.Length; j++)
						{
							bool flag3 = (ulong)rowData.Type[j] == (ulong)((long)this.m_curType);
							if (flag3)
							{
								list.Add(rowData);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06008A41 RID: 35393 RVA: 0x00124980 File Offset: 0x00122B80
		public string GetUrl()
		{
			TaJieHelpUrl.RowData urlTabData = this.GetUrlTabData();
			bool flag = urlTabData != null;
			string result;
			if (flag)
			{
				result = urlTabData.Url;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06008A42 RID: 35394 RVA: 0x001249B0 File Offset: 0x00122BB0
		public string GetSceneName()
		{
			TaJieHelpUrl.RowData urlTabData = this.GetUrlTabData();
			bool flag = urlTabData != null;
			string result;
			if (flag)
			{
				result = urlTabData.Name;
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06008A43 RID: 35395 RVA: 0x001249E0 File Offset: 0x00122BE0
		private TaJieHelpUrl.RowData GetUrlTabData()
		{
			for (int i = 0; i < TaJieHelpDocument.m_tajieHelpUrl.Table.Length; i++)
			{
				TaJieHelpUrl.RowData rowData = TaJieHelpDocument.m_tajieHelpUrl.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					bool flag2 = (ulong)rowData.SceneId == (ulong)((long)this.m_sceneId);
					if (flag2)
					{
						return rowData;
					}
				}
			}
			return null;
		}

		// Token: 0x06008A44 RID: 35396 RVA: 0x00124A44 File Offset: 0x00122C44
		public string GetdDragonTips()
		{
			bool flag = this.m_dragonStatus == 0;
			string result;
			if (flag)
			{
				result = XSingleton<XStringTable>.singleton.GetString("TaJieHelpTips1");
			}
			else
			{
				bool flag2 = this.m_dragonStatus == 1;
				if (flag2)
				{
					result = string.Format("{0}{1}", XSingleton<XStringTable>.singleton.GetString("TaJieHelpTips2"), this.GetTime());
				}
				else
				{
					bool flag3 = this.m_dragonStatus == 2;
					if (flag3)
					{
						result = XSingleton<XStringTable>.singleton.GetString("TaJieHelpTips3");
					}
					else
					{
						result = "";
					}
				}
			}
			return result;
		}

		// Token: 0x06008A45 RID: 35397 RVA: 0x00124AC8 File Offset: 0x00122CC8
		public string GetTime()
		{
			float num = (float)this.m_dragonWeakLeftTime - Time.realtimeSinceStartup + this.m_getMesTime;
			int num2 = (int)(num / 3600f);
			int num3 = num2 % 24;
			bool flag = num % 3600f != 0f;
			if (flag)
			{
				num3++;
			}
			int num4 = num2 / 24;
			bool flag2 = num4 == 0;
			string result;
			if (flag2)
			{
				result = string.Format("{0}{1}", num3, XSingleton<XStringTable>.singleton.GetString("HOUR_DUARATION"));
			}
			else
			{
				result = string.Format("{0}{1}{2}{3}", new object[]
				{
					num4,
					XSingleton<XStringTable>.singleton.GetString("DAY_DUARATION"),
					num3,
					XSingleton<XStringTable>.singleton.GetString("HOUR_DUARATION")
				});
			}
			return result;
		}

		// Token: 0x06008A46 RID: 35398 RVA: 0x00124B94 File Offset: 0x00122D94
		public void OnGetPtcMes(PtcG2C_TajieHelpNotify msg)
		{
			bool flag = msg.Data.sceneID == this.m_sceneId;
			if (flag)
			{
				this.ShowHallBtn = msg.Data.isIconAppear;
				this.m_dragonStatus = msg.Data.dragonStatus;
				this.m_dragonWeakLeftTime = msg.Data.dragonWeakLeftTime;
				this.m_getMesTime = Time.realtimeSinceStartup;
			}
			else
			{
				bool isIconAppear = msg.Data.isIconAppear;
				if (isIconAppear)
				{
					this.m_sceneId = msg.Data.sceneID;
					this.m_curType = msg.Data.sceneType;
					this.m_dragonStatus = msg.Data.dragonStatus;
					this.m_dragonWeakLeftTime = msg.Data.dragonWeakLeftTime;
					this.m_getMesTime = Time.realtimeSinceStartup;
					this.ShowHallBtn = msg.Data.isIconAppear;
				}
			}
		}

		// Token: 0x04002BF2 RID: 11250
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TaJieHelpDocument");

		// Token: 0x04002BF3 RID: 11251
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002BF4 RID: 11252
		private static TaJieHelpTab m_tajieHelpTable = new TaJieHelpTab();

		// Token: 0x04002BF5 RID: 11253
		private static TaJieHelpUrl m_tajieHelpUrl = new TaJieHelpUrl();

		// Token: 0x04002BF6 RID: 11254
		private int m_sceneId = 0;

		// Token: 0x04002BF7 RID: 11255
		private int m_dragonStatus = 0;

		// Token: 0x04002BF8 RID: 11256
		private int m_dragonWeakLeftTime = 0;

		// Token: 0x04002BF9 RID: 11257
		private float m_getMesTime = 0f;

		// Token: 0x04002BFA RID: 11258
		private bool m_showHallBtn = false;

		// Token: 0x04002BFB RID: 11259
		private int m_curType = 0;
	}
}
