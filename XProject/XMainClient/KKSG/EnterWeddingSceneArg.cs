using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnterWeddingSceneArg")]
	[Serializable]
	public class EnterWeddingSceneArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _weddingid;

		private IExtension extensionObject;
	}
}
