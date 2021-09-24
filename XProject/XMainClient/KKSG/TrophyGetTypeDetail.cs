using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TrophyGetTypeDetail")]
	[Serializable]
	public class TrophyGetTypeDetail : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "trophy_id", DataFormat = DataFormat.TwosComplement)]
		public uint trophy_id
		{
			get
			{
				return this._trophy_id ?? 0U;
			}
			set
			{
				this._trophy_id = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool trophy_idSpecified
		{
			get
			{
				return this._trophy_id != null;
			}
			set
			{
				bool flag = value == (this._trophy_id == null);
				if (flag)
				{
					this._trophy_id = (value ? new uint?(this.trophy_id) : null);
				}
			}
		}

		private bool ShouldSerializetrophy_id()
		{
			return this.trophy_idSpecified;
		}

		private void Resettrophy_id()
		{
			this.trophy_idSpecified = false;
		}

		[ProtoMember(2, Name = "detail", DataFormat = DataFormat.Default)]
		public List<TrophyDetail> detail
		{
			get
			{
				return this._detail;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _trophy_id;

		private readonly List<TrophyDetail> _detail = new List<TrophyDetail>();

		private IExtension extensionObject;
	}
}
