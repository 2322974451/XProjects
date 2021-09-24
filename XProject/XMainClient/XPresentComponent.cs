using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPresentComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XPresentComponent.uuID;
			}
		}

		public string SkillPrefix
		{
			get
			{
				return this._skill_prefix;
			}
		}

		public string ActionPrefix
		{
			get
			{
				return this._action_prefix;
			}
		}

		public string CurvePrefix
		{
			get
			{
				return this._curve_prefix;
			}
		}

		public bool IsShowUp { get; set; }

		public Vector3 RadiusOffset
		{
			get
			{
				return this._radius_offset;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.IsShowUp = false;
			this.InitPresent(this._entity.PresentID);
		}

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

		public XEntityPresentation.RowData PresentLib
		{
			get
			{
				return this._present_data;
			}
		}

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

		public override void OnDetachFromHost()
		{
			this._present_data = null;
			this._entity.EngineObject.LocalScale = Vector3.one;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._show_up_token);
			base.OnDetachFromHost();
		}

		public void OnReadyFight(object o)
		{
			XSingleton<XEntityMgr>.singleton.Puppets(this._entity, false, false);
			this.IsShowUp = false;
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Presentation");

		private XEntityPresentation.RowData _present_data = null;

		private uint _show_up_token = 0U;

		private string _skill_prefix = null;

		private string _action_prefix = null;

		private string _curve_prefix = null;

		protected Vector3 _radius_offset = Vector3.zero;
	}
}
