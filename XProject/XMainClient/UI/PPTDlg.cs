using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001851 RID: 6225
	internal class PPTDlg : DlgBase<PPTDlg, PPTBehaviour>
	{
		// Token: 0x17003969 RID: 14697
		// (get) Token: 0x060102EE RID: 66286 RVA: 0x003E318C File Offset: 0x003E138C
		public override string fileName
		{
			get
			{
				return "Common/PPTDlg";
			}
		}

		// Token: 0x1700396A RID: 14698
		// (get) Token: 0x060102EF RID: 66287 RVA: 0x003E31A4 File Offset: 0x003E13A4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700396B RID: 14699
		// (get) Token: 0x060102F0 RID: 66288 RVA: 0x003E31B8 File Offset: 0x003E13B8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700396C RID: 14700
		// (get) Token: 0x060102F1 RID: 66289 RVA: 0x003E31CC File Offset: 0x003E13CC
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060102F2 RID: 66290 RVA: 0x003E31E0 File Offset: 0x003E13E0
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

		// Token: 0x060102F3 RID: 66291 RVA: 0x003E323C File Offset: 0x003E143C
		public void UnInit()
		{
			this.is_inited = false;
			this._targetPPT = (this._curPPT = 0);
		}

		// Token: 0x060102F4 RID: 66292 RVA: 0x003E3261 File Offset: 0x003E1461
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x060102F5 RID: 66293 RVA: 0x003E326C File Offset: 0x003E146C
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

		// Token: 0x060102F6 RID: 66294 RVA: 0x003E3364 File Offset: 0x003E1564
		public void ShowPPT(int ppt)
		{
			this.InitDlg();
			bool flag = ppt != this._targetPPT;
			if (flag)
			{
				this.SetPowerpoint(ppt);
			}
		}

		// Token: 0x060102F7 RID: 66295 RVA: 0x003E3394 File Offset: 0x003E1594
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

		// Token: 0x060102F8 RID: 66296 RVA: 0x003E3430 File Offset: 0x003E1630
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

		// Token: 0x040073EA RID: 29674
		private int _curPPT = 0;

		// Token: 0x040073EB RID: 29675
		private int _targetPPT = 0;

		// Token: 0x040073EC RID: 29676
		private float _PPTtime = 0f;

		// Token: 0x040073ED RID: 29677
		private const float _PPTExistTime = 2.5f;

		// Token: 0x040073EE RID: 29678
		private int delta = 0;

		// Token: 0x040073EF RID: 29679
		private DateTime _last_power_sound_time = DateTime.Now;

		// Token: 0x040073F0 RID: 29680
		private bool is_inited = false;
	}
}
