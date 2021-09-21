using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA6 RID: 3238
	internal class XThemeActivityDocument : XDocComponent
	{
		// Token: 0x17003236 RID: 12854
		// (get) Token: 0x0600B65C RID: 46684 RVA: 0x00242638 File Offset: 0x00240838
		public override uint ID
		{
			get
			{
				return XThemeActivityDocument.uuID;
			}
		}

		// Token: 0x17003237 RID: 12855
		// (get) Token: 0x0600B65D RID: 46685 RVA: 0x00242650 File Offset: 0x00240850
		public static ThemeActivity ThemeActivityTable
		{
			get
			{
				return XThemeActivityDocument.m_ThemeActivityTable;
			}
		}

		// Token: 0x17003238 RID: 12856
		// (get) Token: 0x0600B65E RID: 46686 RVA: 0x00242668 File Offset: 0x00240868
		public static XThemeActivityDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XThemeActivityDocument.uuID) as XThemeActivityDocument;
			}
		}

		// Token: 0x17003239 RID: 12857
		// (get) Token: 0x0600B65F RID: 46687 RVA: 0x00242693 File Offset: 0x00240893
		// (set) Token: 0x0600B660 RID: 46688 RVA: 0x0024269B File Offset: 0x0024089B
		public XThemeActivityView View { get; set; }

		// Token: 0x1700323A RID: 12858
		// (get) Token: 0x0600B661 RID: 46689 RVA: 0x002426A4 File Offset: 0x002408A4
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

		// Token: 0x0600B662 RID: 46690 RVA: 0x00242738 File Offset: 0x00240938
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

		// Token: 0x0600B663 RID: 46691 RVA: 0x002427CE File Offset: 0x002409CE
		public static void Execute(OnLoadedCallback callback = null)
		{
			XThemeActivityDocument.AsyncLoader.AddTask("Table/ThemeActivity", XThemeActivityDocument.m_ThemeActivityTable, false);
			XThemeActivityDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B664 RID: 46692 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B665 RID: 46693 RVA: 0x002427F4 File Offset: 0x002409F4
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID) == SceneType.SCENE_HALL;
			if (flag)
			{
				this.RefreshRedPoints();
			}
		}

		// Token: 0x0600B666 RID: 46694 RVA: 0x00242830 File Offset: 0x00240A30
		public bool SysIsOpen(XSysDefine sys)
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(sys);
		}

		// Token: 0x0600B667 RID: 46695 RVA: 0x0024285C File Offset: 0x00240A5C
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

		// Token: 0x0600B668 RID: 46696 RVA: 0x002428D0 File Offset: 0x00240AD0
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

		// Token: 0x0600B669 RID: 46697 RVA: 0x00242960 File Offset: 0x00240B60
		public void RefreshRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_ThemeActivity, true);
			bool flag = DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.RefreshRedpoint();
			}
		}

		// Token: 0x0600B66A RID: 46698 RVA: 0x00242998 File Offset: 0x00240B98
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

		// Token: 0x0600B66B RID: 46699 RVA: 0x00242A08 File Offset: 0x00240C08
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

		// Token: 0x0600B66C RID: 46700 RVA: 0x00242AF0 File Offset: 0x00240CF0
		public void SendJoinScene(uint actid, uint sceneid)
		{
			RpcC2G_TactEnterScene rpcC2G_TactEnterScene = new RpcC2G_TactEnterScene();
			rpcC2G_TactEnterScene.oArg.actid = actid;
			rpcC2G_TactEnterScene.oArg.sceneid = sceneid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TactEnterScene);
		}

		// Token: 0x0600B66D RID: 46701 RVA: 0x00242B2C File Offset: 0x00240D2C
		public void SendFirstHint(uint actid)
		{
			RpcC2G_ThemeActivityHint rpcC2G_ThemeActivityHint = new RpcC2G_ThemeActivityHint();
			rpcC2G_ThemeActivityHint.oArg.actid = actid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ThemeActivityHint);
		}

		// Token: 0x0600B66E RID: 46702 RVA: 0x00242B5C File Offset: 0x00240D5C
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

		// Token: 0x04004763 RID: 18275
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XThemeActivityDocument");

		// Token: 0x04004764 RID: 18276
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004765 RID: 18277
		private static ThemeActivity m_ThemeActivityTable = new ThemeActivity();

		// Token: 0x04004767 RID: 18279
		private HashSet<uint> m_systemIds;

		// Token: 0x04004768 RID: 18280
		private Dictionary<XSysDefine, bool> m_SysFirstRedPointDic = new Dictionary<XSysDefine, bool>();
	}
}
