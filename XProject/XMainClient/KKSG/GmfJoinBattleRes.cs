using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfJoinBattleRes")]
	[Serializable]
	public class GmfJoinBattleRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "join", DataFormat = DataFormat.Default)]
		public bool join
		{
			get
			{
				return this._join ?? false;
			}
			set
			{
				this._join = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joinSpecified
		{
			get
			{
				return this._join != null;
			}
			set
			{
				bool flag = value == (this._join == null);
				if (flag)
				{
					this._join = (value ? new bool?(this.join) : null);
				}
			}
		}

		private bool ShouldSerializejoin()
		{
			return this.joinSpecified;
		}

		private void Resetjoin()
		{
			this.joinSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _join;

		private IExtension extensionObject;
	}
}
