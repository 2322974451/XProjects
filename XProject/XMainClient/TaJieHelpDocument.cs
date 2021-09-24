using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TaJieHelpDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return TaJieHelpDocument.uuID;
			}
		}

		public static TaJieHelpDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(TaJieHelpDocument.uuID) as TaJieHelpDocument;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			TaJieHelpDocument.AsyncLoader.AddTask("Table/TaJieHelpTab", TaJieHelpDocument.m_tajieHelpTable, false);
			TaJieHelpDocument.AsyncLoader.AddTask("Table/TaJieHelpUrl", TaJieHelpDocument.m_tajieHelpUrl, false);
			TaJieHelpDocument.AsyncLoader.Execute(callback);
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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TaJieHelpDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static TaJieHelpTab m_tajieHelpTable = new TaJieHelpTab();

		private static TaJieHelpUrl m_tajieHelpUrl = new TaJieHelpUrl();

		private int m_sceneId = 0;

		private int m_dragonStatus = 0;

		private int m_dragonWeakLeftTime = 0;

		private float m_getMesTime = 0f;

		private bool m_showHallBtn = false;

		private int m_curType = 0;
	}
}
