using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MulActivityCha")]
	[Serializable]
	public class MulActivityCha : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "opencount", DataFormat = DataFormat.TwosComplement)]
		public int opencount
		{
			get
			{
				return this._opencount ?? 0;
			}
			set
			{
				this._opencount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opencountSpecified
		{
			get
			{
				return this._opencount != null;
			}
			set
			{
				bool flag = value == (this._opencount == null);
				if (flag)
				{
					this._opencount = (value ? new int?(this.opencount) : null);
				}
			}
		}

		private bool ShouldSerializeopencount()
		{
			return this.opencountSpecified;
		}

		private void Resetopencount()
		{
			this.opencountSpecified = false;
		}

		[ProtoMember(2, Name = "changeInfo", DataFormat = DataFormat.Default)]
		public List<MulActivitInfo> changeInfo
		{
			get
			{
				return this._changeInfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _opencount;

		private readonly List<MulActivitInfo> _changeInfo = new List<MulActivitInfo>();

		private IExtension extensionObject;
	}
}
