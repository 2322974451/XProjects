using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000893 RID: 2195
	internal class XPieceWiseDataMgr
	{
		// Token: 0x060085C2 RID: 34242 RVA: 0x0010BC80 File Offset: 0x00109E80
		public void SetRange(double xmin, double ymin, double xmax, double ymax)
		{
			this.m_Min.x = xmin;
			this.m_Min.y = ymin;
			this.m_Max.x = xmax;
			this.m_Max.y = ymax;
			this.bRangeIsSet = true;
			bool flag = this.bDataIsSet;
			if (flag)
			{
				this.m_Datas.Add(this.m_Min);
				this.m_Datas.Add(this.m_Max);
				this.m_Datas.Sort();
			}
		}

		// Token: 0x060085C3 RID: 34243 RVA: 0x0010BD04 File Offset: 0x00109F04
		public void Init(ref SeqListRef<float> datas)
		{
			bool flag = false;
			bool flag2 = false;
			this.m_Datas.Clear();
			for (int i = 0; i < datas.Count; i++)
			{
				XOrderData<double, double> xorderData;
				xorderData.x = (double)datas[i, 0];
				xorderData.y = (double)datas[i, 1];
				this.m_Datas.Add(xorderData);
				bool flag3 = this.bRangeIsSet;
				if (flag3)
				{
					bool flag4 = xorderData.x == this.m_Min.x;
					if (flag4)
					{
						flag = true;
					}
					else
					{
						bool flag5 = xorderData.x == this.m_Max.x;
						if (flag5)
						{
							flag2 = true;
						}
					}
				}
			}
			bool flag6 = this.bRangeIsSet;
			if (flag6)
			{
				bool flag7 = !flag;
				if (flag7)
				{
					this.m_Datas.Add(this.m_Min);
				}
				bool flag8 = !flag2;
				if (flag8)
				{
					this.m_Datas.Add(this.m_Max);
				}
			}
			this.m_Datas.Sort();
			this.bDataIsSet = true;
		}

		// Token: 0x060085C4 RID: 34244 RVA: 0x0010BE0C File Offset: 0x0010A00C
		public double GetData(double x)
		{
			for (int i = 1; i < this.m_Datas.Count; i++)
			{
				bool flag = this.m_Datas[i].x >= x;
				if (flag)
				{
					XOrderData<double, double> xorderData = this.m_Datas[i - 1];
					XOrderData<double, double> xorderData2 = this.m_Datas[i];
					double num = xorderData2.x - xorderData.x;
					bool flag2 = num == 0.0;
					if (flag2)
					{
						num = 1.0;
					}
					return xorderData.y + (xorderData2.y - xorderData.y) * (x - xorderData.x) / num;
				}
			}
			return 0.0;
		}

		// Token: 0x04002993 RID: 10643
		private List<XOrderData<double, double>> m_Datas = new List<XOrderData<double, double>>();

		// Token: 0x04002994 RID: 10644
		private bool bRangeIsSet = false;

		// Token: 0x04002995 RID: 10645
		private bool bDataIsSet = false;

		// Token: 0x04002996 RID: 10646
		private XOrderData<double, double> m_Min;

		// Token: 0x04002997 RID: 10647
		private XOrderData<double, double> m_Max;
	}
}
