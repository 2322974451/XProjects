using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemAccessDlg : DlgBase<ItemAccessDlg, ItemAccessDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/ItemAccessDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._bqDocument = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected bool OnCloseClicked(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		public void ShowAccess(int itemid, List<int> ids, List<int> param, AccessCallback callback = null)
		{
			this.SetVisible(true, true);
			this._idParam.Clear();
			this._callback = callback;
			this._access_item = itemid;
			base.uiBehaviour.m_Item.SetActive(true);
			base.uiBehaviour.m_BossItem.SetActive(false);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_Item, itemid, 0, false);
			this.SetScrollViewItems(ids, param);
		}

		public void ShowMonsterAccess(uint monsterID, List<int> BQList, List<int> param, AccessCallback callback = null)
		{
			this.SetVisible(true, true);
			base.uiBehaviour.m_Item.SetActive(false);
			base.uiBehaviour.m_BossItem.SetActive(true);
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(monsterID);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
			bool flag = byPresentID == null;
			if (!flag)
			{
				IXUISprite ixuisprite = base.uiBehaviour.m_BossItem.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(byPresentID.Avatar, byPresentID.Atlas, false);
				bool flag2 = param != null && param.Count > 0;
				if (flag2)
				{
					SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)param[0]);
					bool flag3 = sceneData != null;
					if (flag3)
					{
						base.uiBehaviour.m_bossDec.SetText(sceneData.Comment);
					}
				}
				else
				{
					bool flag4 = byID != null;
					if (flag4)
					{
						base.uiBehaviour.m_bossDec.SetText(byID.Name);
					}
				}
				this._idParam.Clear();
				this._callback = callback;
				this._access_item = (int)monsterID;
				this.SetScrollViewItems(BQList, param);
			}
		}

		private void SetScrollViewItems(List<int> BQList, List<int> param)
		{
			bool flag = BQList == null || param == null;
			if (!flag)
			{
				List<AccessData> list = new List<AccessData>();
				for (int i = 0; i < BQList.Count; i++)
				{
					FpStrengthenTable.RowData strengthData = this._bqDocument.GetStrengthData(BQList[i]);
					bool flag2 = strengthData == null;
					if (!flag2)
					{
						bool flag3 = this._idParam.ContainsKey(BQList[i]);
						if (!flag3)
						{
							this._idParam.Add(BQList[i], param[i]);
							AccessData accessData = new AccessData();
							accessData.Row = strengthData;
							accessData.BQid = BQList[i];
							FpStrengthenTable.RowData strengthData2 = this._bqDocument.GetStrengthData(BQList[i]);
							XSysDefine bqsystem = (XSysDefine)strengthData2.BQSystem;
							accessData.SysType = bqsystem;
							bool flag4 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(bqsystem);
							accessData.OpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(bqsystem));
							bool flag5 = flag4;
							if (flag5)
							{
								bool flag6 = XSysDefine.XSys_Level_Normal == bqsystem;
								if (flag6)
								{
									XLevelDocument xlevelDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
									bool flag7 = param[i] > 0;
									if (flag7)
									{
										flag4 = (SceneRefuseReason.Admit == xlevelDocument.CanLevelOpen((uint)param[i]));
									}
									SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)param[i]);
									bool flag8 = sceneData != null;
									if (flag8)
									{
										accessData.OpenLevel = (int)sceneData.RequiredLevel;
									}
								}
								else
								{
									bool flag9 = XSysDefine.XSys_Level_Elite == bqsystem;
									if (flag9)
									{
										bool flag10 = 0 < param[i];
										if (flag10)
										{
											XLevelDocument xlevelDocument2 = XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument;
											bool flag11 = param[i] < 10;
											if (!flag11)
											{
												flag4 = (SceneRefuseReason.Admit == xlevelDocument2.CanLevelOpen((uint)param[i]));
											}
										}
										SceneTable.RowData sceneData2 = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)param[i]);
										bool flag12 = sceneData2 != null;
										if (flag12)
										{
											accessData.OpenLevel = (int)sceneData2.RequiredLevel;
										}
									}
									else
									{
										bool flag13 = XSysDefine.XSys_Activity_Nest == bqsystem;
										if (flag13)
										{
											XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
											int expIDBySceneID = xexpeditionDocument.GetExpIDBySceneID((uint)param[i]);
											ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(expIDBySceneID);
											bool flag14 = expeditionDataByID != null;
											if (flag14)
											{
												flag4 = xexpeditionDocument.TeamCategoryMgr.IsExpOpened(expeditionDataByID);
												accessData.OpenLevel = expeditionDataByID.RequiredLevel;
											}
											else
											{
												flag4 = false;
											}
										}
									}
								}
							}
							accessData.IsOpen = flag4;
							accessData.DescStr = strengthData.BQTips;
							bool flag15 = param[i] > 0;
							if (flag15)
							{
								SceneTable.RowData sceneData3 = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)param[i]);
								bool flag16 = sceneData3 != null;
								if (flag16)
								{
									accessData.DescStr = string.Format(strengthData.BQTips, sceneData3.Comment);
									accessData.SceStr = sceneData3.Comment;
								}
								else
								{
									XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
									{
										"SceneId not exist ",
										i,
										"  ",
										param[i]
									}), null, null, null, null, null);
								}
							}
							list.Add(accessData);
						}
					}
				}
				list.Sort(new Comparison<AccessData>(this.Compare));
				base.uiBehaviour.m_RecordPool.ReturnAll(false);
				for (int j = 0; j < list.Count; j++)
				{
					AccessData accessData2 = list[j];
					bool flag17 = accessData2 == null;
					if (!flag17)
					{
						GameObject gameObject = base.uiBehaviour.m_RecordPool.FetchGameObject(false);
						gameObject.name = XSingleton<XCommon>.singleton.StringCombine("access", accessData2.BQid.ToString());
						gameObject.transform.localPosition = base.uiBehaviour.m_RecordPool.TplPos + new Vector3(0f, (float)(-(float)base.uiBehaviour.m_RecordPool.TplHeight * j), 0f);
						IXUISprite ixuisprite = gameObject.transform.FindChild("icon").GetComponent("XUISprite") as IXUISprite;
						IXUILabel ixuilabel = gameObject.transform.FindChild("name").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = gameObject.transform.FindChild("desc").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel3 = gameObject.transform.FindChild("scene").GetComponent("XUILabel") as IXUILabel;
						IXUIButton ixuibutton = gameObject.transform.FindChild("goto").GetComponent("XUIButton") as IXUIButton;
						IXUILabel ixuilabel4 = gameObject.transform.FindChild("notopen").GetComponent("XUILabel") as IXUILabel;
						ixuisprite.SetSprite(accessData2.Row.BQImageID);
						ixuilabel.SetText(accessData2.Row.BQName);
						ixuilabel2.SetText(accessData2.DescStr);
						ixuilabel3.SetText(accessData2.SceStr);
						bool isOpen = accessData2.IsOpen;
						if (isOpen)
						{
							ixuibutton.gameObject.SetActive(true);
							ixuilabel4.gameObject.SetActive(false);
							ixuibutton.ID = (ulong)((long)accessData2.BQid);
							ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.GoToAccessSys));
						}
						else
						{
							ixuibutton.gameObject.SetActive(false);
							ixuilabel4.gameObject.SetActive(true);
							bool flag18 = XSysDefine.XSys_Level_Elite == accessData2.SysType || XSysDefine.XSys_Level_Normal == accessData2.SysType;
							if (flag18)
							{
								bool flag19 = (long)accessData2.OpenLevel > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
								if (flag19)
								{
									ixuilabel4.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKILL_LEARN"), accessData2.OpenLevel));
								}
								else
								{
									ixuilabel4.SetText(XSingleton<XStringTable>.singleton.GetString("ShouldFinishMainTask"));
								}
							}
							else
							{
								ixuilabel4.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKILL_LEARN"), accessData2.OpenLevel));
							}
						}
						bool flag20 = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
						if (flag20)
						{
							ixuibutton.SetVisible(false);
						}
					}
				}
				base.uiBehaviour.m_RecordScrollView.ResetPosition();
			}
		}

		private int Compare(AccessData left, AccessData right)
		{
			bool isOpen = left.IsOpen;
			int result;
			if (isOpen)
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		public bool GoToAccessSys(IXUIButton sp)
		{
			int num = (int)sp.ID;
			FpStrengthenTable.RowData strengthData = this._bqDocument.GetStrengthData(num);
			bool flag = strengthData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSysDefine bqsystem = (XSysDefine)strengthData.BQSystem;
				XSysDefine xsysDefine = bqsystem;
				if (xsysDefine <= XSysDefine.XSys_Mall_Mall)
				{
					if (xsysDefine == XSysDefine.XSys_Level_Normal)
					{
						XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
						specificDocument.AutoGoBattle(this._idParam[num], 0, 0U);
						goto IL_284;
					}
					if (xsysDefine == XSysDefine.XSys_Level_Elite)
					{
						XLevelDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
						bool flag2 = this._idParam[num] < 10;
						if (flag2)
						{
							specificDocument2.AutoGoBattle(0, this._idParam[num], 1U);
						}
						else
						{
							specificDocument2.AutoGoBattle(this._idParam[num], 0, 1U);
						}
						goto IL_284;
					}
					if (xsysDefine != XSysDefine.XSys_Mall_Mall)
					{
						goto IL_261;
					}
				}
				else
				{
					if (xsysDefine == XSysDefine.XSys_Mall_Guild)
					{
						XGuildDocument specificDocument3 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
						this.SetVisible(false, true);
						bool flag3 = !specificDocument3.bInGuild;
						if (flag3)
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Guild, 0UL);
						}
						else
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)strengthData.BQSystem, (ulong)((long)this._access_item));
						}
						goto IL_284;
					}
					if (xsysDefine == XSysDefine.XSys_Activity_Nest)
					{
						this.SetVisible(false, true);
						bool flag4 = 0 <= this._idParam[num];
						if (flag4)
						{
							XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
							int expIDBySceneID = xexpeditionDocument.GetExpIDBySceneID((uint)this._idParam[num]);
							ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(expIDBySceneID);
							bool flag5 = expeditionDataByID != null;
							if (flag5)
							{
								ExpeditionTable.RowData expeditionDataByID2 = xexpeditionDocument.GetExpeditionDataByID(this._idParam[num]);
								bool flag6 = expeditionDataByID2 != null;
								if (flag6)
								{
									DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(expeditionDataByID2.DNExpeditionID);
								}
								else
								{
									DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(-1);
								}
							}
						}
						else
						{
							DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowViewByExpID(this._idParam[num]);
						}
						goto IL_284;
					}
					if (xsysDefine != XSysDefine.XSys_Activity_TeamTower)
					{
						goto IL_261;
					}
				}
				this.SetVisible(false, true);
				bool flag7 = this._callback != null;
				if (flag7)
				{
					this._callback();
				}
				XSingleton<XGameSysMgr>.singleton.OpenSystem(bqsystem, 0UL);
				goto IL_284;
				IL_261:
				this.SetVisible(false, true);
				XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)strengthData.BQSystem, (ulong)((long)this._access_item));
				IL_284:
				result = true;
			}
			return result;
		}

		private XFPStrengthenDocument _bqDocument;

		private AccessCallback _callback;

		private int _access_item = 0;

		private Dictionary<int, int> _idParam = new Dictionary<int, int>();
	}
}
