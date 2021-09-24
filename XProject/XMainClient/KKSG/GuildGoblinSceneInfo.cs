using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildGoblinSceneInfo")]
	[Serializable]
	public class GuildGoblinSceneInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "killNum", DataFormat = DataFormat.TwosComplement)]
		public int killNum
		{
			get
			{
				return this._killNum ?? 0;
			}
			set
			{
				this._killNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killNumSpecified
		{
			get
			{
				return this._killNum != null;
			}
			set
			{
				bool flag = value == (this._killNum == null);
				if (flag)
				{
					this._killNum = (value ? new int?(this.killNum) : null);
				}
			}
		}

		private bool ShouldSerializekillNum()
		{
			return this.killNumSpecified;
		}

		private void ResetkillNum()
		{
			this.killNumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "contribute", DataFormat = DataFormat.TwosComplement)]
		public int contribute
		{
			get
			{
				return this._contribute ?? 0;
			}
			set
			{
				this._contribute = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contributeSpecified
		{
			get
			{
				return this._contribute != null;
			}
			set
			{
				bool flag = value == (this._contribute == null);
				if (flag)
				{
					this._contribute = (value ? new int?(this.contribute) : null);
				}
			}
		}

		private bool ShouldSerializecontribute()
		{
			return this.contributeSpecified;
		}

		private void Resetcontribute()
		{
			this.contributeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _killNum;

		private int? _contribute;

		private IExtension extensionObject;
	}
}
