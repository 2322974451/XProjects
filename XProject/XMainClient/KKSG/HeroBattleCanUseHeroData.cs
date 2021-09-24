using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleCanUseHeroData")]
	[Serializable]
	public class HeroBattleCanUseHeroData : IExtensible
	{

		[ProtoMember(1, Name = "havehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> havehero
		{
			get
			{
				return this._havehero;
			}
		}

		[ProtoMember(2, Name = "freehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> freehero
		{
			get
			{
				return this._freehero;
			}
		}

		[ProtoMember(3, Name = "experiencehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experiencehero
		{
			get
			{
				return this._experiencehero;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "leftChooseTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftChooseTime
		{
			get
			{
				return this._leftChooseTime ?? 0U;
			}
			set
			{
				this._leftChooseTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftChooseTimeSpecified
		{
			get
			{
				return this._leftChooseTime != null;
			}
			set
			{
				bool flag = value == (this._leftChooseTime == null);
				if (flag)
				{
					this._leftChooseTime = (value ? new uint?(this.leftChooseTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftChooseTime()
		{
			return this.leftChooseTimeSpecified;
		}

		private void ResetleftChooseTime()
		{
			this.leftChooseTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _havehero = new List<uint>();

		private readonly List<uint> _freehero = new List<uint>();

		private readonly List<uint> _experiencehero = new List<uint>();

		private uint? _leftChooseTime;

		private IExtension extensionObject;
	}
}
