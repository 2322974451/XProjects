using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetWorldBossStateRes")]
	[Serializable]
	public class GetWorldBossStateRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "TimeLeft", DataFormat = DataFormat.TwosComplement)]
		public uint TimeLeft
		{
			get
			{
				return this._TimeLeft ?? 0U;
			}
			set
			{
				this._TimeLeft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TimeLeftSpecified
		{
			get
			{
				return this._TimeLeft != null;
			}
			set
			{
				bool flag = value == (this._TimeLeft == null);
				if (flag)
				{
					this._TimeLeft = (value ? new uint?(this.TimeLeft) : null);
				}
			}
		}

		private bool ShouldSerializeTimeLeft()
		{
			return this.TimeLeftSpecified;
		}

		private void ResetTimeLeft()
		{
			this.TimeLeftSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "BossHp", DataFormat = DataFormat.TwosComplement)]
		public uint BossHp
		{
			get
			{
				return this._BossHp ?? 0U;
			}
			set
			{
				this._BossHp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BossHpSpecified
		{
			get
			{
				return this._BossHp != null;
			}
			set
			{
				bool flag = value == (this._BossHp == null);
				if (flag)
				{
					this._BossHp = (value ? new uint?(this.BossHp) : null);
				}
			}
		}

		private bool ShouldSerializeBossHp()
		{
			return this.BossHpSpecified;
		}

		private void ResetBossHp()
		{
			this.BossHpSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "BossId", DataFormat = DataFormat.TwosComplement)]
		public uint BossId
		{
			get
			{
				return this._BossId ?? 0U;
			}
			set
			{
				this._BossId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool BossIdSpecified
		{
			get
			{
				return this._BossId != null;
			}
			set
			{
				bool flag = value == (this._BossId == null);
				if (flag)
				{
					this._BossId = (value ? new uint?(this.BossId) : null);
				}
			}
		}

		private bool ShouldSerializeBossId()
		{
			return this.BossIdSpecified;
		}

		private void ResetBossId()
		{
			this.BossIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _TimeLeft;

		private uint? _BossHp;

		private uint? _BossId;

		private IExtension extensionObject;
	}
}
