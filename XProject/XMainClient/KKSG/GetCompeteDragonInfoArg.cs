using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetCompeteDragonInfoArg")]
	[Serializable]
	public class GetCompeteDragonInfoArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "opArg", DataFormat = DataFormat.TwosComplement)]
		public CompeteDragonOpArg opArg
		{
			get
			{
				return this._opArg ?? CompeteDragonOpArg.CompeteDragon_GetInfo;
			}
			set
			{
				this._opArg = new CompeteDragonOpArg?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opArgSpecified
		{
			get
			{
				return this._opArg != null;
			}
			set
			{
				bool flag = value == (this._opArg == null);
				if (flag)
				{
					this._opArg = (value ? new CompeteDragonOpArg?(this.opArg) : null);
				}
			}
		}

		private bool ShouldSerializeopArg()
		{
			return this.opArgSpecified;
		}

		private void ResetopArg()
		{
			this.opArgSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CompeteDragonOpArg? _opArg;

		private IExtension extensionObject;
	}
}
