using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XMobUnitData : XBaseData
	{

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0)]
		public int TemplateID;

		[SerializeField]
		[DefaultValue(false)]
		public bool LifewithinSkill;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_At_X;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_At_Y;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_At_Z;

		[SerializeField]
		[DefaultValue(false)]
		public bool Shield;
	}
}
