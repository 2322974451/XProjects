using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FDC RID: 4060
	internal class XPresentComponent : XComponent
	{
		// Token: 0x170036D1 RID: 14033
		// (get) Token: 0x0600D2E8 RID: 53992 RVA: 0x003161A4 File Offset: 0x003143A4
		public override uint ID
		{
			get
			{
				return XPresentComponent.uuID;
			}
		}

		// Token: 0x170036D2 RID: 14034
		// (get) Token: 0x0600D2E9 RID: 53993 RVA: 0x003161BC File Offset: 0x003143BC
		public string SkillPrefix
		{
			get
			{
				return this._skill_prefix;
			}
		}

		// Token: 0x170036D3 RID: 14035
		// (get) Token: 0x0600D2EA RID: 53994 RVA: 0x003161D4 File Offset: 0x003143D4
		public string ActionPrefix
		{
			get
			{
				return this._action_prefix;
			}
		}

		// Token: 0x170036D4 RID: 14036
		// (get) Token: 0x0600D2EB RID: 53995 RVA: 0x003161EC File Offset: 0x003143EC
		public string CurvePrefix
		{
			get
			{
				return this._curve_prefix;
			}
		}

		// Token: 0x170036D5 RID: 14037
		// (get) Token: 0x0600D2EC RID: 53996 RVA: 0x00316204 File Offset: 0x00314404
		// (set) Token: 0x0600D2ED RID: 53997 RVA: 0x0031620C File Offset: 0x0031440C
		public bool IsShowUp { get; set; }

		// Token: 0x170036D6 RID: 14038
		// (get) Token: 0x0600D2EE RID: 53998 RVA: 0x00316218 File Offset: 0x00314418
		public Vector3 RadiusOffset
		{
			get
			{
				return this._radius_offset;
			}
		}

		// Token: 0x0600D2EF RID: 53999 RVA: 0x00316230 File Offset: 0x00314430
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.IsShowUp = false;
			this.InitPresent(this._entity.PresentID);
		}

		// Token: 0x0600D2F0 RID: 54000 RVA: 0x00316258 File Offset: 0x00314458
		public override void Attached()
		{
			this._entity.Scale = this._present_data.Scale;
			bool flag = this._present_data.BoundRadiusOffset != null && this._present_data.BoundRadiusOffset.Length != 0;
			if (flag)
			{
				this._radius_offset.Set(this._present_data.BoundRadiusOffset[0], 0f, this._present_data.BoundRadiusOffset[1]);
			}
			else
			{
				this._radius_offset.Set(0f, 0f, 0f);
			}
			bool flag2 = this._entity.EngineObject != null;
			if (flag2)
			{
				Vector3 localScale = Vector3.one * this._entity.Scale;
				this._entity.EngineObject.LocalScale = localScale;
			}
		}

		// Token: 0x170036D7 RID: 14039
		// (get) Token: 0x0600D2F1 RID: 54001 RVA: 0x00316324 File Offset: 0x00314524
		public XEntityPresentation.RowData PresentLib
		{
			get
			{
				return this._present_data;
			}
		}

		// Token: 0x0600D2F2 RID: 54002 RVA: 0x0031633C File Offset: 0x0031453C
		public void InitPresent(uint present_id)
		{
			this._present_data = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(present_id);
			this._skill_prefix = "SkillPackage/" + this._present_data.SkillLocation;
			this._action_prefix = "Animation/" + this._present_data.AnimLocation;
			this._curve_prefix = "Curve/" + this._present_data.CurveLocation;
			bool flag = XStateMachine._EnableAtor && this._entity.EngineObject != null;
			if (flag)
			{
				this._entity.EngineObject.InitAnim();
			}
			bool flag2 = this._entity.Attributes != null && this._entity.Attributes.TypeID == XSingleton<XSceneMgr>.singleton.GetDriveID(XSingleton<XScene>.singleton.SceneID);
			if (flag2)
			{
				XSingleton<XScene>.singleton.Dirver = this._entity;
			}
		}

		// Token: 0x0600D2F3 RID: 54003 RVA: 0x0031642C File Offset: 0x0031462C
		public void ShowUp()
		{
			bool flag = this._entity.HasComeOnPresent() && !this._entity.Attributes.MidwayEnter;
			if (flag)
			{
				this.IsShowUp = true;
				XSingleton<XEntityMgr>.singleton.Puppets(this._entity, false, true);
				this._entity.Net.ReportSkillAction(null, this._entity.SkillMgr.GetAppearIdentity(), -1);
				this._show_up_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.OnReadyFight), null);
			}
			else
			{
				XSingleton<XEntityMgr>.singleton.Puppets(this._entity, false, false);
			}
		}

		// Token: 0x0600D2F4 RID: 54004 RVA: 0x003164D8 File Offset: 0x003146D8
		public override void OnDetachFromHost()
		{
			this._present_data = null;
			this._entity.EngineObject.LocalScale = Vector3.one;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._show_up_token);
			base.OnDetachFromHost();
		}

		// Token: 0x0600D2F5 RID: 54005 RVA: 0x00316510 File Offset: 0x00314710
		public void OnReadyFight(object o)
		{
			XSingleton<XEntityMgr>.singleton.Puppets(this._entity, false, false);
			this.IsShowUp = false;
		}

		// Token: 0x0600D2F6 RID: 54006 RVA: 0x00316530 File Offset: 0x00314730
		public void OnTransform(XEntity src, bool to)
		{
			if (to)
			{
				float num = src.Scale / src.Present.PresentLib.Scale * this._present_data.Scale;
				this._entity.Scale = num;
				bool flag = this._entity.EngineObject != null;
				if (flag)
				{
					Vector3 localScale = Vector3.one * num;
					this._entity.EngineObject.LocalScale = localScale;
				}
			}
			else
			{
				bool flag2 = this._entity.EngineObject != null;
				if (flag2)
				{
					this._entity.Scale = this._present_data.Scale;
					Vector3 localScale2 = Vector3.one * this._present_data.Scale;
					this._entity.EngineObject.LocalScale = localScale2;
				}
			}
		}

		// Token: 0x04005FD7 RID: 24535
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Presentation");

		// Token: 0x04005FD8 RID: 24536
		private XEntityPresentation.RowData _present_data = null;

		// Token: 0x04005FD9 RID: 24537
		private uint _show_up_token = 0U;

		// Token: 0x04005FDA RID: 24538
		private string _skill_prefix = null;

		// Token: 0x04005FDB RID: 24539
		private string _action_prefix = null;

		// Token: 0x04005FDC RID: 24540
		private string _curve_prefix = null;

		// Token: 0x04005FDE RID: 24542
		protected Vector3 _radius_offset = Vector3.zero;
	}
}
