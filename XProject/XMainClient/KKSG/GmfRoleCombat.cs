using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfRoleCombat")]
	[Serializable]
	public class GmfRoleCombat : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "gmfrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfRoleBrief gmfrole
		{
			get
			{
				return this._gmfrole;
			}
			set
			{
				this._gmfrole = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "combat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfCombat combat
		{
			get
			{
				return this._combat;
			}
			set
			{
				this._combat = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GmfRoleBrief _gmfrole = null;

		private GmfCombat _combat = null;

		private IExtension extensionObject;
	}
}
