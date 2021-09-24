using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PPTDlg : DlgBase<PPTDlg, PPTBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/PPTDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public void InitDlg()
		{
			bool flag = !this.is_inited;
			if (flag)
			{
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				XPlayerAttributes xplayerAttributes = player.Attributes as XPlayerAttributes;
				this._curPPT = (int)xplayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
				this._targetPPT = this._curPPT;
				this.is_inited = true;
			}
		}

		public void UnInit()
		{
			this.is_inited = false;
			this._targetPPT = (this._curPPT = 0);
		}

		protected override void Init()
		{
			base.Init();
		}

		public override void OnUpdate()
		{
			bool flag = this._curPPT != this._targetPPT;
			if (flag)
			{
				this._curPPT += this.delta;
				bool flag2 = (this.delta > 0 && this._curPPT >= this._targetPPT) || (this.delta < 0 && this._curPPT <= this._targetPPT);
				if (flag2)
				{
					this._curPPT = this._targetPPT;
					this._PPTtime = Time.time;
				}
				base.uiBehaviour.m_PPT.SetText(this._curPPT.ToString());
			}
			else
			{
				bool flag3 = this._PPTtime > 0f && Time.time - this._PPTtime > 2.5f;
				if (flag3)
				{
					this._PPTtime = 0f;
					bool flag4 = base.IsVisible();
					if (flag4)
					{
						this.SetVisible(false, true);
					}
				}
			}
		}

		public void ShowPPT(int ppt)
		{
			this.InitDlg();
			bool flag = ppt != this._targetPPT;
			if (flag)
			{
				this.SetPowerpoint(ppt);
			}
		}

		private void SetPowerpoint(int ppt)
		{
			bool flag = ppt > this._curPPT;
			if (flag)
			{
				bool flag2 = (DateTime.Now - this._last_power_sound_time).TotalMilliseconds > 1000.0;
				if (flag2)
				{
					this._last_power_sound_time = DateTime.Now;
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/zhandoulitishen", true, AudioChannel.Action);
				}
			}
			bool flag3 = ppt != this._targetPPT;
			if (flag3)
			{
				this.OnPowerpointChanged(this._targetPPT, ppt);
			}
			else
			{
				this._targetPPT = ppt;
				this._curPPT = ppt;
			}
		}

		public void OnPowerpointChanged(int oldValue, int newValue)
		{
			this._curPPT = oldValue;
			this._targetPPT = newValue;
			this._PPTtime = 0f;
			int num = newValue - oldValue;
			bool flag = num > 0;
			if (flag)
			{
				this.SetVisible(true, true);
				base.uiBehaviour.m_IncreasePPT.SetVisible(true);
				base.uiBehaviour.m_IncreasePPT.SetText(num.ToString());
				base.uiBehaviour.m_DecreasePPT.SetVisible(false);
			}
			else
			{
				bool flag2 = num < 0;
				if (flag2)
				{
					this.SetVisible(true, true);
					base.uiBehaviour.m_IncreasePPT.SetVisible(false);
					base.uiBehaviour.m_DecreasePPT.SetText((-num).ToString());
					base.uiBehaviour.m_DecreasePPT.SetVisible(true);
				}
			}
			this.delta = (newValue - oldValue) / 30;
			bool flag3 = this.delta == 0;
			if (flag3)
			{
				this.delta = 1;
			}
		}

		private int _curPPT = 0;

		private int _targetPPT = 0;

		private float _PPTtime = 0f;

		private const float _PPTExistTime = 2.5f;

		private int delta = 0;

		private DateTime _last_power_sound_time = DateTime.Now;

		private bool is_inited = false;
	}
}
