using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroRankData")]
	[Serializable]
	public class HeroRankData : IExtensible
	{

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

		private bool ShouldSerializeeloPoint()
		{
			return this.eloPointSpecified;
		}

		private void ReseteloPoint()
		{
			this.eloPointSpecified = false;
		}

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

		private bool ShouldSerializetotalNum()
		{
			return this.totalNumSpecified;
		}

		private void ResettotalNum()
		{
			this.totalNumSpecified = false;
		}

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

		private bool ShouldSerializewinNum()
		{
			return this.winNumSpecified;
		}

		private void ResetwinNum()
		{
			this.winNumSpecified = false;
		}

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

		private bool ShouldSerializecontinueWinNum()
		{
			return this.continueWinNumSpecified;
		}

		private void ResetcontinueWinNum()
		{
			this.continueWinNumSpecified = false;
		}

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

		private bool ShouldSerializemaxKillNum()
		{
			return this.maxKillNumSpecified;
		}

		private void ResetmaxKillNum()
		{
			this.maxKillNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private double? _eloPoint;

		private uint? _totalNum;

		private uint? _winNum;

		private uint? _continueWinNum;

		private uint? _maxKillNum;

		private IExtension extensionObject;
	}
}
