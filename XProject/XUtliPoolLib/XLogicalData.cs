using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XLogicalData
	{

		public XLogicalData()
		{
			this.AttackOnHitDown = true;
		}

		[SerializeField]
		public XStrickenResponse StrickenMask = XStrickenResponse.Cease;

		[SerializeField]
		[DefaultValue(0)]
		public int CanReplacedby;

		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Move_At;

		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Move_End;

		[SerializeField]
		[DefaultValue(0f)]
		public float Rotate_At;

		[SerializeField]
		[DefaultValue(0f)]
		public float Rotate_End;

		[SerializeField]
		[DefaultValue(0f)]
		public float Rotate_Speed;

		[SerializeField]
		[DefaultValue(false)]
		public bool Rotate_Server_Sync;

		[SerializeField]
		[DefaultValue(0)]
		public int CanCastAt_QTE;

		[SerializeField]
		[DefaultValue(0)]
		public int QTE_Key;

		[SerializeField]
		public List<XQTEData> QTEData = null;

		[SerializeField]
		[DefaultValue(0f)]
		public float CanCancelAt;

		[SerializeField]
		[DefaultValue(false)]
		public bool SuppressPlayer;

		[SerializeField]
		[DefaultValue(true)]
		public bool AttackOnHitDown;

		[SerializeField]
		[DefaultValue(false)]
		public bool Association;

		[SerializeField]
		[DefaultValue(false)]
		public bool MoveType;

		[SerializeField]
		public string Association_Skill = null;

		[SerializeField]
		public string Syntonic_CoolDown_Skill = null;

		[SerializeField]
		[DefaultValue(0)]
		public int PreservedStrength;

		[SerializeField]
		[DefaultValue(0f)]
		public float PreservedAt;

		[SerializeField]
		[DefaultValue(0f)]
		public float PreservedEndAt;

		[SerializeField]
		public string Exstring = null;

		[SerializeField]
		[DefaultValue(0f)]
		public float Exstring_At;

		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Selected_At;

		[SerializeField]
		[DefaultValue(0f)]
		public float Not_Selected_End;
	}
}
