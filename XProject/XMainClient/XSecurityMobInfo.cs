using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000B14 RID: 2836
	internal class XSecurityMobInfo
	{
		// Token: 0x0600A6E9 RID: 42729 RVA: 0x001D6D80 File Offset: 0x001D4F80
		private XSecurityMobInfo.MobInfo _TryGetMobInfo(uint templateID)
		{
			XSecurityMobInfo.MobInfo data;
			bool flag = !this._MobInfos.TryGetValue(templateID, out data);
			if (flag)
			{
				data = XDataPool<XSecurityMobInfo.MobInfo>.GetData();
				data._TemplateID = templateID;
				this._MobInfosList.Add(data);
				this._MobInfos.Add(templateID, data);
			}
			return data;
		}

		// Token: 0x0600A6EA RID: 42730 RVA: 0x001D6DD4 File Offset: 0x001D4FD4
		public void Reset()
		{
			for (int i = 0; i < this._MobInfosList.Count; i++)
			{
				this._MobInfosList[i].Recycle();
			}
			this._MobInfosList.Clear();
			this._MobInfos.Clear();
		}

		// Token: 0x0600A6EB RID: 42731 RVA: 0x001D6E28 File Offset: 0x001D5028
		public void Merge(XSecurityMobInfo other)
		{
			for (int i = 0; i < other._MobInfosList.Count; i++)
			{
				XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(other._MobInfosList[i]._TemplateID);
				mobInfo.Merge(other._MobInfosList[i]);
			}
		}

		// Token: 0x0600A6EC RID: 42732 RVA: 0x001D6E80 File Offset: 0x001D5080
		public void OnCast(uint templateID, int count)
		{
			XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(templateID);
			mobInfo._CastCount += count;
		}

		// Token: 0x0600A6ED RID: 42733 RVA: 0x001D6EA4 File Offset: 0x001D50A4
		public void OnCastDamage(uint templateID, double value)
		{
			XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(templateID);
			mobInfo._AttackTotal += (float)value;
		}

		// Token: 0x0600A6EE RID: 42734 RVA: 0x001D6ECC File Offset: 0x001D50CC
		public void Append(XEntity entity)
		{
			XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(entity);
			bool flag = xsecurityStatistics == null || !xsecurityStatistics.bValid;
			if (!flag)
			{
				XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(entity.TypeID);
				mobInfo._CastCount++;
				mobInfo._AttackTotal += xsecurityStatistics.DamageStatistics._AttackTotal;
			}
		}

		// Token: 0x17002FFB RID: 12283
		// (get) Token: 0x0600A6EF RID: 42735 RVA: 0x001D6F2C File Offset: 0x001D512C
		public List<XSecurityMobInfo.MobInfo> MobInfoList
		{
			get
			{
				return this._MobInfosList;
			}
		}

		// Token: 0x0600A6F0 RID: 42736 RVA: 0x001D6F44 File Offset: 0x001D5144
		public XSecurityMobInfo.MobInfo GetMobInfoByID(uint templateID)
		{
			XSecurityMobInfo.MobInfo result;
			this._MobInfos.TryGetValue(templateID, out result);
			return result;
		}

		// Token: 0x0600A6F1 RID: 42737 RVA: 0x001D6F68 File Offset: 0x001D5168
		public static XSecurityMobInfo TryGetStatistics(XEntity entity)
		{
			XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(entity);
			bool flag = xsecurityStatistics == null;
			XSecurityMobInfo result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = xsecurityStatistics.MobStatistics;
			}
			return result;
		}

		// Token: 0x04003D66 RID: 15718
		private List<XSecurityMobInfo.MobInfo> _MobInfosList = new List<XSecurityMobInfo.MobInfo>();

		// Token: 0x04003D67 RID: 15719
		private Dictionary<uint, XSecurityMobInfo.MobInfo> _MobInfos = new Dictionary<uint, XSecurityMobInfo.MobInfo>();

		// Token: 0x0200199A RID: 6554
		public class MobInfo : XDataBase
		{
			// Token: 0x06011036 RID: 69686 RVA: 0x00453E23 File Offset: 0x00452023
			public void Reset()
			{
				this._TemplateID = 0U;
				this._CastCount = 0;
				this._AttackTotal = 0f;
			}

			// Token: 0x06011037 RID: 69687 RVA: 0x00453E40 File Offset: 0x00452040
			public void Merge(XSecurityMobInfo.MobInfo other)
			{
				bool flag = other == null;
				if (!flag)
				{
					this._AttackTotal += other._AttackTotal;
					this._CastCount += other._CastCount;
				}
			}

			// Token: 0x06011038 RID: 69688 RVA: 0x00453E7E File Offset: 0x0045207E
			public override void Init()
			{
				base.Init();
				this.Reset();
			}

			// Token: 0x06011039 RID: 69689 RVA: 0x00453E8F File Offset: 0x0045208F
			public override void Recycle()
			{
				base.Recycle();
				XDataPool<XSecurityMobInfo.MobInfo>.Recycle(this);
			}

			// Token: 0x04007F33 RID: 32563
			public uint _TemplateID;

			// Token: 0x04007F34 RID: 32564
			public int _CastCount;

			// Token: 0x04007F35 RID: 32565
			public float _AttackTotal;
		}
	}
}
