using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildMemberRes")]
	[Serializable]
	public class GuildMemberRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "members", DataFormat = DataFormat.Default)]
		public List<GuildMemberData> members
		{
			get
			{
				return this._members;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "recvFatigue", DataFormat = DataFormat.TwosComplement)]
		public uint recvFatigue
		{
			get
			{
				return this._recvFatigue ?? 0U;
			}
			set
			{
				this._recvFatigue = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool recvFatigueSpecified
		{
			get
			{
				return this._recvFatigue != null;
			}
			set
			{
				bool flag = value == (this._recvFatigue == null);
				if (flag)
				{
					this._recvFatigue = (value ? new uint?(this.recvFatigue) : null);
				}
			}
		}

		private bool ShouldSerializerecvFatigue()
		{
			return this.recvFatigueSpecified;
		}

		private void ResetrecvFatigue()
		{
			this.recvFatigueSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "FatigueMax", DataFormat = DataFormat.TwosComplement)]
		public uint FatigueMax
		{
			get
			{
				return this._FatigueMax ?? 0U;
			}
			set
			{
				this._FatigueMax = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool FatigueMaxSpecified
		{
			get
			{
				return this._FatigueMax != null;
			}
			set
			{
				bool flag = value == (this._FatigueMax == null);
				if (flag)
				{
					this._FatigueMax = (value ? new uint?(this.FatigueMax) : null);
				}
			}
		}

		private bool ShouldSerializeFatigueMax()
		{
			return this.FatigueMaxSpecified;
		}

		private void ResetFatigueMax()
		{
			this.FatigueMaxSpecified = false;
		}

		[ProtoMember(5, Name = "guildinheritid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> guildinheritid
		{
			get
			{
				return this._guildinheritid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<GuildMemberData> _members = new List<GuildMemberData>();

		private uint? _recvFatigue;

		private uint? _FatigueMax;

		private readonly List<ulong> _guildinheritid = new List<ulong>();

		private IExtension extensionObject;
	}
}
