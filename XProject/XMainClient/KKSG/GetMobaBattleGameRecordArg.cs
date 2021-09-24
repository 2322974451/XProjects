using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMobaBattleGameRecordArg")]
	[Serializable]
	public class GetMobaBattleGameRecordArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "tag", DataFormat = DataFormat.TwosComplement)]
		public uint tag
		{
			get
			{
				return this._tag ?? 0U;
			}
			set
			{
				this._tag = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool tagSpecified
		{
			get
			{
				return this._tag != null;
			}
			set
			{
				bool flag = value == (this._tag == null);
				if (flag)
				{
					this._tag = (value ? new uint?(this.tag) : null);
				}
			}
		}

		private bool ShouldSerializetag()
		{
			return this.tagSpecified;
		}

		private void Resettag()
		{
			this.tagSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _tag;

		private IExtension extensionObject;
	}
}
