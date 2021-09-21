using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200058A RID: 1418
	[ProtoContract(Name = "HeroRankData")]
	[Serializable]
	public class HeroRankData : IExtensible
	{
		// Token: 0x17001709 RID: 5897
		// (get) Token: 0x06004AE3 RID: 19171 RVA: 0x0008E624 File Offset: 0x0008C824
		// (set) Token: 0x06004AE4 RID: 19172 RVA: 0x0008E658 File Offset: 0x0008C858
		[ProtoMember(1, IsRequired = false, Name = "eloPoint", DataFormat = DataFormat.TwosComplement)]
		public double eloPoint
		{
			get
			{
				return this._eloPoint ?? 0.0;
			}
			set
			{
				this._eloPoint = new double?(value);
			}
		}

		// Token: 0x1700170A RID: 5898
		// (get) Token: 0x06004AE5 RID: 19173 RVA: 0x0008E668 File Offset: 0x0008C868
		// (set) Token: 0x06004AE6 RID: 19174 RVA: 0x0008E688 File Offset: 0x0008C888
		[XmlIgnore]
		[Browsable(false)]
		public bool eloPointSpecified
		{
			get
			{
				return this._eloPoint != null;
			}
			set
			{
				bool flag = value == (this._eloPoint == null);
				if (flag)
				{
					this._eloPoint = (value ? new double?(this.eloPoint) : null);
				}
			}
		}

		// Token: 0x06004AE7 RID: 19175 RVA: 0x0008E6CC File Offset: 0x0008C8CC
		private bool ShouldSerializeeloPoint()
		{
			return this.eloPointSpecified;
		}

		// Token: 0x06004AE8 RID: 19176 RVA: 0x0008E6E4 File Offset: 0x0008C8E4
		private void ReseteloPoint()
		{
			this.eloPointSpecified = false;
		}

		// Token: 0x1700170B RID: 5899
		// (get) Token: 0x06004AE9 RID: 19177 RVA: 0x0008E6F0 File Offset: 0x0008C8F0
		// (set) Token: 0x06004AEA RID: 19178 RVA: 0x0008E71C File Offset: 0x0008C91C
		[ProtoMember(2, IsRequired = false, Name = "totalNum", DataFormat = DataFormat.TwosComplement)]
		public uint totalNum
		{
			get
			{
				return this._totalNum ?? 0U;
			}
			set
			{
				this._totalNum = new uint?(value);
			}
		}

		// Token: 0x1700170C RID: 5900
		// (get) Token: 0x06004AEB RID: 19179 RVA: 0x0008E72C File Offset: 0x0008C92C
		// (set) Token: 0x06004AEC RID: 19180 RVA: 0x0008E74C File Offset: 0x0008C94C
		[XmlIgnore]
		[Browsable(false)]
		public bool totalNumSpecified
		{
			get
			{
				return this._totalNum != null;
			}
			set
			{
				bool flag = value == (this._totalNum == null);
				if (flag)
				{
					this._totalNum = (value ? new uint?(this.totalNum) : null);
				}
			}
		}

		// Token: 0x06004AED RID: 19181 RVA: 0x0008E790 File Offset: 0x0008C990
		private bool ShouldSerializetotalNum()
		{
			return this.totalNumSpecified;
		}

		// Token: 0x06004AEE RID: 19182 RVA: 0x0008E7A8 File Offset: 0x0008C9A8
		private void ResettotalNum()
		{
			this.totalNumSpecified = false;
		}

		// Token: 0x1700170D RID: 5901
		// (get) Token: 0x06004AEF RID: 19183 RVA: 0x0008E7B4 File Offset: 0x0008C9B4
		// (set) Token: 0x06004AF0 RID: 19184 RVA: 0x0008E7E0 File Offset: 0x0008C9E0
		[ProtoMember(3, IsRequired = false, Name = "winNum", DataFormat = DataFormat.TwosComplement)]
		public uint winNum
		{
			get
			{
				return this._winNum ?? 0U;
			}
			set
			{
				this._winNum = new uint?(value);
			}
		}

		// Token: 0x1700170E RID: 5902
		// (get) Token: 0x06004AF1 RID: 19185 RVA: 0x0008E7F0 File Offset: 0x0008C9F0
		// (set) Token: 0x06004AF2 RID: 19186 RVA: 0x0008E810 File Offset: 0x0008CA10
		[XmlIgnore]
		[Browsable(false)]
		public bool winNumSpecified
		{
			get
			{
				return this._winNum != null;
			}
			set
			{
				bool flag = value == (this._winNum == null);
				if (flag)
				{
					this._winNum = (value ? new uint?(this.winNum) : null);
				}
			}
		}

		// Token: 0x06004AF3 RID: 19187 RVA: 0x0008E854 File Offset: 0x0008CA54
		private bool ShouldSerializewinNum()
		{
			return this.winNumSpecified;
		}

		// Token: 0x06004AF4 RID: 19188 RVA: 0x0008E86C File Offset: 0x0008CA6C
		private void ResetwinNum()
		{
			this.winNumSpecified = false;
		}

		// Token: 0x1700170F RID: 5903
		// (get) Token: 0x06004AF5 RID: 19189 RVA: 0x0008E878 File Offset: 0x0008CA78
		// (set) Token: 0x06004AF6 RID: 19190 RVA: 0x0008E8A4 File Offset: 0x0008CAA4
		[ProtoMember(4, IsRequired = false, Name = "continueWinNum", DataFormat = DataFormat.TwosComplement)]
		public uint continueWinNum
		{
			get
			{
				return this._continueWinNum ?? 0U;
			}
			set
			{
				this._continueWinNum = new uint?(value);
			}
		}

		// Token: 0x17001710 RID: 5904
		// (get) Token: 0x06004AF7 RID: 19191 RVA: 0x0008E8B4 File Offset: 0x0008CAB4
		// (set) Token: 0x06004AF8 RID: 19192 RVA: 0x0008E8D4 File Offset: 0x0008CAD4
		[XmlIgnore]
		[Browsable(false)]
		public bool continueWinNumSpecified
		{
			get
			{
				return this._continueWinNum != null;
			}
			set
			{
				bool flag = value == (this._continueWinNum == null);
				if (flag)
				{
					this._continueWinNum = (value ? new uint?(this.continueWinNum) : null);
				}
			}
		}

		// Token: 0x06004AF9 RID: 19193 RVA: 0x0008E918 File Offset: 0x0008CB18
		private bool ShouldSerializecontinueWinNum()
		{
			return this.continueWinNumSpecified;
		}

		// Token: 0x06004AFA RID: 19194 RVA: 0x0008E930 File Offset: 0x0008CB30
		private void ResetcontinueWinNum()
		{
			this.continueWinNumSpecified = false;
		}

		// Token: 0x17001711 RID: 5905
		// (get) Token: 0x06004AFB RID: 19195 RVA: 0x0008E93C File Offset: 0x0008CB3C
		// (set) Token: 0x06004AFC RID: 19196 RVA: 0x0008E968 File Offset: 0x0008CB68
		[ProtoMember(5, IsRequired = false, Name = "maxKillNum", DataFormat = DataFormat.TwosComplement)]
		public uint maxKillNum
		{
			get
			{
				return this._maxKillNum ?? 0U;
			}
			set
			{
				this._maxKillNum = new uint?(value);
			}
		}

		// Token: 0x17001712 RID: 5906
		// (get) Token: 0x06004AFD RID: 19197 RVA: 0x0008E978 File Offset: 0x0008CB78
		// (set) Token: 0x06004AFE RID: 19198 RVA: 0x0008E998 File Offset: 0x0008CB98
		[XmlIgnore]
		[Browsable(false)]
		public bool maxKillNumSpecified
		{
			get
			{
				return this._maxKillNum != null;
			}
			set
			{
				bool flag = value == (this._maxKillNum == null);
				if (flag)
				{
					this._maxKillNum = (value ? new uint?(this.maxKillNum) : null);
				}
			}
		}

		// Token: 0x06004AFF RID: 19199 RVA: 0x0008E9DC File Offset: 0x0008CBDC
		private bool ShouldSerializemaxKillNum()
		{
			return this.maxKillNumSpecified;
		}

		// Token: 0x06004B00 RID: 19200 RVA: 0x0008E9F4 File Offset: 0x0008CBF4
		private void ResetmaxKillNum()
		{
			this.maxKillNumSpecified = false;
		}

		// Token: 0x06004B01 RID: 19201 RVA: 0x0008EA00 File Offset: 0x0008CC00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012A3 RID: 4771
		private double? _eloPoint;

		// Token: 0x040012A4 RID: 4772
		private uint? _totalNum;

		// Token: 0x040012A5 RID: 4773
		private uint? _winNum;

		// Token: 0x040012A6 RID: 4774
		private uint? _continueWinNum;

		// Token: 0x040012A7 RID: 4775
		private uint? _maxKillNum;

		// Token: 0x040012A8 RID: 4776
		private IExtension extensionObject;
	}
}
