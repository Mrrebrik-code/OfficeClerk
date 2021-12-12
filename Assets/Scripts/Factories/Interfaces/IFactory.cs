using Interactive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T> 
{
	List<IThings> Things { get; }
	T Create(int count);
}
