using System;
using UILib;

namespace XMainClient
{

	internal class RecruitStepCounter : DlgHandlerBase
	{

		public int GetTime()
		{
			return this.limit_step * this.limit_cur;
		}

		public int Step
		{
			get
			{
				return this.limit_step;
			}
		}

		public int Cur
		{
			get
			{
				return this.limit_cur;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_AddBtn = (base.transform.Find("Add").GetComponent("XUIButton") as IXUIButton);
			this.m_MinusBtn = (base.transform.Find("Minus").GetComponent("XUIButton") as IXUIButton);
			this.m_timeLabel = (base.transform.Find("buynum").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_AddBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddClick));
			this.m_MinusBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMinusBtn));
		}

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

		private void Excute()
		{
			bool flag = this.m_counter != null;
			if (flag)
			{
				this.m_counter(this.m_timeLabel);
			}
		}

		private IXUIButton m_AddBtn;

		private IXUIButton m_MinusBtn;

		private IXUILabel m_timeLabel;

		private int limit_max = 0;

		private int limit_min = 0;

		private int limit_normal = 0;

		private int limit_cur = 0;

		private int limit_step = 0;

		private RecruitStepCounterUpdate m_counter;
	}
}
