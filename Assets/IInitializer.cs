using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInitializer <T> where T: struct
{
    /// <summary>
    /// To initialize first data
    /// </summary>
    /// <param name="data">First data</param>
    void Init(T data); 
}
