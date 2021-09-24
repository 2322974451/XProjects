using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XAttrData : XDataBase
	{

		public string Title { get; set; }

		public string StrEmpty { get; set; }

		public List<string> Left
		{
			get
			{
				return this.m_Left;
			}
		}

		public List<string> Right
		{
			get
			{
				return this.m_Right;
			}
		}

		public AttriDataType Type { get; set; }

		public void Reset()
		{
			this.m_Left.Clear();
			this.m_Right.Clear();
			this.Title = string.Empty;
			this.StrEmpty = string.Empty;
		}

		public override void Init()
		{
			base.Init();
			this.Reset();
		}

		public override void Recycle()
		{
			XDataPool<XAttrData>.Recycle(this);
			this.Reset();
		}

		private List<string> m_Left = new List<string>();

		private List<string> m_Right = new List<string>();
	}
}
