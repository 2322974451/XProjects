using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QARoomRankData")]
	[Serializable]
	public class QARoomRankData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uuid", DataFormat = DataFormat.TwosComplement)]
		public ulong uuid
		{
			get
			{
				return this._uuid ?? 0UL;
			}
			set
			{
				this._uuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uuidSpecified
		{
			get
			{
				return this._uuid != null;
			}
			set
			{
				bool flag = value == (this._uuid == null);
				if (flag)
				{
					this._uuid = (value ? new ulong?(this.uuid) : null);
				}
			}
		}

		private bool ShouldSerializeuuid()
		{
			return this.uuidSpecified;
		}

		private void Resetuuid()
		{
			this.uuidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uuid;

		private uint? _score;

		private IExtension extensionObject;
	}
}
