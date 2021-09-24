using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XThemeActivityDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XThemeActivityDocument.uuID;
			}
		}

		public static ThemeActivity ThemeActivityTable
		{
			get
			{
				return XThemeActivityDocument.m_ThemeActivityTable;
			}
		}

		public static XThemeActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XThemeActivityDocument.uuID) as XThemeActivityDocument;
			}
		}

		public XThemeActivityView View { get; set; }

		public HashSet<uint> systemIds
		{
			get
			{
				bool flag = this.m_systemIds == null || this.m_systemIds.Count == 0;
				if (flag)
				{
					this.m_systemIds = new HashSet<uint>();
					for (int i = 0; i < XThemeActivityDocument.m_ThemeActivityTable.Table.Length; i++)
					{
						bool flag2 = XThemeActivityDocument.m_ThemeActivityTable.Table[i] != null;
						if (flag2)
						{
							this.m_systemIds.Add(XThemeActivityDocument.m_ThemeActivityTable.Table[i].SysID);
						}
					}
				}
				return this.m_systemIds;
			}
		}

		public bool GetSysFirstRedPoint(XSysDefine sys)
		{
			bool flag2;
			bool flag = this.m_SysFirstRedPointDic.TryGetValue(sys, out flag2);
			bool result;
			if (flag)
			{
				result = flag2;
			}
			else
			{
				SuperActivityTime.RowData dataBySystemID = XTempActivityDocument.Doc.GetDataBySystemID((uint)sys);
				bool flag3 = dataBySystemID == null;
				if (flag3)
				{
					result = false;
				}
				else
				{
					SpActivityOne activity = XTempActivityDocument.Doc.GetActivity(dataBySystemID.actid);
					bool flag4 = activity == null || activity.theme == null;
					if (flag4)
					{
						result = false;
					}
					else
					{
						this.m_SysFirstRedPointDic[sys] = activity.theme.ishint;
						result = activity.theme.ishint;
					}
				}
			}
			return result;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XThemeActivityDocument.AsyncLoader.AddTask("Table/ThemeActivity", XThemeActivityDocument.m_ThemeActivityTable, false);
			XThemeActivityDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID) == SceneType.SCENE_HALL;
			if (flag)
			{
				this.RefreshRedPoints();
			}
		}

		public bool SysIsOpen(XSysDefine sys)
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
		}

		public bool isHasHallIcon()
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_ThemeActivity);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < XThemeActivityDocument.ThemeActivityTable.Table.Length; i++)
				{
					ThemeActivity.RowData rowData = XThemeActivityDocument.ThemeActivityTable.Table[i];
					XSysDefine sysID = (XSysDefine)rowData.SysID;
					bool flag2 = this.SysIsOpen(sysID);
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		public bool IsHadRedPoint()
		{
			for (int i = 0; i < XThemeActivityDocument.ThemeActivityTable.Table.Length; i++)
			{
				ThemeActivity.RowData rowData = XThemeActivityDocument.ThemeActivityTable.Table[i];
				XSysDefine sysID = (XSysDefine)rowData.SysID;
				bool flag = this.SysIsOpen(sysID);
				if (flag)
				{
					bool tabRedPointState = this.GetTabRedPointState(sysID);
					if (tabRedPointState)
					{
						XSingleton<XDebug>.singleton.AddGreenLog("ThemeActivity RedPoint:" + sysID.ToString(), null, null, null, null, null);
						return true;
					}
				}
			}
			return false;
		}

		public void RefreshRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_ThemeActivity, true);
			bool flag = DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.RefreshRedpoint();
			}
		}

		public bool GetTabRedPointState(XSysDefine sys)
		{
			bool result;
			if (sys != XSysDefine.XSys_ThemeActivity_HellDog)
			{
				if (sys != XSysDefine.XSys_ThemeActivity_MadDuck)
				{
					result = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(sys);
				}
				else
				{
					MadDuckSiegeDocument specificDocument = XDocuments.GetSpecificDocument<MadDuckSiegeDocument>(MadDuckSiegeDocument.uuID);
					result = (this.GetSysFirstRedPoint(sys) | specificDocument.GetRedPoint());
				}
			}
			else
			{
				BiochemicalHellDogDocument specificDocument2 = XDocuments.GetSpecificDocument<BiochemicalHellDogDocument>(BiochemicalHellDogDocument.uuID);
				result = (this.GetSysFirstRedPoint(sys) | specificDocument2.GetRedPoint());
			}
			return result;
		}

		public void OnSystemChanged(List<uint> openIds, List<uint> closeIds)
		{
			bool flag = !DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				int num = 0;
				bool flag2 = this.systemIds != null;
				if (flag2)
				{
					for (int i = 0; i < openIds.Count; i++)
					{
						bool flag3 = this.systemIds.Contains(openIds[i]);
						if (flag3)
						{
							num = 1;
							break;
						}
					}
					for (int j = 0; j < closeIds.Count; j++)
					{
						bool flag4 = this.systemIds.Contains(closeIds[j]);
						if (flag4)
						{
							bool flag5 = num == 1;
							if (flag5)
							{
								num = 3;
							}
							else
							{
								num = 2;
							}
							break;
						}
					}
				}
				bool flag6 = num == 0;
				if (!flag6)
				{
					bool flag7 = num == 1;
					if (flag7)
					{
						DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.RefreshChangeUI(null);
					}
					else
					{
						DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.RefreshChangeUI(closeIds);
					}
				}
			}
		}

		public void SendJoinScene(uint actid, uint sceneid)
		{
			RpcC2G_TactEnterScene rpcC2G_TactEnterScene = new RpcC2G_TactEnterScene();
			rpcC2G_TactEnterScene.oArg.actid = actid;
			rpcC2G_TactEnterScene.oArg.sceneid = sceneid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TactEnterScene);
		}

		public void SendFirstHint(uint actid)
		{
			RpcC2G_ThemeActivityHint rpcC2G_ThemeActivityHint = new RpcC2G_ThemeActivityHint();
			rpcC2G_ThemeActivityHint.oArg.actid = actid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ThemeActivityHint);
		}

		public void SetActivityChange(PtcG2C_ThemeActivityChangeNtf roPtc)
		{
			SuperActivityTime.RowData dataByActivityID = XTempActivityDocument.Doc.GetDataByActivityID(roPtc.Data.actid);
			bool flag = dataByActivityID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("actid:" + roPtc.Data.actid + " No Find", null, null, null, null, null);
			}
			this.m_SysFirstRedPointDic[(XSysDefine)dataByActivityID.systemid] = roPtc.Data.ishint;
			XTempActivityDocument.Doc.SetActivityCompleteScene(roPtc.Data.actid, roPtc.Data.scene);
			this.RefreshRedPoints();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XThemeActivityDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ThemeActivity m_ThemeActivityTable = new ThemeActivity();

		private HashSet<uint> m_systemIds;

		private Dictionary<XSysDefine, bool> m_SysFirstRedPointDic = new Dictionary<XSysDefine, bool>();
	}
}
