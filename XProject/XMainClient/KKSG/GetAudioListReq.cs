using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetAudioListReq")]
	[Serializable]
	public class GetAudioListReq : IExtensible
	{

		[ProtoMember(1, Name = "audioUidList", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> audioUidList
		{
			get
			{
				return this._audioUidList;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "rpcid", DataFormat = DataFormat.TwosComplement)]
		public uint rpcid
		{
			get
			{
				return this._rpcid ?? 0U;
			}
			set
			{
				this._rpcid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rpcidSpecified
		{
			get
			{
				return this._rpcid != null;
			}
			set
			{
				bool flag = value == (this._rpcid == null);
				if (flag)
				{
					this._rpcid = (value ? new uint?(this.rpcid) : null);
				}
			}
		}

		private bool ShouldSerializerpcid()
		{
			return this.rpcidSpecified;
		}

		private void Resetrpcid()
		{
			this.rpcidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ulong> _audioUidList = new List<ulong>();

		private uint? _rpcid;

		private IExtension extensionObject;
	}
}
