using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XSecurityMobInfo
	{

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

		public void Reset()
		{
			for (int i = 0; i < this._MobInfosList.Count; i++)
			{
				this._MobInfosList[i].Recycle();
			}
			this._MobInfosList.Clear();
			this._MobInfos.Clear();
		}

		public void Merge(XSecurityMobInfo other)
		{
			for (int i = 0; i < other._MobInfosList.Count; i++)
			{
				XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(other._MobInfosList[i]._TemplateID);
				mobInfo.Merge(other._MobInfosList[i]);
			}
		}

		public void OnCast(uint templateID, int count)
		{
			XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(templateID);
			mobInfo._CastCount += count;
		}

		public void OnCastDamage(uint templateID, double value)
		{
			XSecurityMobInfo.MobInfo mobInfo = this._TryGetMobInfo(templateID);
			mobInfo._AttackTotal += (float)value;
		}

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

		public List<XSecurityMobInfo.MobInfo> MobInfoList
		{
			get
			{
				return this._MobInfosList;
			}
		}

		public XSecurityMobInfo.MobInfo GetMobInfoByID(uint templateID)
		{
			XSecurityMobInfo.MobInfo result;
			this._MobInfos.TryGetValue(templateID, out result);
			return result;
		}

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

		private List<XSecurityMobInfo.MobInfo> _MobInfosList = new List<XSecurityMobInfo.MobInfo>();

		private Dictionary<uint, XSecurityMobInfo.MobInfo> _MobInfos = new Dictionary<uint, XSecurityMobInfo.MobInfo>();

		public class MobInfo : XDataBase
		{

			public void Reset()
			{
				this._TemplateID = 0U;
				this._CastCount = 0;
				this._AttackTotal = 0f;
			}

			public void Merge(XSecurityMobInfo.MobInfo other)
			{
				bool flag = other == null;
				if (!flag)
				{
					this._AttackTotal += other._AttackTotal;
					this._CastCount += other._CastCount;
				}
			}

			public override void Init()
			{
				base.Init();
				this.Reset();
			}

			public override void Recycle()
			{
				base.Recycle();
				XDataPool<XSecurityMobInfo.MobInfo>.Recycle(this);
			}

			public uint _TemplateID;

			public int _CastCount;

			public float _AttackTotal;
		}
	}
}
