using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpBattleKill")]
	[Serializable]
	public class PvpBattleKill : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "killID", DataFormat = DataFormat.TwosComplement)]
		public ulong killID
		{
			get
			{
				return this._killID ?? 0UL;
			}
			set
			{
				this._killID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killIDSpecified
		{
			get
			{
				return this._killID != null;
			}
			set
			{
				bool flag = value == (this._killID == null);
				if (flag)
				{
					this._killID = (value ? new ulong?(this.killID) : null);
				}
			}
		}

		private bool ShouldSerializekillID()
		{
			return this.killIDSpecified;
		}

		private void ResetkillID()
		{
			this.killIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "deadID", DataFormat = DataFormat.TwosComplement)]
		public ulong deadID
		{
			get
			{
				return this._deadID ?? 0UL;
			}
			set
			{
				this._deadID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deadIDSpecified
		{
			get
			{
				return this._deadID != null;
			}
			set
			{
				bool flag = value == (this._deadID == null);
				if (flag)
				{
					this._deadID = (value ? new ulong?(this.deadID) : null);
				}
			}
		}

		private bool ShouldSerializedeadID()
		{
			return this.deadIDSpecified;
		}

		private void ResetdeadID()
		{
			this.deadIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "reviveTime", DataFormat = DataFormat.TwosComplement)]
		public uint reviveTime
		{
			get
			{
				return this._reviveTime ?? 0U;
			}
			set
			{
				this._reviveTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reviveTimeSpecified
		{
			get
			{
				return this._reviveTime != null;
			}
			set
			{
				bool flag = value == (this._reviveTime == null);
				if (flag)
				{
					this._reviveTime = (value ? new uint?(this.reviveTime) : null);
				}
			}
		}

		private bool ShouldSerializereviveTime()
		{
			return this.reviveTimeSpecified;
		}

		private void ResetreviveTime()
		{
			this.reviveTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "contiKillCount", DataFormat = DataFormat.TwosComplement)]
		public int contiKillCount
		{
			get
			{
				return this._contiKillCount ?? 0;
			}
			set
			{
				this._contiKillCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contiKillCountSpecified
		{
			get
			{
				return this._contiKillCount != null;
			}
			set
			{
				bool flag = value == (this._contiKillCount == null);
				if (flag)
				{
					this._contiKillCount = (value ? new int?(this.contiKillCount) : null);
				}
			}
		}

		private bool ShouldSerializecontiKillCount()
		{
			return this.contiKillCountSpecified;
		}

		private void ResetcontiKillCount()
		{
			this.contiKillCountSpecified = false;
		}

		[ProtoMember(5, Name = "assitids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> assitids
		{
			get
			{
				return this._assitids;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _killID;

		private ulong? _deadID;

		private uint? _reviveTime;

		private int? _contiKillCount;

		private readonly List<ulong> _assitids = new List<ulong>();

		private IExtension extensionObject;
	}
}
