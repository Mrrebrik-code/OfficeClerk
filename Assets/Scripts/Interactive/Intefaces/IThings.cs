using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThings
{
	TypeObject Type { get; set; }
	void Execute();
}
