using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ThemeActivityData")]
	[Serializable]
	public class ThemeActivityData : IExtensible
	{

		[ProtoMember(1, Name = "firstscene", DataFormat = DataFormat.Default)]
		public List<SpFirstCompleteScene> firstscene
		{
			get
			{
				return this._firstscene;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SpFirstCompleteScene> _firstscene = new List<SpFirstCompleteScene>();

		private bool? _ishint;

		private IExtension extensionObject;
	}
}
