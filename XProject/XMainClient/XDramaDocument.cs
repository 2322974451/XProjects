using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDramaDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDramaDocument.uuID;
			}
		}

		public XDramaOperate CurOperate
		{
			get
			{
				return this.m_CurOperate;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.bBlockClose = false;
			this.m_CurOperate = null;
			this.m_CurOperateSys = XSysDefine.XSys_Invalid;
			this._DramaOperateDic.Clear();
			this._DramaOperateDic.Add(XSysDefine.XSys_Mentorship, new XMentorshipPupilsDramaOperate());
			this._DramaOperateDic.Add(XSysDefine.XSys_Partner, new XPartnerDramaOperate());
			this._DramaOperateDic.Add(XSysDefine.XSys_Wedding, new XWeddingDramaOperate());
			this.favorDrama = new XNPCFavorDrama();
			this.favorDrama.BDeprecated = true;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_MentorshipRelationOperation, new XComponent.XEventHandler(this.OnOperatingMentorship));
		}

		public void OnMeetNpc(XNpc npc)
		{
			bool flag = npc == null;
			if (!flag)
			{
				switch (npc.NPCType)
				{
				case 1U:
					this.CommonNpc(npc);
					break;
				case 2U:
					HomePlantDocument.Doc.ClickFarmModle(npc);
					break;
				case 3U:
					HomePlantDocument.Doc.CliclTroubleMakerModle(npc);
					break;
				case 4U:
					DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNpcDialog(npc);
					break;
				case 5U:
				{
					XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
					specificDocument.OnMeetLottery(npc.TypeID);
					break;
				}
				case 6U:
				{
					XWeddingLitterGirlDramaOperate xweddingLitterGirlDramaOperate = new XWeddingLitterGirlDramaOperate();
					xweddingLitterGirlDramaOperate.ShowNpc(npc);
					break;
				}
				case 7U:
				{
					XWeddingLitterBoyDramaOperate xweddingLitterBoyDramaOperate = new XWeddingLitterBoyDramaOperate();
					xweddingLitterBoyDramaOperate.ShowNpc(npc);
					break;
				}
				case 8U:
				{
					XGuildHuntDramaOperate xguildHuntDramaOperate = new XGuildHuntDramaOperate();
					xguildHuntDramaOperate.ShowNpc(npc);
					break;
				}
				}
			}
		}

		public void CommonNpc(XNpc npc)
		{
			this._npc = npc;
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			XTaskInfo xtaskInfo = null;
			NpcTaskState npcTaskState = specificDocument.GetNpcTaskState(npc.TypeID, ref xtaskInfo);
			bool flag = false;
			bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_NPCFavor);
			if (flag2)
			{
				XNPCFavorDocument specificDocument2 = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
				EFavorState state = specificDocument2.GetState(npc.TypeID);
				flag = (state > EFavorState.None);
			}
			bool flag3 = npcTaskState == NpcTaskState.TaskBegin || npcTaskState == NpcTaskState.TaskEnd || (npcTaskState == NpcTaskState.TaskInprocess && !flag) || (npc._linkSys == 0 && !flag);
			if (flag3)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNpcDialog(npc);
			}
			else
			{
				bool flag4 = npc._linkSys != 0;
				if (flag4)
				{
					XSysDefine linkSys = (XSysDefine)npc._linkSys;
					bool flag5 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(linkSys);
					if (flag5)
					{
						DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNpcDialog(npc);
					}
					else
					{
						XDramaOperate xdramaOperate;
						bool flag6 = this._DramaOperateDic.TryGetValue(linkSys, out xdramaOperate);
						if (!flag6)
						{
							bool flag7 = flag;
							if (flag7)
							{
								string @string = XStringDefineProxy.GetString(Enum.GetName(typeof(XSysDefine), linkSys));
								XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("ChooseSYS_OR_NPC"), @string), @string, XStringDefineProxy.GetString("ChooseNPCFavor"), new ButtonClickEventHandler(this.OnClickSys), new ButtonClickEventHandler(this.OnShowNpc), false, XTempTipDefine.OD_START, 50);
							}
							else
							{
								XSingleton<XGameSysMgr>.singleton.OpenSystem(linkSys, 0UL);
							}
							return;
						}
						this.m_CurOperate = xdramaOperate;
						this.m_CurOperateSys = linkSys;
						xdramaOperate.ShowNpc(npc);
					}
				}
				else
				{
					bool flag8 = flag;
					if (flag8)
					{
						bool flag9 = this.favorDrama != null;
						if (flag9)
						{
							this.favorDrama.BDeprecated = false;
							this.favorDrama.ShowNpc(npc);
						}
					}
				}
			}
			XCameraCloseUpEventArgs @event = XEventPool<XCameraCloseUpEventArgs>.GetEvent();
			@event.Target = XSingleton<XInput>.singleton.LastNpc;
			@event.Firer = XSingleton<XScene>.singleton.GameCamera;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private bool OnClickSys(IXUIButton btn)
		{
			bool flag = this._npc == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSysDefine linkSys = (XSysDefine)this._npc._linkSys;
				XSingleton<XGameSysMgr>.singleton.OpenSystem(linkSys, 0UL);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
				result = true;
			}
			return result;
		}

		private bool OnShowNpc(IXUIButton btn)
		{
			bool flag = this.favorDrama != null && this._npc != null;
			if (flag)
			{
				this.favorDrama.BDeprecated = false;
				this.favorDrama.ShowNpc(this._npc);
				this._npc = null;
			}
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public void OnUIClose()
		{
			this.m_CurOperate = null;
			this.m_CurOperateSys = XSysDefine.XSys_Invalid;
			this.favorDrama.BDeprecated = true;
		}

		public XDramaOperate GetOpenedOperate(XSysDefine sys)
		{
			bool flag = this.m_CurOperateSys == sys;
			XDramaOperate result;
			if (flag)
			{
				result = this.m_CurOperate;
			}
			else
			{
				result = null;
			}
			return result;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.bBlockClose = false;
		}

		protected bool OnOperatingMentorship(XEventArgs e)
		{
			XDramaOperate openedOperate = this.GetOpenedOperate(XSysDefine.XSys_Mentorship);
			bool flag = openedOperate != null;
			if (flag)
			{
				XMentorRelationOpArgs xmentorRelationOpArgs = e as XMentorRelationOpArgs;
				XMentorshipPupilsDramaOperate xmentorshipPupilsDramaOperate = openedOperate as XMentorshipPupilsDramaOperate;
				bool flag2 = xmentorshipPupilsDramaOperate != null;
				if (flag2)
				{
					xmentorshipPupilsDramaOperate.OnMentorRelationOp(xmentorRelationOpArgs.oArg, xmentorRelationOpArgs.oRes);
				}
			}
			return true;
		}

		public XNPCFavorDrama GetFavorDrama()
		{
			bool flag = !this.favorDrama.BDeprecated;
			XNPCFavorDrama result;
			if (flag)
			{
				result = this.favorDrama;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DramaDocument");

		private Dictionary<XSysDefine, XDramaOperate> _DramaOperateDic = new Dictionary<XSysDefine, XDramaOperate>(default(XFastEnumIntEqualityComparer<XSysDefine>));

		public bool bBlockClose = false;

		private XSysDefine m_CurOperateSys;

		private XDramaOperate m_CurOperate;

		private XNPCFavorDrama favorDrama;

		private XNpc _npc = null;
	}
}
