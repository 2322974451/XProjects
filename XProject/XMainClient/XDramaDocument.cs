using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A92 RID: 2706
	internal class XDramaDocument : XDocComponent
	{
		// Token: 0x17002FD7 RID: 12247
		// (get) Token: 0x0600A4B1 RID: 42161 RVA: 0x001C8ACC File Offset: 0x001C6CCC
		public override uint ID
		{
			get
			{
				return XDramaDocument.uuID;
			}
		}

		// Token: 0x17002FD8 RID: 12248
		// (get) Token: 0x0600A4B2 RID: 42162 RVA: 0x001C8AE4 File Offset: 0x001C6CE4
		public XDramaOperate CurOperate
		{
			get
			{
				return this.m_CurOperate;
			}
		}

		// Token: 0x0600A4B3 RID: 42163 RVA: 0x001C8AFC File Offset: 0x001C6CFC
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

		// Token: 0x0600A4B4 RID: 42164 RVA: 0x001C8B89 File Offset: 0x001C6D89
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_MentorshipRelationOperation, new XComponent.XEventHandler(this.OnOperatingMentorship));
		}

		// Token: 0x0600A4B5 RID: 42165 RVA: 0x001C8BAC File Offset: 0x001C6DAC
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

		// Token: 0x0600A4B6 RID: 42166 RVA: 0x001C8C90 File Offset: 0x001C6E90
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

		// Token: 0x0600A4B7 RID: 42167 RVA: 0x001C8E98 File Offset: 0x001C7098
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

		// Token: 0x0600A4B8 RID: 42168 RVA: 0x001C8EE4 File Offset: 0x001C70E4
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

		// Token: 0x0600A4B9 RID: 42169 RVA: 0x001C8F43 File Offset: 0x001C7143
		public void OnUIClose()
		{
			this.m_CurOperate = null;
			this.m_CurOperateSys = XSysDefine.XSys_Invalid;
			this.favorDrama.BDeprecated = true;
		}

		// Token: 0x0600A4BA RID: 42170 RVA: 0x001C8F60 File Offset: 0x001C7160
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

		// Token: 0x0600A4BB RID: 42171 RVA: 0x001C8F89 File Offset: 0x001C7189
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.bBlockClose = false;
		}

		// Token: 0x0600A4BC RID: 42172 RVA: 0x001C8F94 File Offset: 0x001C7194
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

		// Token: 0x0600A4BD RID: 42173 RVA: 0x001C8FE8 File Offset: 0x001C71E8
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

		// Token: 0x04003BE6 RID: 15334
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DramaDocument");

		// Token: 0x04003BE7 RID: 15335
		private Dictionary<XSysDefine, XDramaOperate> _DramaOperateDic = new Dictionary<XSysDefine, XDramaOperate>(default(XFastEnumIntEqualityComparer<XSysDefine>));

		// Token: 0x04003BE8 RID: 15336
		public bool bBlockClose = false;

		// Token: 0x04003BE9 RID: 15337
		private XSysDefine m_CurOperateSys;

		// Token: 0x04003BEA RID: 15338
		private XDramaOperate m_CurOperate;

		// Token: 0x04003BEB RID: 15339
		private XNPCFavorDrama favorDrama;

		// Token: 0x04003BEC RID: 15340
		private XNpc _npc = null;
	}
}
