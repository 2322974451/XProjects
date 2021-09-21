using System;
using UILib;

namespace XMainClient
{
	// Token: 0x02000A3A RID: 2618
	internal class RecruitStepCounter : DlgHandlerBase
	{
		// Token: 0x06009F55 RID: 40789 RVA: 0x001A64E4 File Offset: 0x001A46E4
		public int GetTime()
		{
			return this.limit_step * this.limit_cur;
		}

		// Token: 0x17002ED8 RID: 11992
		// (get) Token: 0x06009F56 RID: 40790 RVA: 0x001A6504 File Offset: 0x001A4704
		public int Step
		{
			get
			{
				return this.limit_step;
			}
		}

		// Token: 0x17002ED9 RID: 11993
		// (get) Token: 0x06009F57 RID: 40791 RVA: 0x001A651C File Offset: 0x001A471C
		public int Cur
		{
			get
			{
				return this.limit_cur;
			}
		}

		// Token: 0x06009F58 RID: 40792 RVA: 0x001A6534 File Offset: 0x001A4734
		protected override void Init()
		{
			base.Init();
			this.m_AddBtn = (base.transform.Find("Add").GetComponent("XUIButton") as IXUIButton);
			this.m_MinusBtn = (base.transform.Find("Minus").GetComponent("XUIButton") as IXUIButton);
			this.m_timeLabel = (base.transform.Find("buynum").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06009F59 RID: 40793 RVA: 0x001A65B8 File Offset: 0x001A47B8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_AddBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddClick));
			this.m_MinusBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMinusBtn));
		}

		// Token: 0x06009F5A RID: 40794 RVA: 0x001A65F4 File Offset: 0x001A47F4
		private bool OnAddClick(IXUIButton btn)
		{
			bool flag = this.limit_max == -1;
			if (flag)
			{
				this.limit_cur += this.limit_step;
			}
			else
			{
				bool flag2 = this.limit_cur < this.limit_max - this.limit_step;
				if (flag2)
				{
					this.limit_cur += this.limit_step;
				}
				else
				{
					this.limit_cur = this.limit_max - this.limit_step;
				}
			}
			this.Excute();
			return true;
		}

		// Token: 0x06009F5B RID: 40795 RVA: 0x001A6678 File Offset: 0x001A4878
		private bool OnMinusBtn(IXUIButton btn)
		{
			bool flag = this.limit_min == -1;
			if (flag)
			{
				this.limit_cur -= this.limit_step;
			}
			else
			{
				bool flag2 = this.limit_cur - this.limit_step > this.limit_min;
				if (flag2)
				{
					this.limit_cur -= this.limit_step;
				}
				else
				{
					this.limit_cur = this.limit_min;
				}
			}
			this.Excute();
			return true;
		}

		// Token: 0x06009F5C RID: 40796 RVA: 0x001A66F2 File Offset: 0x001A48F2
		public void Setup(int min, int max, int cur, int step = 1, RecruitStepCounterUpdate counter = null)
		{
			this.limit_max = max;
			this.limit_min = min;
			this.limit_normal = cur;
			this.limit_step = step;
			this.limit_cur = cur;
			this.m_counter = counter;
			this.Excute();
		}

		// Token: 0x06009F5D RID: 40797 RVA: 0x001A6728 File Offset: 0x001A4928
		private void Excute()
		{
			bool flag = this.m_counter != null;
			if (flag)
			{
				this.m_counter(this.m_timeLabel);
			}
		}

		// Token: 0x040038D5 RID: 14549
		private IXUIButton m_AddBtn;

		// Token: 0x040038D6 RID: 14550
		private IXUIButton m_MinusBtn;

		// Token: 0x040038D7 RID: 14551
		private IXUILabel m_timeLabel;

		// Token: 0x040038D8 RID: 14552
		private int limit_max = 0;

		// Token: 0x040038D9 RID: 14553
		private int limit_min = 0;

		// Token: 0x040038DA RID: 14554
		private int limit_normal = 0;

		// Token: 0x040038DB RID: 14555
		private int limit_cur = 0;

		// Token: 0x040038DC RID: 14556
		private int limit_step = 0;

		// Token: 0x040038DD RID: 14557
		private RecruitStepCounterUpdate m_counter;
	}
}
