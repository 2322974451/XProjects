using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XElapseTimer
	{

		public float LeftTime
		{
			get
			{
				return this.m_LeftTime;
			}
			set
			{
				this.m_LeftTime = value;
				this.m_OriLeftTime = this.m_LeftTime;
				this.m_LastTime = -1f;
				this.m_PassTime = 0f;
			}
		}

		public float PassTime
		{
			get
			{
				return this.m_PassTime;
			}
		}

		public void Update()
		{
			this.m_PassTime = 0f;
			bool flag = this.m_LastTime < 0f;
			if (flag)
			{
				this.m_LastTime = Time.time;
			}
			else
			{
				this.m_PassTime = Time.time - this.m_LastTime;
			}
			this.m_LeftTime = this.m_OriLeftTime - this.m_PassTime;
			bool flag2 = this.m_LeftTime < 0f;
			if (flag2)
			{
				this.m_LeftTime = 0f;
			}
		}

		private float m_OriLeftTime = 0f;

		private float m_LeftTime = 0f;

		private float m_LastTime = -1f;

		private float m_PassTime = 0f;
	}
}
